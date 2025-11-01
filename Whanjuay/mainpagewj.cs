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
    public partial class mainpagewj : Form
    {
        // [อัปเดต] สร้างตัวแปรสำหรับเก็บฟอร์มเมนูต่างๆ
        private HotCrepeMenu hotCrepeForm;
        private ColdCrepeMenu coldCrepeForm;
        private DessertsMenu dessertsForm;
        private DrinksMenu drinksForm;
        private CartPage cartForm;

        public mainpagewj()
        {
            InitializeComponent();

            // 1. ปุ่มเมนู 4 ปุ่ม
            this.HotcrepeButton.Click -= HotcrepeButton_Click;
            this.HotcrepeButton.Click += HotcrepeButton_Click;

            this.coldcrepeButton.Click -= coldcrepeButton_Click;
            this.coldcrepeButton.Click += coldcrepeButton_Click;

            this.DessertsButton.Click -= DessertsButton_Click;
            this.DessertsButton.Click += DessertsButton_Click;

            this.DrinksButton.Click -= DrinksButton_Click;
            this.DrinksButton.Click += DrinksButton_Click;

            // 2. ปุ่ม CART (CartmainButton)
            this.CartmainButton.Click -= btnCart_Click;
            this.CartmainButton.Click += btnCart_Click;

            // 3. ปุ่ม LOG OUT (LOmainButton)
            this.LOmainButton.Click -= btnLogOut_Click;
            this.LOmainButton.Click += btnLogOut_Click;
        }

        // --- [อัปเดต] 1. Event Handlers สำหรับปุ่มเมนู 4 ปุ่ม (แบบ Caching) ---

        private void HotcrepeButton_Click(object sender, EventArgs e)
        {
            // ตรวจสอบว่าฟอร์มยังไม่เคยถูกสร้าง หรือถูกปิดไปแล้ว (IsDisposed)
            if (hotCrepeForm == null || hotCrepeForm.IsDisposed)
            {
                hotCrepeForm = new HotCrepeMenu();
                hotCrepeForm.WindowState = FormWindowState.Maximized;
            }
            hotCrepeForm.Show(); // แสดงฟอร์มที่เก็บไว้
            this.Hide();
        }

        private void coldcrepeButton_Click(object sender, EventArgs e)
        {
            if (coldCrepeForm == null || coldCrepeForm.IsDisposed)
            {
                coldCrepeForm = new ColdCrepeMenu();
                coldCrepeForm.WindowState = FormWindowState.Maximized;
            }
            coldCrepeForm.Show();
            this.Hide();
        }

        private void DessertsButton_Click(object sender, EventArgs e)
        {
            if (dessertsForm == null || dessertsForm.IsDisposed)
            {
                dessertsForm = new DessertsMenu();
                dessertsForm.WindowState = FormWindowState.Maximized;
            }
            dessertsForm.Show();
            this.Hide();
        }

        private void DrinksButton_Click(object sender, EventArgs e)
        {
            if (drinksForm == null || drinksForm.IsDisposed)
            {
                drinksForm = new DrinksMenu();
                drinksForm.WindowState = FormWindowState.Maximized;
            }
            drinksForm.Show();
            this.Hide();
        }

        // --- [อัปเดต] 2. Event Handlers สำหรับปุ่ม CART (แบบ Caching) ---
        // [แก้ไข Error CS0122] เปลี่ยนจาก 'private' เป็น 'internal'
        internal void btnCart_Click(object sender, EventArgs e)
        {
            if (cartForm == null || cartForm.IsDisposed)
            {
                cartForm = new CartPage();
                cartForm.WindowState = FormWindowState.Maximized;
            }

            // [สำคัญ] สั่งให้หน้า Cart โหลดข้อมูลใหม่ทุกครั้งที่เปิด
            cartForm.LoadCartItems();

            cartForm.Show();
            this.Hide();
        }

        // --- [อัปเดต] 3. Event Handlers สำหรับปุ่ม LOG OUT ---
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var login = Application.OpenForms.OfType<Loginpage>().FirstOrDefault();
            if (login != null)
            {
                login.Show();
            }
            else
            {
                Loginpage newLogin = new Loginpage();
                newLogin.Show();
            }

            // [อัปเดต] สั่งปิดฟอร์มที่ Caching ไว้ออกจากหน่วยความจำ
            hotCrepeForm?.Close();
            coldCrepeForm?.Close();
            dessertsForm?.Close();
            drinksForm?.Close();
            cartForm?.Close();

            this.Close(); // ปิดหน้าหลักนี้
        }

        // --- (ฟังก์ชันว่างเปล่าที่ Designer.cs อ้างถึง) ---
        private void guna2Button2_Click(object sender, EventArgs e) { /* ไม่ต้องทำอะไร */ }
        private void guna2Button3_Click(object sender, EventArgs e) { /* ไม่ต้องทำอะไร */ }
        private void guna2Button1_Click(object sender, EventArgs e) { /* ไม่ต้องทำอะไร */ }

    }
}