using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whanjuay
{
    public partial class CartPage : Form
    {
        public CartPage()
        {
            InitializeComponent();
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
        }

        private void CartPage_Load(object sender, EventArgs e)
        {
            LoadCartItems();
        }

        public void LoadCartItems()
        {
            flowCartItems.Controls.Clear();
            List<CartItem> items = CartService.GetItems();

            if (items.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "ตะกร้าสินค้าของคุณว่างเปล่า";
                lblEmpty.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
                lblEmpty.ForeColor = Color.Gray;
                lblEmpty.AutoSize = true;
                lblEmpty.Margin = new Padding(10);
                flowCartItems.Controls.Add(lblEmpty);

                btnCheckout.Enabled = false;
                btnCheckout.FillColor = Color.Gainsboro;
            }
            else
            {
                foreach (CartItem item in items)
                {
                    CartItemControl itemControl = new CartItemControl();
                    itemControl.SetData(item);

                    itemControl.CartUpdated += OnCartUpdated;
                    flowCartItems.Controls.Add(itemControl);
                }

                btnCheckout.Enabled = true;
                btnCheckout.FillColor = Color.FromArgb(255, 128, 128);
            }
            UpdateSummary();
        }

        private void OnCartUpdated()
        {
            LoadCartItems();
        }

        /// <summary>
        /// [แก้ไข] อัปเดตการแสดงผลสรุปยอด
        /// </summary>
        private void UpdateSummary()
        {
            // ดึงค่าทั้ง 3 ค่าจาก CartService
            decimal subTotal = CartService.GetTotalPrice();
            decimal vatAmount = CartService.GetVatAmount();
            decimal grandTotal = CartService.GetGrandTotal();

            // อัปเดต Labels (ชื่อ Label ต้องตรงกับ .Designer.cs ที่แก้ไขไป)
            lblSubtotalValue.Text = $"{subTotal:N2} บาท";
            lblVatValue.Text = $"{vatAmount:N2} บาท";
            lblGrandTotalValue.Text = $"{grandTotal:N2} บาท";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            mainpagewj mainForm = Application.OpenForms.OfType<mainpagewj>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.Show();
            }
            this.Hide();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            // ปล่อยว่างไว้
        }

        /// <summary>
        /// [แก้ไข] ส่งยอด GrandTotal ไปยังหน้าชำระเงิน
        /// </summary>
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            // [แก้ไข] เปลี่ยนไปใช้ GetGrandTotal()
            decimal grandTotal = CartService.GetGrandTotal();

            if (grandTotal <= 0)
            {
                MessageBox.Show("ตะกร้าของคุณว่างเปล่า", "ไม่สามารถชำระเงิน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [แก้ไข] ส่ง grandTotal (ยอดรวมภาษี) ไป
            using (PaymentForm paymentForm = new PaymentForm(grandTotal))
            {
                DialogResult result = paymentForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    LoadCartItems();
                }
            }
        }
    }
}