namespace Whanjuay
{
    partial class ProductListView
    {
        private System.ComponentModel.IContainer components = null;

        // ********** ส่วนนี้ถูกปล่อยว่างเพื่อป้องกัน Ambiguity **********

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddProduct = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.productGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.productGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddProduct.BorderRadius = 10;
            this.btnAddProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.btnAddProduct.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddProduct.Location = new System.Drawing.Point(685, 20);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(150, 40);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "+ เพิ่มสินค้าใหม่";
            // *** REMOVED: this.btnAddProduct.Click += new System.EventHandler(this.BtnAddProduct_Click); ***
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(143, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "จัดการสินค้า";
            // 
            // productGrid
            // 
            this.productGrid.AllowUserToAddRows = false;
            this.productGrid.AllowUserToDeleteRows = false;
            // ... (Style and other properties omitted for brevity, use your existing ones) ...
            this.productGrid.Location = new System.Drawing.Point(20, 132);
            this.productGrid.Name = "productGrid";
            this.productGrid.ReadOnly = true;
            this.productGrid.RowHeadersVisible = false;
            this.productGrid.RowTemplate.Height = 80;
            this.productGrid.Size = new System.Drawing.Size(815, 408);
            this.productGrid.TabIndex = 2;
            // *** REMOVED: this.productGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductGrid_CellContentClick); ***
            // *** REMOVED: this.productGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ProductGrid_CellFormatting); ***
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 15;
            // ... (properties omitted for brevity) ...
            this.txtSearch.Location = new System.Drawing.Point(20, 73);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "ค้นหาสินค้า...";
            this.txtSearch.Size = new System.Drawing.Size(328, 36);
            this.txtSearch.TabIndex = 3;
            // *** REMOVED: this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged); ***
            // 
            // btnSearch
            // 
            this.btnSearch.BorderRadius = 15;
            this.btnSearch.FillColor = System.Drawing.Color.Transparent;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(354, 73);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(36, 36);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "🔍"; 
            // *** REMOVED: this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click); ***
            // 
            // ProductListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnSearch); 
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.productGrid);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAddProduct);
            this.Name = "ProductListView";
            this.Size = new System.Drawing.Size(855, 560);
            ((System.ComponentModel.ISupportInitialize)(this.productGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // ********** 2. ประกาศตัวแปรคอนโทรลทั้งหมดเป็น internal **********
        // นี่คือการประกาศที่ถูกต้องและจะถูกใช้โดย ProductListView.cs
        internal Guna.UI2.WinForms.Guna2Button btnAddProduct;
        internal System.Windows.Forms.Label lblTitle;
        internal Guna.UI2.WinForms.Guna2DataGridView productGrid;
        internal Guna.UI2.WinForms.Guna2TextBox txtSearch;
        internal Guna.UI2.WinForms.Guna2Button btnSearch;
    }
}