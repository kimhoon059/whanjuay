namespace Whanjuay
{
    partial class ReceiptForm
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
            this.pnlReceipt = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalHeader = new System.Windows.Forms.Label();
            this.lineSeparator = new System.Windows.Forms.Label();
            this.flowItemsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblItemsHeader = new System.Windows.Forms.Label();
            this.lblOrderCode = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnDownloadPdf = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pnlReceipt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlReceipt
            // 
            this.pnlReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReceipt.BackColor = System.Drawing.Color.White;
            this.pnlReceipt.Controls.Add(this.lblFooter);
            this.pnlReceipt.Controls.Add(this.lblTotal);
            this.pnlReceipt.Controls.Add(this.lblTotalHeader);
            this.pnlReceipt.Controls.Add(this.lineSeparator);
            this.pnlReceipt.Controls.Add(this.flowItemsPanel);
            this.pnlReceipt.Controls.Add(this.lblItemsHeader);
            this.pnlReceipt.Controls.Add(this.lblOrderCode);
            this.pnlReceipt.Controls.Add(this.lblDate);
            this.pnlReceipt.Controls.Add(this.lblUsername);
            this.pnlReceipt.Controls.Add(this.lblHeader);
            this.pnlReceipt.Controls.Add(this.pbLogo);
            this.pnlReceipt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlReceipt.Location = new System.Drawing.Point(12, 12);
            this.pnlReceipt.Name = "pnlReceipt";
            this.pnlReceipt.Size = new System.Drawing.Size(460, 578);
            this.pnlReceipt.TabIndex = 0;
            // 
            // lblFooter
            // 
            this.lblFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFooter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.Location = new System.Drawing.Point(18, 549);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(424, 23);
            this.lblFooter.TabIndex = 10;
            this.lblFooter.Text = "ทาน WHANJUAY ให้อร่อยนะค้าบ";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(232, 513);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(210, 23);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "0.00 บาท";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalHeader
            // 
            this.lblTotalHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalHeader.AutoSize = true;
            this.lblTotalHeader.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHeader.Location = new System.Drawing.Point(17, 513);
            this.lblTotalHeader.Name = "lblTotalHeader";
            this.lblTotalHeader.Size = new System.Drawing.Size(126, 23);
            this.lblTotalHeader.TabIndex = 8;
            this.lblTotalHeader.Text = "รวมยอดเงิน:";
            // 
            // lineSeparator
            // 
            this.lineSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineSeparator.Location = new System.Drawing.Point(18, 502);
            this.lineSeparator.Name = "lineSeparator";
            this.lineSeparator.Size = new System.Drawing.Size(424, 2);
            this.lineSeparator.TabIndex = 7;
            // 
            // flowItemsPanel
            // 
            this.flowItemsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowItemsPanel.AutoScroll = true;
            this.flowItemsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowItemsPanel.Location = new System.Drawing.Point(18, 258);
            this.flowItemsPanel.Name = "flowItemsPanel";
            this.flowItemsPanel.Size = new System.Drawing.Size(424, 232);
            this.flowItemsPanel.TabIndex = 6;
            this.flowItemsPanel.WrapContents = false;
            // 
            // lblItemsHeader
            // 
            this.lblItemsHeader.AutoSize = true;
            this.lblItemsHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsHeader.Location = new System.Drawing.Point(17, 236);
            this.lblItemsHeader.Name = "lblItemsHeader";
            this.lblItemsHeader.Size = new System.Drawing.Size(111, 19);
            this.lblItemsHeader.TabIndex = 5;
            this.lblItemsHeader.Text = "รายการสินค้า:";
            // 
            // lblOrderCode
            // 
            this.lblOrderCode.AutoSize = true;
            this.lblOrderCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderCode.Location = new System.Drawing.Point(18, 172);
            this.lblOrderCode.Name = "lblOrderCode";
            this.lblOrderCode.Size = new System.Drawing.Size(95, 16);
            this.lblOrderCode.TabIndex = 4;
            this.lblOrderCode.Text = "Order ID: WJ0";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(18, 197);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(43, 16);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "วันที่: ";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(18, 147);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(62, 16);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "ผู้ใช้งาน: ";
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(16, 99);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(426, 33);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "ใบเสร็จรับเงิน (Receipt)";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbLogo
            // 
            // [FIXED] เปลี่ยนไปใช้ Resource ชื่อ logowj
            this.pbLogo.Image = global::Whanjuay.Properties.Resources.logowj;
            this.pbLogo.Location = new System.Drawing.Point(121, 16);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(218, 69);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnDownloadPdf
            // 
            this.btnDownloadPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadPdf.BorderRadius = 10;
            this.btnDownloadPdf.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.btnDownloadPdf.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDownloadPdf.ForeColor = System.Drawing.Color.White;
            this.btnDownloadPdf.Location = new System.Drawing.Point(267, 605);
            this.btnDownloadPdf.Name = "btnDownloadPdf";
            this.btnDownloadPdf.Size = new System.Drawing.Size(205, 45);
            this.btnDownloadPdf.TabIndex = 5;
            this.btnDownloadPdf.Text = "ดาวน์โหลด PDF";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BorderRadius = 10;
            this.btnClose.BorderColor = System.Drawing.Color.SaddleBrown;
            this.btnClose.BorderThickness = 1;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnClose.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnClose.Location = new System.Drawing.Point(12, 605);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 45);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "ปิด";
            // 
            // ReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(484, 662);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDownloadPdf);
            this.Controls.Add(this.pnlReceipt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceiptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ใบเสร็จรับเงิน";
            this.pnlReceipt.ResumeLayout(false);
            this.pnlReceipt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReceipt;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblOrderCode;
        private System.Windows.Forms.Label lblItemsHeader;
        private System.Windows.Forms.FlowLayoutPanel flowItemsPanel;
        private System.Windows.Forms.Label lineSeparator;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalHeader;
        private System.Windows.Forms.Label lblFooter;
        private Guna.UI2.WinForms.Guna2Button btnDownloadPdf;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}