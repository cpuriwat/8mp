using System;
using _8mp.Helper.Interfaces;
using _8mpBl.Events;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;

namespace _8mp.Uc
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class UcPassFail : IMpUserControl
    {
        private readonly IPassFailApi _objPassFail;
        // Private ReadOnly _objControlBuild As IControlBuilder
        public UcPassFail(IPassFailApi objPassFail, IControlBuilder objObjControlBuild) : base(objPassFail.GetFlexObj, objPassFail.GetWsObj, objPassFail.GetMsgObj, objPassFail.FormObject, objPassFail.Operation, objObjControlBuild)
        {
            _objPassFail = objPassFail;
            // _objControlBuild = objObjControlBuild
            InitializeComponent();
            HookCustomEvent(this, _objPassFail);
        }
        public override void ResetControl(bool success)
        {
            BtnFail.Visible = true;
            base.ResetControl(success);
        }
        private void BtnPass_Click(object sender, EventArgs e)
        {
            _objPassFail.PassClick();
            RaiseFinishEvent(this, new CustomReturnEventArgs { ReturnEvent = e });
        }

        private void BtnFail_Click(object sender, EventArgs e)
        {
            _objPassFail.FailClick();
            BtnPass.Enabled = false;
            BtnFail.Visible = false;
            RaiseFinishEvent(this, new CustomReturnEventArgs { ReturnEvent = e });
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _objPassFail.CancelClick();
            RaiseFinishEvent(this, new CustomReturnEventArgs { ReturnEvent = e });
        }

        public new void SetFocus()
        {
            BtnPass.Select();
            BtnPass.Focus();
        }

        private void BtnSubmitFail_Click(object sender, EventArgs e)
        {
            _objPassFail.SubmitFailClick();
            RaiseFinishEvent(this, new CustomReturnEventArgs { ReturnEvent = e });
        }
    }
}

