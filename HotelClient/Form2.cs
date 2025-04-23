using System;
using System.Net.Http;
using System.Windows.Forms;
using Grpc.Net.Client;
using HotelClient;
using Hotel;

namespace HotelClient
{
    public partial class Form2 : Form
    {
        private BookingService.BookingServiceClient bookingClient;

        public Form2()
        {
            InitializeComponent();

            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            var channel = GrpcChannel.ForAddress("http://localhost:5207", new GrpcChannelOptions { HttpHandler = httpHandler });

            bookingClient = new BookingService.BookingServiceClient(channel);

            // Заполняем ComboBox тестовыми данными
            cmbRoomType.Items.AddRange(new string[] { "Стандарт", "Люкс", "Семейный", "Делюкс" });
            cmbRoomType.SelectedIndex = 0; // Выбираем первый элемент по умолчанию
            var response = bookingClient.GetBookings(new Empty());

            listBookings.Items.Clear();
            foreach (var booking in response.Bookings)
            {
                listBookings.Items.Add($"{booking.CustomerName} - {booking.RoomType} ({booking.CheckInDate} - {booking.CheckOutDate})");
            }
        }

        private async void btnBookRoom_Click_1(object sender, EventArgs e)
        {
            var request = new BookingRequest
            {
                CustomerName = txtCustomerName.Text,
                RoomType = cmbRoomType.SelectedItem.ToString(),
                CheckInDate = dtpCheckIn.Value.ToString("yyyy-MM-dd"),
                CheckOutDate = dtpCheckOut.Value.ToString("yyyy-MM-dd")
            };

            var response = await bookingClient.BookRoomAsync(request);
            MessageBox.Show(response.Message, "Результат бронирования", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listBookings.Items.Add($"{txtCustomerName.Text} - {cmbRoomType.SelectedItem.ToString()} ({dtpCheckIn.Value.ToString("yyyy-MM-dd")} - {dtpCheckOut.Value.ToString("yyyy-MM-dd")})");
        }

        private async void btnGetBookings_Click_1(object sender, EventArgs e)
        {
            var response = await bookingClient.GetBookingsAsync(new Empty());

            listBookings.Items.Clear();
            foreach (var booking in response.Bookings)
            {
                listBookings.Items.Add($"{booking.CustomerName} - {booking.RoomType} ({booking.CheckInDate} - {booking.CheckOutDate})");
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Закрываем Form1, когда Form2 закрыта
            Application.Exit();  // Завершаем приложение
        }

        private void listBookings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
