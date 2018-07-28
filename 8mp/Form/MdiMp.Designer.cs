using System.Windows.Forms;

namespace _8mp.Form
{
    partial class MdiMp : System.Windows.Forms.Form
    {
        // Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null) components.Dispose();
            }
            finally { base.Dispose(disposing); }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MdiMp));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LoginMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogOutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OperationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MessageExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkInstructionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowControlNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ContentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.ViewMenu,
            this.ToolsMenu,
            this.HelpMenu});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1008, 24);
            this.MenuStrip.TabIndex = 5;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoginMenuItem,
            this.LogOutMenuItem,
            this.ToolStripSeparator5,
            this.ExitToolStripMenuItem});
            this.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "&File";
            // 
            // LoginMenuItem
            // 
            this.LoginMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("LoginMenuItem.Image")));
            this.LoginMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.LoginMenuItem.Name = "LoginMenuItem";
            this.LoginMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.LoginMenuItem.Size = new System.Drawing.Size(160, 22);
            this.LoginMenuItem.Text = "Log &In";
            // 
            // LogOutMenuItem
            // 
            this.LogOutMenuItem.Name = "LogOutMenuItem";
            this.LogOutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.LogOutMenuItem.Size = new System.Drawing.Size(160, 22);
            this.LogOutMenuItem.Text = "&Log Out";
            this.LogOutMenuItem.Click += new System.EventHandler(this.LogOutMenuItem_Click);
            // 
            // ToolStripSeparator5
            // 
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(157, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.ExitToolStripMenuItem.Text = "E&xit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarToolStripMenuItem,
            this.OperationsToolStripMenuItem,
            this.MessageExplorerToolStripMenuItem});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(44, 20);
            this.ViewMenu.Text = "&View";
            // 
            // StatusBarToolStripMenuItem
            // 
            this.StatusBarToolStripMenuItem.Checked = true;
            this.StatusBarToolStripMenuItem.CheckOnClick = true;
            this.StatusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StatusBarToolStripMenuItem.Name = "StatusBarToolStripMenuItem";
            this.StatusBarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.StatusBarToolStripMenuItem.Text = "&Status Bar";
            this.StatusBarToolStripMenuItem.Click += new System.EventHandler(this.StatusBarToolStripMenuItem_Click);
            // 
            // OperationsToolStripMenuItem
            // 
            this.OperationsToolStripMenuItem.Checked = true;
            this.OperationsToolStripMenuItem.CheckOnClick = true;
            this.OperationsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OperationsToolStripMenuItem.Name = "OperationsToolStripMenuItem";
            this.OperationsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OperationsToolStripMenuItem.Text = "Operations Explorer";
            this.OperationsToolStripMenuItem.Click += new System.EventHandler(this.OperationsToolStripMenuItem_Click);
            // 
            // MessageExplorerToolStripMenuItem
            // 
            this.MessageExplorerToolStripMenuItem.Checked = true;
            this.MessageExplorerToolStripMenuItem.CheckOnClick = true;
            this.MessageExplorerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MessageExplorerToolStripMenuItem.Name = "MessageExplorerToolStripMenuItem";
            this.MessageExplorerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.MessageExplorerToolStripMenuItem.Text = "Message Explorer";
            this.MessageExplorerToolStripMenuItem.Click += new System.EventHandler(this.MessageExplorerToolStripMenuItem_Click);
            // 
            // ToolsMenu
            // 
            this.ToolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkInstructionToolStripMenuItem,
            this.ShowControlNameToolStripMenuItem});
            this.ToolsMenu.Name = "ToolsMenu";
            this.ToolsMenu.Size = new System.Drawing.Size(47, 20);
            this.ToolsMenu.Text = "&Tools";
            // 
            // WorkInstructionToolStripMenuItem
            // 
            this.WorkInstructionToolStripMenuItem.Name = "WorkInstructionToolStripMenuItem";
            this.WorkInstructionToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.WorkInstructionToolStripMenuItem.Text = "Work Instruction";
            this.WorkInstructionToolStripMenuItem.Click += new System.EventHandler(this.WorkInstructionToolStripMenuItem_Click);
            // 
            // ShowControlNameToolStripMenuItem
            // 
            this.ShowControlNameToolStripMenuItem.Name = "ShowControlNameToolStripMenuItem";
            this.ShowControlNameToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ShowControlNameToolStripMenuItem.Text = "Show Control Name";
            this.ShowControlNameToolStripMenuItem.Click += new System.EventHandler(this.ShowControlNameToolStripMenuItem_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContentsToolStripMenuItem,
            this.IndexToolStripMenuItem,
            this.ToolStripSeparator8,
            this.AboutToolStripMenuItem});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(44, 20);
            this.HelpMenu.Text = "&Help";
            // 
            // ContentsToolStripMenuItem
            // 
            this.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem";
            this.ContentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.ContentsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.ContentsToolStripMenuItem.Text = "&Contents";
            // 
            // IndexToolStripMenuItem
            // 
            this.IndexToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("IndexToolStripMenuItem.Image")));
            this.IndexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem";
            this.IndexToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.IndexToolStripMenuItem.Text = "&Ticket Request";
            // 
            // ToolStripSeparator8
            // 
            this.ToolStripSeparator8.Name = "ToolStripSeparator8";
            this.ToolStripSeparator8.Size = new System.Drawing.Size(165, 6);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.AboutToolStripMenuItem.Text = "&About ...";
            // 
            // StatusStrip
            // 
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 666);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(1008, 24);
            this.StatusStrip.TabIndex = 7;
            this.StatusStrip.Text = "StatusStrip";
            // 
            // ToolStripStatusLabel
            // 
            this.ToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.ToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            this.ToolStripStatusLabel.Size = new System.Drawing.Size(43, 19);
            this.ToolStripStatusLabel.Text = "Status";
            // 
            // dockPanel
            // 
            this.dockPanel.BackColor = System.Drawing.Color.White;
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.Location = new System.Drawing.Point(0, 24);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(1008, 642);
            this.dockPanel.TabIndex = 14;
            // 
            // MdiMp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 690);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.StatusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MdiMp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MdiMp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MdiMp_FormClosed);
            this.Load += new System.EventHandler(this.MdiMp_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripMenuItem ContentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpMenu;
        private System.Windows.Forms.ToolStripMenuItem IndexToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkInstructionToolStripMenuItem;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem LogOutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoginMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ViewMenu;
        private System.Windows.Forms.ToolStripMenuItem StatusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsMenu;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private ToolStripMenuItem OperationsToolStripMenuItem;
        private ToolStripMenuItem MessageExplorerToolStripMenuItem;
        private ToolStripMenuItem ShowControlNameToolStripMenuItem;
        private ToolTip ToolTip1;
    }
}

