namespace Whanjuay
{
    partial class ForgetPassword
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
            this.verify = new Guna.UI2.WinForms.Guna2Panel();
            this.SUBMIT = new Guna.UI2.WinForms.Guna2Button();
            this.email = new Guna.UI2.WinForms.Guna2TextBox();
            this.USERNAME = new Guna.UI2.WinForms.Guna2TextBox();
            this.verify.SuspendLayout();
            this.SuspendLayout();
            // 
            // verify
            // 
            this.verify.BackgroundImage = global::Whanjuay.Properties.Resources.K_PRA__9_;
            this.verify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.verify.Controls.Add(this.SUBMIT);
            this.verify.Controls.Add(this.email);
            this.verify.Controls.Add(this.USERNAME);
            this.verify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.verify.Location = new System.Drawing.Point(0, 0);
            this.verify.Name = "verify";
            this.verify.Size = new System.Drawing.Size(1264, 681);
            this.verify.TabIndex = 0;
            this.verify.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
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
            this.SUBMIT.Location = new System.Drawing.Point(429, 550);
            this.SUBMIT.Name = "SUBMIT";
            this.SUBMIT.Size = new System.Drawing.Size(158, 37);
            this.SUBMIT.TabIndex = 7;
            this.SUBMIT.Text = "SUBMIT";
            this.SUBMIT.Click += new System.EventHandler(this.SUBMIT_Click);
            // 
            // email
            // 
            this.email.BackColor = System.Drawing.Color.Transparent;
            this.email.BorderColor = System.Drawing.Color.Black;
            this.email.BorderRadius = 20;
            this.email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.email.DefaultText = "";
            this.email.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.email.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.email.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.email.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.email.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.email.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.email.Location = new System.Drawing.Point(317, 466);
            this.email.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.email.Name = "email";
            this.email.PlaceholderText = "E-MAIL";
            this.email.SelectedText = "";
            this.email.Size = new System.Drawing.Size(381, 44);
            this.email.TabIndex = 6;
            this.email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // USERNAME
            // 
            this.USERNAME.BackColor = System.Drawing.Color.Transparent;
            this.USERNAME.BorderColor = System.Drawing.Color.Black;
            this.USERNAME.BorderRadius = 20;
            this.USERNAME.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.USERNAME.DefaultText = "";
            this.USERNAME.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.USERNAME.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.USERNAME.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.USERNAME.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.USERNAME.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.USERNAME.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USERNAME.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.USERNAME.Location = new System.Drawing.Point(317, 396);
            this.USERNAME.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.PlaceholderText = "USERNAME";
            this.USERNAME.SelectedText = "";
            this.USERNAME.Size = new System.Drawing.Size(381, 44);
            this.USERNAME.TabIndex = 5;
            this.USERNAME.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.USERNAME.TextChanged += new System.EventHandler(this.USERNAME_TextChanged);
            // 
            // ForgetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.verify);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ForgetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgetPassword";
            this.verify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel verify;
        private Guna.UI2.WinForms.Guna2TextBox USERNAME;
        private Guna.UI2.WinForms.Guna2TextBox email;
        private Guna.UI2.WinForms.Guna2Button SUBMIT;
    }
}