using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using AbstractFlowerShopView1;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AbstracFlowertShopView1
{
    public partial class CustomerForm : Form
    {
        public int Id { set { id = value; } }
        private int? id;

        public CustomerForm()
        {
            InitializeComponent();
        }
        private void FormCustomer_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CustomerViewModel customer = APICustomer.GetRequest<CustomerViewModel>("api/Customer/ElementGet/" + id.Value);
                    textBoxFIO.Text = customer.CustomerFIO;
                    textBoxMail.Text = customer.Mail;
                    dataGridView.DataSource = customer.InfoMessages;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[4].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }

                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fio = textBoxFIO.Text;
            string mail = textBoxMail.Text;
            if (!string.IsNullOrEmpty(mail))
            {
                if (!Regex.IsMatch(mail, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9az][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
                {
                    MessageBox.Show("Неверный формат для электронной почты", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (id.HasValue)
            {
                APICustomer.PostRequest<CustomerBindingModel, bool>("api/Component/UpdateElement", new CustomerBindingModel
                {
                   Id = id.Value,
                   CustomerFIO = fio,
                   Mail = mail
                });
            }
            else
            {
                APICustomer.PostRequest<CustomerBindingModel, bool>("api/Component/AddElement", new CustomerBindingModel
                {
                   CustomerFIO = fio,
                   Mail = mail
                });
            }
            MessageBox.Show("Сохранение прошло успешно", "Сообщение",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}