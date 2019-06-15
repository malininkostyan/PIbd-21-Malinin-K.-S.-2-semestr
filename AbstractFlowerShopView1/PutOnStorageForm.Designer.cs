namespace AbstractFlowerShopView1
{
    partial class PutOnStorageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxStorage = new System.Windows.Forms.ComboBox();
            this.comboBoxElement = new System.Windows.Forms.ComboBox();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Склад: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Элемент: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Количество: ";
            // 
            // comboBoxStorage
            // 
            this.comboBoxStorage.FormattingEnabled = true;
            this.comboBoxStorage.Location = new System.Drawing.Point(112, 6);
            this.comboBoxStorage.Name = "comboBoxStorage";
            this.comboBoxStorage.Size = new System.Drawing.Size(252, 24);
            this.comboBoxStorage.TabIndex = 3;
            // 
            // comboBoxElement
            // 
            this.comboBoxElement.FormattingEnabled = true;
            this.comboBoxElement.Location = new System.Drawing.Point(112, 36);
            this.comboBoxElement.Name = "comboBoxElement";
            this.comboBoxElement.Size = new System.Drawing.Size(252, 24);
            this.comboBoxElement.TabIndex = 4;
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(112, 74);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(252, 22);
            this.textBoxAmount.TabIndex = 5;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(266, 102);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(98, 27);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(162, 102);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(98, 27);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // PutOnStorageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 141);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.comboBoxElement);
            this.Controls.Add(this.comboBoxStorage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PutOnStorageForm";
            this.Text = "Пополнение склада";
            this.Load += new System.EventHandler(this.FormPutOnStorage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxStorage;
        private System.Windows.Forms.ComboBox comboBoxElement;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}