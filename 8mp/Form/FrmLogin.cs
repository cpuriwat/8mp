using System;
using System.Configuration;
using System.Windows.Forms;
using Interfaces.Helper;
using MpFlexLib.Classes;
using MpFlexLib.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Factory.Classes;
using _8mpBl.Helper.Classes;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.General;

namespace _8mp.Form
{
    public partial class FrmLogin
    {
        private readonly string _hostUrl;
        private readonly IMessageTextHandler _objMsg;
        private readonly IWebServiceHelper _objWs;
        private readonly IControlBuilder _objControlBuilder;
        private readonly IMpFlex _objFlex;

        public FrmLogin()
        {
            _hostUrl = ConfigurationManager.AppSettings["hosturl"];
            _objMsg = new MessageTextHandler();
            IFormatValidate objFv = new FormatValidate();
            _objWs = new WsHelper(_hostUrl, objFv, _objMsg) { ReturnAsModel = true };
            _objFlex = new MpFlex() { Url = _objWs.HostAddress };
            _objControlBuilder = new ControlBuilder(_objFlex, _objWs, _objMsg);
            InitializeComponent();
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            LblVersion.Parent = PbLogo;
            LblCustomer.Parent = PbLogo;
            LblCompany.Parent = PbLogo;
            _objControlBuilder.MessageLabel(EnumMessage.PleaseFillInUsernameAndPassword, LblMsg);
            //TODO:remove this when release
            txtUsername.Text = "admin";
            txtPassword.Text = "admin@2018";

            if (!string.IsNullOrEmpty(_hostUrl)) return;
            _objControlBuilder.MessageLabel(EnumMessage.HostUrlNotFound, LblMsg);
            BtnLogin.Enabled = false;
        }
        // Private Sub RbOperation_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) 
        // SelectionVisible(RbOperation.IsChecked)
        // End Sub
        // Private Sub SelectionVisible(isOperationSelect As Boolean)
        // ddStation.Visible = isOperationSelect
        // TxtSn.Visible = (Not isOperationSelect)
        // If isOperationSelect Then lblStation.Text = "Operation : "
        // If Not isOperationSelect Then lblStation.Text = "Serial Number : "
        // End Sub   

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            StartLogin();
        }
        private void StartLogin()
        {
            var objAuthenicate = new AuthenticationApi(_objWs, _objMsg);
            _objControlBuilder.MessageLabel(EnumMessage.ConnectingToServer, LblMsg);
            if (objAuthenicate.TokenRequest(txtUsername.Text, txtPassword.Text))
            {
                Hide();
                // dim loginData  = _objWs
                var objMdiForm = new MdiMp(_objWs, _objFlex, _objMsg, _objControlBuilder) { LoginInfo = new LoginInfoVm() { Username = txtUsername.Text, LoginDateTime = DateTime.Now, UserId = Convert.ToInt32(_objWs.UserId) } };
                objMdiForm.Username = txtUsername.Text;
                objMdiForm.Show();
            }
            else
            {
                _objControlBuilder.MessageLabel(objAuthenicate.ReturnMsg.ReturnMsgEnum, LblMsg);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)txtPassword.Focus();
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char) 13) return;
            if (txtUsername.Text != "" & txtPassword.Text != "")StartLogin();
        }
        private void BtnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)StartLogin();
        }
    }
}

