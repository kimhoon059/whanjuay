namespace Whanjuay
{
    partial class ResetPassword
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resetpw = new Guna.UI2.WinForms.Guna2Panel();
            this.SUBMIT = new Guna.UI2.WinForms.Guna2Button();
            this.CONFIRMPASS = new Guna.UI2.WinForms.Guna2TextBox();
            this.PASSWORD = new Guna.UI2.WinForms.Guna2TextBox();
            this.resetpw.SuspendLayout();
            this.SuspendLayout();
            // 
            // resetpw
            // 
            this.resetpw.BackgroundImage = global::Whanjuay.Properties.Resources.K_PRA__10_;
            this.resetpw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.resetpw.Controls.Add(this.SUBMIT);
            this.resetpw.Controls.Add(this.CONFIRMPASS);
            this.resetpw.Controls.Add(this.PASSWORD);
            this.resetpw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetpw.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.resetpw.Location = new System.Drawing.Point(0, 0);
            this.resetpw.Name = "resetpw";
            this.resetpw.Size = new System.Drawing.Size(1264, 681);
            this.resetpw.TabIndex = 0;
            this.resetpw.Paint += new System.Windows.Forms.PaintEventHandler(this.resetpw_Paint);
            // 
            // SUBMIT
            // 
            this.SUBMIT.BackColor = System.Drawing.Color.Transparent;
            this.SUBMIT.BorderRadius = 20;
            this.SUBMIT.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SUBMIT.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SUBMIT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SUBMIT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SUBMIT.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SUBMIT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SUBMIT.ForeColor = System.Drawing.Color.White;
            this.SUBMIT.Location = new System.Drawing.Point(413, 560);
            this.SUBMIT.Name = "SUBMIT";
            this.SUBMIT.Size = new System.Drawing.Size(158, 37);
            this.SUBMIT.TabIndex = 8;
            this.SUBMIT.Text = "SUBMIT";
            this.SUBMIT.Click += new System.EventHandler(this.SUBMIT_Click_1);
            // 
            // CONFIRMPASS
            // 
            this.CONFIRMPASS.BackColor = System.Drawing.Color.Transparent;
            this.CONFIRMPASS.BorderColor = System.Drawing.Color.Black;
            this.CONFIRMPASS.BorderRadius = 20;
            this.CONFIRMPASS.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CONFIRMPASS.DefaultText = "";
            this.CONFIRMPASS.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.CONFIRMPASS.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.CONFIRMPASS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CONFIRMPASS.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CONFIRMPASS.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CONFIRMPASS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CONFIRMPASS.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CONFIRMPASS.Location = new System.Drawing.Point(304, 495);
            this.CONFIRMPASS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CONFIRMPASS.Name = "CONFIRMPASS";
            this.CONFIRMPASS.PlaceholderText = "CONFIRM PASSWORD";
            this.CONFIRMPASS.SelectedText = "";
            this.CONFIRMPASS.Size = new System.Drawing.Size(381, 44);
            this.CONFIRMPASS.TabIndex = 7;
            this.CONFIRMPASS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PASSWORD
            // 
            this.PASSWORD.BackColor = System.Drawing.Color.Transparent;
            this.PASSWORD.BorderColor = System.Drawing.Color.Black;
            this.PASSWORD.BorderRadius = 20;
            this.PASSWORD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PASSWORD.DefaultText = "";
            this.PASSWORD.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.PASSWORD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.PASSWORD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PASSWORD.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PASSWORD.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PASSWORD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PASSWORD.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PASSWORD.Location = new System.Drawing.Point(304, 422);
            this.PASSWORD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.PlaceholderText = "PASSWORD";
            this.PASSWORD.SelectedText = "";
            this.PASSWORD.Size = new System.Drawing.Size(381, 44);
            this.PASSWORD.TabIndex = 6;
            this.PASSWORD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.resetpw);
            this.Name = "ResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResetPassword";
            this.resetpw.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel resetpw;
        private Guna.UI2.WinForms.Guna2TextBox CONFIRMPASS;
        private Guna.UI2.WinForms.Guna2TextBox PASSWORD;
        private Guna.UI2.WinForms.Guna2Button SUBMIT;
    }
}