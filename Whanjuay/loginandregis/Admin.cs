using System;
using System.Drawing;
using System.Linq; // [เพิ่มใหม่] เพื่อใช้ .OfType<Loginpage>()
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Whanjuay
{
    public partial class Admin : Form
    {
        // ====== พื้นที่ฝั่งขวา + state ======
        private Guna.UI2.WinForms.Guna2CustomGradientPanel contentHost;
        private Control currentView;

        public Admin()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Text = "Admin Dashboard";

            // 1. ดึง Panel หลักมาจาก Designer
            contentHost = this.guna2CustomGradientPanel1;

            if (contentHost == null)
            {
                MessageBox.Show("Configuration Error: พื้นที่แสดงผลหลัก (guna2CustomGradientPanel1) ไม่ถูกนิยามใน Designer.cs", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. ผูก Event ปุ่มในเมนูซ้าย
            // (ปุ่ม DASHBOARD, PRODUCT, LOGOUTad ถูกผูกไว้ใน Designer แล้ว)

            // [เพิ่มใหม่] ผูกปุ่ม ORER (เนื่องจากใน Designer ยังไม่ได้ผูก)
            this.ORER.Click -= ORER_Click; // กันการผูกซ้ำ
            this.ORER.Click += ORER_Click;

            // 3. สั่งให้เปิดหน้า Dashboard เป็นหน้าแรก
            ShowDashboard();
        }

        #region View Switching Logic (การสลับหน้า)

        /// <summary>
        /// เมธอดหลักสำหรับสลับ UserControl ใน Panel ด้านขวา
        /// </summary>
        private void ShowView(Control view)
        {
            if (contentHost == null) return;

            // ลบ Control เก่า (ถ้ามี)
            if (currentView != null)
            {
                contentHost.Controls.Remove(currentView);
                currentView.Dispose();
                currentView = null;
            }

            // เพิ่ม Control ใหม่
            view.Dock = DockStyle.Fill;
            contentHost.Controls.Clear();
            contentHost.Controls.Add(view);
            currentView = view;
        }

        /// <summary>
        /// 1. แสดงหน้า Dashboard (และเชื่อม Event ปุ่ม Report)
        /// </summary>
        private void ShowDashboard()
        {
            var dashboard = new DashboardView();

            // [สำคัญ] เชื่อม Event ที่มาจาก DashboardView
            // เมื่อปุ่ม "ดู Report" ใน Dashboard ถูกกด ให้เรียกเมธอด ShowReportView()
            dashboard.ReportRequested += (s, e) => ShowReportView();

            ShowView(dashboard);
        }

        /// <summary>
        /// 2. แสดงหน้า Product List (และเชื่อม Event เพิ่ม/แก้ไข)
        /// </summary>
        private void ShowProductList()
        {
            var list = new ProductListView();
            list.AddRequested += ShowAddProduct; // เชื่อม Event "เพิ่มสินค้า"
            list.EditRequested += ShowEditProduct; // เชื่อม Event "แก้ไขสินค้า"
            ShowView(list);
        }

        // (เมธอดลูกของ Product)
        private void ShowAddProduct()
        {
            var add = new ProductAddView(0); // 0 = เพิ่มใหม่
            add.Saved += ShowProductList; // เมื่อบันทึกเสร็จ ให้กลับไปหน้า List
            ShowView(add);
        }

        // (เมธอดลูกของ Product)
        private void ShowEditProduct(int productId)
        {
            var edit = new ProductAddView(productId); // ส่ง ID ไปแก้ไข
            edit.Saved += ShowProductList; // เมื่อบันทึกเสร็จ ให้กลับไปหน้า List
            ShowView(edit);
        }

        /// <summary>
        /// 3. แสดงหน้า Order (Pending)
        /// </summary>
        private void ShowOrderView()
        {
            var orderView = new Orderview();
            ShowView(orderView);
        }

        /// <summary>
        /// 4. แสดงหน้า Report (Completed)
        /// </summary>
        private void ShowReportView()
        {
            // นี่คือ UserControl ที่เราเพิ่งสร้างเสร็จ
            var reportView = new ReportView();
            ShowView(reportView);
        }

        #endregion

        #region Click Handlers (การกดปุ่มเมนูซ้าย)

        // --- 1. Event Handler สำหรับปุ่ม PRODUCT ---
        // (ชื่อเมธอดนี้มาจาก Admin.Designer.cs)
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            ShowProductList();
        }

        // --- 2. Event Handler สำหรับปุ่ม DASHBOARD ---
        // (ชื่อเมธอดนี้มาจาก Admin.Designer.cs)
        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        // --- 3. Event Handler สำหรับปุ่ม ORER ---
        // (เมธอดนี้เราผูกเองใน OnLoad)
        private void ORER_Click(object sender, EventArgs e)
        {
            ShowOrderView();
        }

        // --- 4. Event Handler สำหรับปุ่ม LOGOUTad ---
        // (ชื่อเมธอดนี้มาจาก Admin.Designer.cs)
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            // ถามยืนยัน
            if (MessageBox.Show("คุณต้องการออกจากระบบใช่หรือไม่?", "ยืนยันการออกจากระบบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // ค้นหาหน้า Login ที่เปิดอยู่ (ซึ่งอาจจะถูก Hide ไว้)
                var loginForm = Application.OpenForms.OfType<Loginpage>().FirstOrDefault();

                if (loginForm != null)
                {
                    // ถ้าเจอ ให้แสดงหน้านั้นกลับขึ้นมา
                    loginForm.Show();
                }
                else
                {
                    // ถ้าไม่เจอ (อาจจะปิดไปแล้ว) ให้สร้างใหม่
                    loginForm = new Loginpage();
                    loginForm.StartPosition = FormStartPosition.CenterScreen;
                    loginForm.Show();
                }

                // ปิดหน้า Admin ปัจจุบัน
                this.Close();
            }
        }

        #endregion

        // ... (อีเวนต์ว่างอื่นๆ ที่ Designer สร้างไว้ ห้ามลบ) ...
        private void guna2Button1_Click(object sender, EventArgs e) { }
        private void guna2Button2_Click(object sender, EventArgs e) { }
        private void guna2Button3_Click(object sender, EventArgs e) { }
        private void guna2Button4_Click(object sender, EventArgs e) { }
        private void guna2Button5_Click(object sender, EventArgs e) { }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void MENU_Click(object sender, EventArgs e) { }
        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}