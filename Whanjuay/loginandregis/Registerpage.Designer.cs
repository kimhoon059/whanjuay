namespace Whanjuay
{
    partial class Registerpage
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
            this.Register = new Guna.UI2.WinForms.Guna2Panel();
            this.SUBMIT = new Guna.UI2.WinForms.Guna2Button();
            this.email = new Guna.UI2.WinForms.Guna2TextBox();
            this.CONFIRMPASSWORD = new Guna.UI2.WinForms.Guna2TextBox();
            this.PASSWORD = new Guna.UI2.WinForms.Guna2TextBox();
            this.USERNAME = new Guna.UI2.WinForms.Guna2TextBox();
            this.Register.SuspendLayout();
            this.SuspendLayout();
            // 
            // Register
            // 
            this.Register.BackgroundImage = global::Whanjuay.Properties.Resources.regiswj;
            this.Register.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Register.Controls.Add(this.SUBMIT);
            this.Register.Controls.Add(this.email);
            this.Register.Controls.Add(this.CONFIRMPASSWORD);
            this.Register.Controls.Add(this.PASSWORD);
            this.Register.Controls.Add(this.USERNAME);
            this.Register.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Register.Location = new System.Drawing.Point(0, 0);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(1264, 681);
            this.Register.TabIndex = 0;
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
            this.SUBMIT.Location = new System.Drawing.Point(351, 582);
            this.SUBMIT.Name = "SUBMIT";
            this.SUBMIT.Size = new System.Drawing.Size(158, 37);
            this.SUBMIT.TabIndex = 9;
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
            this.email.Location = new System.Drawing.Point(272, 497);
            this.email.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.email.Name = "email";
            this.email.PlaceholderText = "E-MAIL";
            this.email.SelectedText = "";
            this.email.Size = new System.Drawing.Size(299, 44);
            this.email.TabIndex = 8;
            this.email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.email.TextChanged += new System.EventHandler(this.guna2TextBox2_TextChanged);
            // 
            // CONFIRMPASSWORD
            // 
            this.CONFIRMPASSWORD.BackColor = System.Drawing.Color.Transparent;
            this.CONFIRMPASSWORD.BorderColor = System.Drawing.Color.Black;
            this.CONFIRMPASSWORD.BorderRadius = 20;
            this.CONFIRMPASSWORD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CONFIRMPASSWORD.DefaultText = "";
            this.CONFIRMPASSWORD.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.CONFIRMPASSWORD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.CONFIRMPASSWORD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CONFIRMPASSWORD.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CONFIRMPASSWORD.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CONFIRMPASSWORD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CONFIRMPASSWORD.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CONFIRMPASSWORD.Location = new System.Drawing.Point(272, 417);
            this.CONFIRMPASSWORD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CONFIRMPASSWORD.Name = "CONFIRMPASSWORD";
            this.CONFIRMPASSWORD.PlaceholderText = "CONFIRM PASSWORD";
            this.CONFIRMPASSWORD.SelectedText = "";
            this.CONFIRMPASSWORD.Size = new System.Drawing.Size(299, 44);
            this.CONFIRMPASSWORD.TabIndex = 7;
            this.CONFIRMPASSWORD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CONFIRMPASSWORD.TextChanged += new System.EventHandler(this.CONFIRMPASSWORD_TextChanged);
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
            this.PASSWORD.Location = new System.Drawing.Point(272, 339);
            this.PASSWORD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.PlaceholderText = "PASSWORD";
            this.PASSWORD.SelectedText = "";
            this.PASSWORD.Size = new System.Drawing.Size(299, 44);
            this.PASSWORD.TabIndex = 6;
            this.PASSWORD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PASSWORD.TextChanged += new System.EventHandler(this.PASSWORD_TextChanged);
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
            this.USERNAME.Location = new System.Drawing.Point(272, 257);
            this.USERNAME.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.PlaceholderText = "USERNAME";
            this.USERNAME.SelectedText = "";
            this.USERNAME.Size = new System.Drawing.Size(299, 44);
            this.USERNAME.TabIndex = 5;
            this.USERNAME.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.USERNAME.TextChanged += new System.EventHandler(this.USERNAME_TextChanged);
            // 
            // Registerpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.Register);
            this.Name = "Registerpage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Registerpage_Load);
            this.Register.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel Register;
        private Guna.UI2.WinForms.Guna2TextBox USERNAME;
        private Guna.UI2.WinForms.Guna2TextBox email;
        private Guna.UI2.WinForms.Guna2TextBox CONFIRMPASSWORD;
        private Guna.UI2.WinForms.Guna2TextBox PASSWORD;
        private Guna.UI2.WinForms.Guna2Button SUBMIT;
    }
}