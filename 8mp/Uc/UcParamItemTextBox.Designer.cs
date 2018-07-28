using System.Windows.Forms;

namespace _8mp.Uc
{
    partial class UcParamItemTextBox : CustomMpUserControl
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.txtParamValue = new System.Windows.Forms.TextBox();
            this.lblParamName = new System.Windows.Forms.Label();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.LblMsg = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.FlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.txtParamValue);
            this.Panel1.Controls.Add(this.lblParamName);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(3, 3);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(747, 34);
            this.Panel1.TabIndex = 3;
            // 
            // txtParamValue
            // 
            this.txtParamValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtParamValue.Location = new System.Drawing.Point(138, 0);
            this.txtParamValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtParamValue.Name = "txtParamValue";
            this.txtParamValue.Size = new System.Drawing.Size(373, 20);
            this.txtParamValue.TabIndex = 1;
            this.txtParamValue.TextChanged += new System.EventHandler(this.txtParamValue_TextChanged);
            this.txtParamValue.Enter += new System.EventHandler(this.txtParamValue_Enter);
            this.txtParamValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParamValue_KeyPress);
            this.txtParamValue.Leave += new System.EventHandler(this.txtParamValue_Leave);
            this.txtParamValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtParamValue_Validating);
            // 
            // lblParamName
            // 
            this.lblParamName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblParamName.Location = new System.Drawing.Point(0, 0);
            this.lblParamName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParamName.Name = "lblParamName";
            this.lblParamName.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblParamName.Size = new System.Drawing.Size(138, 34);
            this.lblParamName.TabIndex = 2;
            this.lblParamName.Text = "Parameter Name :";
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.AutoSize = true;
            this.FlowLayoutPanel1.Controls.Add(this.LblMsg);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(3, 37);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(747, 13);
            this.FlowLayoutPanel1.TabIndex = 4;
            // 
            // LblMsg
            // 
            this.LblMsg.AutoSize = true;
            this.LblMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblMsg.Location = new System.Drawing.Point(4, 0);
            this.LblMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(0, 13);
            this.LblMsg.TabIndex = 3;
            this.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UcParamItemTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.Panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcParamItemTextBox";
            this.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.Size = new System.Drawing.Size(750, 63);
            this.Load += new System.EventHandler(this.ucParamItemTextBox_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.FlowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Panel Panel1;
        private TextBox txtParamValue;
        private Label lblParamName;
        private FlowLayoutPanel FlowLayoutPanel1;
        private Label LblMsg;
    }
}
