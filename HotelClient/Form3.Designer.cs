namespace HotelClient
{
    partial class Form3
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
            listBoxRequests = new ListBox();
            groupBox1 = new GroupBox();
            btnRefresh = new Button();
            btnComplete = new Button();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxRequests
            // 
            listBoxRequests.FormattingEnabled = true;
            listBoxRequests.ItemHeight = 15;
            listBoxRequests.Location = new Point(6, 22);
            listBoxRequests.Name = "listBoxRequests";
            listBoxRequests.Size = new Size(306, 409);
            listBoxRequests.TabIndex = 0;
            listBoxRequests.SelectedIndexChanged += listBoxRequests_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(btnComplete);
            groupBox1.Location = new Point(18, 456);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(312, 78);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Заявки на уборку";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(166, 22);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(127, 38);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnComplete
            // 
            btnComplete.Location = new Point(18, 22);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(127, 38);
            btnComplete.TabIndex = 0;
            btnComplete.Text = "Завершить";
            btnComplete.UseVisualStyleBackColor = true;
            btnComplete.Click += btnComplete_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listBoxRequests);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(318, 438);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Список доступных заявок";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 546);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form3";
            Text = "Form3";
            FormClosed += Form3_FormClosed;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxRequests;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnRefresh;
        private Button btnComplete;
    }
}