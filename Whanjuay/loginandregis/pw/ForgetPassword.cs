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
        private static readonly Regex RxUser = new Regex(@"^[A-Za-z0-9]{8,15}$");
        private static readonly Regex RxGmail = new Regex(@"^[A-Za-z0-9._%+-]+@gmail\.com$", RegexOptions.IgnoreCase);

        private Control _tbUser;   // Username
        private Control _tbEmail;  // Email
        private Button _btnSubmit;

        public ForgetPassword()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _tbUser = FindCtrl("USERNAME") ?? FindCtrl("txtUser");
            _tbEmail = FindCtrl("EMAIL") ?? FindCtrl("txtEmail") ?? FindCtrl("guna2TextBox2");
            _btnSubmit = FindCtrl<Button>("SUBMIT") ?? FindCtrl<Button>("btnSubmit");

            var inputs = GetAllInputTextControls(this).OrderBy(c => c.TabIndex).ToList();

            if (_tbUser == null)
            {
                _tbUser =
                    inputs.FirstOrDefault(c => NameLike(c, "user") && !NameLike(c, "email")) ??
                    inputs.FirstOrDefault(c => PlaceholderLike(c, "user")) ??
                    inputs.FirstOrDefault();
            }

            if (_tbEmail == null)
            {
                _tbEmail =
                    inputs.FirstOrDefault(c => NameLike(c, "mail") || NameLike(c, "email")) ??
                    inputs.FirstOrDefault(c => PlaceholderLike(c, "mail") || PlaceholderLike(c, "email") || PlaceholderLike(c, "@")) ??
                    (_tbUser != null && inputs.Contains(_tbUser)
                        ? inputs.Skip(inputs.IndexOf(_tbUser) + 1).FirstOrDefault()
                        : null)
                    ?? inputs.ElementAtOrDefault(1);
            }

            if (_btnSubmit == null)
                _btnSubmit = GetAllControls(this).OfType<Button>().OrderBy(b => b.TabIndex).FirstOrDefault();

            if (_btnSubmit != null)
            {
                if (_btnSubmit is IButtonControl ib) ib.DialogResult = DialogResult.None;        // กันปิดฟอร์มเอง
                var pDR = _btnSubmit.GetType().GetProperty("DialogResult");
                if (pDR != null && pDR.CanWrite) pDR.SetValue(_btnSubmit, DialogResult.None);

                _btnSubmit.Click -= SUBMIT_Click;
                _btnSubmit.Click += SUBMIT_Click;
            }
        }

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

            username = Regex.Replace(username, @"\s", "").Trim();
            email = Regex.Replace(email, @"\s", "").Trim().ToLowerInvariant();

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

                // ✅ ผ่าน → เคลียร์ช่อง แล้วไปหน้า Reset แบบโมดัล
                ClearInputs();                      // <<< เคลียร์ช่องที่ขอ
                this.Hide();                        // ซ่อน Forget ระหว่างรีเซ็ต
                using (var reset = new ResetPassword(username, email))
                {
                    reset.StartPosition = FormStartPosition.CenterParent;
                    var dr = reset.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        // รีเซ็ตสำเร็จ → Reset จะพาไปหน้า Login แล้ว ปิด Forget ต่อเลย
                        this.Close();
                        return;
                    }
                }
                // ถ้ารีเซ็ตถูกยกเลิก → กลับมา Forget ต่อ
                this.Show();
                // โฟกัสกลับไปที่ช่องแรก
                _tbUser?.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการตรวจสอบ:\n" + ex.Message,
                    "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== Helpers =====
        private void ClearInputs()
        {
            SetText(_tbUser, string.Empty);
            SetText(_tbEmail, string.Empty);
        }
        private void SetText(Control c, string value)
        {
            if (c == null) return;
            if (c is TextBoxBase tb) { tb.Text = value; return; }
            var pText = c.GetType().GetProperty("Text");
            if (pText != null && pText.CanWrite) pText.SetValue(c, value);
        }

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
        private IEnumerable<Control> GetAllControls(Control root)
        {
            foreach (Control c in root.Controls)
            {
                yield return c;
                foreach (var child in GetAllControls(c))
                    yield return child;
            }
        }
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
        private bool NameLike(Control c, string keyword) =>
            (c.Name ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;

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
            catch { }
            return false;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void USERNAME_TextChanged(object sender, EventArgs e) { }
    }
}