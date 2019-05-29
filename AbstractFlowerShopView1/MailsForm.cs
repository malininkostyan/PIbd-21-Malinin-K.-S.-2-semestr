using AbstractFlowerShopServiceDAL1.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AbstractFlowerShopView1
{
    public partial class MailsForm : Form
    {
        public MailsForm()
        {
            InitializeComponent();
        }
        private void FormMails_Load(object sender, EventArgs e)
        {
            try
            {
                List<InfoMessageViewModel> list = APICustomer.GetRequest<List<InfoMessageViewModel>>("api/InfoMessage/ListGet");
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[4].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}
