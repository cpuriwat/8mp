using System.Windows.Forms;

namespace _8mp.Form
{
    partial class FrmMessage : Telerik.WinControls.UI.ShapedForm
    {

        // Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                    components.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessage));
            this.RadThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.TelerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.RoundRectShape1 = new Telerik.WinControls.RoundRectShape(this.components);
            this.LblMsg = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList1
            // 
            this.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // PbLogo
            // 
            this.PbLogo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PbLogo.Image = ((System.Drawing.Image)(resources.GetObject("PbLogo.Image")));
            this.PbLogo.Location = new System.Drawing.Point(0, 96);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(354, 95);
            this.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbLogo.TabIndex = 13;
            this.PbLogo.TabStop = false;
            // 
            // RoundRectShape1
            // 
            this.RoundRectShape1.Radius = 10;
            // 
            // LblMsg
            // 
            this.LblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblMsg.AutoSize = true;
            this.LblMsg.Location = new System.Drawing.Point(12, 14);
            this.LblMsg.MaximumSize = new System.Drawing.Size(350, 0);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(39, 13);
            this.LblMsg.TabIndex = 14;
            this.LblMsg.Text = "Label1";
            this.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button1
            // 
            this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button1.Location = new System.Drawing.Point(143, 65);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 26);
            this.Button1.TabIndex = 15;
            this.Button1.Text = "OK";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // FrmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(354, 191);
            this.ControlBox = false;
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.LblMsg);
            this.Controls.Add(this.PbLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMessage";
            this.Shape = this.RoundRectShape1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MP - Login";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Telerik.WinControls.RadThemeManager RadThemeManager1;
        private Telerik.WinControls.Themes.TelerikMetroBlueTheme TelerikMetroBlueTheme1;
        private ImageList ImageList1;
        private PictureBox PbLogo;
        private Telerik.WinControls.RoundRectShape RoundRectShape1;
        private Label LblMsg;
        private Button Button1;

    }
}
