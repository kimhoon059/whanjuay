using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Whanjuay
{
    public partial class Admin : Form
    {
        // ====== พื้นที่ฝั่งขวา + state ======
        private Guna2CustomGradientPanel contentHost;
        private Control currentView;

        public Admin()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Text = "Admin Dashboard";

            contentHost = this.guna2CustomGradientPanel1;

            if (contentHost == null)
            {
                MessageBox.Show("Configuration Error: พื้นที่แสดงผลหลัก (guna2CustomGradientPanel1) ไม่ถูกนิยามใน Designer.cs", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // [เพิ่มใหม่] สั่งให้เปิดหน้า Dashboard เป็นหน้าแรก
            ShowDashboard();
        }

        // ====== สลับหน้า ======

        // [เพิ่มใหม่] เมธอดสำหรับเรียกหน้า Dashboard
        private void ShowDashboard()
        {
            var dashboard = new DashboardView();
            ShowView(dashboard);
        }

        private void ShowProductList()
        {
            var list = new ProductListView();
            list.AddRequested += ShowAddProduct;
            list.EditRequested += ShowEditProduct;
            ShowView(list);
        }

        private void ShowAddProduct()
        {
            // ใช้ 0 เป็นค่าเริ่มต้นสำหรับการเพิ่มสินค้าใหม่
            var add = new ProductAddView(0);
            add.Saved += ShowProductList;
            ShowView(add);
        }

        // เมธอดสำหรับแก้ไขสินค้า
        private void ShowEditProduct(int productId)
        {
            // ใช้ productId เพื่อระบุว่าเป็นการแก้ไข
            var edit = new ProductAddView(productId);
            edit.Saved += ShowProductList;
            ShowView(edit);
        }


        private void ShowView(Control view)
        {
            if (contentHost == null) return;

            if (currentView != null)
            {
                contentHost.Controls.Remove(currentView);
                currentView.Dispose();
                currentView = null;
            }

            view.Dock = DockStyle.Fill;
            contentHost.Controls.Clear();
            contentHost.Controls.Add(view);
            currentView = view;
        }

        // Event นี้ถูกผูกกับปุ่ม PRODUCT ใน Designer.cs
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            ShowProductList();
        }

        // [แก้ไข] Event นี้ถูกผูกกับปุ่ม DASHBOARD
        private void guna2Button3_Click_1(object sender, EventArgs e) // สำหรับ DASHBOARD
        {
            ShowDashboard(); // <--- แก้ไขจากเดิมที่ว่างเปล่า
        }


        // ... (อีเวนต์อื่นๆ ที่ไม่เกี่ยวปล่อยว่างไว้) ...
        private void guna2Button1_Click(object sender, EventArgs e) { }
        private void guna2Button2_Click(object sender, EventArgs e) { }
        private void guna2Button3_Click(object sender, EventArgs e) { }
        private void guna2Button4_Click(object sender, EventArgs e) { }
        private void guna2Button5_Click(object sender, EventArgs e) { }
        private void guna2Button6_Click(object sender, EventArgs e) { } // (ปุ่ม LOGOUT)
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void MENU_Click(object sender, EventArgs e) { }
        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e) { }

        // [แก้ไข] ลบ Event ที่ซ้ำซ้อนออก (ถ้ามี)
        // private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        // {
        // 
        // }
    }
}