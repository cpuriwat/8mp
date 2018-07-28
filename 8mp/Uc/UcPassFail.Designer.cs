using System.Windows.Forms;

namespace _8mp.Uc
{
    partial class UcPassFail : CustomMpUserControl
    {

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
            this.BtnPass = new System.Windows.Forms.Button();
            this.GbPassFailCancel = new System.Windows.Forms.GroupBox();
            this.LblMsg = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnFail = new System.Windows.Forms.Button();
            this.BtnSubmitFail = new System.Windows.Forms.Button();
            this.GbPassFailCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnPass
            // 
            this.BtnPass.BackColor = System.Drawing.Color.Transparent;
            this.BtnPass.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnPass.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPass.Location = new System.Drawing.Point(24, 17);
            this.BtnPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnPass.Name = "BtnPass";
            this.BtnPass.Size = new System.Drawing.Size(231, 85);
            this.BtnPass.TabIndex = 3;
            this.BtnPass.Text = "PASS";
            this.BtnPass.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPass.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.BtnPass.UseVisualStyleBackColor = false;
            this.BtnPass.Click += new System.EventHandler(this.BtnPass_Click);

            // 
            // GbPassFailCancel
            // 
            this.GbPassFailCancel.Controls.Add(this.LblMsg);
            this.GbPassFailCancel.Controls.Add(this.BtnCancel);
            this.GbPassFailCancel.Controls.Add(this.BtnFail);
            this.GbPassFailCancel.Controls.Add(this.BtnPass);
            this.GbPassFailCancel.Controls.Add(this.BtnSubmitFail);
            this.GbPassFailCancel.Location = new System.Drawing.Point(10, -3);
            this.GbPassFailCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GbPassFailCancel.Name = "GbPassFailCancel";
            this.GbPassFailCancel.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GbPassFailCancel.Size = new System.Drawing.Size(788, 138);
            this.GbPassFailCancel.TabIndex = 4;
            this.GbPassFailCancel.TabStop = false;
            // 
            // LblMsg
            // 
            this.LblMsg.AutoSize = true;
            this.LblMsg.Location = new System.Drawing.Point(24, 111);
            this.LblMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(0, 20);
            this.LblMsg.TabIndex = 7;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnCancel.Location = new System.Drawing.Point(532, 17);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(238, 85);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "CANCEL";
            this.BtnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnFail
            // 
            this.BtnFail.BackColor = System.Drawing.Color.Transparent;
            this.BtnFail.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnFail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFail.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnFail.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnFail.Location = new System.Drawing.Point(274, 17);
            this.BtnFail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnFail.Name = "BtnFail";
            this.BtnFail.Size = new System.Drawing.Size(238, 85);
            this.BtnFail.TabIndex = 4;
            this.BtnFail.Text = "FAIL";
            this.BtnFail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnFail.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.BtnFail.UseVisualStyleBackColor = false;
            this.BtnFail.Click += new System.EventHandler(this.BtnFail_Click);
            // 
            // BtnSubmitFail
            // 
            this.BtnSubmitFail.BackColor = System.Drawing.Color.Transparent;
            this.BtnSubmitFail.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnSubmitFail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSubmitFail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnSubmitFail.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSubmitFail.Location = new System.Drawing.Point(274, 17);
            this.BtnSubmitFail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSubmitFail.Name = "BtnSubmitFail";
            this.BtnSubmitFail.Size = new System.Drawing.Size(238, 85);
            this.BtnSubmitFail.TabIndex = 6;
            this.BtnSubmitFail.Text = "SUBMIT";
            this.BtnSubmitFail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSubmitFail.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.BtnSubmitFail.UseVisualStyleBackColor = false;
            this.BtnSubmitFail.Click += new System.EventHandler(this.BtnSubmitFail_Click);
            // 
            // UcPassFail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.GbPassFailCancel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcPassFail";
            this.Size = new System.Drawing.Size(810, 142);
            this.GbPassFailCancel.ResumeLayout(false);
            this.GbPassFailCancel.PerformLayout();
            this.ResumeLayout(false);

        }

        private GroupBox GbPassFailCancel;
        private Button BtnPass;
        private Button BtnCancel;
        private Button BtnFail;
        private Button BtnSubmitFail;
        private Label LblMsg;
    }
}

