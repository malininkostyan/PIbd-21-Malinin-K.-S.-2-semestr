using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using AbstractFlowerShopServiceDAL1.Interfaces;
using AbstractFlowerShopServiceDAL1.ViewModel;
using AbstractFlowerShopServiceDAL1.BindingModel;

namespace AbstractFlowerShopView1
{
    public partial class PutOnStorageForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IStorageService serviceS;
        private readonly IElementService serviceC;
        private readonly IServiceMain serviceM;
        public PutOnStorageForm(IStorageService serviceS, IElementService serviceC,
        IServiceMain serviceM)
        {
            InitializeComponent();
            this.serviceS = serviceS;
            this.serviceC = serviceC;
            this.serviceM = serviceM;
        }
        private void FormPutOnStorage_Load(object sender, EventArgs e)
        {
            try
            {
                List<ElementViewModel> listC = serviceC.ListGet();
                if (listC != null)
                {
                    comboBoxElement.DisplayMember = "ElementName";
                    comboBoxElement.ValueMember = "Id";
                    comboBoxElement.DataSource = listC;
                    comboBoxElement.SelectedItem = null;
                }
                List<StorageViewModel> listS = serviceS.ListGet();
                if (listS != null)
                {
                    comboBoxStorage.DisplayMember = "StorageName";
                    comboBoxStorage.ValueMember = "Id";
                    comboBoxStorage.DataSource = listS;
                    comboBoxStorage.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAmount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxElement.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStorage.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                serviceM.PutElementOnStorage(new StorageElementBindingModel
                {
                    ElementId = Convert.ToInt32(comboBoxElement.SelectedValue),
                    StorageId = Convert.ToInt32(comboBoxStorage.SelectedValue),
                    Amount = Convert.ToInt32(textBoxAmount.Text)
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
