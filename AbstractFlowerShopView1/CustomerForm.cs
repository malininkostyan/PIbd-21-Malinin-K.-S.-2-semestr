using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using AbstractFlowerShopView1;
using System;
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
                }
                catch (Exception ex)
                {
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
            try
            {
                if (id.HasValue)
                {
                    APICustomer.PostRequest<CustomerBindingModel, bool>("api/Customer/UpdateElement", new CustomerBindingModel
                    {
                       Id = id.Value,
                       CustomerFIO = textBoxFIO.Text
                    });
                }
                else
                {
                   APICustomer.PostRequest<CustomerBindingModel,bool>("api/Customer/AddElement", new CustomerBindingModel
                   {
                       CustomerFIO = textBoxFIO.Text
                   });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}