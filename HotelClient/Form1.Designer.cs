namespace HotelClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            lblResult = new Label();
            lblInfo = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(116, 173);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(117, 29);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "ВОЙТИ";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(84, 78);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(184, 23);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(84, 122);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(184, 23);
            txtPassword.TabIndex = 2;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(12, 293);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 15);
            lblResult.TabIndex = 3;
            lblResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 25F);
            lblInfo.Location = new Point(66, 9);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(223, 46);
            lblInfo.TabIndex = 4;
            lblInfo.Text = "Авторизация";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(84, 60);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 5;
            label1.Text = "Логин";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(84, 104);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 6;
            label2.Text = "Пароль";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 317);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblInfo);
            Controls.Add(lblResult);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(btnLogin);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblResult;
        private Label lblInfo;
        private Label label1;
        private Label label2;
    }
}
