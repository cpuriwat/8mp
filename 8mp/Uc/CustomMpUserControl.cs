using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MpFlexLib.Interfaces;
using _8mp.Helper.Classes;
using _8mp.Helper.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Events;
using _8mpBl.Factory.Classes;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.General;
using _8mpBl.Model.Snip;

namespace _8mp.Uc
{
    public class CustomMpUserControl : UserControl, IMpUserControlParam
    {
        private Control _derivedObj;
        private IMpCommonApi _derivedObjApi;
        public event EventHandler<CustomReturnEventArgs> FinishEvent;
        public event EventHandler UcLoadEventEventHandler;
        public ReturnMsgVm ReturnMsgVm { get; set; }
        public EnumResult Result { get; set; }

        //private readonly IMpFlex _objFlex;
        //private readonly IWebServiceHelper _objWs;
        //private readonly IMessageTextHandler _objMsg;
        internal readonly IControlBuilder ObjControlBuilder;

        private readonly IHookApi _hook;

        private readonly object _formObject;
        private readonly string _operation;
        private ReturnMsgVm _returnMsgVm;

        public CustomMpUserControl()
        {
        }
        public CustomMpUserControl(IMpFlex objFlex, IWebServiceHelper objWs, IMessageTextHandler objMsg, object formObject, string operation, IControlBuilder objObjControlBuild)
        {
            ObjControlBuilder = objObjControlBuild;
            //_objFlex = objFlex;
            //_objWs = objWs;
            //_objMsg = objMsg;
            _formObject = formObject;
            _operation = operation;
            _hook = new HookApi(objFlex, objWs); // need to do this because hook will raise event back to UC
        }
        public void SetTabIndex(int ind)
        {
            if (_derivedObj != null)
                _derivedObj.TabIndex = ind;
        }
        public virtual void ResetControl(bool success)
        {
            if (_derivedObj != null)
                _derivedObj.Enabled = false;
        }

        public void SetFocus()
        {
        }
        protected void HookCustomEvent(Control o, IMpCommonApi obj)
        {
            _derivedObj = o;
            _derivedObjApi = obj;
            if (_derivedObj is IMpUserControlParam) return;
            if (!ValidateHookList()) return;
            var hookList = _derivedObjApi.RouteDetail != null ? _derivedObjApi.RouteDetail.hook_set : new List<string>();
            _hook.HookCustomEvent(o, hookList);
            _hook.FinishEvent += HookResponse;
        }
        private bool ValidateHookList()
        {
            if (_derivedObjApi.RouteDetail == null | _hook.GetHookList() == null)
                return true;
            var hl = _hook.GetHookList();
            var rd = _derivedObjApi.RouteDetail.hook_set;
            var commonNames = hl.Intersect(rd).ToArray();
            foreach (var n in commonNames)return false;
            return true;
        }
        private void HookResponse(string objName, string objType, SnipVm code, EnumResult result, Control o)
        {
            _derivedObjApi.Result = result;
            if (result == EnumResult.Fail)
            {
                _derivedObjApi.ReturnMsg = _derivedObjApi.GetMsgObj.GetSystemMsg(EnumMessage.HookFail, new List<string>() { code.title, code.returnmessage });
                ReturnMsgVm = _derivedObjApi.ReturnMsg;
                var lm = (Label) ObjControlBuilder.FindControls(_derivedObj, "LblMsg");
                if (lm != null)ObjControlBuilder.DisplayLabel(lm, _derivedObjApi.ReturnMsg);
                o.Select();
            }
            FinishEvent?.Invoke(this,new CustomReturnEventArgs());
        }
        public virtual void EnableControl(bool enable)
        {
            if (_derivedObj != null)_derivedObj.Enabled = enable;
        }
        // if can't access event of base class, use sub
        public virtual void RaiseFinishEvent(object newSender, CustomReturnEventArgs e)
        {
            FinishEvent?.Invoke(this, e);
        }
        public void HookEvent()
        {
        }

        public int ControlHeight { get; set; }
        public int ControlWidth { get; set; }
        public int LabelParamNameWidth { get; set; }
        public virtual void LabelWidth(int widthValue) {}
        public virtual void ShowData() { }
    }
}
