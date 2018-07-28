using System.Windows.Forms;

namespace _8mp.Uc
{
    partial class UcSn : CustomMpUserControl
    {
        // Inherits System.Windows.Forms.UserControl

        // UserControl overrides dispose to clean up the component list.
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
            this.TxtSn = new System.Windows.Forms.TextBox();
            this.BtnSnSubmit = new System.Windows.Forms.Button();
            this.LblSn = new System.Windows.Forms.Label();
            this.GbSn = new System.Windows.Forms.GroupBox();
            this.ChkAutoSubmit = new System.Windows.Forms.CheckBox();
            this.LblMsg = new System.Windows.Forms.Label();
            this.GbSn.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtSn
            // 
            this.TxtSn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSn.Location = new System.Drawing.Point(136, 20);
            this.TxtSn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtSn.Name = "TxtSn";
            this.TxtSn.Size = new System.Drawing.Size(514, 48);
            this.TxtSn.TabIndex = 1;
            this.TxtSn.TextChanged += new System.EventHandler(this.TxtSn_TextChanged);
            this.TxtSn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSn_KeyPress);
            // 
            // BtnSnSubmit
            // 
            this.BtnSnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnSnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSnSubmit.Location = new System.Drawing.Point(657, 20);
            this.BtnSnSubmit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSnSubmit.Name = "BtnSnSubmit";
            this.BtnSnSubmit.Size = new System.Drawing.Size(112, 54);
            this.BtnSnSubmit.TabIndex = 4;
            this.BtnSnSubmit.Text = "&Submit";
            this.BtnSnSubmit.UseVisualStyleBackColor = true;
            this.BtnSnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // LblSn
            // 
            this.LblSn.AutoSize = true;
            this.LblSn.Location = new System.Drawing.Point(9, 37);
            this.LblSn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblSn.Name = "LblSn";
            this.LblSn.Size = new System.Drawing.Size(117, 20);
            this.LblSn.TabIndex = 5;
            this.LblSn.Text = "Serial Number :";
            // 
            // GbSn
            // 
            this.GbSn.Controls.Add(this.ChkAutoSubmit);
            this.GbSn.Controls.Add(this.LblMsg);
            this.GbSn.Controls.Add(this.LblSn);
            this.GbSn.Controls.Add(this.TxtSn);
            this.GbSn.Controls.Add(this.BtnSnSubmit);
            this.GbSn.Location = new System.Drawing.Point(10, 5);
            this.GbSn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GbSn.Name = "GbSn";
            this.GbSn.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GbSn.Size = new System.Drawing.Size(788, 138);
            this.GbSn.TabIndex = 0;
            this.GbSn.TabStop = false;
            this.GbSn.Text = "Unit";
            // 
            // ChkAutoSubmit
            // 
            this.ChkAutoSubmit.AutoSize = true;
            this.ChkAutoSubmit.Location = new System.Drawing.Point(136, 77);
            this.ChkAutoSubmit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChkAutoSubmit.Name = "ChkAutoSubmit";
            this.ChkAutoSubmit.Size = new System.Drawing.Size(210, 24);
            this.ChkAutoSubmit.TabIndex = 7;
            this.ChkAutoSubmit.Text = "Auto Submit Transaction";
            this.ChkAutoSubmit.UseVisualStyleBackColor = true;
            // 
            // LblMsg
            // 
            this.LblMsg.AutoSize = true;
            this.LblMsg.Location = new System.Drawing.Point(136, 109);
            this.LblMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(137, 20);
            this.LblMsg.TabIndex = 6;
            this.LblMsg.Text = "Ready to process.";
            // 
            // UcSn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.GbSn);
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "UcSn";
            this.Size = new System.Drawing.Size(810, 151);
            this.GbSn.ResumeLayout(false);
            this.GbSn.PerformLayout();
            this.ResumeLayout(false);

        }
        private TextBox TxtSn;
        private Button BtnSnSubmit;
        private Label LblSn;
        private GroupBox GbSn;
        private Label LblMsg;
        private CheckBox ChkAutoSubmit;
    }
}
