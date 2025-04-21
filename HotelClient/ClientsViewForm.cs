using Grpc.Core;
using Hotel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelClient
{
    public partial class ClientsViewForm : Form
    {
        private readonly ClientService.ClientServiceClient _clientService;

        public ClientsViewForm(ChannelBase channel)
        {
            InitializeComponent();
            _clientService = new ClientService.ClientServiceClient(channel);
            InitializeDataGridView();
            LoadClients();
        }

        private void InitializeDataGridView()
        {
            // Настройка внешнего вида
            clientsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            clientsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            clientsGridView.MultiSelect = false;
            clientsGridView.ReadOnly = true;
            clientsGridView.AllowUserToAddRows = false;
            clientsGridView.RowHeadersVisible = false;

            // Добавление колонок
            clientsGridView.Columns.Add("Id", "ID");
            clientsGridView.Columns.Add("FullName", "ФИО");
            clientsGridView.Columns.Add("Phone", "Телефон");
            clientsGridView.Columns.Add("Passport", "Паспорт");
            clientsGridView.Columns.Add("Email", "Email");

            // Настройка ширины колонок
            clientsGridView.Columns["Id"].Width = 50;
            clientsGridView.Columns["FullName"].Width = 150;
            clientsGridView.Columns["Phone"].Width = 120;
            clientsGridView.Columns["Passport"].Width = 100;
        }

        private async void LoadClients()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                clientsGridView.Rows.Clear();

var response = await _clientService.GetAllClientsAsync(new Hotel.Empty());

                foreach (var client in response.Clients)
                {
                    clientsGridView.Rows.Add(
                        client.Id,
                        $"{client.LastName} {client.FirstName} {client.MiddleName}".Trim(),
                        client.Phone,
                        $"{client.PassportSeries} {client.PassportNumber}",
                        client.Email
                    );
                }
            }
            catch (RpcException ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Status.Detail}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadClients();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
