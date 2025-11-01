namespace Whanjuay
{
    partial class CartItemControl
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.pnlIngredients = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDecrease = new Guna.UI2.WinForms.Guna2Button();
            this.btnIncrease = new Guna.UI2.WinForms.Guna2Button();
            this.txtQuantity = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlBackground = new Guna.UI2.WinForms.Guna2Panel();
            this.pbImage = new Guna.UI2.WinForms.Guna2PictureBox(); // [ใหม่]
            this.pnlBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit(); // [ใหม่]
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(140, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(130, 21);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "เครปร้อน (สั่งทำ)";
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Location = new System.Drawing.Point(400, 20);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(160, 21);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "44.00 บาท";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BorderRadius = 5;
            this.btnDelete.FillColor = System.Drawing.Color.Transparent;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(525, 85);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(40, 30);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "🗑️";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlIngredients
            // 
            this.pnlIngredients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlIngredients.AutoSize = true;
            this.pnlIngredients.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlIngredients.Location = new System.Drawing.Point(144, 50);
            this.pnlIngredients.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.pnlIngredients.MaximumSize = new System.Drawing.Size(250, 0);
            this.pnlIngredients.Name = "pnlIngredients";
            this.pnlIngredients.Size = new System.Drawing.Size(0, 0);
            this.pnlIngredients.TabIndex = 5;
            // 
            // btnDecrease
            // 
            this.btnDecrease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecrease.BorderRadius = 5;
            this.btnDecrease.FillColor = System.Drawing.Color.Gainsboro;
            this.btnDecrease.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDecrease.ForeColor = System.Drawing.Color.Black;
            this.btnDecrease.Location = new System.Drawing.Point(380, 85);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(30, 30);
            this.btnDecrease.TabIndex = 6;
            this.btnDecrease.Text = "-";
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
            // 
            // btnIncrease
            // 
            this.btnIncrease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncrease.BorderRadius = 5;
            this.btnIncrease.FillColor = System.Drawing.Color.Gainsboro;
            this.btnIncrease.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnIncrease.ForeColor = System.Drawing.Color.Black;
            this.btnIncrease.Location = new System.Drawing.Point(472, 85);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(30, 30);
            this.btnIncrease.TabIndex = 7;
            this.btnIncrease.Text = "+";
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQuantity.DefaultText = "1";
            this.txtQuantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuantity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtQuantity.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuantity.Location = new System.Drawing.Point(416, 85);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PasswordChar = '\0';
            this.txtQuantity.PlaceholderText = "";
            this.txtQuantity.SelectedText = "";
            this.txtQuantity.Size = new System.Drawing.Size(50, 30);
            this.txtQuantity.TabIndex = 8;
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // pnlBackground
            // 
            this.pnlBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBackground.BackColor = System.Drawing.Color.Transparent;
            this.pnlBackground.BorderRadius = 20;
            this.pnlBackground.Controls.Add(this.pbImage);
            this.pnlBackground.Controls.Add(this.txtQuantity);
            this.pnlBackground.Controls.Add(this.lblName);
            this.pnlBackground.Controls.Add(this.btnIncrease);
            this.pnlBackground.Controls.Add(this.btnDecrease);
            this.pnlBackground.Controls.Add(this.lblPrice);
            this.pnlBackground.Controls.Add(this.pnlIngredients);
            this.pnlBackground.Controls.Add(this.btnDelete);
            this.pnlBackground.FillColor = System.Drawing.Color.White;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlBackground.ShadowDecoration.BorderRadius = 20;
            this.pnlBackground.ShadowDecoration.Enabled = false;
            this.pnlBackground.Size = new System.Drawing.Size(580, 140);
            this.pnlBackground.TabIndex = 9;
            // 
            // pbImage
            // 
            this.pbImage.BorderRadius = 10;
            this.pbImage.ImageRotate = 0F;
            this.pbImage.Location = new System.Drawing.Point(20, 20);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(100, 100);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // CartItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlBackground);
            this.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.MinimumSize = new System.Drawing.Size(580, 140);
            this.Name = "CartItemControl";
            this.Size = new System.Drawing.Size(580, 140);
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private System.Windows.Forms.FlowLayoutPanel pnlIngredients;
        private Guna.UI2.WinForms.Guna2Button btnDecrease;
        private Guna.UI2.WinForms.Guna2Button btnIncrease;
        private Guna.UI2.WinForms.Guna2TextBox txtQuantity;
        private Guna.UI2.WinForms.Guna2Panel pnlBackground;
        private Guna.UI2.WinForms.Guna2PictureBox pbImage;
    }
}