using System;
using System.Drawing;
using System.Windows.Forms;
using MpFlexLib.Interfaces;
using WeifenLuo.WinFormsUI.Docking;
using _8mp.Helper.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Factory.Classes;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Classes;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.General;
using  _8mp.Helper.Classes;

namespace _8mp.Form
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class MdiMp
    {
        private readonly IWebServiceHelper _objWs;
        private readonly IMpFlex _objFlex;
        private readonly IMessageTextHandler _objMsg;

        private readonly IOperationApi _objOperatrion;
        private readonly IControlBuilder _objC;
        private IMpModuleController _objMp;
        private readonly DockContent _dockContent = new DockContent() { Name = "mainMpDockContent", Text = "Operation", BackColor = Color.White, AutoScroll = true };

        private DockContent _operationToolbox;
        private DockContent _SnToolbox;
        private DockContent _MessageToolbox;
        private DockContent _MessageServerToolbox;

        public string Username { get; set; }
        public int UserId { get; set; }
        public string Station { get; set; }
        public int StationId { get; set; }
        public DateTime LoginDateTime { get; set; }
        public LoginInfoVm LoginInfo { get; set; }
        // Private m_toolbox As MpToolbox
        
        public MdiMp(IWebServiceHelper objWs, IMpFlex objFlex, IMessageTextHandler objMsg, IControlBuilder objControlBuilder)
        {
            _objWs = objWs;
            _objFlex = objFlex;
            _objFlex.Form = this;
            _objC = objControlBuilder;
            _objMsg = objMsg;
            _objOperatrion = new OperationApi(objWs);
            InitializeComponent();
        }

        private void MdiMp_Load(object sender, EventArgs e)
        {
            _objMp = new MpModuleController(_objFlex, _objWs, _objC, _objMsg, _objOperatrion, new MpTransaction(_objFlex, _objWs, _objMsg)) { FormObject = this, DockPanelMain =dockPanel };
            IsMdiContainer = true;
            StatusStrip.Items[0].Text = _objMsg.GetSystemMsg(EnumMessage.SL_StatusOnline).ReturnMsg;
            StatusStrip.Items.Add(new ToolStripStatusLabel() { Text = _objMsg.GetSystemMsg(EnumMessage.DisplayUserName, Username).ReturnMsg, BorderStyle = Border3DStyle.Etched, BorderSides = ToolStripStatusLabelBorderSides.Right });
            Text = _objMsg.GetSystemMsg(EnumMessage.SL_FomMainTitle).ReturnMsg;
            _objMp.LoginInfo = LoginInfo;
            _objMp.LoadMain();
        }
        private void OperationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_operationToolbox != null && OperationsToolStripMenuItem.Checked)_operationToolbox.IsHidden = !OperationsToolStripMenuItem.Checked;
        }
        private void MessageExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_MessageToolbox != null && MessageExplorerToolStripMenuItem.Checked)_MessageToolbox.IsHidden = !MessageExplorerToolStripMenuItem.Checked;
        }
        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.StatusStrip.Visible = this.StatusBarToolStripMenuItem.Checked;
        }

        private void ShowControlNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _objC.ShowObjectName(this, ToolTip1);
        }
        private void WorkInstructionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var w = new FrmMessage(_objMsg, _objC);
            w.Top = (Top + (Height / 2)) - w.Height / 2;
            w.Left = (Left + (Width / 2)) - w.Width / 2;
            w.ShowPopup(_objMsg.GetSystemMsg(EnumMessage.AdditionalLicenseRequired), this);
        }
        private void LogOutMenuItem_Click(object sender, EventArgs e)
        {
            _dockContent.Close();
            _operationToolbox?.Close();
            _MessageToolbox?.Close();
            LoginMenuItem.Enabled = true;
            var f = new FrmLogin();
            f.Show();
            Hide();
        }
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }
        private void MdiMp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
}

