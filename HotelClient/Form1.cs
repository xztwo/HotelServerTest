using System;
using System.Windows.Forms;
using Grpc.Core;
using Grpc.Net.Client;
using Hotel;

namespace HotelClient
{
    public partial class Form1 : Form
    {
        private readonly AuthService.AuthServiceClient _authClient;
        private readonly GrpcChannel _authChannel;

        public Form1()
        {
            InitializeComponent();

            // Настройка gRPC канала для авторизации
            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            _authChannel = GrpcChannel.ForAddress("http://localhost:5207",
                new GrpcChannelOptions { HttpHandler = httpHandler });

            _authClient = new AuthService.AuthServiceClient(_authChannel);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                btnLogin.Enabled = false;
                lblResult.Text = "Авторизация...";
                lblResult.ForeColor = System.Drawing.Color.Black;

                var request = new LoginRequest
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text
                };

                var response = await _authClient.LoginAsync(request);

                if (response.Success)
                {
                    OpenRoleSpecificForm(response.Role);
                }
                else
                {
                    lblResult.Text = response.Message;
                    lblResult.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (RpcException ex)
            {
                lblResult.Text = $"Ошибка соединения: {ex.Status.Detail}";
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private void OpenRoleSpecificForm(string role)
        {
            this.Hide(); // Скрываем форму авторизации

            switch (role)
            {
                case "admin":
                    var adminChannel = GrpcChannel.ForAddress("http://localhost:5208");
                    var adminForm = new AdminMenuForm(adminChannel);
                    adminForm.FormClosed += (s, args) => this.Close();
                    adminForm.Show();
                    break;

                case "cleaner":
                    // Форма для уборщиков без передачи канала
                    var cleanerForm = new Form3();
                    cleanerForm.FormClosed += (s, args) => this.Close();
                    cleanerForm.Show();
                    break;

                default:
                    MessageBox.Show("Неизвестная роль пользователя", "Ошибка");
                    this.Close();
                    break;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _authChannel?.Dispose();
            base.OnFormClosing(e);
        }
    }
}