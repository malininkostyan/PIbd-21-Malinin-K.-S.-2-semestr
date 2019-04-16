using System;
using System.Collections.Generic;
using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System.Windows.Forms;

namespace AbstractFlowerShopView1
{
    public partial class BouquetForm : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private List<BouquetElementViewModel> productElements;
        public BouquetForm()
        {
            InitializeComponent();
        }
        private void FormBouquet_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    BouquetViewModel customer = APICustomer.GetRequest<BouquetViewModel>("api/Bouquet/ElementGet/" + id.Value);
                    if (customer != null)
                    {
                        textBoxName.Text = customer.BouquetName;
                        textBoxPrice.Text = customer.Cost.ToString();
                        productElements = customer.BouquetElements;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                productElements = new List<BouquetElementViewModel>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (productElements != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = productElements;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new BouquetElementForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.BouquetId = id.Value;
                    }
                    productElements.Add(form.Model);
                }
                LoadData();
            }
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = new BouquetElementForm
                {
                    Model = productElements[dataGridView.SelectedRows[0].Cells[0].RowIndex]
                };
                if (form.ShowDialog() == DialogResult.OK)
                {
                    productElements[dataGridView.SelectedRows[0].Cells[0].RowIndex] =
                    form.Model;
                    LoadData();
                }
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        productElements.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (productElements == null || productElements.Count == 0)
            {
                MessageBox.Show("Заполните элементы", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<BouquetElementBindingModel> productElementBM = new
               List<BouquetElementBindingModel>();
                for (int i = 0; i < productElements.Count; ++i)
                {
                    productElementBM.Add(new BouquetElementBindingModel
                    {
                        Id = productElements[i].Id,
                        BouquetId = productElements[i].BouquetId,
                        ElementId = productElements[i].ElementId,
                        Amount = productElements[i].Amount
                    });
                }
                if (id.HasValue)
                {
                    APICustomer.PostRequest<BouquetBindingModel, bool>("api/Bouquet/UpdateElement", new BouquetBindingModel
                   {
                        Id = id.Value,
                        BouquetName = textBoxName.Text,
                        Cost = Convert.ToInt32(textBoxPrice.Text),
                        BouquetElements = productElementBM
                    });
                }
                else
                {
                    APICustomer.PostRequest<BouquetBindingModel, bool>("api/Bouquet/AddElement", new BouquetBindingModel
                    {
                        BouquetName = textBoxName.Text,
                        Cost = Convert.ToInt32(textBoxPrice.Text),
                        BouquetElements = productElementBM
                    });
                }
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