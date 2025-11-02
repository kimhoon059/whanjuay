namespace Whanjuay
{
    partial class Orderview
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
            this.dgvPendingOrders = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.colRowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderCodeDisplay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSlipPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiptPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderList = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSlip = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colReceipt = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colComplete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPendingOrders
            // 
            this.dgvPendingOrders.AllowUserToAddRows = false;
            this.dgvPendingOrders.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvPendingOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPendingOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // --- [แก้ไข] --- จัดหัวตารางทั้งหมดให้อยู่ตรงกลาง
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPendingOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPendingOrders.ColumnHeadersHeight = 34;
            this.dgvPendingOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPendingOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRowNumber,
            this.colOrderCodeDisplay,
            this.colOrderId,
            this.colOrderCode,
            this.colSlipPath,
            this.colReceiptPath,
            this.colUsername,
            this.colOrderList,
            this.colTotal,
            this.colSlip,
            this.colReceipt,
            this.colComplete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPendingOrders.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPendingOrders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this.dgvPendingOrders.Location = new System.Drawing.Point(20, 70);
            this.dgvPendingOrders.Name = "dgvPendingOrders";
            this.dgvPendingOrders.ReadOnly = true;
            this.dgvPendingOrders.RowHeadersVisible = false;
            this.dgvPendingOrders.RowTemplate.Height = 40;
            this.dgvPendingOrders.Size = new System.Drawing.Size(860, 470);
            this.dgvPendingOrders.TabIndex = 0;
            this.dgvPendingOrders.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPendingOrders.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvPendingOrders.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPendingOrders.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvPendingOrders.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvPendingOrders.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvPendingOrders.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this.dgvPendingOrders.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(237)))));
            this.dgvPendingOrders.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPendingOrders.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvPendingOrders.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.SaddleBrown;
            this.dgvPendingOrders.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPendingOrders.ThemeStyle.HeaderStyle.Height = 34;
            this.dgvPendingOrders.ThemeStyle.ReadOnly = true;
            this.dgvPendingOrders.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPendingOrders.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPendingOrders.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPendingOrders.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPendingOrders.ThemeStyle.RowsStyle.Height = 40;
            this.dgvPendingOrders.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this.dgvPendingOrders.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(245, 32);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "จัดการออเดอร์ (Pending)";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BorderRadius = 10;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(760, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "รีเฟรช";
            // 
            // colRowNumber
            // 
            this.colRowNumber.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colRowNumber.HeaderText = "ลำดับ";
            this.colRowNumber.Name = "colRowNumber";
            this.colRowNumber.ReadOnly = true;
            this.colRowNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRowNumber.Width = 60;
            // 
            // colOrderCodeDisplay
            // 
            this.colOrderCodeDisplay.DataPropertyName = "order_code";
            // --- [แก้ไข] --- จัดข้อมูลตรงกลาง
            this.colOrderCodeDisplay.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colOrderCodeDisplay.HeaderText = "Order ID";
            this.colOrderCodeDisplay.Name = "colOrderCodeDisplay";
            this.colOrderCodeDisplay.ReadOnly = true;
            this.colOrderCodeDisplay.Width = 110;
            // 
            // colOrderId
            // 
            this.colOrderId.DataPropertyName = "order_id";
            this.colOrderId.HeaderText = "order_id";
            this.colOrderId.Name = "colOrderId";
            this.colOrderId.ReadOnly = true;
            this.colOrderId.Visible = false;
            // 
            // colOrderCode
            // 
            this.colOrderCode.DataPropertyName = "order_code";
            this.colOrderCode.HeaderText = "order_code_hidden";
            this.colOrderCode.Name = "colOrderCode";
            this.colOrderCode.ReadOnly = true;
            this.colOrderCode.Visible = false;
            // 
            // colSlipPath
            // 
            this.colSlipPath.DataPropertyName = "slip_path";
            this.colSlipPath.HeaderText = "slip_path";
            this.colSlipPath.Name = "colSlipPath";
            this.colSlipPath.ReadOnly = true;
            this.colSlipPath.Visible = false;
            // 
            // colReceiptPath
            // 
            this.colReceiptPath.DataPropertyName = "receipt_pdf_path";
            this.colReceiptPath.HeaderText = "receipt_pdf_path";
            this.colReceiptPath.Name = "colReceiptPath";
            this.colReceiptPath.ReadOnly = true;
            this.colReceiptPath.Visible = false;
            // 
            // colUsername
            // 
            this.colUsername.DataPropertyName = "username";
            // --- [แก้ไข] --- จัดข้อมูลตรงกลาง
            this.colUsername.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colUsername.FillWeight = 120F;
            this.colUsername.HeaderText = "User";
            this.colUsername.Name = "colUsername";
            this.colUsername.ReadOnly = true;
            // 
            // colOrderList
            // 
            this.colOrderList.FillWeight = 90F;
            this.colOrderList.HeaderText = "รายการ";
            this.colOrderList.Name = "colOrderList";
            this.colOrderList.ReadOnly = true;
            this.colOrderList.Text = "ดูรายการ";
            this.colOrderList.UseColumnTextForButtonValue = true;
            // 
            // colTotal
            // 
            this.colTotal.DataPropertyName = "total_amount";
            // --- [แก้ไข] --- เปลี่ยนจาก MiddleRight เป็น MiddleCenter
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTotal.FillWeight = 110F;
            this.colTotal.HeaderText = "ยอดรวม";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // colSlip
            // 
            this.colSlip.FillWeight = 90F;
            this.colSlip.HeaderText = "สลิป";
            this.colSlip.Name = "colSlip";
            this.colSlip.ReadOnly = true;
            this.colSlip.Text = "ดูสลิป";
            this.colSlip.UseColumnTextForButtonValue = true;
            // 
            // colReceipt
            // 
            this.colReceipt.FillWeight = 90F;
            this.colReceipt.HeaderText = "ใบเสร็จ";
            this.colReceipt.Name = "colReceipt";
            this.colReceipt.ReadOnly = true;
            this.colReceipt.Text = "ดูใบเสร็จ";
            this.colReceipt.UseColumnTextForButtonValue = true;
            // 
            // colComplete
            // 
            this.colComplete.FillWeight = 120F;
            this.colComplete.HeaderText = "สถานะ";
            this.colComplete.Name = "colComplete";
            this.colComplete.ReadOnly = true;
            this.colComplete.Text = "ยืนยัน (Complete)";
            this.colComplete.UseColumnTextForButtonValue = true;
            // 
            // Orderview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvPendingOrders);
            this.Name = "Orderview";
            this.Size = new System.Drawing.Size(900, 560);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvPendingOrders;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderCodeDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSlipPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiptPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewButtonColumn colOrderList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewButtonColumn colSlip;
        private System.Windows.Forms.DataGridViewButtonColumn colReceipt;
        private System.Windows.Forms.DataGridViewButtonColumn colComplete;
    }
}