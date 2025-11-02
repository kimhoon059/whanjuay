using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.IO;

namespace Whanjuay
{
    public delegate void ProductSavedEventHandler();

    public partial class ProductAddView : UserControl
    {
        public event ProductSavedEventHandler Saved;

        private string currentImagePath = null;
        private int _productId;
        private bool _isDataLoading = false;

        public ProductAddView(int productId = 0)
        {
            InitializeComponent();
            _productId = productId;
            this.Load += ProductAddView_Load;
            this.BackColor = System.Drawing.Color.Transparent;
        }

        private void ProductAddView_Load(object sender, EventArgs e)
        {
            _isDataLoading = true;

            InitializeAddProductUI();
            LoadMainCategories();

            if (_productId > 0)
            {
                lblTitle.Text = "แก้ไขสินค้า (ID: " + _productId + ")";
                btnSave.Text = "บันทึกการแก้ไข";
                LoadProductData(_productId);
            }
            else
            {
                lblTitle.Text = "เพิ่มสินค้าใหม่";
                btnSave.Text = "บันทึกสินค้า";
                _isDataLoading = false;
            }
        }

        // [แก้] ลบ Logic การโหลด txtDescription
        private void LoadProductData(int productId)
        {
            try
            {
                DataTable dt = Db.GetProductById(productId);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtName.Text = row["name"].ToString();
                    txtPrice.Text = Convert.ToDecimal(row["price"]).ToString();
                    txtStock.Text = Convert.ToInt32(row["stock_quantity"]).ToString();
                    // txtDescription.Text = row["description"]?.ToString() ?? string.Empty; // [แก้] ลบออก

                    cmbCategoriesMain.SelectedValue = row["category_id"];
                    LoadSubCategories(Convert.ToInt32(row["category_id"]));
                    cmbIngredientCategoriesSub.SelectedValue = row["ing_category_id"];

                    string imagePathFromDb = row["image_path"]?.ToString();
                    if (!string.IsNullOrEmpty(imagePathFromDb))
                    {
                        string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePathFromDb.Replace('/', Path.DirectorySeparatorChar));
                        if (File.Exists(fullPath))
                        {
                            using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                            {
                                pbImage.Image = Image.FromStream(stream);
                            }
                            currentImagePath = imagePathFromDb;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการโหลดข้อมูลสินค้า:\n{ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isDataLoading = false;
            }
        }


        private void InitializeAddProductUI()
        {
            txtName.BorderRadius = 10;
            cmbCategoriesMain.BorderRadius = 10;
            cmbIngredientCategoriesSub.BorderRadius = 10;
            txtPrice.BorderRadius = 10;
            txtStock.BorderRadius = 10;
            // txtDescription.BorderRadius = 10; // [แก้] ลบออก
            pnlImage.BorderRadius = 10;
            btnChangeImage.BorderRadius = 10;
            btnSave.BorderRadius = 10;
            btnBack.BorderRadius = 10;

            btnBack.Text = "ย้อนกลับ";

            if (pnlImage.Controls.Contains(btnChangeImage))
            {
                btnChangeImage.BringToFront();
            }

            cmbCategoriesMain.SelectedIndexChanged -= CmbCategoriesMain_SelectedIndexChanged;
            cmbCategoriesMain.SelectedIndexChanged += CmbCategoriesMain_SelectedIndexChanged;

            txtPrice.KeyPress -= TxtPrice_KeyPress;
            txtPrice.KeyPress += TxtPrice_KeyPress;

            txtStock.KeyPress -= TxtStock_KeyPress;
            txtStock.KeyPress += TxtStock_KeyPress;

            btnChangeImage.Click -= BtnChangeImage_Click;
            btnChangeImage.Click += BtnChangeImage_Click;

            btnSave.Click -= BtnSave_Click;
            btnSave.Click += BtnSave_Click;

            btnBack.Click -= BtnBack_Click;
            btnBack.Click += BtnBack_Click;
        }

        private void LoadMainCategories()
        {
            try
            {
                if (cmbCategoriesMain == null) throw new Exception("cmbCategoriesMain control not initialized.");

                DataTable dt = Db.GetCategories();

                DataRow dr = dt.NewRow();
                dr["name"] = "--- เลือกประเภทหลัก ---";
                dr["category_id"] = 0;
                dt.Rows.InsertAt(dr, 0);

                cmbCategoriesMain.DataSource = dt;
                cmbCategoriesMain.DisplayMember = "name";
                cmbCategoriesMain.ValueMember = "category_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbCategoriesMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isDataLoading)
            {
                if (cmbCategoriesMain.SelectedIndex > 0)
                {
                    int selectedMainCategoryId = Convert.ToInt32(cmbCategoriesMain.SelectedValue);
                    LoadSubCategories(selectedMainCategoryId);
                }
                else
                {
                    cmbIngredientCategoriesSub.DataSource = null;
                }
            }
        }

        private void LoadSubCategories(int mainCategoryId)
        {
            try
            {
                if (cmbIngredientCategoriesSub == null) throw new Exception("cmbIngredientCategoriesSub control not initialized.");

                DataTable dt = Db.GetIngredientCategories(mainCategoryId);

                if (dt.Rows.Count > 0)
                {
                    cmbIngredientCategoriesSub.DataSource = dt;
                    cmbIngredientCategoriesSub.DisplayMember = "name";
                    cmbIngredientCategoriesSub.ValueMember = "ing_category_id";
                }
                else
                {
                    cmbIngredientCategoriesSub.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sub-categories: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Saved?.Invoke();
        }

        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as Guna2TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void BtnChangeImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "เลือกรูปภาพสินค้า";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pbImage.Image?.Dispose();
                        using (var stream = new MemoryStream(File.ReadAllBytes(ofd.FileName)))
                        {
                            pbImage.Image = Image.FromStream(stream);
                        }
                        currentImagePath = ofd.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ไม่สามารถโหลดรูปภาพได้: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // [แก้] ลบ Logic ของ description ออกจากปุ่ม Save
        private void BtnSave_Click(object sender, EventArgs e)
        {
            decimal price;
            int stockQuantity;

            if (string.IsNullOrWhiteSpace(txtName.Text) || cmbIngredientCategoriesSub.SelectedValue == null || string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน: ชื่อสินค้า, ประเภท (ทั้ง 2 ช่อง), ราคา, และจำนวนสินค้า", "ข้อมูลไม่สมบูรณ์", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("รูปแบบราคาไม่ถูกต้อง", "ข้อมูลไม่สมบูรณ์", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStock.Text, out stockQuantity))
            {
                MessageBox.Show("จำนวนสินค้าต้องเป็นตัวเลขจำนวนเต็ม", "ข้อมูลไม่สมบูรณ์", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string finalImagePath = currentImagePath;

            try
            {
                string name = txtName.Text;
                int ingCategoryId = Convert.ToInt32(cmbIngredientCategoriesSub.SelectedValue);
                // string description = txtDescription.Text; // [แก้] ลบออก
                string status = (stockQuantity > 0) ? "มีสินค้า" : "หมด";

                // --- 1. จัดการการคัดลอกไฟล์รูปภาพ ---
                if (!string.IsNullOrEmpty(currentImagePath) && !currentImagePath.Contains("Images" + Path.DirectorySeparatorChar))
                {
                    string destFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                    if (!Directory.Exists(destFolder))
                    {
                        Directory.CreateDirectory(destFolder);
                    }

                    string extension = Path.GetExtension(currentImagePath);
                    string fileName = Guid.NewGuid().ToString() + extension;
                    string destPath = Path.Combine(destFolder, fileName);

                    File.Copy(currentImagePath, destPath, true);
                    finalImagePath = $"Images/{fileName}";
                }

                // --- 2. บันทึก/แก้ไขข้อมูลลงฐานข้อมูล ---
                if (_productId > 0)
                {
                    Db.UpdateProduct(_productId, name, ingCategoryId, price, status, finalImagePath, stockQuantity); // [แก้]
                    MessageBox.Show($"บันทึกการแก้ไขสินค้า ID: {_productId} เรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int newId = Db.InsertProduct(name, ingCategoryId, price, status, finalImagePath, stockQuantity); // [แก้]
                    MessageBox.Show($"บันทึกสินค้าใหม่เรียบร้อยแล้ว (ID: {newId})", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Saved?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving product: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // [แก้] ลบฟังก์ชันว่างของ txtDescription_TextChanged
        private void txtPrice_TextChanged(object sender, EventArgs e) { /* Do Nothing */ }
        private void txtStock_TextChanged(object sender, EventArgs e) { /* Do Nothing */ }
        private void btnSave_Click_1(object sender, EventArgs e) { /* Do Nothing */ }
        private void btnChangeImage_Click_1(object sender, EventArgs e) { /* Do Nothing */ }
        private void btnBack_Click_1(object sender, EventArgs e) { /* Do Nothing */ }
        private void lblStock_Click(object sender, EventArgs e) { /* Do Nothing */ }
        // private void txtDescription_TextChanged(object sender, EventArgs e) { /* Do Nothing */ } // [แก้] ลบออก
    }
}