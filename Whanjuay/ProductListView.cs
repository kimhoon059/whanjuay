using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.IO;

namespace Whanjuay
{
    public delegate void AddProductEventHandler();

    public partial class ProductListView : UserControl
    {
        public event AddProductEventHandler AddRequested;

        // ********** FIX: ลบการประกาศ private fields ที่ซ้ำซ้อนออกทั้งหมด **********
        // (productGrid, btnAddProduct, ImageBaseDir)
        // Note: ImageBaseDir ถูกย้ายไปเป็น local field หรือต้องถูกประกาศในส่วนอื่นหากจำเป็น

        // เราจะกำหนดค่า ImageBaseDir ในเมธอดแทน
        private const string ImageBaseDir = "Images"; // กำหนดเป็นค่าคงที่

        public ProductListView()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.Transparent;
            this.Load += ProductListView_Load_Logic;
        }

        private void ProductListView_Load_Logic(object sender, EventArgs e)
        {
            // ตรวจสอบความพร้อมของ DataGrid ก่อนเรียกใช้ (ป้องกัน Error ใน Designer)
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
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                SelectionBackColor = Color.Transparent,
                SelectionForeColor = Color.SaddleBrown,
                WrapMode = DataGridViewTriState.True
            };

            // กำหนดความมนของขอบปุ่ม
            btnAddProduct.BorderRadius = 10;

            // ผูก Event Clicks
            productGrid.CellContentClick -= ProductGrid_CellContentClick;
            productGrid.CellContentClick += ProductGrid_CellContentClick;
            productGrid.CellFormatting -= ProductGrid_CellFormatting;
            productGrid.CellFormatting += ProductGrid_CellFormatting;
            btnAddProduct.Click -= BtnAddProduct_Click;
            btnAddProduct.Click += BtnAddProduct_Click;

            ConfigureGridColumns();
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

            // 1. คอลัมน์รูปภาพ
            productGrid.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = "รูปภาพ",
                Name = "image_path",
                DataPropertyName = "image_path",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 80
            });

            // 2. คอลัมน์ HOT SALE (ปุ่ม Toggle)
            productGrid.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "HOT SALE",
                Name = "HotSaleToggleCol",
                DataPropertyName = "is_hot_sale",
                UseColumnTextForButtonValue = false,
                Width = 120
            });

            // 3. ชื่อสินค้า
            AddTextColumn("name", "ชื่อสินค้า", 200);

            // 4. หมวดหมู่
            AddTextColumn("category_name", "หมวดหมู่", 120);

            // 5. ราคา
            AddTextColumn("price", "ราคา (บาท)", 100, DataGridViewContentAlignment.MiddleRight);
            productGrid.Columns["price"].DefaultCellStyle.Format = "N2";

            // 6. คอลัมน์ ACTIONS (Edit/Delete)
            productGrid.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = "แก้ไข/ลบ",
                Name = "ActionsCol",
                Image = null,
                Width = 100
            });

            // ซ่อนคอลัมน์ที่ไม่จำเป็น
            AddTextColumn("is_hot_sale", "IsHotSale", 0);
            productGrid.Columns["is_hot_sale"].Visible = false;
            AddTextColumn("status", "Status", 0);
            productGrid.Columns["status"].Visible = false;
            AddTextColumn("product_id", "ID", 0);
            productGrid.Columns["product_id"].Visible = false;
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
                    string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", imagePathFromDb);

                    if (File.Exists(fullPath))
                    {
                        try
                        {
                            e.Value = Image.FromFile(fullPath);
                        }
                        catch (Exception) { e.Value = null; }
                    }
                    else { e.Value = null; }
                }
            }

            // 2. จัดการคอลัมน์ HOT SALE (แสดงสถานะ)
            if (productGrid.Columns[e.ColumnIndex].Name == "HotSaleToggleCol")
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
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.FormattingApplied = true;
            }
        }

        private void ProductGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int productId = Convert.ToInt32(productGrid.Rows[e.RowIndex].Cells["product_id"].Value);

            // 1. Logic สำหรับ Hot Sale Toggle
            if (productGrid.Columns[e.ColumnIndex].Name == "HotSaleToggleCol")
            {
                bool currentStatus = Convert.ToBoolean(productGrid.Rows[e.RowIndex].Cells["is_hot_sale"].Value);
                bool newStatus = !currentStatus; // สลับสถานะ

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
            // 2. Logic สำหรับ Edit/Delete 
            else if (productGrid.Columns[e.ColumnIndex].Name == "ActionsCol")
            {
                // Logic การแก้ไข/ลบ
            }
        }


        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            AddRequested?.Invoke();
        }
    }
}