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

            // 2. ปุ่ม CART (CartmainButton) - (อิงตามชื่อที่แก้ไขล่าสุด)
            this.CartmainButton.Click -= btnCart_Click;
            this.CartmainButton.Click += btnCart_Click;

            // 3. ปุ่ม LOG OUT (LOmainButton) - (อิงตามชื่อที่แก้ไขล่าสุด)
            this.LOmainButton.Click -= btnLogOut_Click;
            this.LOmainButton.Click += btnLogOut_Click;
        }

        // --- 1. Event Handlers สำหรับปุ่มเมนู 4 ปุ่ม ---

        private void HotcrepeButton_Click(object sender, EventArgs e)
        {
            HotCrepeMenu hotCrepeForm = new HotCrepeMenu();
            hotCrepeForm.WindowState = FormWindowState.Maximized; // [แก้]
            hotCrepeForm.Show();
            this.Hide();
        }

        private void coldcrepeButton_Click(object sender, EventArgs e)
        {
            ColdCrepeMenu coldCrepeForm = new ColdCrepeMenu();
            coldCrepeForm.WindowState = FormWindowState.Maximized; // [แก้]
            coldCrepeForm.Show();
            this.Hide();
        }

        private void DessertsButton_Click(object sender, EventArgs e)
        {
            DessertsMenu dessertsForm = new DessertsMenu();
            dessertsForm.WindowState = FormWindowState.Maximized; // [แก้]
            dessertsForm.Show();
            this.Hide();
        }

        private void DrinksButton_Click(object sender, EventArgs e)
        {
            DrinksMenu drinksForm = new DrinksMenu();
            drinksForm.WindowState = FormWindowState.Maximized; // [แก้]
            drinksForm.Show();
            this.Hide();
        }

        // --- 2. Event Handlers สำหรับปุ่ม CART ---
        private void btnCart_Click(object sender, EventArgs e)
        {
            CartPage cartForm = new CartPage();
            cartForm.WindowState = FormWindowState.Maximized; // [แก้]
            cartForm.Show();
            this.Hide();
        }

        // --- 3. Event Handlers สำหรับปุ่ม LOG OUT ---
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
            this.Close();
        }

        // --- (ฟังก์ชันว่างเปล่าที่ Designer.cs อ้างถึง) ---
        private void guna2Button2_Click(object sender, EventArgs e) { /* ไม่ต้องทำอะไร */ }
        private void guna2Button3_Click(object sender, EventArgs e) { /* ไม่ต้องทำอะไร */ }
        private void guna2Button1_Click(object sender, EventArgs e) { /* ไม่ต้องทำอะไร */ }

    }
}