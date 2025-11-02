using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.IO;
using System.Collections.Generic;

namespace Whanjuay
{
    public delegate void AddProductEventHandler();
    public delegate void EditProductEventHandler(int productId);

    public partial class ProductListView : UserControl
    {
        public event AddProductEventHandler AddRequested;
        public event EditProductEventHandler EditRequested;

        private readonly string ImageBaseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

        private int currentPage = 1;
        private int pageSize = 10;
        private int totalPages = 0;
        private int totalProducts = 0;
        private string currentSearchQuery = "";
        private int currentMainCategoryId = 0;
        private int currentSubCategoryId = 0;
        private bool _isFilterLoading = false;
        private Dictionary<string, Image> imageCache = new Dictionary<string, Image>();

        public ProductListView()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.Transparent;
            this.DoubleBuffered = true;
            this.Load += ProductListView_Load_Logic;
        }

        private void ProductListView_Load_Logic(object sender, EventArgs e)
        {
            if (productGrid == null || btnAddProduct == null)
            {
                return;
            }

            _isFilterLoading = true;
            InitializeProductListUI();
            LoadMainCategoryFilter();
            LoadSubCategoryFilter(0);
            _isFilterLoading = false;
            LoadProducts();
        }

        private void LoadMainCategoryFilter()
        {
            try
            {
                DataTable dt = Db.GetMainCategoriesForFilter();
                cmbMainCategoryFilter.DataSource = dt;
                cmbMainCategoryFilter.DisplayMember = "name";
                cmbMainCategoryFilter.ValueMember = "category_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading main categories: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubCategoryFilter(int mainCategoryId)
        {
            try
            {
                DataTable dt = Db.GetSubCategoriesForFilter(mainCategoryId);
                cmbSubCategoryFilter.DataSource = dt;
                cmbSubCategoryFilter.DisplayMember = "name";
                cmbSubCategoryFilter.ValueMember = "ing_category_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sub-categories: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeProductListUI()
        {
            productGrid.CellContentClick -= ProductGrid_CellContentClick;
            productGrid.CellContentClick += ProductGrid_CellContentClick;
            productGrid.CellFormatting -= ProductGrid_CellFormatting;
            productGrid.CellFormatting += ProductGrid_CellFormatting;
            btnAddProduct.Click -= BtnAddProduct_Click;
            btnAddProduct.Click += BtnAddProduct_Click;
            btnSearch.Click -= BtnSearch_Click;
            btnSearch.Click += BtnSearch_Click;
            cmbMainCategoryFilter.SelectedIndexChanged -= CmbMainCategoryFilter_SelectedIndexChanged;
            cmbMainCategoryFilter.SelectedIndexChanged += CmbMainCategoryFilter_SelectedIndexChanged;
            cmbSubCategoryFilter.SelectedIndexChanged -= CmbSubCategoryFilter_SelectedIndexChanged;
            cmbSubCategoryFilter.SelectedIndexChanged += CmbSubCategoryFilter_SelectedIndexChanged;
            btnNext.Click -= BtnNext_Click;
            btnNext.Click += BtnNext_Click;
            btnPrev.Click -= BtnPrev_Click;
            btnPrev.Click += BtnPrev_Click;
        }

        private int GetComboBoxValue(Guna2ComboBox cmb)
        {
            if (cmb.SelectedItem is DataRowView drv)
            {
                return Convert.ToInt32(drv[cmb.ValueMember]);
            }
            if (cmb.SelectedValue != null)
            {
                try
                {
                    return Convert.ToInt32(cmb.SelectedValue);
                }
                catch (Exception) { return 0; }
            }
            return 0;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            currentSearchQuery = txtSearch.Text;
            currentMainCategoryId = GetComboBoxValue(cmbMainCategoryFilter);
            currentSubCategoryId = GetComboBoxValue(cmbSubCategoryFilter);
            currentPage = 1;
            LoadProducts();
        }

        private void CmbMainCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFilterLoading) return;
            int mainCatId = GetComboBoxValue(cmbMainCategoryFilter);
            currentMainCategoryId = mainCatId;

            _isFilterLoading = true;
            LoadSubCategoryFilter(mainCatId);
            _isFilterLoading = false;

            currentSubCategoryId = 0;
        }

        private void CmbSubCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFilterLoading) return;
            currentSubCategoryId = GetComboBoxValue(cmbSubCategoryFilter);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadProducts();
            }
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadProducts();
            }
        }

        public void LoadProducts()
        {
            try
            {
                this.imageCache.Clear();
                totalProducts = Db.GetProductCount(currentMainCategoryId, currentSubCategoryId, currentSearchQuery);

                if (totalProducts == 0)
                {
                    totalPages = 0;
                    currentPage = 0;
                }
                else
                {
                    totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);
                    if (currentPage == 0) currentPage = 1;
                }

                ConfigureGridColumns();
                DataTable dt = Db.GetProductsPaginated(currentPage, pageSize, currentMainCategoryId, currentSubCategoryId, currentSearchQuery);
                productGrid.DataSource = dt;

                UpdatePaginationUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePaginationUI()
        {
            if (totalPages > 0)
            {
                lblPageInfo.Text = $"หน้า {currentPage} / {totalPages} (สินค้าทั้งหมด {totalProducts} รายการ)";
            }
            else
            {
                lblPageInfo.Text = "ไม่พบสินค้าที่ตรงกัน";
            }

            btnPrev.Enabled = (currentPage > 1);
            btnNext.Enabled = (currentPage < totalPages);
        }

        // =================================================================
        // [แก้ไข] เอาคอลัมน์ Hot Sale ออก
        // =================================================================
        private void ConfigureGridColumns()
        {
            productGrid.Columns.Clear();

            productGrid.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = "รูปภาพ",
                Name = "image_path",
                DataPropertyName = "image_path",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 80
            });

            // [ลบออก] ปุ่ม HotSaleToggleCol

            productGrid.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "แก้ไข",
                Name = "EditCol",
                UseColumnTextForButtonValue = true,
                Text = "✏️",
                Width = 50, // ขยายเล็กน้อย
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            AddTextColumn("category_name", "หมวดหมู่", 140, DataGridViewContentAlignment.MiddleCenter)
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            productGrid.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "ลบ",
                Name = "DeleteCol",
                UseColumnTextForButtonValue = true,
                Text = "🗑️",
                Width = 50, // ขยายเล็กน้อย
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            AddTextColumn("name", "ชื่อสินค้า", 280, DataGridViewContentAlignment.MiddleCenter)
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var priceCol = AddTextColumn("price", "ราคา (บาท)", 100, DataGridViewContentAlignment.MiddleCenter);
            priceCol.DefaultCellStyle.Format = "N2";
            priceCol.DefaultCellStyle.ForeColor = Color.DarkGreen;
            priceCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var stockCol = AddTextColumn("stock_quantity", "จำนวนสินค้า", 100, DataGridViewContentAlignment.MiddleCenter);
            stockCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            stockCol.DefaultCellStyle.ForeColor = Color.DarkGreen;

            // [ลบออก] is_hot_sale
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

        // =================================================================
        // [แก้ไข] เอา Logic การไฮไลท์สีแถว Hot Sale ออก
        // =================================================================
        private void ProductGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= productGrid.Rows.Count) return;

            DataGridViewRow currentRow = productGrid.Rows[e.RowIndex];
            DataRowView drv = (DataRowView)currentRow.DataBoundItem;
            if (drv == null) return;

            // [ลบออก] การไฮไลท์แถว isHotSale
            currentRow.DefaultCellStyle.BackColor = productGrid.DefaultCellStyle.BackColor; // สีขาว

            string colName = productGrid.Columns[e.ColumnIndex].Name;

            if (colName == "image_path")
            {
                string imagePathFromDb = drv["image_path"]?.ToString();
                if (string.IsNullOrEmpty(imagePathFromDb)) { e.Value = null; return; }

                if (imageCache.ContainsKey(imagePathFromDb))
                {
                    e.Value = imageCache[imagePathFromDb];
                }
                else
                {
                    string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePathFromDb.Replace('/', Path.DirectorySeparatorChar));
                    if (File.Exists(fullPath))
                    {
                        try
                        {
                            byte[] imageBytes = File.ReadAllBytes(fullPath);
                            using (var stream = new MemoryStream(imageBytes))
                            {
                                Image img = Image.FromStream(stream);
                                imageCache[imagePathFromDb] = img;
                                e.Value = img;
                            }
                        }
                        catch (Exception) { e.Value = null; }
                    }
                    else { e.Value = null; }
                }
            }
            // [ลบออก] Logic ปุ่ม HotSaleToggleCol
            else if (colName == "stock_quantity")
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int stock))
                {
                    if (stock <= 5)
                    {
                        e.CellStyle.BackColor = Color.LightYellow;
                        e.CellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        e.CellStyle.BackColor = currentRow.DefaultCellStyle.BackColor;
                        e.CellStyle.ForeColor = Color.DarkGreen;
                    }
                }
            }
        }

        // =================================================================
        // [แก้ไข] เอา Logic การคลิกปุ่ม Hot Sale ออก
        // =================================================================
        private void ProductGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!(productGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)) return;

            DataRowView drv = (DataRowView)productGrid.Rows[e.RowIndex].DataBoundItem;
            int productId = Convert.ToInt32(drv["product_id"]);
            string imagePathFromDb = drv["image_path"]?.ToString();
            string colName = productGrid.Columns[e.ColumnIndex].Name;

            // [ลบออก] Logic ของ HotSaleToggleCol

            if (colName == "EditCol")
            {
                EditRequested?.Invoke(productId);
            }
            else if (colName == "DeleteCol")
            {
                if (MessageBox.Show($"ยืนยันการลบสินค้า ID: {productId}?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        Db.DeleteProduct(productId);
                        if (!string.IsNullOrEmpty(imagePathFromDb))
                        {
                            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePathFromDb.Replace('/', Path.DirectorySeparatorChar));
                            if (File.Exists(fullPath))
                            {
                                try { File.Delete(fullPath); } catch { }
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