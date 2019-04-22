using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AbstractFlowerShopView1
{
    public partial class CreateBookingForm : Form
    {
        public CreateBookingForm()
        {
            InitializeComponent();
        }
        private void FormCreateBooking_Load(object sender, EventArgs e)
        {
            try
            {
                List<CustomerViewModel> listC = APICustomer.GetRequest<List<CustomerViewModel>>("api/Customer/ListGet");
                if (listC != null)
                {
                    comboBoxCustomer.DisplayMember = "CustomerFIO";
                    comboBoxCustomer.ValueMember = "Id";
                    comboBoxCustomer.DataSource = listC;
                    comboBoxCustomer.SelectedItem = null;
                }
                List<BouquetViewModel> listP = APICustomer.GetRequest<List<BouquetViewModel>>("api/Bouquet/ListGet");
                if (listP != null)
                {
                    comboBoxBouquet.DisplayMember = "BouquetName";
                    comboBoxBouquet.ValueMember = "Id";
                    comboBoxBouquet.DataSource = listP;
                    comboBoxBouquet.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void CalcSum()
        {
            if (comboBoxBouquet.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxBouquet.SelectedValue);
                    BouquetViewModel product = APICustomer.GetRequest<BouquetViewModel>("api/Bouquet/ElementGet/" + id);
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxTotal.Text = (count * (int)product.Cost).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void comboBoxBouquet_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxCustomer.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxBouquet.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
               APICustomer.PostRequest<BookingBindingModel, bool>("api/Main/CreateBooking", new BookingBindingModel
               {
                    CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue),
                    BouquetId = Convert.ToInt32(comboBoxBouquet.SelectedValue),
                    Amount = Convert.ToInt32(textBoxCount.Text),
                    Total = Convert.ToInt32(textBoxTotal.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
