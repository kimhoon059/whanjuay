using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Whanjuay
{
    public delegate void CartUpdatedEventHandler();

    public partial class CartItemControl : UserControl
    {
        public event CartUpdatedEventHandler CartUpdated;
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

            pnlIngredients.Controls.Clear();
            bool hasSubItems = false;

            if (item.IsCustomCrepe && item.Ingredients != null && item.Ingredients.Count > 0)
            {
                foreach (var ingredient in item.Ingredients)
                {
                    string extraText = ingredient.IsExtra ? $" (เพิ่มพิเศษ +{ingredient.ExtraPrice:N2} บาท)" : "";
                    Label lbl = new Label
                    {
                        Text = $"• {ingredient.Name} (+{ingredient.BasePrice:N2} บาท){extraText}",
                        Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                        ForeColor = Color.Gray,
                        AutoSize = true
                    };
                    pnlIngredients.Controls.Add(lbl);
                }
                hasSubItems = true;
            }
            else if (!item.IsCustomCrepe && item.Options != null && item.Options.Count > 0)
            {
                foreach (var option in item.Options)
                {
                    Label lbl = new Label
                    {
                        Text = $"• {option}",
                        Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                        ForeColor = Color.Gray,
                        AutoSize = true
                    };
                    pnlIngredients.Controls.Add(lbl);
                }
                hasSubItems = true;
            }

            pnlIngredients.Visible = hasSubItems;

            pnlIngredients.PerformLayout();

            int newYPosition = pnlIngredients.Bottom + 10;
            if (!pnlIngredients.Visible)
            {
                newYPosition = pnlIngredients.Top + 10;
            }

            btnDecrease.Top = newYPosition;
            txtQuantity.Top = newYPosition;
            btnIncrease.Top = newYPosition;
            btnDelete.Top = newYPosition;

            int requiredHeight = newYPosition + btnDelete.Height + 15;
            if (requiredHeight < this.MinimumSize.Height)
            {
                requiredHeight = this.MinimumSize.Height;
            }
            this.Height = requiredHeight;
            this.pnlBackground.Height = requiredHeight;

            // [อัปเดต] เรียกใช้ Logic ใหม่ในการโหลดรูป
            LoadCorrectImage(item);
        }

        // [อัปเดต] เปลี่ยนชื่อเมธอด
        private void LoadCorrectImage(CartItem item)
        {
            string pathToLoad = null;

            // 1. ตรวจสอบว่ามี "รูปสินค้าจริง" หรือไม่ (เช่น รูปโกโก้)
            if (!string.IsNullOrEmpty(item.ProductImagePath)) // <--- นี่คือบรรทัดที่เคย Error
            {
                pathToLoad = item.ProductImagePath; // <--- นี่คือบรรทัดที่เคย Error
            }
            // 2. ถ้าไม่มี ให้ใช้ "ไอคอนหมวดหมู่" (เช่น รูปเครป, รูป Drinks)
            else if (!string.IsNullOrEmpty(item.IconPath))
            {
                pathToLoad = item.IconPath;
            }

            // 3. โหลดรูปจาก Path ที่เลือก
            if (string.IsNullOrEmpty(pathToLoad))
            {
                pbImage.Image = null;
                return;
            }

            try
            {
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathToLoad.Replace('/', Path.DirectorySeparatorChar));
                if (File.Exists(fullPath))
                {
                    byte[] imageBytes = File.ReadAllBytes(fullPath);
                    using (var stream = new MemoryStream(imageBytes))
                    {
                        pbImage.Image = Image.FromStream(stream);
                    }
                }
                else
                {
                    pbImage.Image = null;
                }
            }
            catch (Exception)
            {
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