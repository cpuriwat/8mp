using System;
using System.Diagnostics;
using System.Windows.Forms;
using _8mp.Helper.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Events;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;

namespace _8mp.Uc
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class UcSn : IMpModuleRenderController, IMpModuleRenderSnController
    {
        public readonly ISnApi ObjSnApi;
        public event EventHandler ParamRendering;
        public event EventHandler<CustomReturnEventArgs> MsgRendering;
        public event EventHandler EnableOtherControlRendering;

        // Event FinishEvent(sender As Object, e As EventArgs)
        public UcSn(ISnApi objSnApi, IControlBuilder objObjControlBuild) : base(objSnApi.GetFlexObj, objSnApi.GetWsObj, objSnApi.GetMsgObj, objSnApi.FormObject, objSnApi.Operation, objObjControlBuild)
        {
            ObjSnApi = objSnApi;
            InitializeComponent();
            // TxtSn.Text = "sn001" 'TODO : remove this when debug finish
            HookCustomEvent(this, ObjSnApi);

            ChkAutoSubmit.Enabled = ObjSnApi.AllowAutoSubmit();
        }

        private void BtnSubmit_Click(object sender, EventArgs e) => ExecuteValue();

        private void TxtSn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ObjSnApi.Result == EnumResult.Fail)
            {
                ObjSnApi.Result = EnumResult.Cancel; return;
            }
            if (e.KeyChar != Convert.ToChar(13)) return;
            Debug.Print("UnSn - TxtSn KeyPress ");
            ExecuteValue();
        }
        private void ExecuteValue()
        {
            Debug.Print("executevalue");
            TxtSn.Enabled = false;
            if (!ObjSnApi.CheckSerialNumber(TxtSn.Text))
            {
                ObjControlBuilder.DisplayLabel(LblMsg, ObjSnApi.ReturnMsg);
                ObjControlBuilder.SelectText(TxtSn);
                MsgRendering?.Invoke(this,new CustomReturnEventArgs(){ReturnMsg = ObjSnApi.ReturnMsg });
                ObjSnApi.Result = EnumResult.Fail;
            }
            else
            {
                // HookCustomEvent(Me, _objSn) 'rehook for ucsn only
                ObjSnApi.Result = EnumResult.Pass;
                EnableOtherControlRendering?.Invoke(this, new EventArgs());
                if (ObjSnApi.RouteDetail == null || ObjSnApi.RouteDetail.parameter.Count <= 0) return; // if sn not correct, no action
                ParamRendering?.Invoke(this, new EventArgs());
            }

            // If _objSn.Result Then SendKeys.Send("{TAB}")
            //CustomMpUserControl.RaiseFinishEvent(this, new EventArgs());
        }

        private void TxtSn_TextChanged(object sender, EventArgs e)
        {
            LblMsg.Text = "";
            // TODO : check if flex change its value msgbox not allow.
            ObjSnApi.UnitSn = TxtSn.Text;
        }
        public override void ResetControl(bool success)
        {
            Enabled = true;
            ObjControlBuilder.SelectText(TxtSn);
            if (success)TxtSn.Text = "";
            ObjSnApi.SetFocus();
        }
    }
}
