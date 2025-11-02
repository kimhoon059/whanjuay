using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Whanjuay
{
    public partial class Loginpage : Form
    {
        public Loginpage()
        {
            InitializeComponent();

            this.REGISTER.Click -= Register_Click;
            this.REGISTER.Click += Register_Click;

            try { MaskAsPassword(this.PASSWORD); } catch { }
            WireForgetPassword();
            WireLoginButton();
        }

        private void WireLoginButton()
        {
            Control btnLogin =
                this.Controls.Find("SUBMIT", true).FirstOrDefault() ??
                this.Controls.Find("LOGIN", true).FirstOrDefault() ??
                GetAllControls(this)
                    .Where(c => c is ButtonBase || c.GetType().Name.IndexOf("Button", StringComparison.OrdinalIgnoreCase) >= 0)
                    .OrderBy(c => c.TabIndex)
                    .FirstOrDefault();

            if (btnLogin != null)
            {
                btnLogin.Click -= Login_Click;
                btnLogin.Click += Login_Click;
            }
        }

        // --- [แก้ไข] ---
        // เพิ่มการบันทึก Username ลงใน UserSession
        private void Login_Click(object sender, EventArgs e)
        {
            string user = (this.USERNAME.Text ?? "").Trim();
            string pass = (this.PASSWORD.Text ?? "").Trim();

            // 1. ตรวจสอบแอดมิน (ใช้ค่า hard-coded เดิม)
            bool isAdmin =
                string.Equals(user, "a", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(pass, "a1", StringComparison.OrdinalIgnoreCase);

            if (isAdmin)
            {
                // [เพิ่ม] ล้างค่า UserSession ถ้าเป็น Admin
                UserSession.CurrentUsername = "Admin"; // หรือ null ก็ได้
                OpenAdminForm();
                return;
            }

            // 2. ตรวจสอบผู้ใช้ทั่วไป (ถ้าไม่ใช่แอดมิน)
            string authenticatedUser = CheckUserLogin(user, pass);

            if (!string.IsNullOrEmpty(authenticatedUser))
            {
                // --- [นี่คือบรรทัดที่เพิ่มเข้ามา] ---
                // เก็บชื่อผู้ใช้ที่ล็อกอินสำเร็จไว้ใน Session
                UserSession.CurrentUsername = authenticatedUser;
                // --- [สิ้นสุดการเพิ่ม] ---

                // Success: Show welcome message, then open mainpagewj
                MessageBox.Show($"ยินดีต้อนรับ {authenticatedUser}",
                    "เข้าสู่ระบบสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OpenMainUserForm();
                return;
            }

            // 3. ถ้าไม่ผ่านทั้งคู่
            MessageBox.Show("Username หรือ Password ไม่ถูกต้อง",
                "เข้าสู่ระบบไม่สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // --- (โค้ดส่วนที่เหลือของ Loginpage.cs เหมือนเดิม) ---

        private string CheckUserLogin(string username, string password)
        {
            try
            {
                if (ConfigurationManager.ConnectionStrings["MyDb"] == null)
                {
                    MessageBox.Show("ไม่พบ Connection String ชื่อ MyDb", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                string cs = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
                using (var conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(@"
                        SELECT username
                        FROM users
                        WHERE username = @u AND password = @p;", conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);

                        object scalar = cmd.ExecuteScalar();

                        if (scalar != null)
                        {
                            return scalar.ToString();
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการตรวจสอบฐานข้อมูล:\n" + ex.Message,
                    "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void OpenAdminForm()
        {
            var admin = new Admin();
            admin.StartPosition = FormStartPosition.CenterScreen;

            admin.FormClosed += (s, ea) =>
            {
                if (!this.IsDisposed)
                {
                    ResetLoginForm();
                    this.Show();
                }
            };

            this.Hide();
            admin.Show();
        }

        private void OpenMainUserForm()
        {
            var mainForm = new mainpagewj();
            mainForm.StartPosition = FormStartPosition.CenterScreen;

            mainForm.FormClosed += (s, ea) =>
            {
                if (!this.IsDisposed)
                {
                    ResetLoginForm();
                    this.Show();
                }
            };

            this.Hide();
            mainForm.Show();
        }


        private void WireForgetPassword()
        {
            Control forgotCtrl =
                this.Controls.Find("FORGETPASSWORD", true).FirstOrDefault()
                ?? this.Controls.Find("FORGET", true).FirstOrDefault()
                ?? this.Controls
                      .OfType<Control>()
                      .FirstOrDefault(c =>
                      {
                          var t = (c.Text ?? "").Replace(" ", "");
                          return t.Equals("FORGETPASSWORD", StringComparison.OrdinalIgnoreCase)
                                 || t.Equals("FORGET", StringComparison.OrdinalIgnoreCase)
                                 || t.Equals("FORGETPASSWORD?", StringComparison.OrdinalIgnoreCase);
                      });

            if (forgotCtrl != null)
            {
                forgotCtrl.Click -= FORGETPASSWORD_Click;
                forgotCtrl.Click += FORGETPASSWORD_Click;

                if (forgotCtrl is Label lbl)
                {
                    lbl.Cursor = Cursors.Hand;
                    lbl.ForeColor = Color.RoyalBlue;
                }
            }
        }

        private void FORGETPASSWORD_Click(object sender, EventArgs e)
        {
            var f = new ForgetPassword();
            f.StartPosition = FormStartPosition.CenterScreen;

            f.FormClosed += (s, ea) =>
            {
                if (!this.IsDisposed)
                {
                    ResetLoginForm();
                    this.Show();
                }
            };

            this.Hide();
            f.Show();
        }

        private void ResetLoginForm()
        {
            try
            {
                foreach (var c in GetAllControls(this))
                {
                    if (c is TextBox tb) tb.Text = string.Empty;
                    else if (c is MaskedTextBox mtb) mtb.Text = string.Empty;
                    else
                    {
                        var typeName = c.GetType().FullName ?? "";
                        if (typeName.IndexOf("Guna2TextBox", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            var pText = c.GetType().GetProperty("Text");
                            if (pText != null && pText.CanWrite) pText.SetValue(c, string.Empty);
                        }
                    }
                }

                try { MaskAsPassword(this.PASSWORD); } catch { }

                if (this.USERNAME != null && this.USERNAME.CanFocus)
                    this.USERNAME.Focus();
            }
            catch { }
        }

        private void MaskAsPassword(Control c)
        {
            if (c == null) return;

            if (c is TextBox tb)
            {
                tb.UseSystemPasswordChar = true;
                return;
            }

            if (c is MaskedTextBox mtb)
            {
                mtb.UseSystemPasswordChar = true;
                return;
            }

            var t = c.GetType();

            var pUse = t.GetProperty("UseSystemPasswordChar");
            if (pUse != null && pUse.PropertyType == typeof(bool) && pUse.CanWrite)
            {
                pUse.SetValue(c, true);
                return;
            }

            var pChar = t.GetProperty("PasswordChar");
            if (pChar != null && pChar.PropertyType == typeof(char) && pChar.CanWrite)
            {
                pChar.SetValue(c, '●');
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var reg = new Registerpage())
            {
                reg.StartPosition = FormStartPosition.CenterParent;
                reg.ShowDialog();
            }
            ResetLoginForm();
            this.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e) { }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e) { }
        private void USERNAME_TextChanged(object sender, EventArgs e) { }
        private void PASSWORD_TextChanged(object sender, EventArgs e) { }
        private void guna2Button1_Click_1(object sender, EventArgs e) { }
        private void LOGIN_Paint(object sender, PaintEventArgs e) { }

        private IEnumerable<Control> GetAllControls(Control root)
        {
            foreach (Control c in root.Controls)
            {
                yield return c;
                foreach (var child in GetAllControls(c))
                    yield return child;
            }
        }
    }
}