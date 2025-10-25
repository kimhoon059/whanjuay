using System;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Whanjuay
{
    public partial class ResetPassword : Form
    {
        // รูปแบบรหัสผ่าน: a-zA-Z0-9 ความยาว 8–15
        private static readonly Regex RxPass = new Regex(@"^[A-Za-z0-9]{8,15}$");

        private readonly string _username;
        private readonly string _email;

        // อ้างอิงคอนโทรลแบบยืดหยุ่น
        private Control _tbPass;      // PASSWORD / NEWPASSWORD / txtNewPass / Guna2TextBox
        private Control _tbConfirm;   // CONFIRMPASSWORD / txtConfirm / Guna2TextBox
        private Button _btnSubmit;   // SUBMIT / btnSave

        public ResetPassword(string username, string email)
        {
            InitializeComponent();
            _username = username;
            _email = email;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // ----- 1) หา TextBox/ปุ่มจากชื่อที่พบบ่อย -----
            _tbPass = this.Controls.Find("PASSWORD", true).FirstOrDefault()
                   ?? this.Controls.Find("NEWPASSWORD", true).FirstOrDefault()
                   ?? this.Controls.Find("txtNewPass", true).FirstOrDefault();

            _tbConfirm = this.Controls.Find("CONFIRMPASSWORD", true).FirstOrDefault()
                       ?? this.Controls.Find("txtConfirm", true).FirstOrDefault();

            _btnSubmit = this.Controls.Find("SUBMIT", true).OfType<Button>().FirstOrDefault()
                       ?? this.Controls.Find("btnSave", true).OfType<Button>().FirstOrDefault();

            // ----- 2) ถ้ายังไม่เจอ textbox ให้เดา 2 ช่องแรกตาม TabIndex -----
            if (_tbPass == null || _tbConfirm == null)
            {
                var inputs = GetAllInputTextControls(this)
                            .OrderBy(c => c.TabIndex)
                            .ToList();

                if (inputs.Count >= 2)
                {
                    if (_tbPass == null) _tbPass = inputs[0];
                    if (_tbConfirm == null) _tbConfirm = inputs[1];
                }
            }

            // ----- 3) ทำให้พิมพ์แล้วเป็นจุด (รองรับ Guna2TextBox) -----
            MaskAsPassword(_tbPass);
            MaskAsPassword(_tbConfirm);

            // ----- 4) ผูกปุ่ม SUBMIT -----
            if (_btnSubmit == null)
            {
                _btnSubmit = GetAllControls(this).OfType<Button>()
                              .OrderBy(b => b.TabIndex).FirstOrDefault();
            }
            if (_btnSubmit != null)
            {
                // กันผูกซ้ำ (และรองรับกรณี Designer ผูก SUBMIT_Click_1)
                _btnSubmit.Click -= SUBMIT_Click;
                _btnSubmit.Click -= SUBMIT_Click_1;
                _btnSubmit.Click += SUBMIT_Click;
            }
        }

        // ===== บันทึกรหัสผ่านใหม่ =====
        private void SUBMIT_Click(object sender, EventArgs e)
        {
            if (_tbPass == null || _tbConfirm == null)
            {
                MessageBox.Show("ไม่พบช่องรหัสผ่านในฟอร์ม", "ข้อผิดพลาด",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string p = (_tbPass.Text ?? string.Empty).Trim();
            string c = (_tbConfirm.Text ?? string.Empty).Trim();

            // ตรวจรูปแบบและยืนยันซ้ำ
            if (!RxPass.IsMatch(p))
            {
                MessageBox.Show("รหัสผ่านต้องเป็นตัวอักษร/ตัวเลข 8–15 ตัว",
                    "ข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _tbPass.Focus();
                return;
            }
            if (c != p)
            {
                MessageBox.Show("ยืนยันรหัสผ่านไม่ตรงกับรหัสผ่านใหม่",
                    "ข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _tbConfirm.Focus();
                return;
            }

            // อัปเดตลงฐานข้อมูล
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
                using (var conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(
                        @"UPDATE users SET password=@p 
                          WHERE LOWER(TRIM(username)) = LOWER(TRIM(@u))
                            AND LOWER(TRIM(email))    = LOWER(TRIM(@e));", conn))
                    {
                        cmd.Parameters.AddWithValue("@p", p);   // **งานจริงควรทำ hashing**
                        cmd.Parameters.AddWithValue("@u", _username);
                        cmd.Parameters.AddWithValue("@e", _email);

                        int n = cmd.ExecuteNonQuery();
                        if (n == 0)
                        {
                            MessageBox.Show("ไม่สามารถอัปเดตรหัสผ่านได้",
                                "ล้มเหลว", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // ===== ส่วนพากลับหน้า Login =====
                var res = MessageBox.Show("เปลี่ยนรหัสผ่านสำเร็จ",
                    "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (res == DialogResult.OK)
                {
                    // ปิดฟอร์ม Reset (และส่งสัญญาณกลับว่า OK)
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                    // ถ้าฟอร์ม ForgetPassword เป็นเจ้าของ (Owner) อยู่ ให้ปิดด้วย
                    if (this.Owner != null && !this.Owner.IsDisposed)
                    {
                        this.Owner.DialogResult = DialogResult.OK;
                        this.Owner.Close();
                    }

                    // แสดงหน้า Login: ถ้ามีอยู่แล้วให้ Show/Activate, ถ้าไม่มีก็สร้างใหม่
                    var login = Application.OpenForms.OfType<Loginpage>().FirstOrDefault();
                    if (login != null && !login.IsDisposed)
                    {
                        login.Show();
                        login.Activate();
                    }
                    else
                    {
                        new Loginpage().Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการบันทึก:\n" + ex.Message,
                    "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== สตับรองรับกรณี Designer ผูกไว้เป็น SUBMIT_Click_1 =====
        private void SUBMIT_Click_1(object sender, EventArgs e)
        {
            SUBMIT_Click(sender, e);
        }

        // ===== Helper: ทำให้ช่องเป็นรหัส (รองรับ Guna2TextBox ด้วย reflection) =====
        private void MaskAsPassword(Control c)
        {
            if (c == null) return;

            if (c is TextBox tb)
            {
                tb.UseSystemPasswordChar = true;
                return;
            }

            // Guna2TextBox: มี property UseSystemPasswordChar และ PasswordChar
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

        // ===== Helpers: ค้นหาคอนโทรลทั้งฟอร์ม =====
        private IEnumerable<Control> GetAllControls(Control root)
        {
            foreach (Control c in root.Controls)
            {
                yield return c;
                foreach (var child in GetAllControls(c))
                    yield return child;
            }
        }

        // ดึง “ช่องกรอกข้อความ” ทั้งหมด (TextBoxBase + Guna2TextBox)
        private IEnumerable<Control> GetAllInputTextControls(Control root)
        {
            foreach (var c in GetAllControls(root))
            {
                var typeName = c.GetType().FullName ?? "";
                bool looksLikeTextBox =
                    c is TextBoxBase ||
                    typeName.IndexOf("Guna2TextBox", StringComparison.OrdinalIgnoreCase) >= 0;

                if (looksLikeTextBox && c.Enabled && c.Visible)
                    yield return c;
            }
        }

        // ===== สตับสำหรับอีเวนต์ Paint ที่ Designer ผูกไว้ (ถ้ามี) =====
        private void resetpw_Paint(object sender, PaintEventArgs e)
        {
            // ว่างไว้ได้ ไม่มีผลกับการทำงาน
        }
    }
}