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

            // ✅ ให้ช่องรหัสผ่านพิมพ์แล้วเป็นจุด (รองรับทั้ง TextBox/Guna2TextBox)
            try { MaskAsPassword(this.PASSWORD); } catch { /* เผื่อ control ไม่ตรงชนิด ข้ามได้ */ }

            // ✅ ผูก "Forget Password" แบบไม่พึ่ง Designer (ค้นหาคอนโทรลให้เอง)
            WireForgetPassword();

            // ✅ ผูกปุ่ม "ล็อกอิน" เพื่อเช็คแอดมิน (SUBMIT/LOGIN/หรือปุ่มแรกตาม TabIndex)
            WireLoginButton();
        }

        // ====== ผูกปุ่มล็อกอิน แล้วชี้มาที่ Login_Click ======
        private void WireLoginButton()
        {
            // หาได้ทั้งชื่อ SUBMIT/LOGIN หรือถ้าไม่เจอหยิบปุ่มแรกตาม TabIndex (ไม่จำกัดชนิดปุ่ม)
            Control btnLogin =
                this.Controls.Find("SUBMIT", true).FirstOrDefault() ??
                this.Controls.Find("LOGIN", true).FirstOrDefault() ??
                GetAllControls(this)
                    .Where(c => c is ButtonBase || c.GetType().Name.IndexOf("Button", StringComparison.OrdinalIgnoreCase) >= 0)
                    .OrderBy(c => c.TabIndex)
                    .FirstOrDefault();

            if (btnLogin != null)
            {
                // กันผูกซ้ำ แล้วค่อยผูกใหม่
                btnLogin.Click -= Login_Click;
                btnLogin.Click += Login_Click;
            }
        }

        // ====== ล็อกอิน: เช็คแอดมินก่อน (ไม่สนตัวพิมพ์เล็ก-ใหญ่) ======
        private void Login_Click(object sender, EventArgs e)
        {
            string user = (this.USERNAME.Text ?? "").Trim();
            string pass = (this.PASSWORD.Text ?? "").Trim();

            bool isAdmin =
                string.Equals(user, "adminwj", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(pass, "wj88888888", StringComparison.OrdinalIgnoreCase);

            if (isAdmin)
            {
                // เข้าหน้าแอดมิน (ฟอร์มชื่อ Admin ตามที่คุณสร้าง)
                var admin = new Admin();
                admin.StartPosition = FormStartPosition.CenterScreen;

                // เมื่อปิดหน้า Admin แล้ว ให้เคลียร์ฟอร์ม + โชว์หน้า Login กลับมา
                admin.FormClosed += (s, ea) =>
                {
                    if (!this.IsDisposed)
                    {
                        ResetLoginForm();
                        this.Show();
                    }
                };

                this.Hide();    // ❗อย่า Close() ฟอร์มหลัก ไม่งั้นแอปจะปิดหมด
                admin.Show();
                return;
            }

            // (ยังไม่ทำล็อกอินผู้ใช้ทั่วไปในจุดนี้)
            MessageBox.Show("บัญชีนี้ไม่ใช่แอดมิน หรือรหัสผ่านไม่ถูกต้อง",
                "เข้าสู่ระบบไม่สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ====== ค้นหาแล้วผูกคลิกกับคอนโทรล Forget Password ======
        private void WireForgetPassword()
        {
            // พยายามหาจากชื่อคอนโทรลก่อน
            Control forgotCtrl =
                this.Controls.Find("FORGETPASSWORD", true).FirstOrDefault()  // ชื่อเต็ม
                ?? this.Controls.Find("FORGET", true).FirstOrDefault()       // ชื่อสั้น
                                                                             // ถ้ายังไม่เจอ ลองเทียบจากข้อความบนคอนโทรล (เช่น "FORGET PASSWORD")
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
                // กันผูกซ้ำ + ผูกอีเวนต์คลิก
                forgotCtrl.Click -= FORGETPASSWORD_Click;
                forgotCtrl.Click += FORGETPASSWORD_Click;

                // ถ้าเป็น Label ทำให้ดูเหมือนลิงก์ (คลิกได้)
                if (forgotCtrl is Label lbl)
                {
                    lbl.Cursor = Cursors.Hand;
                    lbl.ForeColor = Color.RoyalBlue; // ปรับสีตามชอบได้
                }
            }
        }

        // ====== เมื่อคลิก Forget Password → เปิดหน้า ForgetPassword แบบไม่ปิดแอป ======
        private void FORGETPASSWORD_Click(object sender, EventArgs e)
        {
            var f = new ForgetPassword();
            f.StartPosition = FormStartPosition.CenterScreen;

            // เมื่อปิดหน้า Forget แล้ว ให้เคลียร์ฟอร์ม + โชว์หน้า Login กลับมา
            f.FormClosed += (s, ea) =>
            {
                if (!this.IsDisposed)
                {
                    ResetLoginForm();
                    this.Show();
                }
            };

            this.Hide();   // ❗ซ่อนฟอร์มหลักแทนการ Close()
            f.Show();
        }

        // ====== Helper: เคลียร์ฟอร์มล็อกอิน (ช่องกรอก/โฟกัส/ซ่อนรหัส) ======
        private void ResetLoginForm()
        {
            try
            {
                // เคลียร์ Text ของทุก TextBox/MaskedTextBox/Guna2TextBox ภายในฟอร์ม
                foreach (var c in GetAllControls(this))
                {
                    if (c is TextBox tb) tb.Text = string.Empty;
                    else if (c is MaskedTextBox mtb) mtb.Text = string.Empty;
                    else
                    {
                        // รองรับ Guna2TextBox
                        var typeName = c.GetType().FullName ?? "";
                        if (typeName.IndexOf("Guna2TextBox", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            var pText = c.GetType().GetProperty("Text");
                            if (pText != null && pText.CanWrite) pText.SetValue(c, string.Empty);
                        }
                    }
                }

                // ตั้งให้ช่องรหัสเป็นจุดอีกครั้ง เผื่อ control เปลี่ยน state
                try { MaskAsPassword(this.PASSWORD); } catch { }

                // โฟกัสกลับไปที่ USERNAME ถ้ามี
                if (this.USERNAME != null && this.USERNAME.CanFocus)
                    this.USERNAME.Focus();
            }
            catch { /* ป้องกัน error เล็ก ๆ น้อย ๆ */ }
        }

        // ====== Helper: ทำให้ช่องเป็นรหัส (รองรับ Guna2TextBox / TextBox / MaskedTextBox) ======
        private void MaskAsPassword(Control c)
        {
            if (c == null) return;

            // TextBox ปกติ
            if (c is TextBox tb)
            {
                tb.UseSystemPasswordChar = true;
                return;
            }

            // MaskedTextBox
            if (c is MaskedTextBox mtb)
            {
                mtb.UseSystemPasswordChar = true;
                return;
            }

            // อื่น ๆ (เช่น Guna2TextBox) ใช้ reflection หา property ที่มี
            var t = c.GetType();

            // ลองตั้ง UseSystemPasswordChar ถ้ามี
            var pUse = t.GetProperty("UseSystemPasswordChar");
            if (pUse != null && pUse.PropertyType == typeof(bool) && pUse.CanWrite)
            {
                pUse.SetValue(c, true);
                return;
            }

            // ไม่มีก็ลองตั้ง PasswordChar เป็นจุด
            var pChar = t.GetProperty("PasswordChar");
            if (pChar != null && pChar.PropertyType == typeof(char) && pChar.CanWrite)
            {
                pChar.SetValue(c, '●');  // หรือ '*'
            }
        }

        // ====== ของเดิม (คงไว้เผื่อ Designer อ้างถึง) ======
        private void Register_Click(object sender, EventArgs e)
        {
            this.Hide(); // ซ่อนหน้า Login ชั่วคราว
            using (var reg = new Registerpage())
            {
                reg.StartPosition = FormStartPosition.CenterParent;
                reg.ShowDialog(); // เปิดหน้า Register แบบ modal
            }
            ResetLoginForm();   // กลับมาแล้วเคลียร์ช่องให้พร้อมใช้
            this.Show();        // กลับมาโชว์หน้า Login เมื่อปิด Register
        }

        private void guna2Button1_Click(object sender, EventArgs e) { }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e) { }
        private void USERNAME_TextChanged(object sender, EventArgs e) { }
        private void PASSWORD_TextChanged(object sender, EventArgs e) { }
        private void guna2Button1_Click_1(object sender, EventArgs e) { }
        private void LOGIN_Paint(object sender, PaintEventArgs e) { }

        // ====== Helper: ดึงคอนโทรลทั้งหมดแบบ recursive ======
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