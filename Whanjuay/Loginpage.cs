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
    public partial class Loginpage : Form
    {
        public Loginpage()
        {
            InitializeComponent();

            // กันผูกซ้ำ (ถ้าเผลอไปผูกใน Designer ด้วย)
            this.REGISTER.Click -= Register_Click;

            // ผูกปุ่ม REGISTER ให้เปิดหน้า Register
            this.REGISTER.Click += Register_Click;

            // ให้ช่องรหัสผ่านพิมพ์แล้วเป็นจุด
            PASSWORD.UseSystemPasswordChar = true;
            // ถ้า control ของคุณไม่มี UseSystemPasswordChar ให้ใช้:
            // PASSWORD.PasswordChar = '●';
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void USERNAME_TextChanged(object sender, EventArgs e)
        {

        }

        private void PASSWORD_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {
            this.Hide(); // ซ่อนหน้า Login ชั่วคราว
            using (var reg = new Registerpage())
            {
                reg.ShowDialog(); // เปิดหน้า Register แบบ modal
            }
            this.Show(); // กลับมาโชว์หน้า Login เมื่อปิด Register
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void LOGIN_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}