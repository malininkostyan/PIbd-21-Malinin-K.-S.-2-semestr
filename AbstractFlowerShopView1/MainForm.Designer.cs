namespace AbstractFlowerShopView1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказчикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.элементыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.букетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прайсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загруженностьСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonPayBooking = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.unityContainerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonBookingReady = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonTakeBookingInWork = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unityContainerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнитьСкладToolStripMenuItem,
            this.отчётыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1080, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заказчикиToolStripMenuItem,
            this.элементыToolStripMenuItem,
            this.букетыToolStripMenuItem,
            this.складыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // заказчикиToolStripMenuItem
            // 
            this.заказчикиToolStripMenuItem.Name = "заказчикиToolStripMenuItem";
            this.заказчикиToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.заказчикиToolStripMenuItem.Text = "Покупатели";
            this.заказчикиToolStripMenuItem.Click += new System.EventHandler(this.покупателиToolStripMenuItem_Click);
            // 
            // элементыToolStripMenuItem
            // 
            this.элементыToolStripMenuItem.Name = "элементыToolStripMenuItem";
            this.элементыToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.элементыToolStripMenuItem.Text = "Элементы";
            this.элементыToolStripMenuItem.Click += new System.EventHandler(this.элементыToolStripMenuItem_Click);
            // 
            // букетыToolStripMenuItem
            // 
            this.букетыToolStripMenuItem.Name = "букетыToolStripMenuItem";
            this.букетыToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.букетыToolStripMenuItem.Text = "Букеты";
            this.букетыToolStripMenuItem.Click += new System.EventHandler(this.букетыToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
            // 
            // пополнитьСкладToolStripMenuItem
            // 
            this.пополнитьСкладToolStripMenuItem.Name = "пополнитьСкладToolStripMenuItem";
            this.пополнитьСкладToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.пополнитьСкладToolStripMenuItem.Text = "Пополнить склад";
            this.пополнитьСкладToolStripMenuItem.Click += new System.EventHandler(this.пополнитьСкладToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прайсToolStripMenuItem,
            this.загруженностьСкладовToolStripMenuItem,
            this.заказыToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // прайсToolStripMenuItem
            // 
            this.прайсToolStripMenuItem.Name = "прайсToolStripMenuItem";
            this.прайсToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.прайсToolStripMenuItem.Text = "Прайс букетов";
            this.прайсToolStripMenuItem.Click += new System.EventHandler(this.прайсИзделийToolStripMenuItem_Click);
            // 
            // загруженностьСкладовToolStripMenuItem
            // 
            this.загруженностьСкладовToolStripMenuItem.Name = "загруженностьСкладовToolStripMenuItem";
            this.загруженностьСкладовToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.загруженностьСкладовToolStripMenuItem.Text = "Загруженность складов";
            this.загруженностьСкладовToolStripMenuItem.Click += new System.EventHandler(this.загруженностьСкладовToolStripMenuItem_Click);
            // 
            // заказыToolStripMenuItem
            // 
            this.заказыToolStripMenuItem.Name = "заказыToolStripMenuItem";
            this.заказыToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.заказыToolStripMenuItem.Text = "Заказы клиентов";
            this.заказыToolStripMenuItem.Click += new System.EventHandler(this.заказыКлиентовToolStripMenuItem_Click);
            // 
            // buttonPayBooking
            // 
            this.buttonPayBooking.Location = new System.Drawing.Point(891, 218);
            this.buttonPayBooking.Name = "buttonPayBooking";
            this.buttonPayBooking.Size = new System.Drawing.Size(177, 35);
            this.buttonPayBooking.TabIndex = 23;
            this.buttonPayBooking.Text = "Заказ оплачен";
            this.buttonPayBooking.UseVisualStyleBackColor = true;
            this.buttonPayBooking.Click += new System.EventHandler(this.buttonPayBooking_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 31);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(885, 300);
            this.dataGridView.TabIndex = 19;
            // 
            // unityContainerBindingSource
            // 
            // 
            // buttonBookingReady
            // 
            this.buttonBookingReady.Location = new System.Drawing.Point(891, 159);
            this.buttonBookingReady.Name = "buttonBookingReady";
            this.buttonBookingReady.Size = new System.Drawing.Size(177, 35);
            this.buttonBookingReady.TabIndex = 22;
            this.buttonBookingReady.Text = "Заказ готов";
            this.buttonBookingReady.UseVisualStyleBackColor = true;
            this.buttonBookingReady.Click += new System.EventHandler(this.buttonBookingReady_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(891, 45);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(177, 35);
            this.buttonCreate.TabIndex = 20;
            this.buttonCreate.Text = "Создать заказ";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreateBooking_Click);
            // 
            // buttonTakeBookingInWork
            // 
            this.buttonTakeBookingInWork.Location = new System.Drawing.Point(891, 98);
            this.buttonTakeBookingInWork.Name = "buttonTakeBookingInWork";
            this.buttonTakeBookingInWork.Size = new System.Drawing.Size(177, 35);
            this.buttonTakeBookingInWork.TabIndex = 21;
            this.buttonTakeBookingInWork.Text = "Отдать на выполнение";
            this.buttonTakeBookingInWork.UseVisualStyleBackColor = true;
            this.buttonTakeBookingInWork.Click += new System.EventHandler(this.buttonTakeBookingInWork_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(891, 278);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(177, 35);
            this.buttonRef.TabIndex = 24;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 334);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayBooking);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonBookingReady);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonTakeBookingInWork);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Цветочная лавка";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unityContainerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказчикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem элементыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem букетыToolStripMenuItem;
        private System.Windows.Forms.Button buttonPayBooking;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonBookingReady;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonTakeBookingInWork;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.BindingSource unityContainerBindingSource;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьСкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прайсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загруженностьСкладовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыToolStripMenuItem;
    }
}

