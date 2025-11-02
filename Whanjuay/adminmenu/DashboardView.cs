using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Whanjuay
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
        }

        private void DashboardView_Load(object sender, EventArgs e)
        {
            dtpEndDate.Value = DateTime.Today;
            dtpStartDate.Value = DateTime.Today.AddDays(-6);

            InitializeDataGridView(dgvRecentOrders);
            InitializeDataGridView(dgvTopSelling);

            LoadDashboardData();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void InitializeDataGridView(Guna2DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(249, 243, 237);
            dgv.ThemeStyle.HeaderStyle.ForeColor = Color.SaddleBrown;
            dgv.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dgv.ThemeStyle.HeaderStyle.Height = 30;

            dgv.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(255, 230, 210);
            dgv.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgv.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            dgv.ThemeStyle.RowsStyle.Height = 28;
        }

        private void LoadDashboardData()
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("วันที่เริ่มต้นต้องไม่มากกว่าวันที่สิ้นสุด", "วันที่ไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string startDate = dtpStartDate.Value.ToString("yyyy-MM-dd");
            string endDate = dtpEndDate.Value.ToString("yyyy-MM-dd");

            // 1. ดึงข้อมูลตัวเลขสรุป
            DataTable dtSummary = Db.GetDashboardData(startDate, endDate);

            if (dtSummary.Rows.Count > 0)
            {
                decimal totalSales = 0;
                int totalOrders = 0;

                if (dtSummary.Rows[0]["TotalSales"] != DBNull.Value)
                {
                    totalSales = Convert.ToDecimal(dtSummary.Rows[0]["TotalSales"]);
                }
                if (dtSummary.Rows[0]["TotalOrders"] != DBNull.Value)
                {
                    totalOrders = Convert.ToInt32(dtSummary.Rows[0]["TotalOrders"]);
                }

                lblTotalSales.Text = totalSales.ToString("N2", CultureInfo.InvariantCulture) + " บาท";
                lblTotalOrders.Text = totalOrders.ToString("N0") + " ออเดอร์";
            }
            else
            {
                lblTotalSales.Text = "0.00 บาท";
                lblTotalOrders.Text = "0 ออเดอร์";
            }

            // =================================================================
            // [แก้ไข] เปลี่ยนเกณฑ์แจ้งเตือนจาก 5 เป็น 10
            // =================================================================
            int lowStockCount = Db.GetLowStockCount(10);
            lblLowStockCount.Text = lowStockCount.ToString("N0") + " รายการ";

            // 3. ดึงรายการออเดอร์ล่าสุด 10 รายการ
            DataTable dtRecentOrders = Db.GetRecentOrders(10);
            dgvRecentOrders.DataSource = dtRecentOrders;

            // 4. [ใหม่] ดึงสินค้าขายดี (ตามช่วงวันที่)
            DataTable dtTopSelling = Db.GetTopSellingProducts(startDate, endDate, 5);
            dgvTopSelling.DataSource = dtTopSelling;

            // 5. จัดรูปแบบ DataGridViews
            FormatRecentOrdersGrid();
            FormatTopSellingGrid();
        }

        private void FormatRecentOrdersGrid()
        {
            if (dgvRecentOrders.Columns.Contains("ยอดรวม"))
            {
                dgvRecentOrders.Columns["ยอดรวม"].DefaultCellStyle.Format = "N2";
                dgvRecentOrders.Columns["ยอดรวม"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvRecentOrders.Columns.Contains("วันที่สั่งซื้อ"))
            {
                dgvRecentOrders.Columns["วันที่สั่งซื้อ"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
                dgvRecentOrders.Columns["วันที่สั่งซื้อ"].FillWeight = 120; // ให้กว้างขึ้น
            }
            if (dgvRecentOrders.Columns.Contains("สลิป"))
            {
                foreach (DataGridViewRow row in dgvRecentOrders.Rows)
                {
                    if (row.Cells["สลิป"].Value != null)
                    {
                        string slipPath = row.Cells["สลิป"].Value.ToString();
                        row.Cells["สลิป"].Value = string.IsNullOrEmpty(slipPath) ? "ยังไม่เห็นสลิป" : "มีสลิปแล้ว";
                    }
                    else
                    {
                        row.Cells["สลิป"].Value = "N/A";
                    }
                }
            }
        }

        private void FormatTopSellingGrid()
        {
            if (dgvTopSelling.Columns.Contains("ชื่อสินค้า"))
            {
                dgvTopSelling.Columns["ชื่อสินค้า"].FillWeight = 150; // ให้กว้างขึ้น
            }
            if (dgvTopSelling.Columns.Contains("จำนวนที่ขายได้"))
            {
                dgvTopSelling.Columns["จำนวนที่ขายได้"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTopSelling.Columns["จำนวนที่ขายได้"].FillWeight = 80;
            }
            if (dgvTopSelling.Columns.Contains("ยอดขายรวม"))
            {
                dgvTopSelling.Columns["ยอดขายรวม"].DefaultCellStyle.Format = "N2";
                dgvTopSelling.Columns["ยอดขายรวม"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvTopSelling.Columns["ยอดขายรวม"].FillWeight = 90;
            }
        }
    }
}