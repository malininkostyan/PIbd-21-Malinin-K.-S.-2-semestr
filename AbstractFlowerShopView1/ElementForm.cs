using AbstractFlowerShopServiceDAL1.ViewModel;
using System;
using System.Windows.Forms;

namespace AbstractFlowerShopView1
{
    public partial class ElementForm : Form
    {
        public int Id { set { id = value; } }    
        private int? id;
        public ElementForm()
        {
            InitializeComponent();
        }
        private void FormElement_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ElementViewModel element = APICustomer.GetRequest<ElementViewModel>("api/Element/ElementGet/" + id.Value);
                    if (element != null)
                    {
                        textBoxName.Text = element.ElementName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APICustomer.PostRequest<ElementViewModel, bool>("api/Element/UpdateElement", new ElementViewModel
                    {
                        Id = id.Value,
                        ElementName = textBoxName.Text
                    });
                }
                else
                {
                    APICustomer.PostRequest<ElementViewModel, bool>("api/Element/AddElement", new ElementViewModel
                    {
                        ElementName = textBoxName.Text
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
