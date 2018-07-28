using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using _8mp.Helper.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;

namespace _8mp.Uc
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class UcParamItemTextBox 
    {
        private readonly IParamItemApi _objParamItem;
        public UcParamItemTextBox(IParamItemApi objParamItem, IControlBuilder objObjControlBuild) : base(objParamItem.GetFlexObj, objParamItem.GetWsObj, objParamItem.GetMsgObj, objParamItem.FormObject, objParamItem.Operation, objObjControlBuild)
        {
            _objParamItem = objParamItem;
            InitializeComponent();
        }
        public override void LabelWidth(int widthValue)
        {
            lblParamName.Size = new Size(widthValue, lblParamName.Height);
            LblMsg.Location = new Point(widthValue + 3, LblMsg.Location.Y);
        }
        private void ucParamItemTextBox_Load(object sender, EventArgs e)
        {
            lblParamName.Text = _objParamItem.ParamItem.required ? "*" + _objParamItem.ParamItem.title : _objParamItem.ParamItem.title + " : ";
            lblParamName.Name = "Lbl_" + base.ObjControlBuilder.RemoveNontext(_objParamItem.ParamItem.title);
            txtParamValue.Name = "Txt_" + base.ObjControlBuilder.RemoveNontext(_objParamItem.ParamItem.title);
        }
         public override void ShowData() 
        {
            ControlHeight = Height;
            ControlWidth = Width;
            LabelParamNameWidth = lblParamName.Width;
            HookCustomEvent(this, _objParamItem);
            Show();
        }
        private void txtParamValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) SendKeys.Send("{TAB}");
        }
        private void txtParamValue_Validating(object sender, CancelEventArgs e)
        {
            ValidateData();
            RaiseFinishEvent(this, null);
        }
        private void txtParamValue_Enter(object sender, EventArgs e)
        {
            base.ObjControlBuilder.SelectText(txtParamValue);
        }
        private void txtParamValue_TextChanged(object sender, EventArgs e)
        {
            LblMsg.Text = "";
        }

        private void txtParamValue_Leave(object sender, EventArgs e)
        {
            TextBox data = (TextBox)sender;
            _objParamItem.AddParamItemValue(data.Name, data.Text, true);
        }
        private void ValidateData()
        {
            Result = EnumResult.Pass;
            if (txtParamValue.Text == "") return;
            if (_objParamItem.InputValidation(txtParamValue.Text)) return;
            ReturnMsgVm = _objParamItem.ReturnMsg;
            ObjControlBuilder.DisplayLabel(LblMsg, _objParamItem.ReturnMsg);
            ObjControlBuilder.SelectText(txtParamValue);
            Result = EnumResult.Fail;
            txtParamValue.Select();
        }
    }
}
