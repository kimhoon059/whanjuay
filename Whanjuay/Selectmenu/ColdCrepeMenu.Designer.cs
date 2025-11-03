namespace Whanjuay
{
    // [อัปเดต] เปลี่ยนชื่อคลาสเป็น ColdCrepeMenu
    partial class ColdCrepeMenu
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

        // [เพิ่มใหม่] คัดลอก UI ทั้งหมดมาจาก HotCrepeMenu.Designer.cs
        private void InitializeComponent()
        {
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlFilters = new Guna.UI2.WinForms.Guna2Panel();
            this.chkConfirmCrepe = new Guna.UI2.WinForms.Guna2CheckBox();
            this.pnlRoundedContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.flowMainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddToCart = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.btnCart = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMain.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlRoundedContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackgroundImage = global::Whanjuay.Properties.Resources.selectmenuwj;
            this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMain.Controls.Add(this.pnlFilters);
            this.pnlMain.Controls.Add(this.pnlRoundedContainer);
            this.pnlMain.Controls.Add(this.btnAddToCart);
            this.pnlMain.Controls.Add(this.btnBack);
            this.pnlMain.Controls.Add(this.btnCart);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1264, 681);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlFilters
            // 
            this.pnlFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilters.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilters.BorderRadius = 15;
            this.pnlFilters.Controls.Add(this.chkConfirmCrepe);
            this.pnlFilters.FillColor = System.Drawing.Color.White;
            this.pnlFilters.Location = new System.Drawing.Point(40, 91);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(1182, 53);
            this.pnlFilters.TabIndex = 5;
            // 
            // chkConfirmCrepe
            // 
            this.chkConfirmCrepe.AutoSize = true;
            this.chkConfirmCrepe.BackColor = System.Drawing.Color.Transparent;
            this.chkConfirmCrepe.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.chkConfirmCrepe.CheckedState.BorderRadius = 2;
            this.chkConfirmCrepe.CheckedState.BorderThickness = 0;
            this.chkConfirmCrepe.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.chkConfirmCrepe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.chkConfirmCrepe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.chkConfirmCrepe.Location = new System.Drawing.Point(23, 15);
            this.chkConfirmCrepe.Name = "chkConfirmCrepe";
            this.chkConfirmCrepe.Size = new System.Drawing.Size(260, 25);
            this.chkConfirmCrepe.TabIndex = 0;
            this.chkConfirmCrepe.Text = "ยืนยันเครปเย็น (ราคา 45.00 บาท)";
            this.chkConfirmCrepe.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkConfirmCrepe.UncheckedState.BorderRadius = 2;
            this.chkConfirmCrepe.UncheckedState.BorderThickness = 0;
            this.chkConfirmCrepe.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkConfirmCrepe.UseVisualStyleBackColor = false;
            this.chkConfirmCrepe.CheckedChanged += new System.EventHandler(this.chkConfirmCrepe_CheckedChanged_1);
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
            this.pnlRoundedContainer.Location = new System.Drawing.Point(40, 150);
            this.pnlRoundedContainer.Name = "pnlRoundedContainer";
            this.pnlRoundedContainer.Padding = new System.Windows.Forms.Padding(5);
            this.pnlRoundedContainer.Size = new System.Drawing.Size(1182, 434);
            this.pnlRoundedContainer.TabIndex = 4;
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
            this.flowMainPanel.Size = new System.Drawing.Size(1172, 424);
            this.flowMainPanel.TabIndex = 0;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToCart.BackColor = System.Drawing.Color.Transparent;
            this.btnAddToCart.BorderRadius = 20;
            this.btnAddToCart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(992, 629);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(230, 40);
            this.btnAddToCart.TabIndex = 3;
            this.btnAddToCart.Text = "เพิ่มลงตะกร้า";
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BorderRadius = 20;
            this.btnBack.FillColor = System.Drawing.Color.LightCoral;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.Snow;
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
            // ColdCrepeMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pnlMain);
            this.Name = "ColdCrepeMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ColdCrepeMenu";
            this.pnlMain.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlRoundedContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal Guna.UI2.WinForms.Guna2Panel pnlMain;
        internal Guna.UI2.WinForms.Guna2Button btnCart;
        internal Guna.UI2.WinForms.Guna2Button btnBack;
        internal System.Windows.Forms.FlowLayoutPanel flowMainPanel;
        internal Guna.UI2.WinForms.Guna2Button btnAddToCart;
        internal Guna.UI2.WinForms.Guna2Panel pnlRoundedContainer;
        // [เพิ่มใหม่]
        internal Guna.UI2.WinForms.Guna2Panel pnlFilters;
        internal Guna.UI2.WinForms.Guna2CheckBox chkConfirmCrepe;
    }
}