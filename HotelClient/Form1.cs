using System;
using System.Net.Http;
using System.Windows.Forms;
using Grpc.Net.Client;
using Hotel;
using HotelClient;

namespace HotelClient
{
    public partial class Form1 : Form
    {
        private AuthService.AuthServiceClient authClient;

        public Form1()
        {
            InitializeComponent();

            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            var channel = GrpcChannel.ForAddress("http://localhost:5207", new GrpcChannelOptions { HttpHandler = httpHandler });

            authClient = new AuthService.AuthServiceClient(channel);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var request = new LoginRequest
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            var response = await authClient.LoginAsync(request);

            if (response.Success)
            {
                MessageBox.Show(response.Message, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (response.Role == "admin")
                {
                    Form2 bookingForm = new Form2();
                    bookingForm.Show();
                }
                else if (response.Role == "cleaner")
                {
                    Form3 cleanerForm = new Form3(); // Добавляем новую форму
                    cleanerForm.Show();
                }

                this.Hide(); // Скрываем форму авторизации
            }
            else
            {
                lblResult.Text = response.Message;
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}