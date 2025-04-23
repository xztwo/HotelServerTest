using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Net.Client;
using Hotel;
using HotelClient;

namespace HotelClient
{
    public partial class Form3 : Form
    {
        private readonly CleaningService.CleaningServiceClient client;

        public Form3()
        {
            InitializeComponent();

            // Разрешаем использование HTTP/2 без TLS
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            // Настраиваем gRPC-канал для подключения к порту 5207
            var httpHandler = new SocketsHttpHandler
            {
                EnableMultipleHttp2Connections = true
            };

            var channel = GrpcChannel.ForAddress("http://localhost:5207", new GrpcChannelOptions
            {
                HttpHandler = httpHandler
            });

            client = new CleaningService.CleaningServiceClient(channel);

            // Загружаем заявки (через REST на порт 5208)
            LoadRequests();
        }

        private async void LoadRequests()
        {
            listBoxRequests.Items.Clear();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // REST-запрос по HTTP/1.1 на порт 5208
                    var response = await httpClient.GetAsync("http://localhost:5208/api/ServiceRequest");
                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();
                    var requests = JsonSerializer.Deserialize<List<ServiceRequest>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    foreach (var req in requests)
                    {
                        string status = req.Completed ? "[Выполнено]" : "[Ожидает]";
                        listBoxRequests.Items.Add($"{req.Id}: Комната {req.RoomNumber} - {req.Description} {status}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки: " + ex.Message);
                }
            }
        }

        private async void btnComplete_Click(object sender, EventArgs e)
        {
            if (listBoxRequests.SelectedItem == null) return;

            var selected = listBoxRequests.SelectedItem.ToString();
            if (!int.TryParse(selected.Split(':')[0], out int id)) return;

            try
            {
                var ack = await client.CompleteRequestAsync(new CleaningRequestId { Id = id });
                MessageBox.Show(ack.Message);
                LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при завершении заявки: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRequests();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Закрываем всё приложение
        }

        private void listBoxRequests_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}