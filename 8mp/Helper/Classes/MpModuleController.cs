using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MpFlexLib.Interfaces;
using WeifenLuo.WinFormsUI.Docking;
using _8mp.Form;
using _8mp.Helper.Interfaces;
using _8mp.Uc;
using _8mpBl.Enums;
using _8mpBl.Events;
using _8mpBl.Factory.Classes;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.General;
using IWebServiceHelper = _8mpBl.Helper.Interfaces.IWebServiceHelper;

namespace _8mp.Helper.Classes
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class MpModuleController : IMpModuleController
    {
        private readonly IMpFlex _objFlex;
        private readonly IMessageTextHandler _objMsg;
        private readonly IWebServiceHelper _objWs;
        private readonly IControlBuilder _objCb;
        private readonly IOperationApi _objOper;
        private readonly IMpTransaction _objTrans;
        public DockPanel DockPanelMain { get; set; }
        public ReturnMsgVm ReturnMsgVm { get; set; }
        public EnumResult Result { get; set; }
        public Control FormObject { get; set; }
        public LoginInfoVm LoginInfo { get; set; }
        private string _operation;
        private EnumOperationType _mType;
        private MpDockContent _dockContent;
        private TabControl _tabControl;
        private readonly List<DockContent> _listOfMpDockContent = new List<DockContent>();
        private List<Control> _listOfUc = new List<Control>();
        private readonly List<UserControl> _listOfUcSnBase = new List<UserControl>();

        private readonly List<object> _listOfObj = new List<object>();
        private readonly List<Object> _listOfObjSnBase = new List<Object>();

        private DockContent _operationToolbox;
        private DockContent _snToolbox;
        private DockContent _messageToolbox;
        private DockContent _messageServerToolbox;

        public MpModuleController(IMpFlex objFlex, IWebServiceHelper objWs, IControlBuilder objCb, IMessageTextHandler objMsg, IOperationApi objOper, IMpTransaction objTrans)
        {
            _objFlex = objFlex;
            _objWs = objWs;
            _objMsg = objMsg;
            _objCb = objCb;
            _objOper = objOper;
            _objTrans = objTrans;
            _objTrans.TransactionProceed += OnTransactionProceed;
        }
        protected void OnTransactionProceed(object sender, CustomReturnEventArgs e)
        {
            _objCb.DisplayMsgToolbox(_messageToolbox, e.ReturnMsg.ReturnMsg);
        }
        protected void OnMsgUcRendering(object sender, CustomReturnEventArgs e)
        {
            _objCb.DisplayMsgToolbox(_messageToolbox, e.ReturnMsg.ReturnMsg);
        }
        protected void OnUcSnEnable(object sender, EventArgs e)
        {
            //_objCb.DisplayMsgToolbox(_messageToolbox, e.ReturnMsg.ReturnMsg);
        }
        

        public void OperationButtonClick(object sender, EventArgs e)
        {
            if (!(sender is Button btn)) return;
            _dockContent.Text = btn.Text;
            var opValue = btn.Name.Split(new[] { "-type-" }, StringSplitOptions.None);
            //_mType = (EnumOperationType)int.Parse(opValue[1]);
            _mType = (EnumOperationType)Enum.Parse(typeof(EnumOperationType), opValue[1]);
            _operation = opValue[0];
            RenderModule();
        }
        private void CancelSn(bool success)
        {
            for (var i = _listOfMpDockContent.Count - 1; i >= 0; i--)
            {
                var o = _listOfMpDockContent[i];
                _listOfMpDockContent.RemoveAt(i);
                o.DockHandler.DockPanel = null;
                o = null;
            }
            for (int i = _listOfObjSnBase.Count - 1; i >= 0; i--)
            {
                Object o = _listOfObjSnBase[i];
                _tabControl.TabPages.RemoveByKey(o.GetType().Name);
                o = null;
            }
            _listOfObjSnBase.Clear();
            foreach (IMpUserControl o in _listOfUc) o.ResetControl(success);
        }

      
      
        private void RenderUcSubmit()
        {
            var objUcSubmit = new UcSubmit(new SubmitApi(_objWs, _objMsg, _objFlex) { FormObject = FormObject }, _objCb);
            objUcSubmit.FinishEvent += UcSubmit_Finish;
            _listOfUc.Add(objUcSubmit);
        }
        private void RenderUcPassFail()
        {
            var objPassFail = new PassFailApi(_objWs, _objMsg, _objFlex) { FormObject = FormObject };
            var objUcPassFail = new UcPassFail(objPassFail, _objCb);
            objUcPassFail.EnableControl(false);
            objUcPassFail.FinishEvent += UcPassFail_Finish;
            _listOfUc.Add(objUcPassFail);
            _listOfObj.Add(objPassFail);
        }
        private void RenderUcFailure()
        {
            var objSn = (ISnApi)_objCb.FindControlHasInterfaceInList<ISnApi>(_listOfObj);
            var objFailure = new FailureApi(_objWs, _objMsg, _objFlex, _objCb) { FormObject = objSn.FormObject };
            if (_mType == EnumOperationType.TROUBLESHOOTING) objFailure.ReworkOperation = true;
            var objUcFailure = new UcFailure(objFailure, _objCb);
            objUcFailure.FinishEvent += UcFailure_Finish;
            _listOfUc.Add(objUcFailure);
            _listOfObj.Add(objFailure);
        }

        private void AddMessage(ReturnMsgVm msg)
        {
            var lbl =(Label)_messageToolbox.Controls[_messageToolbox.Controls.Count - 1];
            var lblValue = lbl.Text.Split('-');
            if (lblValue.Length <= 0) return;
            if(!lblValue[1].Contains(msg.ReturnMsg))_objCb.DisplayMsgToolbox(_messageToolbox, msg.ReturnMsg);
        }

        private void AddMsg(object objApi, object ui)
        {
            var ump = (IMpUserControl)ui;
            var a = (IMpCommonApi)objApi;
            var msgApi = "";
            if (a == null | ump == null) _objCb.DisplayMsgToolbox(_messageToolbox, _objMsg.GetSystemMsg(EnumMessage.SystemObjectIsNothing).ReturnMsg);
            if (a.ReturnMsg != null && a.ReturnMsg.ReturnMsg != "")
            {
                _objCb.DisplayMsgToolbox(_messageToolbox, a.ReturnMsg.ReturnMsg); msgApi = a.ReturnMsg.ReturnMsg;
            }
            if (ump.ReturnMsgVm == null || ump.ReturnMsgVm.ReturnMsg == "") return;
            if (msgApi != ump.ReturnMsgVm.ReturnMsg) _objCb.DisplayMsgToolbox(_messageToolbox, ump.ReturnMsgVm.ReturnMsg); // prevent duplicate msg
        }

      
     
     


    }
}

