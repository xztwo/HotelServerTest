using Grpc.Core;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelClient
{
    public partial class AdminMenuForm : Form
    {
        private readonly ChannelBase _channel;
        private readonly ToolStripStatusLabel _statusLabel;
        private readonly StatusStrip _statusStrip;

        public AdminMenuForm(ChannelBase channel)
        {
            _channel = channel;

            // Инициализация компонентов статус-бара
            _statusLabel = new ToolStripStatusLabel();
            _statusStrip = new StatusStrip();

            InitializeComponent();
            InitializeMenu();
            InitializeToolbar();
            SetupStatusBar(); // Переименованный метод
            this.IsMdiContainer = true;
        }

        private void SetupStatusBar() // Реализация вместо InitializeStatusBar
        {
            _statusLabel.Spring = true;
            _statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            _statusLabel.Text = "Готово";

            var timeLabel = new ToolStripStatusLabel
            {
                Text = DateTime.Now.ToString("HH:mm:ss dd.MM.yyyy")
            };

            _statusStrip.Items.AddRange(new ToolStripItem[] { _statusLabel, timeLabel });
            _statusStrip.Dock = DockStyle.Bottom;

            if (!this.Controls.Contains(_statusStrip))
            {
                this.Controls.Add(_statusStrip);
            }
        }

        private void InitializeMenu()
        {
            var menuStrip = new MenuStrip();

            // Меню "Файл"
            var fileMenu = new ToolStripMenuItem("Файл");
            var logoutItem = new ToolStripMenuItem("Выход", null, (s, e) => Application.Exit())
            {
                ShortcutKeys = Keys.Alt | Keys.F4
            };
            fileMenu.DropDownItems.Add(logoutItem);

            // Меню "Управление"
            var manageMenu = new ToolStripMenuItem("Управление");

            var clientsItem = new ToolStripMenuItem("Клиенты", null, (s, e) => OpenForm(new ClientsForm(_channel)))
            {
                ShortcutKeys = Keys.Control | Keys.C
            };

            var roomsItem = new ToolStripMenuItem("Номера", null, (s, e) => OpenForm(new RoomsForm(_channel)))
            {
                ShortcutKeys = Keys.Control | Keys.R
            };

            manageMenu.DropDownItems.AddRange(new[] { clientsItem, roomsItem });
            menuStrip.Items.AddRange(new[] { fileMenu, manageMenu });

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void InitializeToolbar()
        {
            var toolStrip = new ToolStrip
            {
                Dock = DockStyle.Top,
                ImageScalingSize = new Size(32, 32)
            };

            var clientsBtn = new ToolStripButton("Клиенты")
            {
                DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            };
            clientsBtn.Click += (s, e) => OpenForm(new ClientsForm(_channel));

            var roomsBtn = new ToolStripButton("Номера");
            roomsBtn.Click += (s, e) => OpenForm(new RoomsForm(_channel));

            toolStrip.Items.AddRange(new ToolStripItem[] { clientsBtn, roomsBtn });
            this.Controls.Add(toolStrip);
        }

        private void OpenForm(Form form)
        {
            form.MdiParent = this;
            form.Show();
            UpdateStatus($"Открыто: {form.Text}");
        }

        private void UpdateStatus(string message)
        {
            _statusLabel.Text = message;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (MessageBox.Show("Закрыть приложение?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                _channel?.ShutdownAsync().Wait();
                base.OnFormClosing(e);
            }
        }
    }

    public class ClientsForm : Form
    {
        public ClientsForm(ChannelBase channel)
        {
            this.Text = "Управление клиентами";
            // Инициализация содержимого формы
        }
    }

    public class RoomsForm : Form
    {
        public RoomsForm(ChannelBase channel)
        {
            this.Text = "Управление номерами";
            // Инициализация содержимого формы
        }
    }
}