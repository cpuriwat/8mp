namespace _8mp.Form
{
    partial class MpToolbox
    {
        // Inherits System.Windows.Forms.Form

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
            this.SuspendLayout();
            // 
            // MpToolbox
            // 
            this.ClientSize = new System.Drawing.Size(332, 443);
            // Me.HideOnClose = true
            this.Name = "MpToolbox";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            // Me.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide
            // Me.TabText = "Toolbox"
            this.Text = "Toolbox";
            this.ResumeLayout(false);
        }
    }
}
