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
        public event EventHandler ReportRequested;

        public DashboardView()
        {
            InitializeComponent();
        }

        private void DashboardView_Load(object sender, EventArgs e)
        {
            PopulateDropdowns();

            InitializeDataGridView(dgvTopOrders);
            InitializeDataGridView(dgvTopSelling);

            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            this.btnGoToReport.Click += new System.EventHandler(this.btnGoToReport_Click);

            LoadDashboardData();
        }

        private void PopulateDropdowns()
        {
            cmbYear.Items.Clear();
            int currentYear = DateTime.Today.Year;
            cmbYear.Items.Add("ทุกปี");
            for (int y = currentYear - 2; y <= currentYear + 1; y++)
            {
                cmbYear.Items.Add(y);
            }
            cmbYear.SelectedItem = currentYear;

            cmbMonth.Items.Clear();
            cmbMonth.Items.Add("ทุกเดือน");
            for (int m = 1; m <= 12; m++)
            {
                cmbMonth.Items.Add(new DateTime(2000, m, 1).ToString("MMMM"));
            }
            cmbMonth.SelectedIndex = DateTime.Today.Month;
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void btnGoToReport_Click(object sender, EventArgs e)
        {
            ReportRequested?.Invoke(this, EventArgs.Empty);
        }

        private void InitializeDataGridView(Guna2DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // นี่คือโค้ดที่แก้ไข Error CS1061 (จัดกลางหัวตาราง)
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            string startDate, endDate;
            DateTime today = DateTime.Today;

            int year = (cmbYear.SelectedIndex == 0) ? 0 : Convert.ToInt32(cmbYear.SelectedItem);
            int month = cmbMonth.SelectedIndex;

            if (year == 0)
            {
                year = today.Year;
                if (month == 0)
                {
                    startDate = new DateTime(year, 1, 1).ToString("yyyy-MM-dd");
                    endDate = new DateTime(year, 12, 31).ToString("yyyy-MM-dd");
                }
                else
                {
                    startDate = new DateTime(year, month, 1).ToString("yyyy-MM-dd");
                    endDate = new DateTime(year, month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
                }
            }
            else
            {
                if (month == 0)
                {
                    startDate = new DateTime(year, 1, 1).ToString("yyyy-MM-dd");
                    endDate = new DateTime(year, 12, 31).ToString("yyyy-MM-dd");
                }
                else
                {
                    startDate = new DateTime(year, month, 1).ToString("yyyy-MM-dd");
                    endDate = new DateTime(year, month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
                }
            }

            // 1. ดึงข้อมูลตัวเลขสรุป
            DataTable dtSummary = Db.GetDashboardData(startDate, endDate);
            if (dtSummary.Rows.Count > 0)
            {
                decimal totalSales = (dtSummary.Rows[0]["TotalSales"] != DBNull.Value) ? Convert.ToDecimal(dtSummary.Rows[0]["TotalSales"]) : 0;
                int totalOrders = (dtSummary.Rows[0]["TotalOrders"] != DBNull.Value) ? Convert.ToInt32(dtSummary.Rows[0]["TotalOrders"]) : 0;
                lblTotalSales.Text = totalSales.ToString("N2", CultureInfo.InvariantCulture) + " บาท";
                lblTotalOrders.Text = totalOrders.ToString("N0") + " ออเดอร์";
            }
            else
            {
                lblTotalSales.Text = "0.00 บาท";
                lblTotalOrders.Text = "0 ออเดอร์";
            }

            // 2. ดึงสินค้าใกล้หมด
            int lowStockCount = Db.GetLowStockCount(10);
            lblLowStockCount.Text = lowStockCount.ToString("N0") + " รายการ";

            // 3. ดึง "Top 10 Orders"
            DataTable dtTopOrders = Db.GetTopOrdersByTotal(startDate, endDate, 10);
            dgvTopOrders.DataSource = dtTopOrders;

            // 4. ดึง "Top 10 Selling"
            DataTable dtTopSelling = Db.GetTopSellingProducts(startDate, endDate, 10);
            dgvTopSelling.DataSource = dtTopSelling;

            // 5. จัดรูปแบบตาราง
            FormatTopOrdersGrid();
            FormatTopSellingGrid();
        }

        // [แก้ไข] จัดข้อมูลใน Cell ให้อยู่ "ตรงกลาง"
        private void FormatTopOrdersGrid()
        {
            if (dgvTopOrders.Columns.Contains("ยอดรวม"))
            {
                dgvTopOrders.Columns["ยอดรวม"].DefaultCellStyle.Format = "N2";
                dgvTopOrders.Columns["ยอดรวม"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvTopOrders.Columns.Contains("วันที่สั่งซื้อ"))
            {
                dgvTopOrders.Columns["วันที่สั่งซื้อ"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
                dgvTopOrders.Columns["วันที่สั่งซื้อ"].FillWeight = 120;
                dgvTopOrders.Columns["วันที่สั่งซื้อ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvTopOrders.Columns.Contains("User"))
            {
                dgvTopOrders.Columns["User"].FillWeight = 80;
                dgvTopOrders.Columns["User"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvTopOrders.Columns.Contains("รหัสออเดอร์"))
            {
                dgvTopOrders.Columns["รหัสออเดอร์"].FillWeight = 110;
                dgvTopOrders.Columns["รหัสออเดอร์"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // [แก้ไข] จัดข้อมูลใน Cell ให้อยู่ "ตรงกลาง"
        private void FormatTopSellingGrid()
        {
            if (dgvTopSelling.Columns.Contains("ชื่อสินค้า"))
            {
                dgvTopSelling.Columns["ชื่อสินค้า"].FillWeight = 150;
                dgvTopSelling.Columns["ชื่อสินค้า"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvTopSelling.Columns.Contains("จำนวนที่ขายได้"))
            {
                dgvTopSelling.Columns["จำนวนที่ขายได้"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTopSelling.Columns["จำนวนที่ขายได้"].FillWeight = 80;
            }
            if (dgvTopSelling.Columns.Contains("ยอดขายรวม"))
            {
                dgvTopSelling.Columns["ยอดขายรวม"].DefaultCellStyle.Format = "N2";
                dgvTopSelling.Columns["ยอดขายรวม"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTopSelling.Columns["ยอดขายรวม"].FillWeight = 90;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}