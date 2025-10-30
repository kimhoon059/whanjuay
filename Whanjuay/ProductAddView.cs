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

        // currentImagePath: เก็บ path ของรูปภาพที่ถูกโหลด/เลือก: 
        // 1. Full Path จาก OpenFileDialog (ก่อนบันทึก)
        // 2. Relative Path (Images/...) จากฐานข้อมูล (เมื่อโหลดเพื่อแก้ไข)
        private string currentImagePath = null;
        private int _productId;

        public ProductAddView(int productId = 0)
        {
            InitializeComponent();
            _productId = productId;
            this.Load += ProductAddView_Load;
            this.BackColor = System.Drawing.Color.Transparent;
        }

        private void ProductAddView_Load(object sender, EventArgs e)
        {
            InitializeAddProductUI();
            LoadCategories();

            if (_productId > 0)
            {
                lblTitle.Text = "แก้ไขสินค้า (ID: " + _productId + ")";
                btnSave.Text = "บันทึกการแก้ไข";
                LoadProductData(_productId); // เรียกเมธอดโหลดข้อมูล
            }
            else
            {
                lblTitle.Text = "เพิ่มสินค้าใหม่";
                btnSave.Text = "บันทึกสินค้า";
            }
        }

        // เมธอดสำหรับโหลดข้อมูลสินค้า (Item 5)
        private void LoadProductData(int productId)
        {
            try
            {
                DataTable dt = Db.GetProductById(productId);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtName.Text = row["name"].ToString();

                    // ตั้งค่า ComboBox (ต้องแน่ใจว่า LoadCategories() ทำงานเสร็จก่อน)
                    cmbCategory.SelectedValue = row["category_id"];

                    // แสดงราคาและ Stock 
                    txtPrice.Text = Convert.ToDecimal(row["price"]).ToString();
                    txtStock.Text = Convert.ToInt32(row["stock_quantity"]).ToString();

                    txtDescription.Text = row["description"]?.ToString() ?? string.Empty;

                    // โหลดรูปภาพ
                    string imagePathFromDb = row["image_path"]?.ToString();
                    if (!string.IsNullOrEmpty(imagePathFromDb))
                    {
                        // Path.Combine จะจัดการเรื่องเครื่องหมาย / และ \ ให้ถูกต้อง
                        string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePathFromDb.Replace('/', Path.DirectorySeparatorChar));
                        if (File.Exists(fullPath))
                        {
                            // ใช้ FileStream เพื่อป้องกันการล็อคไฟล์
                            using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                            {
                                pbImage.Image = Image.FromStream(stream);
                            }
                            // เก็บ path เดิม (Images/...) เพื่อส่งกลับไป DB หากไม่ได้เปลี่ยนรูป
                            currentImagePath = imagePathFromDb;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการโหลดข้อมูลสินค้า:\n{ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void InitializeAddProductUI()
        {
            // 1. ตั้งค่า BorderRadius (ความมนของขอบ)
            txtName.BorderRadius = 10;
            cmbCategory.BorderRadius = 10;
            txtPrice.BorderRadius = 10;
            txtStock.BorderRadius = 10;
            txtDescription.BorderRadius = 10;
            pnlImage.BorderRadius = 10;
            btnChangeImage.BorderRadius = 10;
            btnSave.BorderRadius = 10;
            btnBack.BorderRadius = 10;

            // 3. ปรับ Style 
            btnBack.Text = "ย้อนกลับ";

            // สั่งให้ปุ่มเปลี่ยนรูปภาพอยู่ด้านหน้าเสมอ
            if (pnlImage.Controls.Contains(btnChangeImage))
            {
                btnChangeImage.BringToFront();
            }

            // 2. ผูก Event Handler
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

        private void LoadCategories()
        {
            try
            {
                if (cmbCategory == null) throw new Exception("cmbCategory control not initialized.");

                DataTable dt = Db.GetCategories();
                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "name";
                cmbCategory.ValueMember = "category_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        // ปลดล็อคไฟล์เดิมก่อนเปลี่ยนรูปภาพ
                        pbImage.Image?.Dispose();

                        // อ่านเป็น MemoryStream เพื่อปลดล็อคไฟล์ต้นฉบับทันที
                        using (var stream = new MemoryStream(File.ReadAllBytes(ofd.FileName)))
                        {
                            pbImage.Image = Image.FromStream(stream);
                        }
                        // เก็บ Full Path ของไฟล์ต้นฉบับ
                        currentImagePath = ofd.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ไม่สามารถโหลดรูปภาพได้: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || cmbCategory.SelectedValue == null || string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน: ชื่อสินค้า, หมวดหมู่, ราคา, และจำนวนสินค้า", "ข้อมูลไม่สมบูรณ์", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("รูปแบบราคาไม่ถูกต้อง", "ข้อมูลไม่สมบูรณ์", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stockQuantity))
            {
                MessageBox.Show("จำนวนสินค้าต้องเป็นตัวเลขจำนวนเต็ม", "ข้อมูลไม่สมบูรณ์", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string finalImagePath = currentImagePath;

            try
            {
                string name = txtName.Text;
                int categoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                string description = txtDescription.Text;
                string status = (stockQuantity > 0) ? "มีสินค้า" : "หมด";

                // --- 1. จัดการการคัดลอกไฟล์รูปภาพ (ถ้ามีการเลือกรูปใหม่) ---
                // ตรวจสอบว่าเป็น Full Path (จาก OFD) หรือไม่
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

                    // คัดลอก
                    File.Copy(currentImagePath, destPath, true);

                    finalImagePath = $"Images/{fileName}";
                }

                // --- 2. บันทึก/แก้ไขข้อมูลลงฐานข้อมูล ---
                if (_productId > 0)
                {
                    // Update
                    Db.UpdateProduct(_productId, name, categoryId, price, status, description, finalImagePath, stockQuantity);
                    MessageBox.Show($"บันทึกการแก้ไขสินค้า ID: {_productId} เรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Insert
                    int newId = Db.InsertProduct(name, categoryId, price, status, description, finalImagePath, stockQuantity);
                    MessageBox.Show($"บันทึกสินค้าใหม่เรียบร้อยแล้ว (ID: {newId})", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Saved?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving product: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ********** Event Handler ว่างเปล่าที่ Designer.cs อ้างถึง (ต้องมีเพื่อแก้ Error) **********

        private void txtPrice_TextChanged(object sender, EventArgs e) { /* Do Nothing */ }
        private void txtStock_TextChanged(object sender, EventArgs e) { /* Do Nothing */ }
        private void btnSave_Click_1(object sender, EventArgs e) { /* Do Nothing */ }
        private void btnChangeImage_Click_1(object sender, EventArgs e) { /* Do Nothing */ }
        private void btnBack_Click_1(object sender, EventArgs e) { /* Do Nothing */ }
        private void lblStock_Click(object sender, EventArgs e) { /* Do Nothing */ }
        private void txtDescription_TextChanged(object sender, EventArgs e) { /* Do Nothing */ }
    }
}