namespace Whanjuay
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSlipStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbSlipPreview = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnConfirmPayment = new Guna.UI2.WinForms.Guna2Button();
            this.btnUploadSlip = new Guna.UI2.WinForms.Guna2Button();
            this.lblAmount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbQRCode = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlipPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.lblSlipStatus);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.pbSlipPreview);
            this.pnlMain.Controls.Add(this.btnConfirmPayment);
            this.pnlMain.Controls.Add(this.btnUploadSlip);
            this.pnlMain.Controls.Add(this.lblAmount);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.pbQRCode);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(434, 661);
            this.pnlMain.TabIndex = 0;
            // 
            // lblSlipStatus
            // 
            this.lblSlipStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlipStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblSlipStatus.Location = new System.Drawing.Point(50, 526);
            this.lblSlipStatus.Name = "lblSlipStatus";
            this.lblSlipStatus.Size = new System.Drawing.Size(335, 23);
            this.lblSlipStatus.TabIndex = 7;
            this.lblSlipStatus.Text = "(ยังไม่ได้อัปโหลดสลิป)";
            this.lblSlipStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "2. ยืนยันการชำระ";
            // 
            // pbSlipPreview
            // 
            this.pbSlipPreview.BorderRadius = 10;
            this.pbSlipPreview.FillColor = System.Drawing.Color.Gainsboro;
            this.pbSlipPreview.ImageRotate = 0F;
            this.pbSlipPreview.Location = new System.Drawing.Point(50, 421);
            this.pbSlipPreview.Name = "pbSlipPreview";
            this.pbSlipPreview.Size = new System.Drawing.Size(335, 102);
            this.pbSlipPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSlipPreview.TabIndex = 5;
            this.pbSlipPreview.TabStop = false;
            // 
            // btnConfirmPayment
            // 
            this.btnConfirmPayment.BorderRadius = 10;
            this.btnConfirmPayment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnConfirmPayment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnConfirmPayment.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPayment.Location = new System.Drawing.Point(50, 584);
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.Size = new System.Drawing.Size(335, 45);
            this.btnConfirmPayment.TabIndex = 4;
            this.btnConfirmPayment.Text = "ยืนยันการชำระเงิน";
            // 
            // btnUploadSlip
            // 
            this.btnUploadSlip.BorderRadius = 10;
            this.btnUploadSlip.BorderThickness = 1;
            this.btnUploadSlip.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.btnUploadSlip.FillColor = System.Drawing.Color.White;
            this.btnUploadSlip.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUploadSlip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.btnUploadSlip.Location = new System.Drawing.Point(50, 386);
            this.btnUploadSlip.Name = "btnUploadSlip";
            this.btnUploadSlip.Size = new System.Drawing.Size(335, 29);
            this.btnUploadSlip.TabIndex = 3;
            this.btnUploadSlip.Text = "คลิกเพื่ออัปโหลดสลิป";
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAmount.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblAmount.Location = new System.Drawing.Point(12, 318);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(410, 30);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "ยอดชำระ: 0.00 บาท";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "1. สแกน QR เพื่อชำระเงิน";
            // 
            // pbQRCode
            // 
            this.pbQRCode.FillColor = System.Drawing.Color.Gainsboro;
            this.pbQRCode.ImageRotate = 0F;
            this.pbQRCode.Location = new System.Drawing.Point(87, 60);
            this.pbQRCode.Name = "pbQRCode";
            this.pbQRCode.Size = new System.Drawing.Size(260, 260);
            this.pbQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbQRCode.TabIndex = 0;
            this.pbQRCode.TabStop = false;
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 661);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ชำระเงิน";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlipPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2PictureBox pbQRCode;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnUploadSlip;
        private Guna.UI2.WinForms.Guna2Button btnConfirmPayment;
        private Guna.UI2.WinForms.Guna2PictureBox pbSlipPreview;
        private System.Windows.Forms.Label lblSlipStatus;
        private System.Windows.Forms.Label label3;
    }
}