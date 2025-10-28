using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.IO;

namespace Whanjuay
{
    // กำหนด Delegate สำหรับการแจ้งเตือนว่าผู้ใช้ต้องการเพิ่มสินค้า
    public delegate void AddProductEventHandler();

    // User Control สำหรับแสดงรายการสินค้า
    public partial class ProductListView : UserControl
    {
        public event AddProductEventHandler AddRequested;

        // *** FIX CS0649: ลบการประกาศ private fields ที่ไม่มีการใช้งานใน Designer.cs ทิ้ง ***
        // เนื่องจาก productGrid และ btnAddProduct ถูกสร้างและกำหนดค่าใน InitializeProductListUI()
        // จึงไม่ต้องประกาศซ้ำที่นี่อีกต่อไป
        private Guna2DataGridView productGrid;
        private Guna2Button btnAddProduct;

        private readonly string ImageBaseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

        public ProductListView()
        {
            InitializeComponent();
            // ********** FIX: ทำให้พื้นหลังโปร่งใส **********
            this.BackColor = System.Drawing.Color.Transparent;
            // ***********************************************
            this.Load += ProductListView_Load;
        }

        private void ProductListView_Load(object sender, EventArgs e)
        {
            InitializeProductListUI();
            LoadProducts();
        }

        private void InitializeProductListUI()
        {
            // Title Label
            var lblTitle = new Label
            {
                Text = "จัดการสินค้า",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            // ปุ่ม "เพิ่มสินค้าใหม่" 
            btnAddProduct = new Guna2Button
            {
                Text = "+ เพิ่มสินค้าใหม่",
                FillColor = Color.FromArgb(255, 175, 100),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BorderRadius = 10,
                Size = new Size(150, 40),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnAddProduct.Location = new Point(this.Width - btnAddProduct.Width - 20, 20);
            btnAddProduct.Click += BtnAddProduct_Click;
            this.Controls.Add(btnAddProduct);

            // ปรับตำแหน่งปุ่มเมื่อขนาด Control เปลี่ยน
            this.Resize += (s, e) => {
                btnAddProduct.Location = new Point(this.Width - btnAddProduct.Width - 20, 20);
                if (productGrid != null)
                {
                    productGrid.Size = new Size(this.Width - 40, this.Height - 120);
                }
            };

            // DataGridView (productGrid)
            productGrid = new Guna2DataGridView
            {
                Location = new Point(20, 100),
                Size = new Size(this.Width - 40, this.Height - 120),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                BackgroundColor = Color.White,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                BorderStyle = BorderStyle.None,
                ColumnHeadersHeight = 40,
                RowTemplate = { Height = 80 },
            };

            // ... (โค้ด DataGridView style และ Event handlers เหมือนเดิม) ...
            productGrid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(249, 243, 237),
                ForeColor = Color.SaddleBrown,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                SelectionBackColor = Color.Transparent,
                SelectionForeColor = Color.SaddleBrown,
                WrapMode = DataGridViewTriState.True
            };

            productGrid.CellContentClick += ProductGrid_CellContentClick;
            productGrid.CellFormatting += ProductGrid_CellFormatting;

            this.Controls.Add(productGrid);
        }

        public void LoadProducts()
        {
            try
            {
                DataTable dt = Db.GetProductsForList();
                productGrid.DataSource = dt;

                ConfigureGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureGridColumns()
        {
            productGrid.Columns.Clear();

            // 1. คอลัมน์รูปภาพ
            var colImage = new DataGridViewImageColumn
            {
                HeaderText = "รูปภาพ",
                Name = "ImageCol",
                DataPropertyName = "image_path",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 100
            };
            productGrid.Columns.Add(colImage);

            // 2. ชื่อสินค้า
            AddTextColumn("name", "ชื่อสินค้า", 250);

            // 3. ราคา
            AddTextColumn("price", "ราคา (บาท)", 100, DataGridViewContentAlignment.MiddleRight);
            productGrid.Columns["price"].DefaultCellStyle.Format = "N2";

            // 4. หมวดหมู่
            AddTextColumn("category_name", "หมวดหมู่", 150);

            // 5. สถานะ
            AddTextColumn("status", "สถานะ", 100, DataGridViewContentAlignment.MiddleCenter);

            // ซ่อนคอลัมน์ ID
            AddTextColumn("product_id", "ID", 0);
            productGrid.Columns["product_id"].Visible = false;

            // 6. คอลัมน์จัดการ (แก้ไข)
            var colEdit = new DataGridViewImageColumn
            {
                HeaderText = "จัดการ",
                Name = "EditCol",
                Image = null,
                Width = 50
            };
            productGrid.Columns.Add(colEdit);

            // 7. คอลัมน์จัดการ (ลบ)
            var colDelete = new DataGridViewImageColumn
            {
                HeaderText = "",
                Name = "DeleteCol",
                Image = null,
                Width = 50
            };
            productGrid.Columns.Add(colDelete);
        }

        private DataGridViewTextBoxColumn AddTextColumn(string dataPropertyName, string headerText, int width, DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleLeft)
        {
            var col = new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataPropertyName,
                HeaderText = headerText,
                Name = dataPropertyName,
                Width = width,
                DefaultCellStyle = { Alignment = alignment }
            };
            productGrid.Columns.Add(col);
            return col;
        }

        private void ProductGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= productGrid.Rows.Count) return;

            var row = productGrid.Rows[e.RowIndex];

            // 1. จัดการคอลัมน์รูปภาพ (ImageCol)
            if (productGrid.Columns[e.ColumnIndex].Name == "ImageCol")
            {
                string imagePathFromDb = row.Cells["image_path"].Value?.ToString();
                if (!string.IsNullOrEmpty(imagePathFromDb))
                {
                    string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePathFromDb);

                    if (File.Exists(fullPath))
                    {
                        try
                        {
                            e.Value = Image.FromFile(fullPath);
                        }
                        catch (Exception)
                        {
                            e.Value = null;
                        }
                    }
                    else
                    {
                        e.Value = null;
                    }
                }
            }

            // 2. จัดการคอลัมน์สถานะ (status)
            if (productGrid.Columns[e.ColumnIndex].Name == "status")
            {
                string status = e.Value?.ToString() ?? "";
                if (status.Contains("มีสินค้า"))
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 240, 220);
                    e.CellStyle.ForeColor = Color.OrangeRed;
                }
                else if (status.Contains("หมด"))
                {
                    e.CellStyle.BackColor = Color.LightGray;
                    e.CellStyle.ForeColor = Color.DimGray;
                }
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.FormattingApplied = true;
            }
        }

        private void ProductGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (productGrid.Rows[e.RowIndex].Cells["product_id"].Value == DBNull.Value) return;

            int productId = Convert.ToInt32(productGrid.Rows[e.RowIndex].Cells["product_id"].Value);

            if (productGrid.Columns[e.ColumnIndex].Name == "DeleteCol")
            {
                if (MessageBox.Show($"ยืนยันการลบสินค้า ID: {productId}?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        Db.DeleteProduct(productId);
                        MessageBox.Show("ลบสินค้าเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"เกิดข้อผิดพลาดในการลบ: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (productGrid.Columns[e.ColumnIndex].Name == "EditCol")
            {
                MessageBox.Show($"คุณต้องการแก้ไขสินค้า ID: {productId}", "แก้ไข", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // *************** ต้องสร้าง logic สำหรับการแก้ไขต่อ ***************
            }
        }


        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            AddRequested?.Invoke();
        }
    }
}