using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.IO;

namespace Whanjuay
{
    public delegate void AddProductEventHandler();
    public delegate void EditProductEventHandler(int productId);

    public partial class ProductListView : UserControl
    {
        public event AddProductEventHandler AddRequested;
        public event EditProductEventHandler EditRequested;

        private readonly string ImageBaseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

        public ProductListView()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.Transparent;
            this.Load += ProductListView_Load_Logic;
        }

        private void ProductListView_Load_Logic(object sender, EventArgs e)
        {
            if (productGrid == null || btnAddProduct == null)
            {
                return;
            }
            InitializeProductListUI();
            LoadProducts();
        }

        private void InitializeProductListUI()
        {
            // กำหนด Style Header ของ DataGrid 
            productGrid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(249, 243, 237),
                ForeColor = Color.SaddleBrown,
                SelectionBackColor = Color.FromArgb(249, 243, 237),
                SelectionForeColor = Color.SaddleBrown,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                WrapMode = DataGridViewTriState.True
            };

            // กำหนด Style Cell ทั่วไป (เพื่อควบคุมการเลือกแถว)
            productGrid.RowsDefaultCellStyle = new DataGridViewCellStyle
            {
                SelectionBackColor = Color.FromArgb(255, 230, 210),
                SelectionForeColor = Color.SaddleBrown,
            };

            // กำหนดความมนของขอบปุ่ม
            btnAddProduct.BorderRadius = 10;
            txtSearch.BorderRadius = 15;
            btnSearch.BorderRadius = 15;

            // ผูก Event Clicks
            productGrid.CellContentClick -= ProductGrid_CellContentClick;
            productGrid.CellContentClick += ProductGrid_CellContentClick;
            productGrid.CellFormatting -= ProductGrid_CellFormatting;
            productGrid.CellFormatting += ProductGrid_CellFormatting;
            btnAddProduct.Click -= BtnAddProduct_Click;
            btnAddProduct.Click += BtnAddProduct_Click;

            // ผูก Event Search
            txtSearch.TextChanged -= TxtSearch_TextChanged;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnSearch.Click -= BtnSearch_Click;
            btnSearch.Click += BtnSearch_Click;

