namespace Whanjuay
{
    partial class CartPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSummary = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGrandTotalValue = new System.Windows.Forms.Label();
            this.lblGrandTotalLabel = new System.Windows.Forms.Label();
            this.btnCheckout = new Guna.UI2.WinForms.Guna2Button();
            this.flowCartItems = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            // [เพิ่มใหม่]
            this.lblSubtotalLabel = new System.Windows.Forms.Label();
            this.lblSubtotalValue = new System.Windows.Forms.Label();
            this.lblVatLabel = new System.Windows.Forms.Label();
            this.lblVatValue = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.pnlMain.Controls.Add(this.pnlSummary);
            this.pnlMain.Controls.Add(this.flowCartItems);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.btnBack);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1264, 681);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlSummary
            // 
            this.pnlSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlSummary.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummary.BorderRadius = 20;
            // [เพิ่มใหม่] เพิ่ม 4 Labels
            this.pnlSummary.Controls.Add(this.lblVatValue);
            this.pnlSummary.Controls.Add(this.lblVatLabel);
            this.pnlSummary.Controls.Add(this.lblSubtotalValue);
            this.pnlSummary.Controls.Add(this.lblSubtotalLabel);
            // [แก้ไข] เปลี่ยนชื่อ Controls
            this.pnlSummary.Controls.Add(this.lblGrandTotalValue);
            this.pnlSummary.Controls.Add(this.lblGrandTotalLabel);
            this.pnlSummary.Controls.Add(this.btnCheckout);
            this.pnlSummary.FillColor = System.Drawing.Color.White;
            this.pnlSummary.Location = new System.Drawing.Point(824, 110);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.ShadowDecoration.BorderRadius = 20;
            this.pnlSummary.ShadowDecoration.Enabled = false;
            // [แก้ไข] เพิ่มความสูง
            this.pnlSummary.Size = new System.Drawing.Size(400, 240);
            this.pnlSummary.TabIndex = 3;
            // 
            // lblGrandTotalValue
            // 
            this.lblGrandTotalValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotalValue.ForeColor = System.Drawing.Color.Black;
            // [แก้ไข] ปรับตำแหน่ง
            this.lblGrandTotalValue.Location = new System.Drawing.Point(180, 110);
            this.lblGrandTotalValue.Name = "lblGrandTotalValue";
            this.lblGrandTotalValue.Size = new System.Drawing.Size(190, 30);
            this.lblGrandTotalValue.TabIndex = 2;
            this.lblGrandTotalValue.Text = "0.00 บาท";
            this.lblGrandTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGrandTotalLabel
            // 
            this.lblGrandTotalLabel.AutoSize = true;
            this.lblGrandTotalLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotalLabel.ForeColor = System.Drawing.Color.Black;
            // [แก้ไข] ปรับตำแหน่ง
            this.lblGrandTotalLabel.Location = new System.Drawing.Point(20, 110);
            this.lblGrandTotalLabel.Name = "lblGrandTotalLabel";
            // [แก้ไข] เปลี่ยน Text
            this.lblGrandTotalLabel.Size = new System.Drawing.Size(155, 30);
            this.lblGrandTotalLabel.TabIndex = 1;
            this.lblGrandTotalLabel.Text = "ยอดรวมทั้งหมด";
            // 
            // btnCheckout
            // 
            this.btnCheckout.BorderRadius = 10;
            this.btnCheckout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            // [แก้ไข] ปรับตำแหน่ง
            this.btnCheckout.Location = new System.Drawing.Point(25, 175);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(350, 45);
            this.btnCheckout.TabIndex = 0;
            this.btnCheckout.Text = "ดำเนินการชำระเงิน";
            // 
            // flowCartItems
            // 
            this.flowCartItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowCartItems.AutoScroll = true;
            this.flowCartItems.BackColor = System.Drawing.Color.Transparent;
            this.flowCartItems.Location = new System.Drawing.Point(40, 110);
            this.flowCartItems.Name = "flowCartItems";
            this.flowCartItems.Size = new System.Drawing.Size(760, 531);
            this.flowCartItems.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(32, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "ตะกร้าสินค้า";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.FillColor = System.Drawing.Color.Transparent;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnBack.Location = new System.Drawing.Point(1042, 40);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(180, 45);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "BACK";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblSubtotalLabel
            // [เพิ่มใหม่]
            this.lblSubtotalLabel.AutoSize = true;
            this.lblSubtotalLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalLabel.ForeColor = System.Drawing.Color.Black;
            this.lblSubtotalLabel.Location = new System.Drawing.Point(21, 29);
            this.lblSubtotalLabel.Name = "lblSubtotalLabel";
            this.lblSubtotalLabel.Size = new System.Drawing.Size(95, 21);
            this.lblSubtotalLabel.TabIndex = 3;
            this.lblSubtotalLabel.Text = "ยอดรวมสินค้า";
            // 
            // lblSubtotalValue
            // [เพิ่มใหม่]
            this.lblSubtotalValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalValue.ForeColor = System.Drawing.Color.Black;
            this.lblSubtotalValue.Location = new System.Drawing.Point(180, 29);
            this.lblSubtotalValue.Name = "lblSubtotalValue";
            this.lblSubtotalValue.Size = new System.Drawing.Size(190, 21);
            this.lblSubtotalValue.TabIndex = 4;
            this.lblSubtotalValue.Text = "0.00 บาท";
            this.lblSubtotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVatLabel
            // [เพิ่มใหม่]
            this.lblVatLabel.AutoSize = true;
            this.lblVatLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVatLabel.ForeColor = System.Drawing.Color.Black;
            this.lblVatLabel.Location = new System.Drawing.Point(21, 65);
            this.lblVatLabel.Name = "lblVatLabel";
            this.lblVatLabel.Size = new System.Drawing.Size(75, 21);
            this.lblVatLabel.TabIndex = 5;
            this.lblVatLabel.Text = "ภาษี (7%)";
            // 
            // lblVatValue
            // [เพิ่มใหม่]
            this.lblVatValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVatValue.ForeColor = System.Drawing.Color.Black;
            this.lblVatValue.Location = new System.Drawing.Point(180, 65);
            this.lblVatValue.Name = "lblVatValue";
            this.lblVatValue.Size = new System.Drawing.Size(190, 21);
            this.lblVatValue.TabIndex = 6;
            this.lblVatValue.Text = "0.00 บาท";
            this.lblVatValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pnlMain);
            this.Name = "CartPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CartPage";
            this.Load += new System.EventHandler(this.CartPage_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowCartItems;
        private Guna.UI2.WinForms.Guna2Panel pnlSummary;
        private Guna.UI2.WinForms.Guna2Button btnCheckout;
        // [แก้ไข] เปลี่ยนชื่อ
        private System.Windows.Forms.Label lblGrandTotalValue;
        private System.Windows.Forms.Label lblGrandTotalLabel;
        // [เพิ่มใหม่]
        private System.Windows.Forms.Label lblVatValue;
        private System.Windows.Forms.Label lblVatLabel;
        private System.Windows.Forms.Label lblSubtotalValue;
        private System.Windows.Forms.Label lblSubtotalLabel;
    }
}