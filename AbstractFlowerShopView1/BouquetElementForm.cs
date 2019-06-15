using AbstractFlowerShopServiceDAL.Interfaces;
using AbstractFlowerShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace AbstractFlowerShopView1
{
    public partial class FormBouquetElement : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public BouquetElementViewModel Model
        {
            set { model = value; }
            get
            {
                return model;
            }
        }
        private readonly IElementService service;
        private BouquetElementViewModel model;
        public FormBouquetElement(IElementService service)
        {
            InitializeComponent();
            this.service = service;
        }
        private void FormBouquetElement_Load(object sender, EventArgs e)
        {
            try
            {
                List<ElementViewModel> list = service.ListGet();
                if (list != null)
                {
                    comboBoxElement.DisplayMember = "ElementName";
                    comboBoxElement.ValueMember = "Id";
                    comboBoxElement.DataSource = list;
                    comboBoxElement.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxElement.Enabled = false;
                comboBoxElement.SelectedValue = model.ElementId;
                textBoxCount.Text = model.Amount.ToString();
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxElement.SelectedValue == null)
            {
                MessageBox.Show("Выберите элемент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new BouquetElementViewModel
                    {
                        ElementId = Convert.ToInt32(comboBoxElement.SelectedValue),
                        ElementName = comboBoxElement.Text,
                        Amount = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                model.Amount = Convert.ToInt32(textBoxCount.Text);
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
