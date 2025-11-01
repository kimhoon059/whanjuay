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
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCheckout = new Guna.UI2.WinForms.Guna2Button();
            this.flowCartItems = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
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
            // 
            // pnlSummary
            // 
            this.pnlSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSummary.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummary.BorderRadius = 20;
            this.pnlSummary.Controls.Add(this.lblTotal);
            this.pnlSummary.Controls.Add(this.label3);
            this.pnlSummary.Controls.Add(this.btnCheckout);
            this.pnlSummary.FillColor = System.Drawing.Color.White;
            this.pnlSummary.Location = new System.Drawing.Point(824, 110);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.ShadowDecoration.BorderRadius = 20;
            this.pnlSummary.ShadowDecoration.Enabled = false; // [แก้] ปิดเงาสีเทา
            this.pnlSummary.Size = new System.Drawing.Size(400, 200);
            this.pnlSummary.TabIndex = 3;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(180, 20);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(190, 30);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "0.00 บาท";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(20, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "ยอดรวมทั้งหมด";
            // 
            // btnCheckout
            // 
            this.btnCheckout.BorderRadius = 10;
            this.btnCheckout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(25, 130);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(350, 45);
            this.btnCheckout.TabIndex = 0;
            this.btnCheckout.Text = "ดำเนินการชำระเงิน";
            // 
            // flowCartItems
            // 
            this.flowCartItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowCartItems.AutoScroll = true;
            this.flowCartItems.BackColor = System.Drawing.Color.Transparent; // [แก้]
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
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label3;
    }
}