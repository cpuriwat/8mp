using System.Windows.Forms;

namespace _8mp.Uc
{
    partial class UcFailure : CustomMpUserControl
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
            this.UnitHistory = new System.Windows.Forms.TreeView();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.CbDefectCode = new System.Windows.Forms.ComboBox();
            this.CbFailCode = new System.Windows.Forms.ComboBox();
            this.GbRework = new System.Windows.Forms.GroupBox();
            this.CbReworkCode = new System.Windows.Forms.ComboBox();
            this.RdRemove = new System.Windows.Forms.RadioButton();
            this.RdReplace = new System.Windows.Forms.RadioButton();
            this.RdRework = new System.Windows.Forms.RadioButton();
            this.LblReworkCode = new System.Windows.Forms.Label();
            this.LblDefectCode = new System.Windows.Forms.Label();
            this.LblFailCode = new System.Windows.Forms.Label();
            this.BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.LblMsg = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.TxtPn = new System.Windows.Forms.TextBox();
            this.LblPn = new System.Windows.Forms.Label();
            this.LblRefDes = new System.Windows.Forms.Label();
            this.TxtRefDes = new System.Windows.Forms.TextBox();
            this.GvFailure = new System.Windows.Forms.DataGridView();
            this.GroupBox1.SuspendLayout();
            this.GbRework.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvFailure)).BeginInit();
            this.SuspendLayout();
            // 
            // UnitHistory
            // 
            this.UnitHistory.Dock = System.Windows.Forms.DockStyle.Left;
            this.UnitHistory.Location = new System.Drawing.Point(0, 0);
            this.UnitHistory.Margin = new System.Windows.Forms.Padding(2);
            this.UnitHistory.Name = "UnitHistory";
            this.UnitHistory.Size = new System.Drawing.Size(212, 366);
            this.UnitHistory.TabIndex = 0;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.CbDefectCode);
            this.GroupBox1.Controls.Add(this.CbFailCode);
            this.GroupBox1.Controls.Add(this.GbRework);
            this.GroupBox1.Controls.Add(this.LblDefectCode);
            this.GroupBox1.Controls.Add(this.LblFailCode);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GroupBox1.Location = new System.Drawing.Point(212, 154);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox1.Size = new System.Drawing.Size(542, 137);
            this.GroupBox1.TabIndex = 11;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Failure Information";
            // 
            // CbDefectCode
            // 
            this.CbDefectCode.FormattingEnabled = true;
            this.CbDefectCode.Location = new System.Drawing.Point(142, 46);
            this.CbDefectCode.Name = "CbDefectCode";
            this.CbDefectCode.Size = new System.Drawing.Size(256, 21);
            this.CbDefectCode.TabIndex = 11;
            // 
            // CbFailCode
            // 
            this.CbFailCode.FormattingEnabled = true;
            this.CbFailCode.Location = new System.Drawing.Point(142, 19);
            this.CbFailCode.Name = "CbFailCode";
            this.CbFailCode.Size = new System.Drawing.Size(256, 21);
            this.CbFailCode.TabIndex = 1;
            // 
            // GbRework
            // 
            this.GbRework.Controls.Add(this.CbReworkCode);
            this.GbRework.Controls.Add(this.RdRemove);
            this.GbRework.Controls.Add(this.RdReplace);
            this.GbRework.Controls.Add(this.RdRework);
            this.GbRework.Controls.Add(this.LblReworkCode);
            this.GbRework.Location = new System.Drawing.Point(52, 69);
            this.GbRework.Name = "GbRework";
            this.GbRework.Size = new System.Drawing.Size(389, 60);
            this.GbRework.TabIndex = 9;
            this.GbRework.TabStop = false;
            // 
            // CbReworkCode
            // 
            this.CbReworkCode.FormattingEnabled = true;
            this.CbReworkCode.Location = new System.Drawing.Point(90, 11);
            this.CbReworkCode.Name = "CbReworkCode";
            this.CbReworkCode.Size = new System.Drawing.Size(256, 21);
            this.CbReworkCode.TabIndex = 14;
            // 
            // RdRemove
            // 
            this.RdRemove.AutoSize = true;
            this.RdRemove.Location = new System.Drawing.Point(281, 38);
            this.RdRemove.Name = "RdRemove";
            this.RdRemove.Size = new System.Drawing.Size(65, 17);
            this.RdRemove.TabIndex = 13;
            this.RdRemove.TabStop = true;
            this.RdRemove.Text = "Remove";
            this.RdRemove.UseVisualStyleBackColor = true;
            // 
            // RdReplace
            // 
            this.RdReplace.AutoSize = true;
            this.RdReplace.Location = new System.Drawing.Point(187, 38);
            this.RdReplace.Name = "RdReplace";
            this.RdReplace.Size = new System.Drawing.Size(65, 17);
            this.RdReplace.TabIndex = 12;
            this.RdReplace.TabStop = true;
            this.RdReplace.Text = "Replace";
            this.RdReplace.UseVisualStyleBackColor = true;
            // 
            // RdRework
            // 
            this.RdRework.AutoSize = true;
            this.RdRework.Location = new System.Drawing.Point(90, 38);
            this.RdRework.Name = "RdRework";
            this.RdRework.Size = new System.Drawing.Size(62, 17);
            this.RdRework.TabIndex = 11;
            this.RdRework.TabStop = true;
            this.RdRework.Text = "Rework";
            this.RdRework.UseVisualStyleBackColor = true;
            // 
            // LblReworkCode
            // 
            this.LblReworkCode.AutoSize = true;
            this.LblReworkCode.Location = new System.Drawing.Point(6, 14);
            this.LblReworkCode.Name = "LblReworkCode";
            this.LblReworkCode.Size = new System.Drawing.Size(78, 13);
            this.LblReworkCode.TabIndex = 10;
            this.LblReworkCode.Text = "Rework Code :";
            // 
            // LblDefectCode
            // 
            this.LblDefectCode.AutoSize = true;
            this.LblDefectCode.Location = new System.Drawing.Point(63, 49);
            this.LblDefectCode.Name = "LblDefectCode";
            this.LblDefectCode.Size = new System.Drawing.Size(73, 13);
            this.LblDefectCode.TabIndex = 4;
            this.LblDefectCode.Text = "Defect Code :";
            // 
            // LblFailCode
            // 
            this.LblFailCode.AutoSize = true;
            this.LblFailCode.Location = new System.Drawing.Point(79, 22);
            this.LblFailCode.Name = "LblFailCode";
            this.LblFailCode.Size = new System.Drawing.Size(57, 13);
            this.LblFailCode.TabIndex = 3;
            this.LblFailCode.Text = "Fail Code :";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.LblMsg);
            this.GroupBox2.Controls.Add(this.BtnCancel);
            this.GroupBox2.Controls.Add(this.BtnRemove);
            this.GroupBox2.Controls.Add(this.BtnAdd);
            this.GroupBox2.Controls.Add(this.TxtPn);
            this.GroupBox2.Controls.Add(this.LblPn);
            this.GroupBox2.Controls.Add(this.LblRefDes);
            this.GroupBox2.Controls.Add(this.TxtRefDes);
            this.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GroupBox2.Location = new System.Drawing.Point(212, 291);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox2.Size = new System.Drawing.Size(542, 75);
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Unit Reference Designator";
            // 
            // LblMsg
            // 
            this.LblMsg.AutoSize = true;
            this.LblMsg.Location = new System.Drawing.Point(292, 48);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(0, 13);
            this.LblMsg.TabIndex = 12;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(446, 18);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(370, 18);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(75, 23);
            this.BtnRemove.TabIndex = 5;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.UseVisualStyleBackColor = true;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(294, 18);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 4;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            // 
            // TxtPn
            // 
            this.TxtPn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtPn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtPn.Location = new System.Drawing.Point(142, 45);
            this.TxtPn.Name = "TxtPn";
            this.TxtPn.Size = new System.Drawing.Size(144, 20);
            this.TxtPn.TabIndex = 3;
            // 
            // LblPn
            // 
            this.LblPn.AutoSize = true;
            this.LblPn.Location = new System.Drawing.Point(64, 48);
            this.LblPn.Name = "LblPn";
            this.LblPn.Size = new System.Drawing.Size(72, 13);
            this.LblPn.TabIndex = 2;
            this.LblPn.Text = "Part Number :";
            this.LblPn.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblRefDes
            // 
            this.LblRefDes.AutoSize = true;
            this.LblRefDes.Location = new System.Drawing.Point(19, 21);
            this.LblRefDes.Name = "LblRefDes";
            this.LblRefDes.Size = new System.Drawing.Size(117, 13);
            this.LblRefDes.TabIndex = 11;
            this.LblRefDes.Text = "Reference Designator :";
            // 
            // TxtRefDes
            // 
            this.TxtRefDes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtRefDes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtRefDes.Location = new System.Drawing.Point(142, 18);
            this.TxtRefDes.Name = "TxtRefDes";
            this.TxtRefDes.Size = new System.Drawing.Size(144, 20);
            this.TxtRefDes.TabIndex = 2;
            this.TxtRefDes.TextChanged += new System.EventHandler(this.TxtRefDes_TextChanged);
            // 
            // GvFailure
            // 
            this.GvFailure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvFailure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GvFailure.Location = new System.Drawing.Point(212, 0);
            this.GvFailure.Name = "GvFailure";
            this.GvFailure.Size = new System.Drawing.Size(542, 154);
            this.GvFailure.TabIndex = 3;
            // 
            // UcFailure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GvFailure);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.UnitHistory);
            this.Name = "UcFailure";
            this.Size = new System.Drawing.Size(754, 366);
            this.Load += new System.EventHandler(this.UcFailure_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GbRework.ResumeLayout(false);
            this.GbRework.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvFailure)).EndInit();
            this.ResumeLayout(false);

        }
        private TreeView UnitHistory;
        private GroupBox GroupBox1;
        private System.ComponentModel.BackgroundWorker BackgroundWorker1;
        private GroupBox GroupBox2;
        private DataGridView GvFailure;
        private TextBox TxtRefDes;
        private TextBox TxtPn;
        private Label LblPn;
        private Label LblRefDes;
        private Button BtnCancel;
        private Button BtnRemove;
        private Button BtnAdd;
        private GroupBox GbRework;
        private RadioButton RdRemove;
        private RadioButton RdReplace;
        private RadioButton RdRework;
        private Label LblReworkCode;
        private Label LblDefectCode;
        private Label LblFailCode;
        private ComboBox CbDefectCode;
        private ComboBox CbFailCode;
        private ComboBox CbReworkCode;
        private Label LblMsg;
    }
}

