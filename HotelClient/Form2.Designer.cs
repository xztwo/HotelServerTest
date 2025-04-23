namespace HotelClient
{
    partial class Form2
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
            txtCustomerName = new TextBox();
            cmbRoomType = new ComboBox();
            dtpCheckIn = new DateTimePicker();
            dtpCheckOut = new DateTimePicker();
            btnBookRoom = new Button();
            btnGetBookings = new Button();
            listBookings = new ListBox();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(6, 46);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(188, 23);
            txtCustomerName.TabIndex = 0;
            // 
            // cmbRoomType
            // 
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(6, 98);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(188, 23);
            cmbRoomType.TabIndex = 1;
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Location = new Point(6, 153);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(188, 23);
            dtpCheckIn.TabIndex = 2;
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Location = new Point(6, 202);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(188, 23);
            dtpCheckOut.TabIndex = 3;
            // 
            // btnBookRoom
            // 
            btnBookRoom.Location = new Point(29, 245);
            btnBookRoom.Name = "btnBookRoom";
            btnBookRoom.Size = new Size(135, 30);
            btnBookRoom.TabIndex = 4;
            btnBookRoom.Text = "Создать";
            btnBookRoom.UseVisualStyleBackColor = true;
            btnBookRoom.Click += btnBookRoom_Click_1;
            // 
            // btnGetBookings
            // 
            btnGetBookings.Location = new Point(29, 294);
            btnGetBookings.Name = "btnGetBookings";
            btnGetBookings.Size = new Size(135, 43);
            btnGetBookings.TabIndex = 5;
            btnGetBookings.Text = "Показать бронирования";
            btnGetBookings.UseVisualStyleBackColor = true;
            btnGetBookings.Click += btnGetBookings_Click_1;
            // 
            // listBookings
            // 
            listBookings.FormattingEnabled = true;
            listBookings.ItemHeight = 15;
            listBookings.Location = new Point(6, 22);
            listBookings.Name = "listBookings";
            listBookings.Size = new Size(411, 304);
            listBookings.TabIndex = 6;
            listBookings.SelectedIndexChanged += listBookings_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnGetBookings);
            groupBox1.Controls.Add(dtpCheckOut);
            groupBox1.Controls.Add(txtCustomerName);
            groupBox1.Controls.Add(cmbRoomType);
            groupBox1.Controls.Add(btnBookRoom);
            groupBox1.Controls.Add(dtpCheckIn);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 343);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Создание бронирования";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 184);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 7;
            label4.Text = "Дата выезда";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 135);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 8;
            label3.Text = "Дата заезда";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 80);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 7;
            label2.Text = "Тип номера";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 28);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 6;
            label1.Text = "Имя клиента";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listBookings);
            groupBox2.Location = new Point(218, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(423, 343);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Список доступных бронирований";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(653, 367);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "Form2";
            Text = "Form2";
            FormClosed += Form2_FormClosed;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtCustomerName;
        private ComboBox cmbRoomType;
        private DateTimePicker dtpCheckIn;
        private DateTimePicker dtpCheckOut;
        private Button btnBookRoom;
        private Button btnGetBookings;
        private ListBox listBookings;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
    }
}