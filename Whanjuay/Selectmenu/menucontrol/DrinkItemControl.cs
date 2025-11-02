using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Whanjuay
{
    public partial class DrinkItemControl : UserControl
    {
        private int _productId;
        private string _itemName;
        private decimal _basePrice;
        private string _imagePath;
        private string _categoryName;

        public string CategoryIconPath { get; set; }
        private Guna.UI2.WinForms.Guna2RadioButton _lastChecked = null;

        // [อัปเดต] ย้ายข้อความ Placeholder มาไว้ในโค้ด (แก้ปัญหาข้อ 1)
        private string placeholderText = "(เช่น หวานน้อย, หวานมาก, หวานปกติ และอื่นๆ)";

        public DrinkItemControl()
        {
            InitializeComponent();

            // [อัปเดต] ลบการผูก Event MouseClick ทั้งหมด
            // เราจะใช้ Event ที่ผูกไว้ใน Designer.cs (CheckedChanged และ MouseDown)
        }

        public void SetData(int productId, string name, decimal price, string imagePath, string categoryName)
        {
            _productId = productId;
            _itemName = name;
            _basePrice = price;
            _imagePath = imagePath;
            _categoryName = categoryName;

            lblName.Text = name;
            lblPrice.Text = $"({price:N2} บาท)";

            ResetSelections();
            LoadImage(imagePath);
        }

        public void ResetSelections()
        {
            rbIced.Checked = false;
            rbHot.Checked = false;
            rbFrappe.Checked = false;
            _lastChecked = null;

            // [อัปเดต] เรียกใช้ txtNote_Leave เพื่อตั้งค่า Placeholder (แก้ปัญหาข้อ 1)
            txtNote.Text = ""; // ล้างค่าจริงก่อน
            txtNote_Leave(null, null); // เรียก Event Leave เพื่อเซ็ต Placeholder

            UpdateFrappeButtonText();
        }

        private void LoadImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath)) return;
            try
            {
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath.Replace('/', Path.DirectorySeparatorChar));
                if (File.Exists(fullPath))
                {
                    byte[] imageBytes = File.ReadAllBytes(fullPath);
                    using (var stream = new MemoryStream(imageBytes))
                    {
                        pbImage.Image = Image.FromStream(stream);
                    }
                }
            }
            catch { pbImage.Image = null; }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            // [อัปเดต] เพิ่มการ Validation (แก้ปัญหาข้อ 2)
            if (!rbHot.Checked && !rbIced.Checked && !rbFrappe.Checked)
            {
                MessageBox.Show("กรุณาเลือกรูปแบบ (ร้อน, เย็น, หรือ ปั่น)", "ยังไม่ได้เลือก", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // หยุดการทำงาน
            }

            List<string> optionsList = new List<string>();
            decimal finalPrice = _basePrice;
            string optionTextForMessage = "";

            if (rbHot.Checked)
            {
                optionsList.Add("ร้อน");
                optionTextForMessage = " (ร้อน)";
            }
            else if (rbIced.Checked)
            {
                optionsList.Add("เย็น");
                optionTextForMessage = " (เย็น)";
            }
            else if (rbFrappe.Checked)
            {
                optionsList.Add("ปั่น (+10.00 บาท)");
                optionTextForMessage = " (ปั่น)";
                finalPrice += 10;
            }

            // [อัปเดต] ตรวจสอบว่า Text ไม่ใช่ Placeholder ก่อนเพิ่ม (แก้ปัญหาข้อ 1)
            string note = "";
            if (txtNote.Text != placeholderText && !string.IsNullOrWhiteSpace(txtNote.Text))
            {
                note = txtNote.Text.Trim();
                optionsList.Add(note);
            }

            string displayName = _itemName;

            CartItem drinkItem = new CartItem
            {
                DisplayName = displayName,
                TotalPrice = finalPrice,
                Quantity = 1,
                IsCustomCrepe = false,
                CategoryName = _categoryName,
                Ingredients = null,
                IconPath = this.CategoryIconPath,
                ProductImagePath = this._imagePath,
                Options = optionsList
            };

            CartService.AddItem(drinkItem);

            MessageBox.Show($"เพิ่ม '{displayName}{optionTextForMessage}' ราคา {finalPrice:N2} บาท ลงในตะกร้าแล้ว!", "เพิ่มสินค้าสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetSelections();
        }

        private void UpdateFrappeButtonText()
        {
            if (rbFrappe.Checked)
            {
                rbFrappe.Text = "ปั่น (+10.00 บาท)";
            }
            else
            {
                rbFrappe.Text = "ปั่น";
            }
        }

        private void rbOption_CheckedChanged(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2RadioButton checkedButton = (Guna.UI2.WinForms.Guna2RadioButton)sender;

            if (checkedButton.Checked)
            {
                _lastChecked = checkedButton;
            }

            UpdateFrappeButtonText();
        }

        private void rbOption_MouseDown(object sender, MouseEventArgs e)
        {
            Guna.UI2.WinForms.Guna2RadioButton clickedButton = (Guna.UI2.WinForms.Guna2RadioButton)sender;

            if (clickedButton == _lastChecked)
            {
                clickedButton.Checked = false;
                _lastChecked = null;
            }
        }

        // [เพิ่มใหม่] Event 2 อันนี้สำหรับจำลอง Placeholder (แก้ปัญหาข้อ 1)
        private void txtNote_Enter(object sender, EventArgs e)
        {
            // ถ้าข้อความคือ Placeholder
            if (txtNote.Text == placeholderText)
            {
                txtNote.Text = ""; // ล้างค่า
                txtNote.ForeColor = Color.Black; // เปลี่ยนเป็นสีพิมพ์
            }
        }

        private void txtNote_Leave(object sender, EventArgs e)
        {
            // ถ้าช่องว่างเปล่า
            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                txtNote.Text = placeholderText; // ใส่ Placeholder กลับ
                txtNote.ForeColor = Color.Gray; // เปลี่ยนเป็นสีจาง
            }
        }

        private void lblNoteExample_Click(object sender, EventArgs e)
        {

        }
    }
}