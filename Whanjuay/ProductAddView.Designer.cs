namespace Whanjuay
{
    partial class ProductAddView
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
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbCategoriesMain = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbIngredientCategoriesSub = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtStock = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCategoriesMain = new System.Windows.Forms.Label();
            this.lblSubCategory = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.btnChangeImage = new Guna.UI2.WinForms.Guna2Button();
            this.pnlImage = new Guna.UI2.WinForms.Guna2Panel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.Location = new System.Drawing.Point(20, 124);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(400, 36);
            this.txtName.TabIndex = 0;
            // 
            // cmbCategoriesMain
            // 
            this.cmbCategoriesMain.BackColor = System.Drawing.Color.Transparent;
            this.cmbCategoriesMain.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCategoriesMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriesMain.FocusedColor = System.Drawing.Color.Empty;
            this.cmbCategoriesMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategoriesMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbCategoriesMain.ItemHeight = 30;
            this.cmbCategoriesMain.Location = new System.Drawing.Point(20, 212);
            this.cmbCategoriesMain.Name = "cmbCategoriesMain";
            this.cmbCategoriesMain.Size = new System.Drawing.Size(400, 36);
            this.cmbCategoriesMain.TabIndex = 1;
            // 
            // cmbIngredientCategoriesSub
            // 
            this.cmbIngredientCategoriesSub.BackColor = System.Drawing.Color.Transparent;
            this.cmbIngredientCategoriesSub.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbIngredientCategoriesSub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIngredientCategoriesSub.FocusedColor = System.Drawing.Color.Empty;
            this.cmbIngredientCategoriesSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbIngredientCategoriesSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbIngredientCategoriesSub.ItemHeight = 30;
            this.cmbIngredientCategoriesSub.Location = new System.Drawing.Point(20, 300);
            this.cmbIngredientCategoriesSub.Name = "cmbIngredientCategoriesSub";
            this.cmbIngredientCategoriesSub.Size = new System.Drawing.Size(400, 36);
            this.cmbIngredientCategoriesSub.TabIndex = 2;
            // 
            // txtPrice
            // 
            this.txtPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrice.DefaultText = "";
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPrice.Location = new System.Drawing.Point(20, 391);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PlaceholderText = "";
            this.txtPrice.SelectedText = "";
            this.txtPrice.Size = new System.Drawing.Size(79, 36);
            this.txtPrice.TabIndex = 3;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // txtStock
            // 
            this.txtStock.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStock.DefaultText = "";
            this.txtStock.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtStock.Location = new System.Drawing.Point(238, 391);
            this.txtStock.Name = "txtStock";
            this.txtStock.PlaceholderText = "";
            this.txtStock.SelectedText = "";
            this.txtStock.Size = new System.Drawing.Size(86, 36);
            this.txtStock.TabIndex = 4;
            this.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStock.TextChanged += new System.EventHandler(this.txtStock_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 10;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(373, 468);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 45);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "บันทึกสินค้า";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(160, 32);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "เพิ่มสินค้าใหม่";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(20, 90);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 19);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "ชื่อสินค้า";
            // 
            // lblCategoriesMain
            // 
            this.lblCategoriesMain.AutoSize = true;
            this.lblCategoriesMain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCategoriesMain.Location = new System.Drawing.Point(20, 178);
            this.lblCategoriesMain.Name = "lblCategoriesMain";
            this.lblCategoriesMain.Size = new System.Drawing.Size(103, 19);
            this.lblCategoriesMain.TabIndex = 9;
            this.lblCategoriesMain.Text = "ประเภทเมนูหลัก";
            // 
            // lblSubCategory
            // 
            this.lblSubCategory.AutoSize = true;
            this.lblSubCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubCategory.Location = new System.Drawing.Point(20, 266);
            this.lblSubCategory.Name = "lblSubCategory";
            this.lblSubCategory.Size = new System.Drawing.Size(145, 19);
            this.lblSubCategory.TabIndex = 10;
            this.lblSubCategory.Text = "ประเภทวัตถุดิบ / สินค้า";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Location = new System.Drawing.Point(20, 356);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(79, 19);
            this.lblPrice.TabIndex = 11;
            this.lblPrice.Text = "ราคา (บาท)";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStock.Location = new System.Drawing.Point(238, 356);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(86, 19);
            this.lblStock.TabIndex = 12;
            this.lblStock.Text = "จำนวนสินค้า";
            this.lblStock.Click += new System.EventHandler(this.lblStock_Click);
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblImage.Location = new System.Drawing.Point(477, 90);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(87, 19);
            this.lblImage.TabIndex = 14;
            this.lblImage.Text = "รูปภาพสินค้า";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BorderRadius = 10;
            this.btnBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(792, 20);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 36);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "ย้อนกลับ";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // btnChangeImage
            // 
            this.btnChangeImage.BorderRadius = 10;
            this.btnChangeImage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.btnChangeImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeImage.ForeColor = System.Drawing.Color.White;
            this.btnChangeImage.Location = new System.Drawing.Point(575, 363);
            this.btnChangeImage.Name = "btnChangeImage";
            this.btnChangeImage.Size = new System.Drawing.Size(150, 35);
            this.btnChangeImage.TabIndex = 17;
            this.btnChangeImage.Text = "เปลี่ยนรูปภาพ";
            this.btnChangeImage.Click += new System.EventHandler(this.btnChangeImage_Click_1);
            // 
            // pnlImage
            // 
            this.pnlImage.BorderColor = System.Drawing.Color.Gray;
            this.pnlImage.BorderRadius = 10;
            this.pnlImage.BorderThickness = 1;
            this.pnlImage.Controls.Add(this.pbImage);
            this.pnlImage.Location = new System.Drawing.Point(477, 124);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(352, 224);
            this.pnlImage.TabIndex = 16;
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.LightGray;
            this.pbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage.Location = new System.Drawing.Point(0, 0);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(352, 224);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // ProductAddView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmbCategoriesMain);
            this.Controls.Add(this.lblCategoriesMain);
            this.Controls.Add(this.btnChangeImage);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pnlImage);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblSubCategory);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.cmbIngredientCategoriesSub);
            this.Controls.Add(this.txtName);
            this.Name = "ProductAddView";
            this.Size = new System.Drawing.Size(918, 545);
            this.pnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Guna.UI2.WinForms.Guna2TextBox txtName;
        internal Guna.UI2.WinForms.Guna2ComboBox cmbCategoriesMain;
        internal Guna.UI2.WinForms.Guna2ComboBox cmbIngredientCategoriesSub;
        internal Guna.UI2.WinForms.Guna2TextBox txtPrice;
        internal Guna.UI2.WinForms.Guna2TextBox txtStock;
        // [แก้] ลบ txtDescription
        internal Guna.UI2.WinForms.Guna2Button btnSave;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.Label lblCategoriesMain;
        internal System.Windows.Forms.Label lblSubCategory;
        internal System.Windows.Forms.Label lblPrice;
        internal System.Windows.Forms.Label lblStock;
        // [แก้] ลบ lblDescription
        internal System.Windows.Forms.Label lblImage;
        internal Guna.UI2.WinForms.Guna2Button btnBack;
        internal Guna.UI2.WinForms.Guna2Button btnChangeImage;
        internal Guna.UI2.WinForms.Guna2Panel pnlImage;
        internal System.Windows.Forms.PictureBox pbImage;
    }
}