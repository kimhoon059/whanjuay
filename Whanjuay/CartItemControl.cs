using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Whanjuay
{
    public delegate void CartUpdatedEventHandler();
    // [แก้] ลบ EditItemEventHandler

    public partial class CartItemControl : UserControl
    {
        public event CartUpdatedEventHandler CartUpdated;
        // [แก้] ลบ EditRequested
        private CartItem _item;

        public CartItemControl()
        {
            InitializeComponent();
        }

        public void SetData(CartItem item)
        {
            _item = item;

            lblName.Text = item.DisplayName;
            txtQuantity.Text = item.Quantity.ToString();

            UpdatePrice();

            if (item.IsCustomCrepe && item.Ingredients != null)
            {
                pnlIngredients.Visible = true;
                pnlIngredients.Controls.Clear();

                foreach (var ingredient in item.Ingredients)
                {
                    string extraText = "";
                    if (ingredient.IsExtra)
                    {
                        extraText = $" (เพิ่มพิเศษ +{ingredient.ExtraPrice:N2} บาท)";
                    }

                    Label lbl = new Label();
                    lbl.Text = $"• {ingredient.Name} (+{ingredient.BasePrice:N2} บาท){extraText}";
                    lbl.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                    lbl.ForeColor = Color.Gray;
                    lbl.AutoSize = true;
                    pnlIngredients.Controls.Add(lbl);
                }
            }
            else
            {
                pnlIngredients.Visible = false;
            }

            // [ใหม่] โหลดรูปภาพหมวดหมู่
            LoadCategoryImage(item.CategoryName);
        }

        // [ใหม่] ฟังก์ชันโหลดรูปภาพหมวดหมู่
        private void LoadCategoryImage(string categoryName)
        {
            try
            {
                // คุณต้องเพิ่มรูปภาพเหล่านี้ลงใน Resources ของโปรเจกต์ก่อน
                // และตั้งชื่อให้ตรงกับ CategoryName
                // เช่น "เครปร้อน.png", "เครื่องดื่ม.png"

                if (categoryName == "เครปร้อน")
                {
                    // (ตัวอย่าง) อ้างอิงจาก Resource ของคุณ
                    pbImage.Image = Properties.Resources.K_PRA__8_;
                }
                else if (categoryName == "เครปเย็น")
                {
                    // (ตัวอย่าง) (คุณต้องเพิ่มรูป icon เครปเย็น ลงใน Resources)
                    // pbImage.Image = Properties.Resources.Icon_ColdCrepe; 
                }
                else if (categoryName == "เครื่องดื่ม")
                {
                    // (ตัวอย่าง) (คุณต้องเพิ่มรูป icon เครื่องดื่ม ลงใน Resources)
                    // pbImage.Image = Properties.Resources.Icon_Drink;
                }
                else
                {
                    // รูปภาพเริ่มต้น (ถ้ามี)
                }
            }
            catch (Exception)
            {
                // ถ้าหารูปไม่เจอ ให้ปล่อยว่างไว้
                pbImage.Image = null;
            }
        }


        private void UpdatePrice()
        {
            lblPrice.Text = $"{(_item.TotalPrice * _item.Quantity):N2} บาท";
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            _item.Quantity++;
            txtQuantity.Text = _item.Quantity.ToString();
            UpdatePrice();
            CartUpdated?.Invoke();
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            if (_item.Quantity > 1)
            {
                _item.Quantity--;
                txtQuantity.Text = _item.Quantity.ToString();
                UpdatePrice();
                CartUpdated?.Invoke();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CartService.RemoveItem(_item.ItemId);
            CartUpdated?.Invoke();
        }

        // [แก้] ลบ btnEdit_Click

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtQuantity.Text, out int newQty) && newQty > 0)
            {
                if (_item != null && _item.Quantity != newQty)
                {
                    _item.Quantity = newQty;
                    UpdatePrice();
                    CartUpdated?.Invoke();
                }
            }
            else if (!string.IsNullOrEmpty(txtQuantity.Text) && _item != null)
            {
                txtQuantity.Text = _item.Quantity.ToString();
            }
        }
    }
}