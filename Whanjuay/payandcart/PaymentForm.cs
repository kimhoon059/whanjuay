using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QRCoder;
using PromptPayQrCode;
using PPay = PromptPayQrCode.PromptPayQrCode;

namespace Whanjuay
{
    public partial class PaymentForm : Form
    {
        // (*** อย่าลืมแก้ MY_PROMPTPAY_ID เป็นของคุณ ***)
        private const string MY_PROMPTPAY_ID = "0801234567";

        private decimal _totalAmount;
        private string _slipImagePath = null;

        public PaymentForm(decimal totalAmount)
        {
            InitializeComponent();
            _totalAmount = totalAmount;

            this.Load += PaymentForm_Load;
            this.btnUploadSlip.Click += new System.EventHandler(this.btnUploadSlip_Click);
            this.btnConfirmPayment.Click += new System.EventHandler(this.btnConfirmPayment_Click);
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            lblAmount.Text = $"ยอดชำระ: {_totalAmount:N2} บาท";

            try
            {
                PPay payload = new PPay(MY_PROMPTPAY_ID, (double)_totalAmount);
                string payloadString = payload.PromptPayPayload;

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(payloadString, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);

                pbQRCode.Image = qrCodeImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการสร้าง QR Code: " + ex.Message);
                pbQRCode.Image = null;
            }

            UpdatePaymentButtonState();
        }

        private void btnUploadSlip_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "รูปภาพสลิป|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "กรุณาเลือกสลิปการโอนเงิน";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _slipImagePath = ofd.FileName;
                        using (var stream = new FileStream(_slipImagePath, FileMode.Open, FileAccess.Read))
                        {
                            pbSlipPreview.Image = Image.FromStream(stream);
                        }
                        lblSlipStatus.Text = Path.GetFileName(_slipImagePath);
                        lblSlipStatus.ForeColor = Color.Green;
                        UpdatePaymentButtonState();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ไม่สามารถโหลดรูปภาพได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _slipImagePath = null;
                        pbSlipPreview.Image = null;
                        lblSlipStatus.Text = "(ยังไม่ได้อัปโหลดสลิป)";
                        lblSlipStatus.ForeColor = Color.Gray;
                        UpdatePaymentButtonState();
                    }
                }
            }
        }

        // --- [แก้ไข] ---
        // นี่คือ Logic ใหม่ทั้งหมดสำหรับปุ่มยืนยัน
        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            // ตรวจสอบข้อมูลอีกครั้ง
            if (string.IsNullOrEmpty(_slipImagePath))
            {
                MessageBox.Show("กรุณาอัปโหลดสลิปก่อน", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string currentUsername = UserSession.CurrentUsername;
            if (string.IsNullOrEmpty(currentUsername))
            {
                MessageBox.Show("ไม่พบข้อมูลผู้ใช้งาน (Session หลุด)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newOrderCode = "";
            string relativeSlipPath = "";

            try
            {
                // --- 1. บันทึก Order ลง DB ---
                // (เมธอดนี้จะคืนค่า Order Code เช่น "WJ000123")
                newOrderCode = Db.CreateOrder(currentUsername, _totalAmount, CartService.GetItems());

                // --- 2. คัดลอกไฟล์สลิปไปเก็บ ---
                // สร้างโฟลเดอร์ "Slips" (ถ้ายังไม่มี)
                string slipFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Slips");
                Directory.CreateDirectory(slipFolder);

                // ตั้งชื่อไฟล์สลิปใหม่ (เช่น WJ000123.jpg)
                string slipExtension = Path.GetExtension(_slipImagePath);
                string newSlipFileName = $"{newOrderCode}{slipExtension}";
                string destinationPath = Path.Combine(slipFolder, newSlipFileName);

                // คัดลอกไฟล์
                File.Copy(_slipImagePath, destinationPath, true);
                relativeSlipPath = $"Slips/{newSlipFileName}"; // Path ที่จะเก็บลง DB

                // --- 3. อัปเดต DB ด้วย Path ของสลิป ---
                Db.UpdateOrderSlipPath(newOrderCode, relativeSlipPath);

                // --- 4. ทุกอย่างสำเร็จ ---
                MessageBox.Show("ชำระเงินสำเร็จ!\nขอบคุณที่ใช้บริการครับ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ล้างตะกร้า
                CartService.ClearCart();

                // ส่งสัญญาณบอก CartPage ว่าสำเร็จ
                this.DialogResult = DialogResult.OK;

                // --- 5. เปิดหน้าใบเสร็จ ---
                this.Hide(); // ซ่อนหน้าจ่ายเงิน
                using (ReceiptForm receipt = new ReceiptForm(newOrderCode))
                {
                    // แสดงใบเสร็จ โดยให้ CartPage เป็นแม่ (Owner)
                    receipt.ShowDialog(this.Owner);
                }

                this.Close(); // ปิดหน้าจ่ายเงินถาวร
            }
            catch (Exception ex)
            {
                // ถ้าขั้นตอน 1, 2, หรือ 3 ล้มเหลว
                MessageBox.Show("เกิดข้อผิดพลาดร้ายแรงในการบันทึกคำสั่งซื้อ:\n" + ex.Message,
                                "บันทึกล้มเหลว", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // (ถ้าบันทึกล้มเหลว เราจะไม่ปิดหน้าต่าง และไม่ล้างตะกร้า)
            }
        }

        private void UpdatePaymentButtonState()
        {
            if (!string.IsNullOrEmpty(_slipImagePath))
            {
                btnConfirmPayment.Enabled = true;
                btnConfirmPayment.FillColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
                btnConfirmPayment.Enabled = false;
                btnConfirmPayment.FillColor = Color.Gainsboro;
            }
        }
    }
}