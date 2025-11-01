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
        }

        private void CartPage_Load(object sender, EventArgs e)
        {
            LoadCartItems();
        }

        private void LoadCartItems()
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
            }
            else
            {
                foreach (CartItem item in items)
                {
                    CartItemControl itemControl = new CartItemControl();
                    itemControl.SetData(item);

                    itemControl.CartUpdated += OnCartUpdated;
                    // [แก้] ลบการผูก Event แก้ไข

                    flowCartItems.Controls.Add(itemControl);
                }
            }
            UpdateSummary();
        }

        // [แก้] ลบฟังก์ชัน OnItemEditRequested

        private void OnCartUpdated()
        {
            LoadCartItems();
        }

        private void UpdateSummary()
        {
            decimal total = CartService.GetTotalPrice();
            lblTotal.Text = $"{total:N2} บาท";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            mainpagewj mainForm = Application.OpenForms.OfType<mainpagewj>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.Show();
            }
            this.Close();
        }
    }
}