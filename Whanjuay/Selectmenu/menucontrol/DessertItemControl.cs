using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Whanjuay
{
    // นี่คือ User Control ใหม่สำหรับ "ของหวาน" (แบบง่าย)
    public partial class DessertItemControl : UserControl
    {
        private int _productId;
        private string _itemName;
        private decimal _basePrice;
        private string _imagePath;
        private string _categoryName;

        public string CategoryIconPath { get; set; }

        public DessertItemControl()
        {
            InitializeComponent();
        }

        public void SetData(int productId, string name, decimal price, string imagePath, string categoryName)
        {
            _productId = productId;
            _itemName = name;
            _basePrice = price;
            _imagePath = imagePath;
            _categoryName = categoryName;

            // ตั้งค่า UI
            lblName.Text = name;
            lblPrice.Text = $"({price:N2} บาท)";

            LoadImage(imagePath);
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

        // Event ที่ผูกไว้กับปุ่ม "เพิ่มลงตะกร้า"
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            CartItem dessertItem = new CartItem
            {
                DisplayName = _itemName,
                TotalPrice = _basePrice,
                Quantity = 1,
                IsCustomCrepe = false, // ไม่ใช่เครป
                CategoryName = _categoryName,
                Ingredients = null, // ไม่มีส่วนผสม
                Options = null,     // ไม่มีตัวเลือก
                IconPath = this.CategoryIconPath,
                ProductImagePath = this._imagePath
            };

            CartService.AddItem(dessertItem);

            MessageBox.Show($"เพิ่ม '{_itemName}' ราคา {_basePrice:N2} บาท ลงในตะกร้าแล้ว!", "เพิ่มสินค้าสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ไม่ต้อง Reset อะไร เพราะไม่มีตัวเลือก
        }
    }
}