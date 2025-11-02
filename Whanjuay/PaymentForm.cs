using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QRCoder;
using PromptPayQrCode; // 1. Namespace (ที่อยู่) ถูกต้อง

// 2. สร้าง "ชื่อเล่น" (Alias) "PPay" ให้กับ Class ที่ชื่อซ้ำกับ Namespace
using PPay = PromptPayQrCode.PromptPayQrCode;

namespace Whanjuay
{
    public partial class PaymentForm : Form
    {
        // --- !!! [สำคัญมาก] ---
        // --- !!! แก้ไขเลขพร้อมเพย์นี้เป็นของคุณ !!! ---
        private const string MY_PROMPTPAY_ID = "0935573411";
        // --- !!! [สำคัญมาก] ---

        private decimal _totalAmount;
        private string _slipImagePath = null;

        public PaymentForm(decimal totalAmount)
        {
            InitializeComponent();
            _totalAmount = totalAmount;

            // ผูก Event
            this.Load += PaymentForm_Load;
            this.btnUploadSlip.Click += new System.EventHandler(this.btnUploadSlip_Click);
            this.btnConfirmPayment.Click += new System.EventHandler(this.btnConfirmPayment_Click);
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            // 1. แสดงยอดเงิน
            lblAmount.Text = $"ยอดชำระ: {_totalAmount:N2} บาท";

            // 2. สร้าง QR Code แบบล็อคยอดเงิน
            try
            {
                // --- [FIX 1: CS1503] ---
                // แปลง _totalAmount (decimal) ให้เป็น (double) ที่ Library ต้องการ
                PPay payload = new PPay(MY_PROMPTPAY_ID, (double)_totalAmount);

                // --- [FIX 2: CS1061] ---
                // เปลี่ยนจาก Method .GeneratePayload() เป็น Property .PromptPayPayload
                string payloadString = payload.PromptPayPayload;

                // ใช้ Library QRCoder สร้างรูปภาพ
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

            // 3. ตั้งค่าสถานะปุ่มเริ่มต้น (ยังกดไม่ได้)
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
                        // เก็บ Path รูป
                        _slipImagePath = ofd.FileName;

                        // แสดงรูปตัวอย่าง
                        using (var stream = new FileStream(_slipImagePath, FileMode.Open, FileAccess.Read))
                        {
                            pbSlipPreview.Image = Image.FromStream(stream);
                        }

                        // อัปเดตข้อความ
                        lblSlipStatus.Text = Path.GetFileName(_slipImagePath);
                        lblSlipStatus.ForeColor = Color.Green;

                        // เปิดปุ่มยืนยัน
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

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            // เมื่อสำเร็จ
            MessageBox.Show("ชำระเงินสำเร็จ!\nขอบคุณที่ใช้บริการครับ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ล้างตะกร้า
            CartService.ClearCart();

            // ส่งสัญญาณบอก CartPage ว่าสำเร็จ
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // เมธอดสำหรับควบคุมสถานะปุ่มยืนยัน
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