using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
// --- [iTextSharp] ---
using iTextSharp.text;
using iTextSharp.text.pdf;
// [เพิ่มใหม่]
using System.Diagnostics;

namespace Whanjuay
{
    public partial class ReceiptForm : Form
    {
        private string _orderCode;
        private DataTable _dtOrder;
        private DataTable _dtItems;

        private iTextSharp.text.Font fontThai;
        private iTextSharp.text.Font fontThaiBold;
        private iTextSharp.text.Font fontThaiSmallGray;

        private string _generatedPdfPath = null;

        public ReceiptForm(string orderCode)
        {
            InitializeComponent();
            _orderCode = orderCode;

            this.Load += ReceiptForm_Load;
            this.btnDownloadPdf.Click += new System.EventHandler(this.btnDownloadPdf_Click);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            LoadThaiFonts();

            try
            {
                // 1. ดึงข้อมูล Order หลัก
                _dtOrder = Db.GetOrderDetails(_orderCode);
                if (_dtOrder.Rows.Count == 0)
                {
                    MessageBox.Show("ไม่พบข้อมูลคำสั่งซื้อ");
                    this.Close();
                    return;
                }

                DataRow orderRow = _dtOrder.Rows[0];
                int orderId = Convert.ToInt32(orderRow["order_id"]);

                // 2. แสดงข้อมูลหลัก (หน้า WinForm)
                lblUsername.Text = "ผู้ใช้งาน: " + orderRow["username"].ToString();
                lblOrderCode.Text = "Order ID: " + orderRow["order_code"].ToString();
                lblDate.Text = "วันที่: " + Convert.ToDateTime(orderRow["order_date"]).ToString("yyyy-MM-dd HH:mm:ss");
                lblTotal.Text = Convert.ToDecimal(orderRow["total_amount"]).ToString("N2") + " บาท";
                lblFooter.Text = "ทาน WHANJUAY ให้อร่อยนะค้าบ";

                // 3. ดึงข้อมูลรายการสินค้า
                _dtItems = Db.GetOrderItemsDetails(orderId);

                // 4. วนลูปสร้าง Label รายการสินค้า (โค้ดส่วนนี้เหมือนเดิม)
                flowItemsPanel.Controls.Clear();
                foreach (DataRow itemRow in _dtItems.Rows) // <--- ลูปนี้ (สำหรับ WinForm) ถูกต้องอยู่แล้ว
                {
                    decimal subTotal = Convert.ToDecimal(itemRow["sub_total"]);
                    int quantity = Convert.ToInt32(itemRow["quantity"]);

                    Panel pnlTitlePrice = new Panel { Height = 20, Width = flowItemsPanel.Width - 10, Margin = new Padding(0, 3, 0, 0) };
                    Label lblItemName = new Label { Text = $"• {itemRow["display_name"]} x{quantity}", Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold), ForeColor = Color.Black, AutoSize = true, Location = new Point(0, 3) };
                    Label lblItemTotal = new Label { Text = $"{subTotal:N2} บาท", Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold), ForeColor = Color.Black, AutoSize = false, Width = 100, Height = 20, TextAlign = ContentAlignment.MiddleRight, Location = new Point(pnlTitlePrice.Width - 100 - 5, 3) };
                    pnlTitlePrice.Controls.Add(lblItemName);
                    pnlTitlePrice.Controls.Add(lblItemTotal);

                    FlowLayoutPanel pnlItemBlock = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true, WrapContents = false, Width = flowItemsPanel.Width - 10, Margin = new Padding(0) };
                    pnlItemBlock.Controls.Add(pnlTitlePrice);

