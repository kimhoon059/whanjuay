namespace Whanjuay
{
    partial class Loginpage
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
            this.LOGIN = new System.Windows.Forms.Panel();
            this.REGISTER = new Guna.UI2.WinForms.Guna2Button();
            this.FORGETPASSWORD = new Guna.UI2.WinForms.Guna2Button();
            this.USERNAME = new Guna.UI2.WinForms.Guna2TextBox();
            this.PASSWORD = new Guna.UI2.WinForms.Guna2TextBox();
            this.SUBMIT = new Guna.UI2.WinForms.Guna2Button();
            this.LOGIN.SuspendLayout();
            this.SuspendLayout();
            // 
            // LOGIN
            // 
            this.LOGIN.BackgroundImage = global::Whanjuay.Properties.Resources.K_PRA__3_;
            this.LOGIN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LOGIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LOGIN.Controls.Add(this.REGISTER);
            this.LOGIN.Controls.Add(this.FORGETPASSWORD);
            this.LOGIN.Controls.Add(this.USERNAME);
            this.LOGIN.Controls.Add(this.PASSWORD);
            this.LOGIN.Controls.Add(this.SUBMIT);
            this.LOGIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LOGIN.Location = new System.Drawing.Point(0, 0);
            this.LOGIN.Name = "LOGIN";
            this.LOGIN.Size = new System.Drawing.Size(1264, 681);
            this.LOGIN.TabIndex = 0;
            this.LOGIN.Paint += new System.Windows.Forms.PaintEventHandler(this.LOGIN_Paint);
            // 
            // REGISTER
            // 
            this.REGISTER.BackColor = System.Drawing.Color.Transparent;
            this.REGISTER.BorderRadius = 20;
            this.REGISTER.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.REGISTER.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.REGISTER.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.REGISTER.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.REGISTER.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.REGISTER.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REGISTER.ForeColor = System.Drawing.Color.White;
            this.REGISTER.Location = new System.Drawing.Point(470, 559);
            this.REGISTER.Name = "REGISTER";
            this.REGISTER.Size = new System.Drawing.Size(158, 37);
            this.REGISTER.TabIndex = 6;
            this.REGISTER.Text = "REGISTER";
            // 
            // FORGETPASSWORD
            // 
            this.FORGETPASSWORD.BackColor = System.Drawing.Color.Transparent;
            this.FORGETPASSWORD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.FORGETPASSWORD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.FORGETPASSWORD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.FORGETPASSWORD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.FORGETPASSWORD.FillColor = System.Drawing.Color.Transparent;
            this.FORGETPASSWORD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.FORGETPASSWORD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.FORGETPASSWORD.Location = new System.Drawing.Point(455, 516);
            this.FORGETPASSWORD.Name = "FORGETPASSWORD";
            this.FORGETPASSWORD.Size = new System.Drawing.Size(150, 19);
            this.FORGETPASSWORD.TabIndex = 5;
            this.FORGETPASSWORD.Text = "FORGET PASSWORD";
            this.FORGETPASSWORD.Click += new System.EventHandler(this.guna2Button1_Click_1);
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
            this.USERNAME.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.USERNAME.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.USERNAME.Location = new System.Drawing.Point(306, 390);
            this.USERNAME.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.PlaceholderText = "USERNAME";
            this.USERNAME.SelectedText = "";
            this.USERNAME.Size = new System.Drawing.Size(299, 44);
            this.USERNAME.TabIndex = 4;
            this.USERNAME.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.USERNAME.TextChanged += new System.EventHandler(this.USERNAME_TextChanged);
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
            this.PASSWORD.Location = new System.Drawing.Point(306, 465);
            this.PASSWORD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.PlaceholderText = "PASSWORD";
            this.PASSWORD.SelectedText = "";
            this.PASSWORD.Size = new System.Drawing.Size(299, 44);
            this.PASSWORD.TabIndex = 3;
            this.PASSWORD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PASSWORD.TextChanged += new System.EventHandler(this.PASSWORD_TextChanged);
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
            this.SUBMIT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.SUBMIT.ForeColor = System.Drawing.Color.White;
            this.SUBMIT.Location = new System.Drawing.Point(292, 559);
            this.SUBMIT.Name = "SUBMIT";
            this.SUBMIT.Size = new System.Drawing.Size(158, 37);
            this.SUBMIT.TabIndex = 0;
            this.SUBMIT.Text = "SUBMIT";
            this.SUBMIT.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // Loginpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.LOGIN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Loginpage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.LOGIN.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button SUBMIT;
        private Guna.UI2.WinForms.Guna2TextBox PASSWORD;
        private Guna.UI2.WinForms.Guna2TextBox USERNAME;
        private Guna.UI2.WinForms.Guna2Button FORGETPASSWORD;
        private Guna.UI2.WinForms.Guna2Button REGISTER;
        private System.Windows.Forms.Panel LOGIN;
    }
}

