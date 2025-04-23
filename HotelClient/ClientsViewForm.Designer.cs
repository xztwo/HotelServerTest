namespace HotelClient
{
    partial class ClientsViewForm
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
            clientsGridView = new DataGridView();
            btnRefresh = new Button();
            btnClose = new Button();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)clientsGridView).BeginInit();
            SuspendLayout();
            // 
            // clientsGridView
            // 
            clientsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clientsGridView.Location = new Point(12, 12);
            clientsGridView.Name = "clientsGridView";
            clientsGridView.Size = new Size(760, 400);
            clientsGridView.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefresh.Location = new Point(12, 425);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Обновить";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(672, 425);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 30);
            btnClose.TabIndex = 0;
            btnClose.Text = "Закрыть";
            btnClose.Click += btnClose_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(145, 430);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(130, 23);
            comboBox1.TabIndex = 2;
            // 
            // ClientsViewForm
            // 
            ClientSize = new Size(784, 461);
            Controls.Add(comboBox1);
            Controls.Add(btnClose);
            Controls.Add(btnRefresh);
            Controls.Add(clientsGridView);
            MinimumSize = new Size(600, 400);
            Name = "ClientsViewForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Список клиентов";
            ((System.ComponentModel.ISupportInitialize)clientsGridView).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView clientsGridView;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private ComboBox comboBox1;
    }
}