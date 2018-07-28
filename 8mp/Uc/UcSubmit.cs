using System;
using _8mp.Helper.Interfaces;
using _8mpBl.Events;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;

namespace _8mp.Uc
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class UcSubmit : IMpUserControl
    {
        private readonly ISubmitApi _objSubmit;
        public UcSubmit(ISubmitApi objSubmit, IControlBuilder objObjControlBuild) : base(objSubmit.GetFlexObj, objSubmit.GetWsObj, objSubmit.GetMsgObj, objSubmit.FormObject, objSubmit.Operation, objObjControlBuild)
        {
            _objSubmit = objSubmit;
            InitializeComponent();
        }
        private void UcSubmit_Load(object sender, EventArgs e) { EnableControl(false); }
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            _objSubmit.SubmitClick();
            RaiseFinishEvent(this, new CustomReturnEventArgs { ReturnMsg = _objSubmit.ReturnMsg });

        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _objSubmit.CancelClick();
            RaiseFinishEvent(this, new CustomReturnEventArgs{ReturnMsg = _objSubmit.ReturnMsg });
        }
        public new void SetFocus()
        {
            BtnSubmit.Select();
            BtnSubmit.Focus();
        }
        public new void HookEvent() => HookCustomEvent(this, _objSubmit);
    }
}
