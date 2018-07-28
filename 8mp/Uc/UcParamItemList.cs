using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using _8mp.Helper.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Events;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.Parameter;

namespace _8mp.Uc
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class UcParamItemList 
    {
        public int ControlHeight { get; set; }
        public int ControlWidth { get; set; }
        public int LabelParamNameWidth { get; set; }
        private readonly IParamItemApi _objParamItem;
        private bool _firstLoad = true;
        // Private ReadOnly _objControlBuild As IControlBuilder
        public UcParamItemList(IParamItemApi objParamItem, IControlBuilder objObjControlBuild) : base(objParamItem.GetFlexObj, objParamItem.GetWsObj, objParamItem.GetMsgObj, objParamItem.FormObject, objParamItem.Operation, objObjControlBuild)
        {
            _objParamItem = objParamItem;
            // _objControlBuild = objObjControlBuild
            InitializeComponent();
            HookCustomEvent(this, _objParamItem);
        }
        public override void LabelWidth(int widthValue)
        {
            lblParamName.Size = new Size(widthValue, lblParamName.Height);
            LblMsg.Location = new Point(widthValue + 3, LblMsg.Location.Y);
        }
        private void ucParamItemList_Load(object sender, EventArgs e)
        {
            lblParamName.Text = _objParamItem.ParamItem.required ? "*" + _objParamItem.ParamItem.title : _objParamItem.ParamItem.title + " : ";
            lblParamName.Name = "Lbl_" + base.ObjControlBuilder.RemoveNontext(_objParamItem.ParamItem.title);
        }
        public override void ShowData()
        {
            ControlHeight = Height;
            ControlWidth = Width;
            LabelParamNameWidth = lblParamName.Width;
            LoadListItem();
            Show();
        }
        private void LoadListItem()
        {
            {
                var withBlock = CbParamValue;
                withBlock.DataSource = _objParamItem.GetParamtemList();
                withBlock.Name = "List_" + _objParamItem.ParamItem.name;
                withBlock.DisplayMember = nameof(ParameterItemListValueVm.name);
                withBlock.ValueMember = nameof(ParameterItemListValueVm.value);
            }
        }
        public new void SetFocus()
        {
            CbParamValue.Select();
        }

        private void CbParamValue_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Result = EnumResult.Pass;
            var cb = (ComboBox)sender;
            if (!_objParamItem.SelectionValidation((ParameterItemListValueVm)CbParamValue.SelectedItem))
            {
                ReturnMsgVm = _objParamItem.ReturnMsg;
                ObjControlBuilder.DisplayLabel(LblMsg, _objParamItem.ReturnMsg);
                Result = EnumResult.Fail;
                cb.Select();
                return;
            }
            ParameterItemListValueVm data = (ParameterItemListValueVm)CbParamValue.SelectedItem;
            _objParamItem.AddParamItemValue(data.name, data.value, true);
            Debug.Print("ItemListBox SelectedIndexChanged");
            Result = EnumResult.Pass;
            RaiseFinishEvent(this, new CustomReturnEventArgs { ReturnEvent = e });
        }
    }
}
