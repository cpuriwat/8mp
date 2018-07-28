using System.Windows.Forms;

namespace _8mp.Uc
{
    partial class UcSo : CustomMpUserControl
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
            this.LblSo = new System.Windows.Forms.Label();
            this.CbSo = new System.Windows.Forms.ComboBox();
            this.GbOrder = new System.Windows.Forms.GroupBox();
            this.LblMsg = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.LblRoute = new System.Windows.Forms.Label();
            this.LblRouteNameLabel = new System.Windows.Forms.Label();
            this.LblProductNameLabel = new System.Windows.Forms.Label();
            this.LblProductName = new System.Windows.Forms.Label();
            this.LblRegisteredQty = new System.Windows.Forms.Label();
            this.LblRegisterQtyLabel = new System.Windows.Forms.Label();
            this.LblOrderQty = new System.Windows.Forms.Label();
            this.LblOrderQtyLabel = new System.Windows.Forms.Label();
            this.GbOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblSo
            // 
            this.LblSo.AutoSize = true;
            this.LblSo.Location = new System.Drawing.Point(23, 44);
            this.LblSo.Name = "LblSo";
            this.LblSo.Size = new System.Drawing.Size(68, 13);
            this.LblSo.TabIndex = 0;
            this.LblSo.Text = "Work Order :";
            // 
            // CbSo
            // 
            this.CbSo.FormattingEnabled = true;
            this.CbSo.Location = new System.Drawing.Point(135, 40);
            this.CbSo.Name = "CbSo";
            this.CbSo.Size = new System.Drawing.Size(297, 21);
            this.CbSo.TabIndex = 2;
            this.CbSo.SelectedValueChanged += new System.EventHandler(this.CbSo_SelectedValueChanged);
            // 
            // GbOrder
            // 
            this.GbOrder.Controls.Add(this.LblMsg);
            this.GbOrder.Controls.Add(this.lblProduct);
            this.GbOrder.Controls.Add(this.cbProduct);
            this.GbOrder.Controls.Add(this.LblRoute);
            this.GbOrder.Controls.Add(this.LblRouteNameLabel);
            this.GbOrder.Controls.Add(this.LblProductNameLabel);
            this.GbOrder.Controls.Add(this.LblProductName);
            this.GbOrder.Controls.Add(this.LblRegisteredQty);
            this.GbOrder.Controls.Add(this.LblRegisterQtyLabel);
            this.GbOrder.Controls.Add(this.LblOrderQty);
            this.GbOrder.Controls.Add(this.LblOrderQtyLabel);
            this.GbOrder.Controls.Add(this.LblSo);
            this.GbOrder.Controls.Add(this.CbSo);
            this.GbOrder.Location = new System.Drawing.Point(8, -3);
            this.GbOrder.Margin = new System.Windows.Forms.Padding(2);
            this.GbOrder.Name = "GbOrder";
            this.GbOrder.Padding = new System.Windows.Forms.Padding(2);
            this.GbOrder.Size = new System.Drawing.Size(525, 126);
            this.GbOrder.TabIndex = 2;
            this.GbOrder.TabStop = false;
            // 
            // LblMsg
            // 
            this.LblMsg.AutoSize = true;
            this.LblMsg.Location = new System.Drawing.Point(21, 106);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(0, 13);
            this.LblMsg.TabIndex = 11;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(23, 16);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(50, 13);
            this.lblProduct.TabIndex = 10;
            this.lblProduct.Text = "Product :";
            // 
            // cbProduct
            // 
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(135, 12);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(297, 21);
            this.cbProduct.TabIndex = 1;
            this.cbProduct.SelectionChangeCommitted += new System.EventHandler(this.cbProduct_SelectionChangeCommitted);
            this.cbProduct.SelectedValueChanged += new System.EventHandler(this.cbProduct_SelectedValueChanged);
            // 
            // LblRoute
            // 
            this.LblRoute.AutoSize = true;
            this.LblRoute.Location = new System.Drawing.Point(285, 84);
            this.LblRoute.Name = "LblRoute";
            this.LblRoute.Size = new System.Drawing.Size(27, 13);
            this.LblRoute.TabIndex = 9;
            this.LblRoute.Text = "N/A";
            // 
            // LblRouteNameLabel
            // 
            this.LblRouteNameLabel.AutoSize = true;
            this.LblRouteNameLabel.Location = new System.Drawing.Point(197, 84);
            this.LblRouteNameLabel.Name = "LblRouteNameLabel";
            this.LblRouteNameLabel.Size = new System.Drawing.Size(76, 13);
            this.LblRouteNameLabel.TabIndex = 8;
            this.LblRouteNameLabel.Text = "Route Name : ";
            // 
            // LblProductNameLabel
            // 
            this.LblProductNameLabel.AutoSize = true;
            this.LblProductNameLabel.Location = new System.Drawing.Point(186, 67);
            this.LblProductNameLabel.Name = "LblProductNameLabel";
            this.LblProductNameLabel.Size = new System.Drawing.Size(84, 13);
            this.LblProductNameLabel.TabIndex = 7;
            this.LblProductNameLabel.Text = "Product Name : ";
            // 
            // LblProductName
            // 
            this.LblProductName.AutoSize = true;
            this.LblProductName.Location = new System.Drawing.Point(285, 67);
            this.LblProductName.Name = "LblProductName";
            this.LblProductName.Size = new System.Drawing.Size(27, 13);
            this.LblProductName.TabIndex = 6;
            this.LblProductName.Text = "N/A";
            // 
            // LblRegisteredQty
            // 
            this.LblRegisteredQty.AutoSize = true;
            this.LblRegisteredQty.Location = new System.Drawing.Point(119, 84);
            this.LblRegisteredQty.Name = "LblRegisteredQty";
            this.LblRegisteredQty.Size = new System.Drawing.Size(13, 13);
            this.LblRegisteredQty.TabIndex = 5;
            this.LblRegisteredQty.Text = "0";
            // 
            // LblRegisterQtyLabel
            // 
            this.LblRegisterQtyLabel.AutoSize = true;
            this.LblRegisterQtyLabel.Location = new System.Drawing.Point(20, 84);
            this.LblRegisterQtyLabel.Name = "LblRegisterQtyLabel";
            this.LblRegisterQtyLabel.Size = new System.Drawing.Size(86, 13);
            this.LblRegisterQtyLabel.TabIndex = 4;
            this.LblRegisterQtyLabel.Text = "Registered Qty : ";
            // 
            // LblOrderQty
            // 
            this.LblOrderQty.AutoSize = true;
            this.LblOrderQty.Location = new System.Drawing.Point(119, 67);
            this.LblOrderQty.Name = "LblOrderQty";
            this.LblOrderQty.Size = new System.Drawing.Size(13, 13);
            this.LblOrderQty.TabIndex = 3;
            this.LblOrderQty.Text = "0";
            // 
            // LblOrderQtyLabel
            // 
            this.LblOrderQtyLabel.AutoSize = true;
            this.LblOrderQtyLabel.Location = new System.Drawing.Point(45, 67);
            this.LblOrderQtyLabel.Name = "LblOrderQtyLabel";
            this.LblOrderQtyLabel.Size = new System.Drawing.Size(61, 13);
            this.LblOrderQtyLabel.TabIndex = 2;
            this.LblOrderQtyLabel.Text = "Order Qty : ";
            // 
            // UcSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.GbOrder);
            this.Name = "UcSo";
            this.Size = new System.Drawing.Size(540, 125);
            this.Load += new System.EventHandler(this.UcSo_Load);
            this.GbOrder.ResumeLayout(false);
            this.GbOrder.PerformLayout();
            this.ResumeLayout(false);

        }

        private Label LblSo;
        private ComboBox CbSo;
        private GroupBox GbOrder;
        private Label LblRoute;
        private Label LblRouteNameLabel;
        private Label LblProductNameLabel;
        private Label LblProductName;
        private Label LblRegisteredQty;
        private Label LblRegisterQtyLabel;
        private Label LblOrderQty;
        private Label LblOrderQtyLabel;
        private Label lblProduct;
        private ComboBox cbProduct;
        private Label LblMsg;
    }
}
