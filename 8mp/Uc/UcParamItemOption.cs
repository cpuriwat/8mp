using System;
using System.Drawing;
using System.Windows.Forms;
using _8mpBl.Enums;
using _8mpBl.Events;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.Parameter;

namespace _8mp.Uc
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class UcParamItemOption 
    {
        private readonly IParamItemApi _objParamItem;
        private readonly IControlBuilder _objObjControlBuild;
        public UcParamItemOption(IParamItemApi objParamItem, IControlBuilder objObjControlBuild) : base(objParamItem.GetFlexObj, objParamItem.GetWsObj, objParamItem.GetMsgObj, objParamItem.FormObject, objParamItem.Operation, objObjControlBuild)
        {
            _objParamItem = objParamItem;
            _objObjControlBuild = objObjControlBuild;
            InitializeComponent();
            HookCustomEvent(this, _objParamItem);
        }
        public override void LabelWidth(int widthValue)
        {
            lblParamName.Size = new Size(widthValue, lblParamName.Height);
            LblMsg.Location = new Point(widthValue + 3, LblMsg.Location.Y);
        }
        private void ucParamItemOption_Load(object sender, EventArgs e)
        {
            lblParamName.Text = _objParamItem.ParamItem.required ? "*" + _objParamItem.ParamItem.title : _objParamItem.ParamItem.title + " : ";
            lblParamName.Name = "Lbl_" + _objObjControlBuild.RemoveNontext(_objParamItem.ParamItem.title);
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
            foreach (ParameterItemListValueVm o in _objParamItem.GetParamtemList())
            {
                var opt = new CheckBox() { Name = o.name, Text = o.value, Checked = o.@default, Dock = DockStyle.Left };
                opt.CheckedChanged += CheckChanged;
                if (opt.Checked)
                    _objParamItem.AddParamItemValue(opt.Name, opt.Text, opt.Checked);
                Panel1.Controls.Add(opt);
                opt.BringToFront();
            }
        }

        private void CheckChanged(object sender, EventArgs e)
        {
            var data = (CheckBox)sender;
            if (data.IsHandleCreated) return;
            _objParamItem.AddParamItemValue(data.Name, data.Text, data.Checked);
            if (!_objParamItem.CheckValidation(data.Name))
            {
                ReturnMsgVm = _objParamItem.ReturnMsg;
                _objObjControlBuild.DisplayLabel(LblMsg, _objParamItem.ReturnMsg);
                Result = EnumResult.Fail;
                data.Select();
                return;
            }
            RaiseFinishEvent(this, new CustomReturnEventArgs { ReturnEvent = e });
            SendKeys.Send("{TAB}");
        }
    }
}
