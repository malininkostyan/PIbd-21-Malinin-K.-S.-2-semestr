namespace AbstractFlowerShopView1
{
    partial class CustomerBookingForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonToPdf = new System.Windows.Forms.Button();
            this.buttonMake = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonToPdf);
            this.panel1.Controls.Add(this.buttonMake);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePickerTo);
            this.panel1.Controls.Add(this.dateTimePickerFrom);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 37);
            this.panel1.TabIndex = 0;
            // 
            // buttonToPdf
            // 
            this.buttonToPdf.Location = new System.Drawing.Point(719, 3);
            this.buttonToPdf.Name = "buttonToPdf";
            this.buttonToPdf.Size = new System.Drawing.Size(136, 31);
            this.buttonToPdf.TabIndex = 4;
            this.buttonToPdf.Text = "В PDF";
            this.buttonToPdf.UseVisualStyleBackColor = true;
            this.buttonToPdf.Click += new System.EventHandler(this.buttonToPdf_Click);
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(472, 3);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(197, 31);
            this.buttonMake.TabIndex = 3;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "По";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "C";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "По";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(268, 9);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(171, 22);
            this.dateTimePickerTo.TabIndex = 1;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(49, 9);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(171, 22);
            this.dateTimePickerFrom.TabIndex = 0;
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "AbstractFlowerShopView1.Report.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(1, 40);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(982, 524);
            this.reportViewer.TabIndex = 1;
            // 
            // CustomerBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 564);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.panel1);
            this.Name = "CustomerBookingForm";
            this.Text = "Заказы клиентов";
            this.Load += new System.EventHandler(this.CustomerBookingForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonToPdf;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}