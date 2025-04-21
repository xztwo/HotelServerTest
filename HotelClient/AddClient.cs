using Grpc.Core;
using Hotel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelClient
{
    public partial class AddClient : Form
    {
        private readonly ClientService.ClientServiceClient _clientService;

        public AddClient(ChannelBase channel)
        {
            InitializeComponent();
            _clientService = new ClientService.ClientServiceClient(channel);
            SetupForm();
        }

        private void SetupForm()
        {
            // Настройка масок ввода
            txtPhone.TextChanged += PhoneTextChanged;
            txtPassportSeries.KeyPress += NumericOnlyKeyPress;
            txtPassportNumber.KeyPress += NumericOnlyKeyPress;

            // Настройка кнопки
            btnAdd.Click += AddClient_Click;
            btnCancel.Click += (s, e) => this.Close();
        }

        private async void AddClient_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            var request = new ClientRequest
            {
                LastName = txtLastName.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                MiddleName = txtMiddleName.Text.Trim(),
                Phone = NormalizePhone(txtPhone.Text),
                PassportSeries = txtPassportSeries.Text,
                PassportNumber = txtPassportNumber.Text,
                Email = txtEmail.Text.Trim().ToLower()
            };

            try
            {
                var response = await _clientService.AddClientAsync(request);

                if (response.Success)
                {
                    MessageBox.Show(response.Message, "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (RpcException ex)
            {
                MessageBox.Show($"Ошибка связи с сервером: {ex.Status.Detail}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                ShowValidationError("Введите фамилию клиента", txtLastName);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                ShowValidationError("Введите имя клиента", txtFirstName);
                return false;
            }

            if (!IsValidPhoneFormat(txtPhone.Text))
            {
                ShowValidationError("Телефон должен быть в формате: +7(XXX)XXX-XX-XX", txtPhone);
                return false;
            }

            if (txtPassportSeries.Text.Length != 4)
            {
                ShowValidationError("Серия паспорта должна содержать 4 цифры", txtPassportSeries);
                return false;
            }

            if (txtPassportNumber.Text.Length != 6)
            {
                ShowValidationError("Номер паспорта должен содержать 6 цифр", txtPassportNumber);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                ShowValidationError("Введите корректный email адрес", txtEmail);
                return false;
            }

            return true;
        }

        private void ShowValidationError(string message, Control control)
        {
            MessageBox.Show(message, "Ошибка ввода",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private void PhoneTextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            var text = textBox.Text;
            var cursorPos = textBox.SelectionStart;

            // Маска для телефона: +7(XXX)XXX-XX-XX
            if (text.Length == 2 && !text.Contains("("))
                text = text.Insert(2, "(");
            else if (text.Length == 6 && !text.Contains(")"))
                text = text.Insert(6, ")");
            else if (text.Length == 10 && !text.Contains("-"))
                text = text.Insert(10, "-");
            else if (text.Length == 13 && text.Length > text.LastIndexOf('-') + 1)
                text = text.Insert(13, "-");

            // Удаляем лишние символы маски
            if (text.Length > 16)
                text = text.Substring(0, 16);

            textBox.Text = text;
            textBox.SelectionStart = Math.Min(cursorPos, text.Length);
        }

        private void NumericOnlyKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private string NormalizePhone(string phone)
        {
            // Конвертируем +7(XXX)XXX-XX-XX в +7XXXXXXXXXX
            return phone.Replace("(", "").Replace(")", "").Replace("-", "");
        }

        private bool IsValidPhoneFormat(string phone)
        {
            return Regex.IsMatch(phone, @"^\+7\(\d{3}\)\d{3}-\d{2}-\d{2}$");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void lblLastName_Click(object sender, EventArgs e)
        {

        }

        private void lblFirstName_Click(object sender, EventArgs e)
        {

        }

        private void lblPassport_Click(object sender, EventArgs e)
        {

        }
    }
}
