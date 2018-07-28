using System.Windows.Forms;

namespace _8mp.Uc
{
    partial class UcSubmit : CustomMpUserControl
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
            this.BtnSubmit = new System.Windows.Forms.Button();
            this.GbSubmitCancel = new System.Windows.Forms.GroupBox();
            this.LblMsg = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.GbSubmitCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.BtnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSubmit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnSubmit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSubmit.Location = new System.Drawing.Point(24, 20);
            this.BtnSubmit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(231, 85);
            this.BtnSubmit.TabIndex = 3;
            this.BtnSubmit.Text = "Submit";
            this.BtnSubmit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSubmit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.BtnSubmit.UseVisualStyleBackColor = false;
            this.BtnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // GbSubmitCancel
            // 
            this.GbSubmitCancel.Controls.Add(this.LblMsg);
            this.GbSubmitCancel.Controls.Add(this.BtnCancel);
            this.GbSubmitCancel.Controls.Add(this.BtnSubmit);
            this.GbSubmitCancel.Location = new System.Drawing.Point(10, -3);
            this.GbSubmitCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GbSubmitCancel.Name = "GbSubmitCancel";
            this.GbSubmitCancel.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GbSubmitCancel.Size = new System.Drawing.Size(788, 140);
            this.GbSubmitCancel.TabIndex = 4;
            this.GbSubmitCancel.TabStop = false;
            // 
            // LblMsg
            // 
            this.LblMsg.AutoSize = true;
            this.LblMsg.Location = new System.Drawing.Point(24, 112);
            this.LblMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(0, 20);
            this.LblMsg.TabIndex = 6;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnCancel.Location = new System.Drawing.Point(532, 20);
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
            // UcSubmit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.GbSubmitCancel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcSubmit";
            this.Size = new System.Drawing.Size(810, 142);
            this.Load += new System.EventHandler(this.UcSubmit_Load);
            this.GbSubmitCancel.ResumeLayout(false);
            this.GbSubmitCancel.PerformLayout();
            this.ResumeLayout(false);

        }

        private Button BtnSubmit;
        private GroupBox GbSubmitCancel;
        private Button BtnCancel;
        private Label LblMsg;
    }
}
