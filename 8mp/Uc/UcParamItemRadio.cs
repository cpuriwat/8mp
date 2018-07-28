using System;
using System.Drawing;
using System.Windows.Forms;
using _8mpBl.Events;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.Parameter;

namespace _8mp.Uc
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class UcParamItemRadio 
    {
        private readonly IParamItemApi _objParamItem;
        public UcParamItemRadio(IParamItemApi objParamItem, IControlBuilder objObjControlBuild) : base(objParamItem.GetFlexObj, objParamItem.GetWsObj, objParamItem.GetMsgObj, objParamItem.FormObject, objParamItem.Operation, objObjControlBuild)
        {
            _objParamItem = objParamItem;
            InitializeComponent();
        }
        public override void LabelWidth(int widthValue)
        {
            lblParamName.Size = new Size(widthValue, lblParamName.Height);
            LblMsg.Location = new Point(widthValue + 3, LblMsg.Location.Y);
        }
        private void ucParamItemRadio_Load(object sender, EventArgs e)
        {
            lblParamName.Name = "Lbl_" + base.ObjControlBuilder.RemoveNontext(_objParamItem.ParamItem.title);
            lblParamName.Text = _objParamItem.ParamItem.required ? "*" + _objParamItem.ParamItem.title : _objParamItem.ParamItem.title + " : ";
        }
        public override void ShowData()
        {
            LabelParamNameWidth = lblParamName.Width;
            LoadListItem();
            ControlHeight = Height;
            ControlWidth = Width;
            HookCustomEvent(this, _objParamItem);
            Show();
        }
        private void LoadListItem()
        {
            var h =0;
            foreach (ParameterItemListValueVm o in _objParamItem.GetParamtemList())
            {
                var opt = new RadioButton() { Name = o.name, Text = o.title, Checked = o.@default, Dock = DockStyle.Top, AutoSize = false, Width = GbParamItem.Width };
                opt.CheckedChanged += CheckChanged;
                if (opt.Checked) _objParamItem.AddParamItemValue(opt.Name, opt.Text, opt.Checked);
                GbParamItem.Controls.Add(opt);
                opt.BringToFront();
                h = h + opt.PreferredSize.Height + 10;
            }
            Panel1.Size = new Size(Panel1.Width, h + 20);
            GbParamItem.Size = new Size(GbParamItem.Width, h + 10);
            Size = new Size(Width, h + 30);
        }
        private void CheckChanged(object sender, EventArgs e)
        {
            foreach (Control r in GbParamItem.Controls)
            {
                if (r.GetType() != typeof(RadioButton)) continue;
                var data = (RadioButton)sender;
                if (data.IsHandleCreated) return;
                _objParamItem.AddParamItemValue(data.Name, data.Text, data.Checked);
                if (_objParamItem.CheckValidation(data.Name)) continue;
                ReturnMsgVm = _objParamItem.ReturnMsg;
                base.ObjControlBuilder.DisplayLabel(LblMsg, _objParamItem.ReturnMsg);
            }
            RaiseFinishEvent(this, new CustomReturnEventArgs { ReturnEvent = e });
        }
    }
}
