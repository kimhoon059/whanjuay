using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Whanjuay
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Text = "Admin Dashboard";

            // ถ้ายังไม่มี Label แสดงข้อความ ให้ใส่ให้
            if (!this.Controls.OfType<Label>().Any(l => l.Name == "lblWelcome"))
            {
                var lbl = new Label
                {
                    Name = "lblWelcome",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 18f, FontStyle.Bold),
                    Text = "ยินดีต้อนรับสู่ระบบแอดมิน",
                    Location = new Point(30, 30)
                };
                this.Controls.Add(lbl);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e) { }
        private void guna2Button2_Click(object sender, EventArgs e) { }
        private void guna2Button3_Click(object sender, EventArgs e) { }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }
    }
}