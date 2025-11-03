using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;    // (จำเป็นสำหรับ StringReader)
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whanjuay
{
    public partial class ReportView : UserControl
    {
        public ReportView()
        {
            InitializeComponent();
            // [เพิ่ม] ผูก Load Event ที่ขาดหายไป
            this.Load += new System.EventHandler(this.ReportView_Load);
        }

        /// <summary>
        /// เมธอดนี้จะทำงาน "เมื่อโปรแกรมรัน" (ไม่ใช่ใน Designer)
        /// </summary>
        private void ReportView_Load(object sender, EventArgs e)
        {
            // 1. เรียกใช้เมธอดเติมข้อมูล Dropdowns
            PopulateDropdowns();

            // 2. ผูก Event: เมื่อเลือก Dropdown ให้โหลดข้อมูลใหม่
            cmbYear.SelectedIndexChanged += FilterChanged;
            cmbMonth.SelectedIndexChanged += FilterChanged;
            cmbDay.SelectedIndexChanged += FilterChanged;

            // 3. ผูก Event การคลิกปุ่ม "ดูรายการ" ในตาราง
            dgvReport.CellContentClick += dgvReport_CellContentClick;

            // 4. ผูก Event การจัดรูปแบบวันที่
            dgvReport.CellFormatting += dgvReport_CellFormatting;

            // 5. โหลดข้อมูลครั้งแรก (แสดงทั้งหมด)
            LoadReport();
        }

        /// <summary>
        /// เติมตัวเลือก "ทุกปี", "2025", "2024", ... ลงใน Dropdown
        /// </summary>
        private void PopulateDropdowns()
        {
            // --- เติมปี ---
            cmbYear.Items.Add("ทุกปี");
            int currentYear = DateTime.Today.Year;
            for (int y = currentYear - 2; y <= currentYear + 1; y++)
            {
                cmbYear.Items.Add(y);
            }
            cmbYear.SelectedIndex = 0; // ตั้งค่าเริ่มต้นเป็น "ทุกปี"

            // --- เติมเดือน ---
            cmbMonth.Items.Add("ทุกเดือน");
            for (int m = 1; m <= 12; m++)
            {
                // แปลงเลขเดือนเป็นชื่อเดือน (เช่น 1 -> "มกราคม")
                cmbMonth.Items.Add(new DateTime(2000, m, 1).ToString("MMMM"));
            }
            cmbMonth.SelectedIndex = 0; // ตั้งค่าเริ่มต้นเป็น "ทุกเดือน"

            // --- เติมวัน (1-31) ---
            cmbDay.Items.Add("ทุกวัน");
            for (int d = 1; d <= 31; d++)
            {
                cmbDay.Items.Add(d);
            }
            cmbDay.SelectedIndex = 0; // ตั้งค่าเริ่มต้นเป็น "ทุกวัน"
        }

        /// <summary>
        /// Event ที่ถูกเรียกเมื่อ Dropdown ใดๆ ถูกเปลี่ยน
        /// </summary>
        private void FilterChanged(object sender, EventArgs e)
        {
            LoadReport();
        }

        /// <summary>
        /// ดึงข้อมูลจาก DB ตาม Dropdown ที่เลือก
        /// </summary>
        private void LoadReport()
        {
            try
            {
                // 1. อ่านค่าจาก Dropdowns
                int year = (cmbYear.SelectedIndex == 0) ? 0 : (int)cmbYear.SelectedItem;
                int month = cmbMonth.SelectedIndex; // (0 = ทุกเดือน, 1 = มกราคม, ...)
                int day = (cmbDay.SelectedIndex == 0) ? 0 : (int)cmbDay.SelectedItem;

                // 2. เรียกใช้เมธอดจาก Db.cs (ที่ดึง order_id มาด้วย)
                DataTable dt = Db.GetCompletedOrdersReport(year, month, day);

                // 3. แสดงผลในตาราง
                dgvReport.DataSource = dt;

                // 4. คำนวณยอดรวมที่แสดงในตาราง
                decimal total = 0;
                foreach (DataRow row in dt.Rows)
                {
                    total += Convert.ToDecimal(row["ยอดรวม"]);
                }
                lblTotal.Text = $"ยอดรวมที่แสดงผล: {total:N2} บาท";
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลด Report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// จัดการการแสดงผลวันที่ (เพราะเราปิด AutoGenerateColumns)
        /// </summary>
        private void dgvReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvReport.Columns["colDate"].Index && e.Value != null)
            {
                if (e.Value is DateTime)
                {
                    // รูปแบบ: 2/11/2025 10:50 PM
                    e.Value = ((DateTime)e.Value).ToString("d/M/yyyy h:mm tt");
                    e.FormattingApplied = true;
                }
            }
        }

        /// <summary>
        /// Event Handler สำหรับปุ่ม "ดูรายการ"
        /// </summary>
        private void dgvReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // กันคลิกหัวตาราง

            // ตรวจสอบว่าคลิกที่คอลัมน์ปุ่ม "ดูรายการ"
            if (e.ColumnIndex == dgvReport.Columns["colOrderList"].Index)
            {
                try
                {
                    // ดึง ID และ Code จากคอลัมน์
                    int orderId = Convert.ToInt32(dgvReport.Rows[e.RowIndex].Cells["colOrderIdHidden"].Value);
                    string orderCode = dgvReport.Rows[e.RowIndex].Cells["colOrderID"].Value.ToString();

                    ShowOrderItems(orderId, orderCode);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// เมธอดแสดงรายการสินค้าใน MessageBox (คัดลอกจาก Orderview.cs)
        /// </summary>
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