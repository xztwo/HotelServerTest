namespace HotelClient
{
    partial class AddClient
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblMiddleName = new Label();
            txtMiddleName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblPassportSeries = new Label();
            txtPassportSeries = new TextBox();
            lblPassportNumber = new Label();
            txtPassportNumber = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnAdd = new Button();
            btnCancel = new Button();
            label2 = new Label();
            lblPassport = new Label();
            SuspendLayout();
            // 
            // lblLastName
            // 
            lblLastName.Location = new Point(30, 144);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(88, 22);
            lblLastName.TabIndex = 15;
            lblLastName.Text = "Отчество";
            lblLastName.Click += lblLastName_Click;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(30, 169);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(241, 23);
            txtLastName.TabIndex = 14;
            // 
            // lblFirstName
            // 
            lblFirstName.Location = new Point(30, 42);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(88, 22);
            lblFirstName.TabIndex = 13;
            lblFirstName.Text = "Фамилия";
            lblFirstName.Click += lblFirstName_Click;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(30, 67);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(241, 23);
            txtFirstName.TabIndex = 12;
            // 
            // lblMiddleName
            // 
            lblMiddleName.Location = new Point(30, 93);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(88, 22);
            lblMiddleName.TabIndex = 11;
            lblMiddleName.Text = "Имя";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(30, 118);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(241, 23);
            txtMiddleName.TabIndex = 10;
            // 
            // lblPhone
            // 
            lblPhone.Location = new Point(30, 313);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(88, 22);
            lblPhone.TabIndex = 9;
            lblPhone.Text = "Телефон";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(30, 338);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(241, 23);
            txtPhone.TabIndex = 8;
            // 
            // lblPassportSeries
            // 
            lblPassportSeries.Location = new Point(30, 220);
            lblPassportSeries.Name = "lblPassportSeries";
            lblPassportSeries.Size = new Size(88, 22);
            lblPassportSeries.TabIndex = 7;
            lblPassportSeries.Text = "Серия";
            // 
            // txtPassportSeries
            // 
            txtPassportSeries.Location = new Point(30, 236);
            txtPassportSeries.Name = "txtPassportSeries";
            txtPassportSeries.Size = new Size(88, 23);
            txtPassportSeries.TabIndex = 6;
            // 
            // lblPassportNumber
            // 
            lblPassportNumber.Location = new Point(140, 220);
            lblPassportNumber.Name = "lblPassportNumber";
            lblPassportNumber.Size = new Size(88, 22);
            lblPassportNumber.TabIndex = 5;
            lblPassportNumber.Text = "Номер";
            // 
            // txtPassportNumber
            // 
            txtPassportNumber.Location = new Point(140, 236);
            txtPassportNumber.Name = "txtPassportNumber";
            txtPassportNumber.Size = new Size(131, 23);
            txtPassportNumber.TabIndex = 4;
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(30, 262);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(131, 22);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(30, 287);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(241, 23);
            txtEmail.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(188, 384);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(83, 22);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Добавить";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(30, 384);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(83, 22);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Назад";
            btnCancel.Click += btnCancel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(193, 25);
            label2.TabIndex = 17;
            label2.Text = "Добавление клиента";
            // 
            // lblPassport
            // 
            lblPassport.AutoSize = true;
            lblPassport.Location = new Point(30, 195);
            lblPassport.Name = "lblPassport";
            lblPassport.Size = new Size(54, 15);
            lblPassport.TabIndex = 18;
            lblPassport.Text = "Паспорт";
            lblPassport.Click += lblPassport_Click;
            // 
            // AddClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 456);
            Controls.Add(lblPassport);
            Controls.Add(label2);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtPassportNumber);
            Controls.Add(lblPassportNumber);
            Controls.Add(txtPassportSeries);
            Controls.Add(lblPassportSeries);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtMiddleName);
            Controls.Add(lblMiddleName);
            Controls.Add(txtFirstName);
            Controls.Add(lblFirstName);
            Controls.Add(txtLastName);
            Controls.Add(lblLastName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddClient";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление нового клиента";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblMiddleName;
        private TextBox txtMiddleName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblPassportSeries;
        private TextBox txtPassportSeries;
        private Label lblPassportNumber;
        private TextBox txtPassportNumber;
        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnAdd;
        private Button btnCancel;
        private Label label2;
        private Label lblPassport;
    }
}