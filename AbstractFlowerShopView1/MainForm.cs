using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.Interfaces;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace AbstractFlowerShopView1
{
    public partial class MainForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private ILogService logService;
        private readonly IServiceMain service;
        public MainForm(IServiceMain service, ILogService logService)
        {
            InitializeComponent();
            this.service = service;
            this.logService = logService;
        }
        private void LoadData()
        {
            try
            {
                List<BookingViewModel> list = service.ListGet();
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void покупателиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<CustomersForm>();
            form.ShowDialog();
        }
        private void элементыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<ElementsForm>();
            form.ShowDialog();
        }
        private void букетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<BouquetsForm>();
            form.ShowDialog();
        }
        private void пополнитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<PutOnStorageForm>();
            form.ShowDialog();
        }

        private void складыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<StoragesForm>();
            form.ShowDialog();
        }
        private void buttonCreateBooking_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<BookingForm>();
            form.ShowDialog();
            LoadData();
        }
        private void buttonTakeBookingInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    service.TakeBookingInWork(new BookingBindingModel { Id = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        private void buttonBookingReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    service.FinishBooking(new BookingBindingModel { Id = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        private void buttonPayBooking_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    service.PayBooking(new BookingBindingModel { Id = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void прайсИзделийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "doc|*.doc|docx|*.docx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    logService.SaveBouquetPrice(new LogBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void загруженностьСкладовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<StoragesLoadForm>();
            form.ShowDialog();
        }
        private void заказыКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<CustomerBookingForm>();
            form.ShowDialog();
        }
    }
}
