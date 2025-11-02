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

            // --- [เพิ่มใหม่] ---
            // ผูก Event ให้ปุ่มชำระเงิน
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // --- [สิ้นสุด] ---
        }

        private void CartPage_Load(object sender, EventArgs e)
        {
            LoadCartItems();
        }

        // [อัปเดต] เปลี่ยนจาก private เป็น public
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

                // [เพิ่มใหม่] ถ้าตะกร้าว่าง ให้ปิดปุ่มชำระเงิน
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

                // [เพิ่มใหม่] ถ้ามีของ ให้เปิดปุ่มชำระเงิน
                btnCheckout.Enabled = true;
                btnCheckout.FillColor = Color.FromArgb(255, 128, 128);
            }
            UpdateSummary();
        }

        private void OnCartUpdated()
        {
            LoadCartItems();
        }

        private void UpdateSummary()
        {
            decimal total = CartService.GetTotalPrice();
            lblTotal.Text = $"{total:N2} บาท";
        }

        // [อัปเดต] แก้ไขปุ่ม Back ให้ซ่อน (Hide) แทนการปิด (Close)
        private void btnBack_Click(object sender, EventArgs e)
        {
            mainpagewj mainForm = Application.OpenForms.OfType<mainpagewj>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.Show();
            }
            this.Hide();
        }

        // [แก้ไข Error CS1061] เพิ่มเมธอดที่ Designer อ้างถึงกลับเข้ามา
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            // ปล่อยว่างไว้
        }

        // --- [เพิ่มใหม่] ---
        // Event Handler สำหรับปุ่มชำระเงิน
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            decimal total = CartService.GetTotalPrice();

            // ตรวจสอบอีกครั้งว่ามีของในตะกร้า
            if (total <= 0)
            {
                MessageBox.Show("ตะกร้าของคุณว่างเปล่า", "ไม่สามารถชำระเงิน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // เปิดฟอร์มชำระเงินแบบ Pop-up (Modal)
            // โดยส่งยอดรวม (total) เข้าไป
            using (PaymentForm paymentForm = new PaymentForm(total))
            {
                // .ShowDialog() จะหยุดโค้ดไว้จนกว่าหน้า PaymentForm จะถูกปิด
                DialogResult result = paymentForm.ShowDialog(this);

                // ตรวจสอบว่าการชำระเงินสำเร็จหรือไม่
                if (result == DialogResult.OK)
                {
                    // ถ้าสำเร็จ (ผู้ใช้กดยืนยันและสลิปถูกอัปโหลด)
                    // CartService.ClearCart() จะถูกเรียกใน PaymentForm แล้ว

                    // ให้โหลดตะกร้าใหม่ (ซึ่งตอนนี้จะว่างเปล่า)
                    LoadCartItems();
                }
            }
        }
        // --- [สิ้นสุด] ---
    }
}