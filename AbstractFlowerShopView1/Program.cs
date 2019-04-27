using System;
using System.Windows.Forms;

namespace AbstractFlowerShopView1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            APICustomer.Connect();
            MailCustomer.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
           
        }
    }
}