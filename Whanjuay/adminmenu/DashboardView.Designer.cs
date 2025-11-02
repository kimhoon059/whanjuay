namespace Whanjuay
{
    partial class DashboardView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSales = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlOrders = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlLowStock = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLowStockCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRecentOrders = new System.Windows.Forms.Label();
            this.dgvRecentOrders = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadData = new Guna.UI2.WinForms.Guna2Button();
            this.dgvTopSelling = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSales.SuspendLayout();
            this.pnlOrders.SuspendLayout();
            this.pnlLowStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSelling)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "จากวันที่:";
            // 
            // pnlSales
            // 
            this.pnlSales.BackColor = System.Drawing.Color.Transparent;
            this.pnlSales.BorderRadius = 10;
            this.pnlSales.Controls.Add(this.lblTotalSales);
            this.pnlSales.Controls.Add(this.label4);
            this.pnlSales.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlSales.Location = new System.Drawing.Point(16, 46);
            this.pnlSales.Name = "pnlSales";
            this.pnlSales.Size = new System.Drawing.Size(220, 100);
            this.pnlSales.TabIndex = 5;
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalSales.Location = new System.Drawing.Point(3, 40);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(214, 30);
            this.lblTotalSales.TabIndex = 1;
            this.lblTotalSales.Text = "0.00 บาท";
            this.lblTotalSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(59, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "ยอดขายรวม";
            // 
            // pnlOrders
            // 
            this.pnlOrders.BackColor = System.Drawing.Color.Transparent;
            this.pnlOrders.BorderRadius = 10;
            this.pnlOrders.Controls.Add(this.lblTotalOrders);
            this.pnlOrders.Controls.Add(this.label5);
            this.pnlOrders.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlOrders.Location = new System.Drawing.Point(242, 46);
            this.pnlOrders.Name = "pnlOrders";
            this.pnlOrders.Size = new System.Drawing.Size(220, 100);
            this.pnlOrders.TabIndex = 6;
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotalOrders.Location = new System.Drawing.Point(3, 40);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(214, 30);
            this.lblTotalOrders.TabIndex = 2;
            this.lblTotalOrders.Text = "0 ออเดอร์";
            this.lblTotalOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(55, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "จำนวนออเดอร์";
            // 
            // pnlLowStock
            // 
            this.pnlLowStock.BackColor = System.Drawing.Color.Transparent;
            this.pnlLowStock.BorderRadius = 10;
            this.pnlLowStock.Controls.Add(this.lblLowStockCount);
            this.pnlLowStock.Controls.Add(this.label6);
            this.pnlLowStock.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.pnlLowStock.Location = new System.Drawing.Point(468, 46);
            this.pnlLowStock.Name = "pnlLowStock";
            this.pnlLowStock.Size = new System.Drawing.Size(220, 100);
            this.pnlLowStock.TabIndex = 7;
            // 
            // lblLowStockCount
            // 
            this.lblLowStockCount.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStockCount.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblLowStockCount.Location = new System.Drawing.Point(3, 40);
            this.lblLowStockCount.Name = "lblLowStockCount";
            this.lblLowStockCount.Size = new System.Drawing.Size(214, 30);
            this.lblLowStockCount.TabIndex = 3;
            this.lblLowStockCount.Text = "0 รายการ";
            this.lblLowStockCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(38, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "สินค้าใกล้หมดสต็อก";
            // 
            // lblRecentOrders
            // 
            this.lblRecentOrders.AutoSize = true;
            this.lblRecentOrders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecentOrders.Location = new System.Drawing.Point(12, 160);
            this.lblRecentOrders.Name = "lblRecentOrders";
            this.lblRecentOrders.Size = new System.Drawing.Size(144, 21);
            this.lblRecentOrders.TabIndex = 8;
            this.lblRecentOrders.Text = "รายการออเดอร์ล่าสุด";
            // 
            // dgvRecentOrders
            // 
            this.dgvRecentOrders.AllowUserToAddRows = false;
            this.dgvRecentOrders.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvRecentOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecentOrders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecentOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecentOrders.ColumnHeadersHeight = 30;
            this.dgvRecentOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecentOrders.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRecentOrders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRecentOrders.Location = new System.Drawing.Point(16, 184);
            this.dgvRecentOrders.Name = "dgvRecentOrders";
            this.dgvRecentOrders.ReadOnly = true;
            this.dgvRecentOrders.RowHeadersVisible = false;
            this.dgvRecentOrders.RowTemplate.Height = 28;
            this.dgvRecentOrders.Size = new System.Drawing.Size(446, 303);
            this.dgvRecentOrders.TabIndex = 9;
            this.dgvRecentOrders.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecentOrders.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvRecentOrders.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvRecentOrders.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvRecentOrders.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvRecentOrders.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecentOrders.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRecentOrders.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(237)))));
            this.dgvRecentOrders.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRecentOrders.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRecentOrders.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.SaddleBrown;
            this.dgvRecentOrders.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvRecentOrders.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvRecentOrders.ThemeStyle.ReadOnly = true;
            this.dgvRecentOrders.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecentOrders.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecentOrders.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRecentOrders.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvRecentOrders.ThemeStyle.RowsStyle.Height = 28;
            this.dgvRecentOrders.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this.dgvRecentOrders.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.BorderRadius = 5;
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.FillColor = System.Drawing.Color.WhiteSmoke;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(67, 7);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(125, 26);
            this.dtpStartDate.TabIndex = 10;
            this.dtpStartDate.Value = new System.DateTime(2025, 11, 3, 1, 25, 4, 301);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.BorderRadius = 5;
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.FillColor = System.Drawing.Color.WhiteSmoke;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(232, 7);
            this.dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(125, 26);
            this.dtpEndDate.TabIndex = 12;
            this.dtpEndDate.Value = new System.DateTime(2025, 11, 3, 1, 25, 7, 715);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(198, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "ถึง:";
            // 
            // btnLoadData
            // 
            this.btnLoadData.BorderRadius = 5;
            this.btnLoadData.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoadData.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoadData.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoadData.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoadData.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.btnLoadData.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadData.ForeColor = System.Drawing.Color.White;
            this.btnLoadData.Location = new System.Drawing.Point(363, 7);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(99, 26);
            this.btnLoadData.TabIndex = 13;
            this.btnLoadData.Text = "แสดงข้อมูล";
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // dgvTopSelling
            // 
            this.dgvTopSelling.AllowUserToAddRows = false;
            this.dgvTopSelling.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvTopSelling.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTopSelling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTopSelling.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTopSelling.ColumnHeadersHeight = 30;
            this.dgvTopSelling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTopSelling.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTopSelling.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTopSelling.Location = new System.Drawing.Point(468, 184);
            this.dgvTopSelling.Name = "dgvTopSelling";
            this.dgvTopSelling.ReadOnly = true;
            this.dgvTopSelling.RowHeadersVisible = false;
            this.dgvTopSelling.RowTemplate.Height = 28;
            this.dgvTopSelling.Size = new System.Drawing.Size(410, 303);
            this.dgvTopSelling.TabIndex = 15;
            this.dgvTopSelling.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTopSelling.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTopSelling.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTopSelling.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTopSelling.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTopSelling.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTopSelling.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTopSelling.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(237)))));
            this.dgvTopSelling.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTopSelling.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTopSelling.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.SaddleBrown;
            this.dgvTopSelling.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTopSelling.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvTopSelling.ThemeStyle.ReadOnly = true;
            this.dgvTopSelling.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTopSelling.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTopSelling.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTopSelling.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTopSelling.ThemeStyle.RowsStyle.Height = 28;
            this.dgvTopSelling.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this.dgvTopSelling.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(464, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "สินค้าขายดี 5 อันดับ";
            // 
            // DashboardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvTopSelling);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dgvRecentOrders);
            this.Controls.Add(this.lblRecentOrders);
            this.Controls.Add(this.pnlLowStock);
            this.Controls.Add(this.pnlOrders);
            this.Controls.Add(this.pnlSales);
            this.Controls.Add(this.label1);
            this.Name = "DashboardView";
            this.Size = new System.Drawing.Size(900, 500);
            this.Load += new System.EventHandler(this.DashboardView_Load);
            this.pnlSales.ResumeLayout(false);
            this.pnlSales.PerformLayout();
            this.pnlOrders.ResumeLayout(false);
            this.pnlOrders.PerformLayout();
            this.pnlLowStock.ResumeLayout(false);
            this.pnlLowStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSelling)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel pnlSales;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Panel pnlOrders;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Panel pnlLowStock;
        private System.Windows.Forms.Label lblLowStockCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRecentOrders;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRecentOrders;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnLoadData;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTopSelling;
        private System.Windows.Forms.Label label3;
    }
}