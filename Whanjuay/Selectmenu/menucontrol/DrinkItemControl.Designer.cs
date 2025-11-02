namespace Whanjuay
{
    partial class DrinkItemControl
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
            this.lblNoteExample = new System.Windows.Forms.Label();
            this.btnAddToCart = new Guna.UI2.WinForms.Guna2Button();
            this.txtNote = new Guna.UI2.WinForms.Guna2TextBox();
            this.groupOptions = new Guna.UI2.WinForms.Guna2GroupBox();
            this.rbFrappe = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbIced = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbHot = new Guna.UI2.WinForms.Guna2RadioButton();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pbImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlBackground.SuspendLayout();
            this.groupOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.BorderRadius = 15;
            this.pnlBackground.Controls.Add(this.lblNoteExample);
            this.pnlBackground.Controls.Add(this.btnAddToCart);
            this.pnlBackground.Controls.Add(this.txtNote);
            this.pnlBackground.Controls.Add(this.groupOptions);
            this.pnlBackground.Controls.Add(this.lblPrice);
            this.pnlBackground.Controls.Add(this.lblName);
            this.pnlBackground.Controls.Add(this.pbImage);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(240, 390);
            this.pnlBackground.TabIndex = 0;
            // 
            // lblNoteExample
            // 
            this.lblNoteExample.AutoSize = true;
            this.lblNoteExample.BackColor = System.Drawing.Color.Transparent;
            this.lblNoteExample.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNoteExample.ForeColor = System.Drawing.Color.Gray;
            this.lblNoteExample.Location = new System.Drawing.Point(26, 268);
            this.lblNoteExample.Name = "lblNoteExample";
            this.lblNoteExample.Size = new System.Drawing.Size(91, 13);
            this.lblNoteExample.TabIndex = 6;
            this.lblNoteExample.Text = "รายละเอียดเพิ่มเติม :";
            this.lblNoteExample.Click += new System.EventHandler(this.lblNoteExample_Click);
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BorderRadius = 10;
            this.btnAddToCart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(23, 345);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(194, 30);
            this.btnAddToCart.TabIndex = 5;
            this.btnAddToCart.Text = "เพิ่มลงตะกร้า";
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // txtNote
            // 
            this.txtNote.BorderRadius = 5;
            this.txtNote.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNote.DefaultText = "";
            this.txtNote.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNote.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNote.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNote.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNote.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNote.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNote.Location = new System.Drawing.Point(23, 284);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.PlaceholderText = "";
            this.txtNote.SelectedText = "";
            this.txtNote.Size = new System.Drawing.Size(194, 51);
            this.txtNote.TabIndex = 4;
            this.txtNote.Enter += new System.EventHandler(this.txtNote_Enter);
            this.txtNote.Leave += new System.EventHandler(this.txtNote_Leave);
            // 
            // groupOptions
            // 
            this.groupOptions.BackColor = System.Drawing.Color.Transparent;
            this.groupOptions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupOptions.Controls.Add(this.rbFrappe);
            this.groupOptions.Controls.Add(this.rbIced);
            this.groupOptions.Controls.Add(this.rbHot);
            this.groupOptions.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupOptions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupOptions.ForeColor = System.Drawing.Color.SaddleBrown;
            this.groupOptions.Location = new System.Drawing.Point(23, 146);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(194, 119);
            this.groupOptions.TabIndex = 3;
            this.groupOptions.Text = "รูปแบบ";
            // 
            // rbFrappe
            // 
            this.rbFrappe.AutoSize = true;
            this.rbFrappe.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.rbFrappe.CheckedState.BorderThickness = 0;
            this.rbFrappe.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.rbFrappe.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbFrappe.CheckedState.InnerOffset = -4;
            this.rbFrappe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbFrappe.ForeColor = System.Drawing.Color.Black;
            this.rbFrappe.Location = new System.Drawing.Point(15, 91);
            this.rbFrappe.Name = "rbFrappe";
            this.rbFrappe.Size = new System.Drawing.Size(39, 19);
            this.rbFrappe.TabIndex = 2;
            this.rbFrappe.Text = "ปั่น";
            this.rbFrappe.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbFrappe.UncheckedState.BorderThickness = 2;
            this.rbFrappe.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbFrappe.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbFrappe.UseVisualStyleBackColor = true;
            this.rbFrappe.CheckedChanged += new System.EventHandler(this.rbOption_CheckedChanged);
            this.rbFrappe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rbOption_MouseDown);
            // 
            // rbIced
            // 
            this.rbIced.AutoSize = true;
            this.rbIced.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.rbIced.CheckedState.BorderThickness = 0;
            this.rbIced.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.rbIced.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbIced.CheckedState.InnerOffset = -4;
            this.rbIced.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbIced.ForeColor = System.Drawing.Color.Black;
            this.rbIced.Location = new System.Drawing.Point(15, 68);
            this.rbIced.Name = "rbIced";
            this.rbIced.Size = new System.Drawing.Size(41, 19);
            this.rbIced.TabIndex = 1;
            this.rbIced.Text = "เย็น";
            this.rbIced.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbIced.UncheckedState.BorderThickness = 2;
            this.rbIced.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbIced.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbIced.UseVisualStyleBackColor = true;
            this.rbIced.CheckedChanged += new System.EventHandler(this.rbOption_CheckedChanged);
            this.rbIced.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rbOption_MouseDown);
            // 
            // rbHot
            // 
            this.rbHot.AutoSize = true;
            this.rbHot.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.rbHot.CheckedState.BorderThickness = 0;
            this.rbHot.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.rbHot.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbHot.CheckedState.InnerOffset = -4;
            this.rbHot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbHot.ForeColor = System.Drawing.Color.Black;
            this.rbHot.Location = new System.Drawing.Point(15, 45);
            this.rbHot.Name = "rbHot";
            this.rbHot.Size = new System.Drawing.Size(43, 19);
            this.rbHot.TabIndex = 0;
            this.rbHot.Text = "ร้อน";
            this.rbHot.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbHot.UncheckedState.BorderThickness = 2;
            this.rbHot.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbHot.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbHot.UseVisualStyleBackColor = true;
            this.rbHot.CheckedChanged += new System.EventHandler(this.rbOption_CheckedChanged);
            this.rbHot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rbOption_MouseDown);
            // 
            // lblPrice
            // 
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
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.lblName.Location = new System.Drawing.Point(0, 105);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(240, 21);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Drink Name";
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
            // DrinkItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlBackground);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DrinkItemControl";
            this.Size = new System.Drawing.Size(240, 390);
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlBackground;
        private Guna.UI2.WinForms.Guna2PictureBox pbImage;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblName;
        private Guna.UI2.WinForms.Guna2GroupBox groupOptions;
        private Guna.UI2.WinForms.Guna2RadioButton rbFrappe;
        private Guna.UI2.WinForms.Guna2RadioButton rbIced;
        private Guna.UI2.WinForms.Guna2RadioButton rbHot;
        private Guna.UI2.WinForms.Guna2Button btnAddToCart;
        private Guna.UI2.WinForms.Guna2TextBox txtNote;
        private System.Windows.Forms.Label lblNoteExample; // [เพิ่มใหม่]
    }
}