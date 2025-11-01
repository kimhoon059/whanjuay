namespace Whanjuay
{
    partial class HotCrepeMenu
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
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.btnCart = new Guna.UI2.WinForms.Guna2Button();
            this.flowMainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddToCart = new Guna.UI2.WinForms.Guna2Button();
            this.pnlRoundedContainer = new Guna.UI2.WinForms.Guna2Panel(); // [ใหม่] Panel ขอบมน
            this.pnlMain.SuspendLayout();
            this.pnlRoundedContainer.SuspendLayout(); // [ใหม่]
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackgroundImage = global::Whanjuay.Properties.Resources.Selectmenu;
            this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMain.Controls.Add(this.pnlRoundedContainer); // [แก้]
            this.pnlMain.Controls.Add(this.btnAddToCart);
            this.pnlMain.Controls.Add(this.btnBack);
            this.pnlMain.Controls.Add(this.btnCart);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1264, 681);
            this.pnlMain.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.FillColor = System.Drawing.Color.Transparent;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnBack.Location = new System.Drawing.Point(40, 40);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(180, 45);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "BACK";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCart
            // 
            this.btnCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCart.BackColor = System.Drawing.Color.Transparent;
            this.btnCart.BorderRadius = 20;
            this.btnCart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCart.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnCart.Location = new System.Drawing.Point(1042, 40);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(180, 45);
            this.btnCart.TabIndex = 1;
            this.btnCart.Text = "CART";
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // flowMainPanel
            // 
            this.flowMainPanel.AutoScroll = true;
            this.flowMainPanel.BackColor = System.Drawing.Color.Transparent;
            this.flowMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowMainPanel.Location = new System.Drawing.Point(5, 5);
            this.flowMainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.flowMainPanel.Name = "flowMainPanel";
            this.flowMainPanel.Padding = new System.Windows.Forms.Padding(10);
            this.flowMainPanel.Size = new System.Drawing.Size(1172, 460);
            this.flowMainPanel.TabIndex = 0;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToCart.BackColor = System.Drawing.Color.Transparent;
            this.btnAddToCart.BorderRadius = 20;
            this.btnAddToCart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddToCart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddToCart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddToCart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddToCart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(992, 606);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(230, 50);
            this.btnAddToCart.TabIndex = 3;
            this.btnAddToCart.Text = "เพิ่มลงตะกร้า";
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // pnlRoundedContainer
            // 
            this.pnlRoundedContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRoundedContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlRoundedContainer.BorderRadius = 30;
            this.pnlRoundedContainer.Controls.Add(this.flowMainPanel);
            this.pnlRoundedContainer.FillColor = System.Drawing.Color.White;
            this.pnlRoundedContainer.Location = new System.Drawing.Point(40, 110);
            this.pnlRoundedContainer.Name = "pnlRoundedContainer";
            this.pnlRoundedContainer.Padding = new System.Windows.Forms.Padding(5);
            this.pnlRoundedContainer.Size = new System.Drawing.Size(1182, 470);
            this.pnlRoundedContainer.TabIndex = 4;
            // 
            // HotCrepeMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pnlMain);
            this.Name = "HotCrepeMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HotCrepeMenu";
            this.Load += new System.EventHandler(this.HotCrepeMenu_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlRoundedContainer.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Button btnCart;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private System.Windows.Forms.FlowLayoutPanel flowMainPanel;
        private Guna.UI2.WinForms.Guna2Button btnAddToCart;
        private Guna.UI2.WinForms.Guna2Panel pnlRoundedContainer;
    }
}