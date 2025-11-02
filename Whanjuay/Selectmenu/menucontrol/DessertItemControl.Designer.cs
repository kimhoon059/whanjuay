namespace Whanjuay
{
    partial class DessertItemControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlBackground = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAddToCart = new Guna.UI2.WinForms.Guna2Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pbImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.BorderRadius = 15;
            this.pnlBackground.Controls.Add(this.btnAddToCart);
            this.pnlBackground.Controls.Add(this.lblPrice);
            this.pnlBackground.Controls.Add(this.lblName);
            this.pnlBackground.Controls.Add(this.pbImage);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(240, 200); // [อัปเดต] ขนาดเล็กกะทัดรัด
            this.pnlBackground.TabIndex = 0;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BorderRadius = 10;
            this.btnAddToCart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(23, 155); // [อัปเดต] เลื่อนขึ้นมา
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(194, 30);
            this.btnAddToCart.TabIndex = 5;
            this.btnAddToCart.Text = "เพิ่มลงตะกร้า";
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = false;
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.DimGray;
            this.lblPrice.Location = new System.Drawing.Point(0, 128);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(240, 15);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "(+0.00)";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = false;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.lblName.Location = new System.Drawing.Point(0, 105);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(240, 21);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Dessert Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbImage
            // 
            this.pbImage.BorderRadius = 10;
            this.pbImage.ImageRotate = 0F;
            this.pbImage.Location = new System.Drawing.Point(80, 18);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(80, 80);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // DessertItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlBackground);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DessertItemControl";
            this.Size = new System.Drawing.Size(240, 200); // [อัปเดต] ขนาดเล็กกะทัดรัด
            this.pnlBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlBackground;
        private Guna.UI2.WinForms.Guna2PictureBox pbImage;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblName;
        private Guna.UI2.WinForms.Guna2Button btnAddToCart;
    }
}