            ConfigureGridColumns();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterProducts(txtSearch.Text);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            FilterProducts(txtSearch.Text);
        }

        public void FilterProducts(string searchTerm)
        {
            if (this.productGrid.DataSource is DataTable dt)
            {
                string safeSearchTerm = searchTerm.Replace("'", "''");

                if (string.IsNullOrWhiteSpace(safeSearchTerm))
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    string filter = $"name LIKE '%{safeSearchTerm}%' OR category_name LIKE '%{safeSearchTerm}%'";
                    dt.DefaultView.RowFilter = filter;
                }
            }
        }

        public void LoadProducts()
        {
            try
            {
                ConfigureGridColumns();
                DataTable dt = Db.GetProductsForList();
                productGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureGridColumns()
        {
            productGrid.Columns.Clear();
            // Total Width: 80 + 50 + 30 + 100 + 30 + 390 + 150 = 830 (เท่ากับขนาดตารางใน Designer.cs)

            // 1. คอลัมน์รูปภาพ
            productGrid.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = "รูปภาพ",
                Name = "image_path",
                DataPropertyName = "image_path",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 80
            });

            // 2. คอลัมน์ สถานะสินค้า (Hot Sale)
            productGrid.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "สถานะสินค้า",
                Name = "HotSaleToggleCol",
                DataPropertyName = "is_hot_sale",
                UseColumnTextForButtonValue = false,
                Width = 50, // 👈 FIX (Item 3): เล็กลงตามมาร์กเกอร์สีแดง
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 3. คอลัมน์ ACTIONS (แก้ไข)
            productGrid.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "แก้ไข",
                Name = "EditCol",
                UseColumnTextForButtonValue = true,
                Text = "✏️",
                Width = 30, // 👈 FIX (Item 3): เล็กลงตามมาร์กเกอร์สีแดง
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 4. หมวดหมู่
            AddTextColumn("category_name", "หมวดหมู่", 100, DataGridViewContentAlignment.MiddleCenter) // 👈 FIX (Item 4): จัดข้อมูลให้อยู่กึ่งกลาง
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 5. คอลัมน์ ACTIONS (ลบ)
            productGrid.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "ลบ",
                Name = "DeleteCol",
                UseColumnTextForButtonValue = true,
                Text = "🗑️",
                Width = 30, // 👈 FIX (Item 3): เล็กลงตามมาร์กเกอร์สีแดง
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 6. ชื่อสินค้า
            AddTextColumn("name", "ชื่อสินค้า", 390, DataGridViewContentAlignment.MiddleLeft) // 👈 FIX (Item 4): จัดข้อมูลให้อยู่ชิดซ้าย (ดูจากภาพประกอบ)
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            // 7. ราคา
            // ใช้ความกว้าง 150 และจัดชิดขวา โดยตัวเลขจะถูกจัด MiddleRight (Item 2)
            var priceCol = AddTextColumn("price", "ราคา (บาท)", 150, DataGridViewContentAlignment.MiddleRight); // 👈 FIX (Item 2): เพิ่มความกว้างเป็น 150
            priceCol.DefaultCellStyle.Format = "N2";
            priceCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            // ซ่อนคอลัมน์ที่ไม่จำเป็น
            AddTextColumn("is_hot_sale", "IsHotSale", 0).Visible = false;
            AddTextColumn("status", "Status", 0).Visible = false;
            AddTextColumn("product_id", "ID", 0).Visible = false;
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

            // 1. จัดการคอลัมน์รูปภาพ
            if (productGrid.Columns[e.ColumnIndex].Name == "image_path")
            {
                string imagePathFromDb = row.Cells["image_path"].Value?.ToString();
                if (!string.IsNullOrEmpty(imagePathFromDb))
                {
                    string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePathFromDb.Replace('/', Path.DirectorySeparatorChar));

                    if (File.Exists(fullPath))
                    {
                        try
                        {
                            // ใช้วิธีอ่านเป็น MemoryStream เพื่อปลดล็อคไฟล์
                            using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                            {
                                e.Value = Image.FromStream(stream);
                            }
                        }
                        catch (Exception) { e.Value = null; }
                    }
                    else { e.Value = null; }
                }
            }

            // 2. จัดการคอลัมน์ สถานะสินค้า (Hot Sale)
            else if (productGrid.Columns[e.ColumnIndex].Name == "HotSaleToggleCol")
            {
                bool isHotSale = Convert.ToBoolean(row.Cells["is_hot_sale"].Value);

                if (isHotSale)
                {
                    e.Value = "🔥 HOT SALE";
                    e.CellStyle.BackColor = Color.IndianRed;
                    e.CellStyle.ForeColor = Color.White;
                }
                else
                {
                    e.Value = "NORMAL";
                    e.CellStyle.BackColor = Color.LightGray;
                    e.CellStyle.ForeColor = Color.Black;
                }
                e.FormattingApplied = true;
            }
        }

        private void ProductGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!(productGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) && !(productGrid.Columns[e.ColumnIndex].Name == "HotSaleToggleCol")) return;

            int productId = Convert.ToInt32(productGrid.Rows[e.RowIndex].Cells["product_id"].Value);

            // 1. Logic สำหรับ Hot Sale Toggle
            if (productGrid.Columns[e.ColumnIndex].Name == "HotSaleToggleCol")
            {
                bool currentStatus = Convert.ToBoolean(productGrid.Rows[e.RowIndex].Cells["is_hot_sale"].Value);
                bool newStatus = !currentStatus;

                try
                {
                    Db.UpdateHotSaleStatus(productId, newStatus);
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating Hot Sale status: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // 2. Logic สำหรับ Edit
            else if (productGrid.Columns[e.ColumnIndex].Name == "EditCol")
            {
                EditRequested?.Invoke(productId);
            }
            // 3. Logic สำหรับ Delete
            else if (productGrid.Columns[e.ColumnIndex].Name == "DeleteCol")
            {
                if (MessageBox.Show($"ยืนยันการลบสินค้า ID: {productId}?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        string imagePathFromDb = productGrid.Rows[e.RowIndex].Cells["image_path"].Value?.ToString();

                        Db.DeleteProduct(productId);

                        if (!string.IsNullOrEmpty(imagePathFromDb))
                        {
                            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePathFromDb.Replace('/', Path.DirectorySeparatorChar));
                            if (File.Exists(fullPath))
                            {
                                try { File.Delete(fullPath); } catch { /* ละเว้นข้อผิดพลาดในการลบไฟล์ */ }
                            }
                        }

                        LoadProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"เกิดข้อผิดพลาดในการลบ: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            AddRequested?.Invoke();
        }
    }
}