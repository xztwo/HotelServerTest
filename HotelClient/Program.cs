using System;
using System.Windows.Forms;

namespace HotelClient
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Стартовая форма - Form1 (Авторизация)
        }
    }
}
