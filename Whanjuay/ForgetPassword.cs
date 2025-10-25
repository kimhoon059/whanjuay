using System;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Whanjuay
{
    public partial class ForgetPassword : Form
    {
        // ✅ กติกาเดิมตามที่ต้องการ: a-zA-Z0-9 ความยาว 8–15
        private static readonly Regex RxUser = new Regex(@"^[A-Za-z0-9]{8,15}$");
        private static readonly Regex RxGmail = new Regex(@"^[A-Za-z0-9._%+-]+@gmail\.com$", RegexOptions.IgnoreCase);

        // อ้างอิงคอนโทรล (ไม่ต้องแตะ Designer)
        private Control _tbUser;   // ช่อง Username
        private Control _tbEmail;  // ช่อง Email
        private Button _btnSubmit;

        public ForgetPassword()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // ---------- ขั้นที่ 1: พยายามหาโดย "ชื่อคอนโทรล" ก่อน ----------
            _tbUser = FindCtrl("USERNAME") ?? FindCtrl("txtUser");
            _tbEmail = FindCtrl("EMAIL") ?? FindCtrl("txtEmail") ?? FindCtrl("guna2TextBox2");
            _btnSubmit = FindCtrl<Button>("SUBMIT") ?? FindCtrl<Button>("btnSubmit");

            // ---------- ขั้นที่ 2: ถ้าไม่เจอ ให้กวาด input ทั้งหมด แล้วเดาตาม heuristic ----------
            var inputs = GetAllInputTextControls(this).OrderBy(c => c.TabIndex).ToList();

            if (_tbUser == null)
            {
                _tbUser =
                    // จากชื่อคอนโทรล
                    inputs.FirstOrDefault(c => NameLike(c, "user") && !NameLike(c, "email")) ??
                    // จาก placeholder
                    inputs.FirstOrDefault(c => PlaceholderLike(c, "user")) ??
                    // fallback: ช่องแรก
                    inputs.FirstOrDefault();
            }

            if (_tbEmail == null)
            {
                _tbEmail =
                    // จากชื่อคอนโทรล
                    inputs.FirstOrDefault(c => NameLike(c, "mail") || NameLike(c, "email")) ??
                    // จาก placeholder
                    inputs.FirstOrDefault(c => PlaceholderLike(c, "mail") || PlaceholderLike(c, "email") || PlaceholderLike(c, "@")) ??
                    // fallback: ช่องถัดจาก user (ถ้าเจอ user แล้ว)
                    (_tbUser != null && inputs.Contains(_tbUser)
                        ? inputs.Skip(inputs.IndexOf(_tbUser) + 1).FirstOrDefault()
                        : null)
                    ?? inputs.ElementAtOrDefault(1);
            }

            // ---------- ขั้นที่ 3: หา/ผูกปุ่ม Submit ----------
            if (_btnSubmit == null)
            {
                _btnSubmit = GetAllControls(this).OfType<Button>().OrderBy(b => b.TabIndex).FirstOrDefault();
            }
            if (_btnSubmit != null)
            {
                _btnSubmit.Click -= SUBMIT_Click; // กันผูกซ้ำ
                _btnSubmit.Click += SUBMIT_Click;
            }
        }

        // ===== กด SUBMIT → ตรวจ Username/Email → เปิดหน้า Reset =====
        private void SUBMIT_Click(object sender, EventArgs e)
        {
            if (_tbUser == null || _tbEmail == null)
            {
                MessageBox.Show("ไม่พบช่องกรอก Username/Email ในฟอร์ม",
                    "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = (_tbUser.Text ?? string.Empty);
            string email = (_tbEmail.Text ?? string.Empty);

            // Normalize: ลบช่องว่างทุกชนิด + ตัดหัวท้าย; อีเมลแปลงเป็นตัวเล็ก
            username = Regex.Replace(username, @"\s", "").Trim();
            email = Regex.Replace(email, @"\s", "").Trim().ToLowerInvariant();

            // ตรวจรูปแบบ (กติกาเดิม 8–15)
            if (!RxUser.IsMatch(username))
            {
                MessageBox.Show("Username ต้องเป็นตัวอักษร/ตัวเลข 8–15 ตัว",
                    "ข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _tbUser.Focus();
                return;
            }
            if (!RxGmail.IsMatch(email))
            {
                MessageBox.Show("กรุณากรอกอีเมลให้ถูกต้อง และเป็น @gmail.com",
                    "ข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _tbEmail.Focus();
                return;
            }

            // ตรวจในฐานข้อมูล (ไม่สนพิมพ์เล็ก-ใหญ่ และตัดช่องว่าง)
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
                using (var conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(@"
                        SELECT COUNT(*)
                        FROM users
                        WHERE LOWER(TRIM(username)) = LOWER(TRIM(@u))
                          AND LOWER(TRIM(email))    = LOWER(TRIM(@e));", conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@e", email);

                        var scalar = cmd.ExecuteScalar();
                        long ok = (scalar is long) ? (long)scalar : Convert.ToInt64(scalar);

                        if (ok == 0)
                        {
                            MessageBox.Show(
                                "ไม่พบบัญชีที่ตรงกับ Username/Email นี้\n(ตรวจตัวสะกด เว้นวรรค หรือพิมพ์เล็ก-ใหญ่)",
                                "ตรวจสอบไม่ผ่าน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // ผ่าน → เปิดหน้าเปลี่ยนรหัสผ่าน
                using (var reset = new ResetPassword(username, email))
                {
                    reset.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการตรวจสอบ:\n" + ex.Message,
                    "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= Helpers =================

        // หา Control ตาม “ชื่อเป๊ะ” (recursive, case-insensitive)
        private Control FindCtrl(string name)
        {
            return GetAllControls(this)
                   .FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
        }
        private T FindCtrl<T>(string name) where T : Control
        {
            return GetAllControls(this)
                   .OfType<T>()
                   .FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        // เดินทุกคอนโทรลในฟอร์ม (รวมลูกหลาน)
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

        // เช็คว่าชื่อคอนโทรลมีคีย์เวิร์ด
        private bool NameLike(Control c, string keyword)
        {
            return (c.Name ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        // อ่าน PlaceholderText (รองรับ Guna2TextBox ด้วย reflection)
        private bool PlaceholderLike(Control c, string keyword)
        {
            try
            {
                var prop = c.GetType().GetProperty("PlaceholderText");
                if (prop != null)
                {
                    var val = prop.GetValue(c) as string;
                    return (val ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
                }
            }
            catch { /* ignore */ }
            return false;
        }

        // Stubs ที่ Designer เคยผูกไว้ (เว้นว่างได้)
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void USERNAME_TextChanged(object sender, EventArgs e) { }
    }
}