                    string details = itemRow["details"]?.ToString();
                    if (!string.IsNullOrEmpty(details))
                    {
                        FlowLayoutPanel pnlDetails = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true, Width = pnlItemBlock.Width, Margin = new Padding(20, 0, 0, 5), Padding = new Padding(0) };
                        string[] detailLines = details.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string line in detailLines)
                        {
                            string cleanedLine = line.Replace("•", "").Trim();
                            if (!string.IsNullOrEmpty(cleanedLine))
                            {
                                Label lblDetail = new Label { Text = "• " + cleanedLine, Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular), ForeColor = Color.Gray, AutoSize = true, Margin = new Padding(0, 0, 0, 2) };
                                pnlDetails.Controls.Add(lblDetail);
                            }
                        }
                        pnlItemBlock.Controls.Add(pnlDetails);
                    }
                    flowItemsPanel.Controls.Add(pnlItemBlock);
                }

                // 5. สร้าง PDF และบันทึก Path ลง DB อัตโนมัติ
                if (_dtOrder.Rows.Count > 0 && _dtItems.Rows.Count > 0)
                {
                    _generatedPdfPath = GenerateAndSaveReceiptPdf(
                        _orderCode,
                        _dtOrder.Rows[0],
                        _dtItems // <--- ส่ง DataTable
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดใบเสร็จ: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadThaiFonts()
        {
            try
            {
                string fontFileName = "tahoma.ttf";
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), fontFileName);

                if (!File.Exists(fontPath))
                {
                    fontFileName = "AngsanaNew.ttf";
                    fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), fontFileName);
                }

                if (!File.Exists(fontPath))
                {
                    // Fallback ถ้าหาฟอนต์ไม่เจอจริงๆ
                    throw new Exception("ไม่พบฟอนต์ 'tahoma.ttf' หรือ 'AngsanaNew.ttf'");
                }

                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                fontThai = new iTextSharp.text.Font(bf, 12, (int)iTextSharp.text.Font.NORMAL);
                fontThaiBold = new iTextSharp.text.Font(bf, 14, (int)iTextSharp.text.Font.BOLD);
                fontThaiSmallGray = new iTextSharp.text.Font(bf, 9, (int)iTextSharp.text.Font.NORMAL, BaseColor.GRAY);
            }
            catch
            {
                fontThai = FontFactory.GetFont(FontFactory.HELVETICA, 12, (int)iTextSharp.text.Font.NORMAL);
                fontThaiBold = FontFactory.GetFont(FontFactory.HELVETICA, 14, (int)iTextSharp.text.Font.BOLD);
                fontThaiSmallGray = FontFactory.GetFont(FontFactory.HELVETICA, 9, (int)iTextSharp.text.Font.NORMAL, BaseColor.GRAY);
                MessageBox.Show("ไม่พบฟอนต์ภาษาไทย Tahoma/AngsanaNew ในระบบ\nPDF อาจแสดงผลผิดพลาด", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // [แก้ไข] เมธอดนี้รับ DataTable
        private string GenerateAndSaveReceiptPdf(string orderCode, DataRow orderRow, DataTable dtItems)
        {
            string relativeReceiptPath = $"Receipts/Receipt-{orderCode}.pdf";
            string destinationFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Receipts");
            Directory.CreateDirectory(destinationFolder);

            string fullPath = Path.Combine(destinationFolder, $"Receipt-{orderCode}.pdf");

            try
            {
                // --- 1. สร้างไฟล์ PDF ---
                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // --- 1. โลโก้ ---
                    try
                    {
                        System.Drawing.Image logoImg = global::Whanjuay.Properties.Resources.logowj;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            logoImg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            iTextSharp.text.Image pdfLogo = iTextSharp.text.Image.GetInstance(ms.ToArray());
                            pdfLogo.ScaleToFit(200f, 80f);
                            pdfLogo.Alignment = Element.ALIGN_CENTER;
                            pdfDoc.Add(pdfLogo);
                        }
                    }
                    catch { /* ข้ามไปถ้าโหลดโลโก้ไม่ได้ */ }

                    // --- 2. หัวกระดาษ ---
                    Paragraph header = new Paragraph("ใบเสร็จรับเงิน (Receipt)", fontThaiBold);
                    header.Alignment = Element.ALIGN_CENTER;
                    header.SpacingBefore = 10f;
                    pdfDoc.Add(header);

                    // --- 3. ข้อมูล Order ---
                    Paragraph pUser = new Paragraph("ผู้ใช้งาน: " + orderRow["username"].ToString(), fontThai);
                    pUser.SpacingBefore = 10f;
                    pdfDoc.Add(pUser);
                    pdfDoc.Add(new Paragraph("Order ID: " + orderRow["order_code"].ToString(), fontThai));
                    pdfDoc.Add(new Paragraph("วันที่: " + Convert.ToDateTime(orderRow["order_date"]).ToString("yyyy-MM-dd HH:mm:ss"), fontThai));

                    // --- 4. ตารางรายการสินค้า ---
                    pdfDoc.Add(new Paragraph(" ", fontThai));
                    PdfPTable table = new PdfPTable(3);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 60f, 15f, 25f });

                    // หัวตาราง
                    table.AddCell(new PdfPCell(new Phrase("รายการ", fontThaiBold)) { Border = 0, PaddingBottom = 5f });
                    table.AddCell(new PdfPCell(new Phrase("จํานวน", fontThaiBold)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 5f });
                    table.AddCell(new PdfPCell(new Phrase("ราคา", fontThaiBold)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 5f });

                    PdfPCell lineCellHeader = new PdfPCell(new Phrase(" ", fontThai)) { Colspan = 3, Border = 1, BorderWidthTop = 1f, BorderColor = BaseColor.BLACK, Padding = 0f, PaddingBottom = 5f };
                    table.AddCell(lineCellHeader);


                    // ==========================================================
                    // --- [แก้ไข] บรรทัดนี้คือจุดที่แก้ไข ---
                    // ข้อมูลสินค้า (วนลูปจาก .Rows)
                    foreach (DataRow itemRow in dtItems.Rows) // <--- แก้ไขจาก 'dtItems' เป็น 'dtItems.Rows'
                    {
                        // ==========================================================

                        table.AddCell(new PdfPCell(new Phrase(itemRow["display_name"].ToString(), fontThai)) { Border = 0, PaddingTop = 5f });
                        table.AddCell(new PdfPCell(new Phrase(itemRow["quantity"].ToString(), fontThai)) { Border = 0, PaddingTop = 5f, HorizontalAlignment = Element.ALIGN_RIGHT });
                        table.AddCell(new PdfPCell(new Phrase(Convert.ToDecimal(itemRow["sub_total"]).ToString("N2"), fontThai)) { Border = 0, PaddingTop = 5f, HorizontalAlignment = Element.ALIGN_RIGHT });

                        // รายละเอียด
                        string details = itemRow["details"]?.ToString();
                        if (!string.IsNullOrEmpty(details))
                        {
                            PdfPCell detailCell = new PdfPCell { Border = 0, Colspan = 3, PaddingLeft = 20f, PaddingTop = 0f, PaddingBottom = 5f };
                            string[] detailLines = details.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string line in detailLines)
                            {
                                string cleanedLine = line.Replace("•", "").Trim();
                                if (!string.IsNullOrEmpty(cleanedLine))
                                {
                                    detailCell.AddElement(new Paragraph("• " + cleanedLine, fontThaiSmallGray));
                                }
                            }
                            table.AddCell(detailCell);
                        }
                    }

                    PdfPCell emptySpacerCell = new PdfPCell(new Phrase(" ", fontThai)) { Colspan = 3, Border = 0, Padding = 0, PaddingBottom = 5f };
                    table.AddCell(emptySpacerCell);
                    PdfPCell lineCellFooter = new PdfPCell(new Phrase(" ", fontThai)) { Colspan = 3, Border = 1, BorderWidthTop = 1f, BorderColor = BaseColor.BLACK, PaddingTop = 10f };
                    table.AddCell(lineCellFooter);

                    // --- 5. ยอดรวม ---
                    table.AddCell(new PdfPCell(new Phrase("รวมยอดเงิน:", fontThaiBold)) { Border = 0, Colspan = 2, HorizontalAlignment = Element.ALIGN_RIGHT });
                    table.AddCell(new PdfPCell(new Phrase(Convert.ToDecimal(orderRow["total_amount"]).ToString("N2") + " บาท", fontThaiBold)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    pdfDoc.Add(table);

                    // --- 6. Footer ---
                    Paragraph footer = new Paragraph("ทาน WHANJUAY ให้อร่อยนะค้าบ", fontThai);
                    footer.Alignment = Element.ALIGN_CENTER;
                    footer.SpacingBefore = 20f;
                    pdfDoc.Add(footer);

                    pdfDoc.Close();
                    writer.Close();
                }

                // --- 2. บันทึก Path ลง DB ---
                Db.UpdateOrderReceiptPath(orderCode, relativeReceiptPath);

                return fullPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการสร้างไฟล์ PDF: " + ex.Message, "PDF Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        private void btnDownloadPdf_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_generatedPdfPath) || !File.Exists(_generatedPdfPath))
            {
                MessageBox.Show("ไม่พบไฟล์ PDF ที่สร้างไว้ (อาจเกิดข้อผิดพลาดตอนโหลดอัตโนมัติ)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF file (*.pdf)|*.pdf";
                sfd.FileName = Path.GetFileName(_generatedPdfPath);

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(_generatedPdfPath, sfd.FileName, true);
                        MessageBox.Show("บันทึกไฟล์ PDF สำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการคัดลอก PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}