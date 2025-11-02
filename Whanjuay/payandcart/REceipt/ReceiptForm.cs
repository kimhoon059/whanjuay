using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
// --- [iTextSharp] ---
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Whanjuay
{
    public partial class ReceiptForm : Form
    {
        private string _orderCode;
        private DataTable _dtOrder;
        private DataTable _dtItems;

        // เราจะไม่ใช้ alias Font เพราะมันทำให้เกิด Error
        private iTextSharp.text.Font fontThai;
        private iTextSharp.text.Font fontThaiBold;
        private iTextSharp.text.Font fontThaiSmallGray;

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
            // โหลด Font ไทยสำหรับ PDF
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

                // ปรับรวมยอดเงินให้มีหน่วย "บาท"
                lblTotal.Text = Convert.ToDecimal(orderRow["total_amount"]).ToString("N2") + " บาท";

                // ปรับข้อความ Footer ใน WinForm
                lblFooter.Text = "ทาน WHANJUAY ให้อร่อยนะค้าบ";

                // 3. ดึงข้อมูลรายการสินค้า
                _dtItems = Db.GetOrderItemsDetails(orderId);

                // 4. วนลูปสร้าง Label รายการสินค้า
                flowItemsPanel.Controls.Clear();
                foreach (DataRow itemRow in _dtItems.Rows)
                {
                    decimal subTotal = Convert.ToDecimal(itemRow["sub_total"]);
                    int quantity = Convert.ToInt32(itemRow["quantity"]);

                    // --- A) แถวชื่อสินค้า + ราคา (ใช้ Panel ย่อยเพื่อจัดซ้าย-ขวา) ---
                    Panel pnlTitlePrice = new Panel();
                    pnlTitlePrice.AutoSize = false;
                    pnlTitlePrice.Height = 20;
                    pnlTitlePrice.Width = flowItemsPanel.Width - 10;
                    pnlTitlePrice.Margin = new Padding(0, 3, 0, 0);

                    // A.1) Label ชื่อสินค้า (ชิดซ้าย)
                    Label lblItemName = new Label();
                    lblItemName.Text = $"• {itemRow["display_name"]} x{quantity}";
                    lblItemName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                    lblItemName.ForeColor = Color.Black;
                    lblItemName.AutoSize = true;
                    lblItemName.Location = new Point(0, 3);
                    pnlTitlePrice.Controls.Add(lblItemName);

                    // A.2) Label ราคารวม (ชิดขวา)
                    Label lblItemTotal = new Label();
                    lblItemTotal.Text = $"{subTotal:N2} บาท";
                    lblItemTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                    lblItemTotal.ForeColor = Color.Black;
                    lblItemTotal.AutoSize = false;
                    lblItemTotal.Width = 100;
                    lblItemTotal.Height = 20;
                    lblItemTotal.TextAlign = ContentAlignment.MiddleRight;
                    lblItemTotal.Location = new Point(pnlTitlePrice.Width - lblItemTotal.Width - 5, 3);
                    pnlTitlePrice.Controls.Add(lblItemTotal);

                    // --- เพิ่ม Panel ย่อยเข้า FlowLayoutPanel หลัก ---
                    FlowLayoutPanel pnlItemBlock = new FlowLayoutPanel();
                    pnlItemBlock.FlowDirection = FlowDirection.TopDown;
                    pnlItemBlock.AutoSize = true;
                    pnlItemBlock.WrapContents = false;
                    pnlItemBlock.Width = flowItemsPanel.Width - 10;
                    pnlItemBlock.Margin = new Padding(0);
                    pnlItemBlock.Controls.Add(pnlTitlePrice);

                    // --- B) รายละเอียด (ตัวหนังสือสีเทา) ---
                    string details = itemRow["details"]?.ToString();
                    if (!string.IsNullOrEmpty(details))
                    {
                        FlowLayoutPanel pnlDetails = new FlowLayoutPanel();
                        pnlDetails.FlowDirection = FlowDirection.TopDown;
                        pnlDetails.AutoSize = true;
                        pnlDetails.Width = pnlItemBlock.Width;
                        pnlDetails.Margin = new Padding(20, 0, 0, 5); // Margin คงที่ 20
                        pnlDetails.Padding = new Padding(0);

                        string[] detailLines = details.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string line in detailLines)
                        {
                            string cleanedLine = line.Replace("•", "").Trim();
                            if (!string.IsNullOrEmpty(cleanedLine))
                            {
                                Label lblDetail = new Label();
                                lblDetail.Text = "• " + cleanedLine;
                                lblDetail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
                                lblDetail.ForeColor = Color.Gray;
                                lblDetail.AutoSize = true;
                                lblDetail.Margin = new Padding(0, 0, 0, 2);
                                pnlDetails.Controls.Add(lblDetail);
                            }
                        }
                        pnlItemBlock.Controls.Add(pnlDetails);
                    }

                    // --- เพิ่ม Item Block เข้า FlowLayoutPanel หลัก ---
                    flowItemsPanel.Controls.Add(pnlItemBlock);
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

        // --- [FIX] ปรับปรุง LoadThaiFonts ให้ใช้ TAHOMA/ANGSANA ที่เสถียร ---
        private void LoadThaiFonts()
        {
            try
            {
                // [FIX] บังคับใช้ TAHOMA ซึ่งเป็นฟอนต์ที่เสถียรที่สุดสำหรับ iTextSharp
                string fontFileName = "tahoma.ttf";
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), fontFileName);

                if (!File.Exists(fontPath))
                {
                    // Fallback: หากไม่พบ Tahoma จริงๆ ให้ลองหา AngsanaNew
                    fontFileName = "AngsanaNew.ttf";
                    fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), fontFileName);
                }

                // ใช้ IDENTITY_H เพื่อรองรับการเข้ารหัสภาษาเอเชีย
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                // ใช้ค่าคงที่ที่เป็นตัวเลข (0=NORMAL, 1=BOLD)
                fontThai = new iTextSharp.text.Font(bf, 12, (int)iTextSharp.text.Font.NORMAL);
                fontThaiBold = new iTextSharp.text.Font(bf, 14, (int)iTextSharp.text.Font.BOLD);
                fontThaiSmallGray = new iTextSharp.text.Font(bf, 9, (int)iTextSharp.text.Font.NORMAL, BaseColor.GRAY);
            }
            catch
            {
                // Fallback: ใช้ฟอนต์ Helvetica (กรณีฉุกเฉิน)
                fontThai = FontFactory.GetFont(FontFactory.HELVETICA, 12, (int)iTextSharp.text.Font.NORMAL);
                fontThaiBold = FontFactory.GetFont(FontFactory.HELVETICA, 14, (int)iTextSharp.text.Font.BOLD);
                fontThaiSmallGray = FontFactory.GetFont(FontFactory.HELVETICA, 9, (int)iTextSharp.text.Font.NORMAL, BaseColor.GRAY);
                MessageBox.Show("ไม่พบฟอนต์ภาษาไทย Tahoma/AngsanaNew ในระบบ\nPDF อาจแสดงผลผิดพลาด", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDownloadPdf_Click(object sender, EventArgs e)
        {
            if (_dtOrder == null || _dtItems == null)
            {
                MessageBox.Show("ข้อมูลใบเสร็จไม่พร้อมใช้งาน", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF file (*.pdf)|*.pdf";
                sfd.FileName = $"Receipt-{_orderCode}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DataRow orderRow = _dtOrder.Rows[0];

                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();

                            // --- 1. โลโก้ ---
                            iTextSharp.text.Image pdfLogo;
                            try
                            {
                                System.Drawing.Image logoImg = global::Whanjuay.Properties.Resources.logowj;
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    logoImg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    pdfLogo = iTextSharp.text.Image.GetInstance(ms.ToArray());
                                }
                                pdfLogo.ScaleToFit(200f, 80f);
                                pdfLogo.Alignment = Element.ALIGN_CENTER;
                                pdfDoc.Add(pdfLogo);
                            }
                            catch (Exception)
                            {
                                // ถ้าโหลดรูปไม่ได้ ก็ข้ามไป
                            }


                            // --- 2. หัวกระดาษ ---
                            Paragraph header = new Paragraph("ใบเสร็จรับเงิน (Receipt)", fontThaiBold);
                            header.Alignment = Element.ALIGN_CENTER;
                            header.SpacingBefore = 10f;
                            pdfDoc.Add(header);

                            // --- 3. ข้อมูล Order ---
                            Paragraph pUser = new Paragraph("ผู้ใช้งาน: " + orderRow["username"].ToString(), fontThai);
                            pUser.SpacingBefore = 10f;
                            pdfDoc.Add(pUser);
                            // [แก้ไข 2] เปลี่ยนเป็น "คำสั่งซื้อ:"
                            pdfDoc.Add(new Paragraph("Order ID: " + orderRow["order_code"].ToString(), fontThai));
                            pdfDoc.Add(new Paragraph("วันที่: " + Convert.ToDateTime(orderRow["order_date"]).ToString("yyyy-MM-dd HH:mm:ss"), fontThai));

                            // --- 4. ตารางรายการสินค้า ---
                            pdfDoc.Add(new Paragraph(" ", fontThai)); // เว้นวรรค
                            PdfPTable table = new PdfPTable(3); // 3 คอลัมน์ (รายการ, จำนวน, ราคา)
                            table.WidthPercentage = 100;
                            table.SetWidths(new float[] { 60f, 15f, 25f });

                            // หัวตาราง
                            table.AddCell(new PdfPCell(new Phrase("รายการ", fontThaiBold)) { Border = 0, PaddingBottom = 5f });
                            table.AddCell(new PdfPCell(new Phrase("จำนวน", fontThaiBold)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 5f });
                            table.AddCell(new PdfPCell(new Phrase("ราคา", fontThaiBold)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 5f });

                            // เส้นใต้หัวตาราง 
                            PdfPCell lineCellHeader = new PdfPCell(new Phrase(" ", fontThai));
                            lineCellHeader.Colspan = 3;
                            lineCellHeader.Border = 1;
                            lineCellHeader.BorderWidthTop = 1f;
                            lineCellHeader.BorderColor = BaseColor.BLACK;
                            lineCellHeader.Padding = 0f;
                            lineCellHeader.PaddingBottom = 5f;
                            table.AddCell(lineCellHeader);


                            // ข้อมูลสินค้า
                            foreach (DataRow itemRow in _dtItems.Rows)
                            {
                                // ชื่อ
                                table.AddCell(new PdfPCell(new Phrase(itemRow["display_name"].ToString(), fontThai)) { Border = 0, PaddingTop = 5f });
                                // จำนวน
                                table.AddCell(new PdfPCell(new Phrase(itemRow["quantity"].ToString(), fontThai)) { Border = 0, PaddingTop = 5f, HorizontalAlignment = Element.ALIGN_RIGHT });
                                // ราคา (รวม)
                                table.AddCell(new PdfPCell(new Phrase(Convert.ToDecimal(itemRow["sub_total"]).ToString("N2"), fontThai)) { Border = 0, PaddingTop = 5f, HorizontalAlignment = Element.ALIGN_RIGHT });

                                // รายละเอียด (ถ้ามี)
                                string details = itemRow["details"]?.ToString();
                                if (!string.IsNullOrEmpty(details))
                                {
                                    // สร้างรายการย่อย (List of items)
                                    PdfPCell detailCell = new PdfPCell();
                                    detailCell.Border = 0;
                                    detailCell.Colspan = 3;
                                    // [FIX A] เพิ่ม PaddingLeft ให้เยื้องเข้ามามากพอสมควร (20f)
                                    detailCell.PaddingLeft = 20f;
                                    detailCell.PaddingTop = 0f;
                                    detailCell.PaddingBottom = 5f; // ระยะห่างใต้รายการย่อย

                                    // แยกแต่ละบรรทัดรายละเอียดแล้วเพิ่มเข้าไปใน Cell
                                    string[] detailLines = details.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                                    foreach (string line in detailLines)
                                    {
                                        // ตัดเครื่องหมาย bullet (•) และ trim whitespace
                                        string cleanedLine = line.Replace("•", "").Trim();
                                        if (!string.IsNullOrEmpty(cleanedLine))
                                        {
                                            detailCell.AddElement(new Paragraph("• " + cleanedLine, fontThaiSmallGray));
                                        }
                                    }
                                    table.AddCell(detailCell);
                                }
                            }

                            // --- [FIX B] เพิ่ม Cell ว่างๆ เพื่อเว้นบรรทัดก่อนเส้นขีดสุดท้าย ---
                            PdfPCell emptySpacerCell = new PdfPCell(new Phrase(" ", fontThai));
                            emptySpacerCell.Colspan = 3;
                            emptySpacerCell.Border = 0; // ไม่มีเส้น
                            emptySpacerCell.Padding = 0;
                            emptySpacerCell.PaddingBottom = 5f; // เว้นระยะ 5f
                            table.AddCell(emptySpacerCell);

                            // เส้นขั้นก่อนรวมยอด 
                            PdfPCell lineCellFooter = new PdfPCell(new Phrase(" ", fontThai));
                            lineCellFooter.Colspan = 3;
                            lineCellFooter.Border = 1;
                            lineCellFooter.BorderWidthTop = 1f;
                            lineCellFooter.BorderColor = BaseColor.BLACK;
                            lineCellFooter.PaddingTop = 10f;
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

                        MessageBox.Show("บันทึกไฟล์ PDF สำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการสร้าง PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}