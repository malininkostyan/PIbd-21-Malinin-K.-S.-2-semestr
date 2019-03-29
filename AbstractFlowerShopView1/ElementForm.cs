using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.Interfaces;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System;
using System.Windows.Forms;
using Unity;

namespace AbstractFlowerShopView1
{
    public partial class ElementForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }    
        private readonly IElementService service;
        private int? id;
        public ElementForm(IElementService service)
        {
            InitializeComponent();
            this.service = service;
        }
        private void FormElement_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ElementViewModel view = service.ElementGet(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.ElementName;
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
                    service.UpdateElement(new ElementBindingModel
                    {
                        Id = id.Value,
                        ElementName = textBoxName.Text
                    });
                }
                else
                {
                    service.AddElement(new ElementBindingModel
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
