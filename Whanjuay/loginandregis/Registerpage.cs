using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Whanjuay
{
    public partial class Registerpage : Form
    {
        // [แก้ไข] กฎสำหรับ Username: a-zA-Z0-9 ความยาว 8–15 (กลับไปเป็นแบบเดิม)
        private static readonly Regex RxUser = new Regex(@"^[A-Za-z0-9]{8,15}$");

        // [แก้ไข] กฎสำหรับ Password: a-zA-Z0-9 ความยาว 8–15
        private static readonly Regex RxPass = new Regex(@"^[A-Za-z0-9]{8,15}$");

        // [เพิ่มใหม่] กฎสำหรับ Password: ต้องมีตัวเลขอย่างน้อย 1 ตัว
        private static readonly Regex RxPassHasDigit = new Regex(@"\d");

        // อีเมลต้องเป็น @gmail.com
        private static readonly Regex RxGmail = new Regex(@"^[A-Za-z0-9._%+-]+@gmail\.com$", RegexOptions.IgnoreCase);

        public Registerpage()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // ซ่อนรหัสเป็นจุด
            PASSWORD.UseSystemPasswordChar = true;
            CONFIRMPASSWORD.UseSystemPasswordChar = true;

            // ผูกปุ่ม SUBMIT → SUBMIT_Click (กันผูกซ้ำ)
            this.SUBMIT.Click -= SUBMIT_Click;
            this.SUBMIT.Click += SUBMIT_Click;
        }

        // ตรวจข้อมูล → บันทึก DB → แจ้งสำเร็จ → ปิด
        private void SUBMIT_Click(object sender, EventArgs e)
        {
            string username = (USERNAME.Text ?? "").Trim();
            string password = (PASSWORD.Text ?? "").Trim();
            string confirm = (CONFIRMPASSWORD.Text ?? "").Trim();
            string emailRaw = (this.email.Text ?? "");
            string email = emailRaw.Trim().ToLowerInvariant();

            // 1) Username: (กลับมาใช้กฎเดิม)
            if (!RxUser.IsMatch(username))
            {
                MessageBox.Show("Username ต้องเป็นตัวอักษร/ตัวเลขเท่านั้น และยาว 8–15 ตัว",
                                "กรอกข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                USERNAME.Focus();
                return;
            }

            // 2) Password: (กฎเดิม)
            if (!RxPass.IsMatch(password))
            {
                MessageBox.Show("Password ต้องเป็นตัวอักษร/ตัวเลขเท่านั้น และยาว 8–15 ตัว",
                                "กรอกข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PASSWORD.Focus();
                return;
            }

            // [เพิ่มใหม่] 3) Password: ต้องมีตัวเลข
            if (!RxPassHasDigit.IsMatch(password))
            {
                MessageBox.Show("Password ต้องมีตัวเลขอย่างน้อย 1 ตัว",
                               "กรอกข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PASSWORD.Focus();
                return;
            }

            // 4) Confirm ต้องตรงกับ Password
            if (confirm != password)
            {
                MessageBox.Show("Confirm Password ไม่ตรงกับ Password",
                                "กรอกข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CONFIRMPASSWORD.Focus();
                return;
            }

            // 5) Email ต้องเป็น @gmail.com
            if (!RxGmail.IsMatch(email))
            {
                MessageBox.Show("กรุณากรอกอีเมลให้ถูกต้อง และเป็น @gmail.com",
                                "กรอกข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.email.Focus();
                return;
            }
            if (email.Length > 100)
            {
                MessageBox.Show("อีเมลยาวเกินกำหนด (สูงสุด 100 ตัวอักษร)",
                                "กรอกข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.email.Focus();
                return;
            }

            // ผ่านแล้ว → บันทึกลง MySQL
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
                using (var conn = new MySqlConnection(cs))
                {
                    conn.Open();

                    // กันซ้ำ: username / email
                    using (var chk = new MySqlCommand(
                        "SELECT COUNT(*) FROM users WHERE username = @u OR LOWER(TRIM(email)) = LOWER(TRIM(@e))", conn))
                    {
                        chk.Parameters.AddWithValue("@u", username);
                        chk.Parameters.AddWithValue("@e", email);

                        long exists = Convert.ToInt64(chk.ExecuteScalar());
                        if (exists > 0)
                        {
                            MessageBox.Show("Username หรือ Email นี้ถูกใช้แล้ว",
                                            "สมัครไม่สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // บันทึก
                    using (var cmd = new MySqlCommand(
                        "INSERT INTO users (username, password, email) VALUES (@u, @p, @e)", conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);
                        cmd.Parameters.AddWithValue("@e", email);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("สมัครสมาชิกสำเร็จ", "สำเร็จ",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // ปิด Register → กลับหน้า Login
            }
            // ดักชน UNIQUE ของ MySQL
            catch (MySqlException mex) when (mex.Number == 1062)
            {
                MessageBox.Show("Username หรือ Email นี้ถูกใช้แล้ว (ชน UNIQUE ที่ฐานข้อมูล)",
                                "สมัครไม่สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูล:\n" + ex.Message,
                                "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // อีเวนต์ที่ยังไม่ได้ใช้ (เก็บไว้ได้เผื่อ Designer อ้างถึง)
        private void Registerpage_Load(object sender, EventArgs e) { }
        private void guna2TextBox2_TextChanged(object sender, EventArgs e) { }
        private void PASSWORD_TextChanged(object sender, EventArgs e) { }
        private void USERNAME_TextChanged(object sender, EventArgs e) { }
        private void CONFIRMPASSWORD_TextChanged(object sender, EventArgs e) { }
    }
}