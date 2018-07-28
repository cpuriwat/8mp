using System;
using Interfaces.Helper;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.General;

namespace _8mp.Form
{
    public partial class FrmMessage
    {
        private readonly IMessageTextHandler _objMsg;
        private readonly IWebServiceHelper _objWs;
        private readonly IFormatValidate _objFormatValidate;
        private readonly IControlBuilder _objControl;

        public FrmMessage(IMessageTextHandler objMsg, IControlBuilder objControl)
        {
            InitializeComponent();
            _objMsg = objMsg;
            _objControl = objControl;
        }
        public void ShowPopup(ReturnMsgVm msg, System.Windows.Forms.Form parentObject)
        {
            _objControl.DisplayLabel(LblMsg, msg);
            parentObject.Show(this);
            //this.ShowDialog(parentObject);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
