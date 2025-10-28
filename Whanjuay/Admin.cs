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

            // ********** ต้องแน่ใจว่าได้แก้ไข Admin.Designer.cs เป็น protected แล้ว **********
            contentHost = this.guna2CustomGradientPanel1;

            if (contentHost == null)
            {
                // หากโค้ดมาถึงตรงนี้ แสดงว่า Admin.Designer.cs ยังไม่ถูกแก้ไข
                MessageBox.Show("Configuration Error: พื้นที่แสดงผลหลัก (guna2CustomGradientPanel1) ไม่ถูกนิยามใน Designer.cs", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ********** ลบโค้ดป้ายต้อนรับทิ้งแล้ว **********

            // ********** ลบ WireProductButton ออก เพื่อให้พื้นที่ว่างเปล่าเมื่อเปิด **********
            // เราจะใช้ Event ของ Designer แทนการผูกเอง
            // WireProductButton(); // ลบการเรียกเมธอดนี้

            // ShowProductList(); // คอมเมนต์ไว้เพื่อให้พื้นที่ว่างเปล่าตอนเปิดโปรแกรม
        }

        // ********** ลบเมธอด WireProductButton() และ AllChildren() ทิ้งทั้งหมด **********
        // (เราจะใช้ Designer Event แทน)

        // ====== สลับหน้า ======

        // ********** ลบเมธอด BtnProduct_Click ทิ้ง **********

        private void ShowProductList()
        {
            var list = new ProductListView();
            list.AddRequested += ShowAddProduct;
            ShowView(list);
        }

        private void ShowAddProduct()
        {
            var add = new ProductAddView();
            // เมื่อกดปุ่มย้อนกลับ/บันทึก จะกลับมาหน้า List
            add.Saved += ShowProductList;
            ShowView(add);
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

        // ====== อีเวนต์ที่ถูกสร้างโดย Designer (ใช้ Event นี้แทน BtnProduct_Click) ======
        // Event นี้ถูกผูกกับปุ่ม PRODUCT ใน Designer.cs
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            ShowProductList(); // ********** ให้เรียก ShowProductList() ตรงนี้ **********
        }

        // ... (อีเวนต์อื่นๆ ที่ไม่เกี่ยวปล่อยว่างไว้) ...
        private void guna2Button1_Click(object sender, EventArgs e) { }
        private void guna2Button2_Click(object sender, EventArgs e) { }
        private void guna2Button3_Click(object sender, EventArgs e) { }
        private void guna2Button4_Click(object sender, EventArgs e) { }
        private void guna2Button5_Click(object sender, EventArgs e) { }
        private void guna2Button6_Click(object sender, EventArgs e) { }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void MENU_Click(object sender, EventArgs e) { }
        private void guna2Button3_Click_1(object sender, EventArgs e) { } // สำหรับ DASHBOARD
        private void guna2CustomGradientPanel1_Paint(object sender, EventArgs e) { }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}