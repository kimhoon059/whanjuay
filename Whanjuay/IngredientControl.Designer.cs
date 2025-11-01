namespace Whanjuay
{
    partial class IngredientControl
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
            this.pbImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.chkSelect = new Guna.UI2.WinForms.Guna2CheckBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.chkExtra = new Guna.UI2.WinForms.Guna2CheckBox();
            this.pnlBackground = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.pnlBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.BorderRadius = 10;
            this.pbImage.ImageRotate = 0F;
            this.pbImage.Location = new System.Drawing.Point(10, 10);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(80, 80);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // chkSelect
            // 
            this.chkSelect.AutoSize = true;
            this.chkSelect.BackColor = System.Drawing.Color.Transparent;
            this.chkSelect.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.chkSelect.CheckedState.BorderRadius = 2;
            this.chkSelect.CheckedState.BorderThickness = 0;
            this.chkSelect.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.chkSelect.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.chkSelect.Location = new System.Drawing.Point(105, 10);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(103, 23);
            this.chkSelect.TabIndex = 1;
            this.chkSelect.Text = "Ingredient";
            this.chkSelect.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkSelect.UncheckedState.BorderRadius = 2;
            this.chkSelect.UncheckedState.BorderThickness = 0;
            this.chkSelect.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkSelect.UseVisualStyleBackColor = false;
            this.chkSelect.CheckedChanged += new System.EventHandler(this.chkSelect_CheckedChanged);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.DimGray;
            this.lblPrice.Location = new System.Drawing.Point(102, 36);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(46, 15);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "(+0.00)";
            // 
            // chkExtra
            // 
            this.chkExtra.AutoSize = true;
            this.chkExtra.BackColor = System.Drawing.Color.Transparent;
            this.chkExtra.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.chkExtra.CheckedState.BorderRadius = 2;
            this.chkExtra.CheckedState.BorderThickness = 0;
            this.chkExtra.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.chkExtra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkExtra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.chkExtra.Location = new System.Drawing.Point(105, 65);
            this.chkExtra.Name = "chkExtra";
            this.chkExtra.Size = new System.Drawing.Size(91, 19);
            this.chkExtra.TabIndex = 3;
            this.chkExtra.Text = "เพิ่ม (+0.00)";
            this.chkExtra.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkExtra.UncheckedState.BorderRadius = 2;
            this.chkExtra.UncheckedState.BorderThickness = 0;
            this.chkExtra.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkExtra.UseVisualStyleBackColor = false;
            this.chkExtra.Visible = false;
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.Transparent;
            this.pnlBackground.BorderRadius = 15;
            this.pnlBackground.Controls.Add(this.pbImage);
            this.pnlBackground.Controls.Add(this.chkExtra);
            this.pnlBackground.Controls.Add(this.chkSelect);
            this.pnlBackground.Controls.Add(this.lblPrice);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(230))))); // [แก้] สีส้ม Hotsale
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.ShadowDecoration.BorderRadius = 15;
            this.pnlBackground.ShadowDecoration.Enabled = false; // [แก้] ปิดเงาสีเทา
            this.pnlBackground.Size = new System.Drawing.Size(240, 100);
            this.pnlBackground.TabIndex = 4;
            // 
            // IngredientControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlBackground);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "IngredientControl";
            this.Size = new System.Drawing.Size(240, 100);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        internal Guna.UI2.WinForms.Guna2PictureBox pbImage;
        internal Guna.UI2.WinForms.Guna2CheckBox chkSelect;
        internal System.Windows.Forms.Label lblPrice;
        internal Guna.UI2.WinForms.Guna2CheckBox chkExtra;
        private Guna.UI2.WinForms.Guna2Panel pnlBackground;
    }
}