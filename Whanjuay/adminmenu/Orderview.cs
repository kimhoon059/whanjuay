using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Whanjuay
{
    public partial class Orderview : UserControl
    {
        public Orderview()
        {
            InitializeComponent();

            dgvPendingOrders.AutoGenerateColumns = false;

            this.Load += Orderview_Load;
            dgvPendingOrders.CellContentClick += dgvPendingOrders_CellContentClick;
            btnRefresh.Click += btnRefresh_Click;

            // [เพิ่มใหม่] ผูก Event สำหรับใส่เลขลำดับ
            dgvPendingOrders.CellFormatting += dgvPendingOrders_CellFormatting;
        }

        private void Orderview_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                DataTable dt = Db.GetPendingOrders();
                dgvPendingOrders.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดออเดอร์: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // [เพิ่มใหม่] เมธอดสำหรับใส่เลขลำดับในคอลัมน์ "colRowNumber"
        private void dgvPendingOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // ตรวจสอบว่าเป็นคอลัมน์ "ลำดับ" และไม่ใช่แถว Header
            if (e.ColumnIndex == dgvPendingOrders.Columns["colRowNumber"].Index && e.RowIndex >= 0)
            {
                // e.RowIndex เริ่มจาก 0, ดังนั้น +1
                e.Value = (e.RowIndex + 1).ToString();
                e.FormattingApplied = true;
            }
        }

        private void dgvPendingOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvPendingOrders.Rows[e.RowIndex];

                // [แก้ไข] ดึง Order ID จาก colOrderCodeDisplay ที่เพิ่มมาใหม่ (หรือ colOrderCode ก็ได้เพราะ DataProperty เดียวกัน)
                int orderId = Convert.ToInt32(row.Cells["colOrderId"].Value);
                string orderCode = row.Cells["colOrderCodeDisplay"].Value.ToString(); // ใช้คอลัมน์ที่มองเห็นได้
                string slipPath = row.Cells["colSlipPath"].Value?.ToString();
                string receiptPath = row.Cells["colReceiptPath"].Value?.ToString();

                string colName = dgvPendingOrders.Columns[e.ColumnIndex].Name;

                if (colName == "colOrderList")
                {
                    ShowOrderItems(orderId, orderCode);
                }
                else if (colName == "colSlip")
                {
                    OpenFile(slipPath, "สลิป");
                }
                else if (colName == "colReceipt")
                {
                    // นี่คือปุ่มที่ Error! ตอนนี้ receiptPath ควรจะมีค่าแล้ว
                    OpenFile(receiptPath, "ใบเสร็จ");
                }
                else if (colName == "colComplete")
                {
                    if (MessageBox.Show($"ยืนยันว่าออเดอร์ {orderCode} เสร็จสิ้นแล้ว?\n(ออเดอร์นี้จะย้ายไปอยู่ในหน้า Report)",
                                        "ยืนยันออเดอร์",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Db.UpdateOrderStatus(orderId, "Completed");
                        MessageBox.Show($"ออเดอร์ {orderCode} เสร็จสิ้นแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrders();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenFile(string relativePath, string fileType)
        {
            if (!string.IsNullOrEmpty(relativePath))
            {
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath.Replace('/', Path.DirectorySeparatorChar));

                if (File.Exists(fullPath))
                {
                    System.Diagnostics.Process.Start(fullPath);
                }
                else
                {
                    MessageBox.Show($"ไม่พบไฟล์{fileType}ที่: " + fullPath, "ไม่พบไฟล์", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // [แก้ไข] เปลี่ยนข้อความเป็น "ยังไม่มี" เพื่อให้ชัดเจน
                MessageBox.Show($"ยังไม่มี{fileType}สำหรับรายการนี้", "ไม่มีข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShowOrderItems(int orderId, string orderCode)
        {
            try
            {
                DataTable items = Db.GetOrderItemsDetails(orderId);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"รายการสินค้าสำหรับ Order: {orderCode}\n");

                foreach (DataRow itemRow in items.Rows)
                {
                    sb.AppendLine($"• {itemRow["display_name"]} (x{itemRow["quantity"]}) - {Convert.ToDecimal(itemRow["sub_total"]):N2} บาท");

                    string details = itemRow["details"]?.ToString();
                    if (!string.IsNullOrEmpty(details))
                    {
                        using (StringReader reader = new StringReader(details))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                sb.AppendLine($"    {line.Trim()}");
                            }
                        }
                    }
                }
                MessageBox.Show(sb.ToString(), "รายการสั่งซื้อ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการดึงรายการสินค้า: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}