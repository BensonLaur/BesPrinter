namespace BesPrinter
{
    partial class FormPrintSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrintSetting));
            this.labelPrinter = new System.Windows.Forms.Label();
            this.labelPaper = new System.Windows.Forms.Label();
            this.comboBoxPrinter = new System.Windows.Forms.ComboBox();
            this.comboBoxPaper = new System.Windows.Forms.ComboBox();
            this.buttonSettingPrinter = new System.Windows.Forms.Button();
            this.labelMarginLeft = new System.Windows.Forms.Label();
            this.labelMarginRight = new System.Windows.Forms.Label();
            this.textBoxMarginLeft = new System.Windows.Forms.TextBox();
            this.textBoxMarginRight = new System.Windows.Forms.TextBox();
            this.textBoxMarginBottom = new System.Windows.Forms.TextBox();
            this.textBoxMarginTop = new System.Windows.Forms.TextBox();
            this.labelMarginBottom = new System.Windows.Forms.Label();
            this.labelMarginTop = new System.Windows.Forms.Label();
            this.checkBoxKeepRadio = new System.Windows.Forms.CheckBox();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // labelPrinter
            // 
            this.labelPrinter.Location = new System.Drawing.Point(25, 33);
            this.labelPrinter.Name = "labelPrinter";
            this.labelPrinter.Size = new System.Drawing.Size(112, 40);
            this.labelPrinter.TabIndex = 0;
            this.labelPrinter.Text = "当前打印机";
            this.labelPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPaper
            // 
            this.labelPaper.Location = new System.Drawing.Point(25, 73);
            this.labelPaper.Name = "labelPaper";
            this.labelPaper.Size = new System.Drawing.Size(112, 40);
            this.labelPaper.TabIndex = 1;
            this.labelPaper.Text = "当前纸张";
            this.labelPaper.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxPrinter
            // 
            this.comboBoxPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrinter.Enabled = false;
            this.comboBoxPrinter.FormattingEnabled = true;
            this.comboBoxPrinter.Location = new System.Drawing.Point(154, 40);
            this.comboBoxPrinter.Name = "comboBoxPrinter";
            this.comboBoxPrinter.Size = new System.Drawing.Size(309, 28);
            this.comboBoxPrinter.TabIndex = 2;
            // 
            // comboBoxPaper
            // 
            this.comboBoxPaper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPaper.FormattingEnabled = true;
            this.comboBoxPaper.Location = new System.Drawing.Point(154, 80);
            this.comboBoxPaper.Name = "comboBoxPaper";
            this.comboBoxPaper.Size = new System.Drawing.Size(174, 28);
            this.comboBoxPaper.TabIndex = 3;
            this.comboBoxPaper.SelectedIndexChanged += new System.EventHandler(this.comboBoxPaper_SelectedIndexChanged);
            // 
            // buttonSettingPrinter
            // 
            this.buttonSettingPrinter.Location = new System.Drawing.Point(345, 80);
            this.buttonSettingPrinter.Name = "buttonSettingPrinter";
            this.buttonSettingPrinter.Size = new System.Drawing.Size(118, 30);
            this.buttonSettingPrinter.TabIndex = 4;
            this.buttonSettingPrinter.Text = "设置打印机";
            this.buttonSettingPrinter.UseVisualStyleBackColor = true;
            this.buttonSettingPrinter.Click += new System.EventHandler(this.buttonSettingPrinter_Click);
            // 
            // labelMarginLeft
            // 
            this.labelMarginLeft.Location = new System.Drawing.Point(25, 131);
            this.labelMarginLeft.Name = "labelMarginLeft";
            this.labelMarginLeft.Size = new System.Drawing.Size(112, 40);
            this.labelMarginLeft.TabIndex = 5;
            this.labelMarginLeft.Text = "左边距";
            this.labelMarginLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMarginRight
            // 
            this.labelMarginRight.Location = new System.Drawing.Point(25, 167);
            this.labelMarginRight.Name = "labelMarginRight";
            this.labelMarginRight.Size = new System.Drawing.Size(112, 40);
            this.labelMarginRight.TabIndex = 6;
            this.labelMarginRight.Text = "右边距";
            this.labelMarginRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxMarginLeft
            // 
            this.textBoxMarginLeft.Location = new System.Drawing.Point(154, 138);
            this.textBoxMarginLeft.Name = "textBoxMarginLeft";
            this.textBoxMarginLeft.Size = new System.Drawing.Size(89, 27);
            this.textBoxMarginLeft.TabIndex = 7;
            this.textBoxMarginLeft.TextChanged += new System.EventHandler(this.textBoxMarginLeft_TextChanged);
            // 
            // textBoxMarginRight
            // 
            this.textBoxMarginRight.Location = new System.Drawing.Point(154, 174);
            this.textBoxMarginRight.Name = "textBoxMarginRight";
            this.textBoxMarginRight.Size = new System.Drawing.Size(89, 27);
            this.textBoxMarginRight.TabIndex = 8;
            this.textBoxMarginRight.TextChanged += new System.EventHandler(this.textBoxMarginRight_TextChanged);
            // 
            // textBoxMarginBottom
            // 
            this.textBoxMarginBottom.Location = new System.Drawing.Point(376, 174);
            this.textBoxMarginBottom.Name = "textBoxMarginBottom";
            this.textBoxMarginBottom.Size = new System.Drawing.Size(87, 27);
            this.textBoxMarginBottom.TabIndex = 12;
            this.textBoxMarginBottom.TextChanged += new System.EventHandler(this.textBoxMarginBottom_TextChanged);
            // 
            // textBoxMarginTop
            // 
            this.textBoxMarginTop.Location = new System.Drawing.Point(376, 138);
            this.textBoxMarginTop.Name = "textBoxMarginTop";
            this.textBoxMarginTop.Size = new System.Drawing.Size(87, 27);
            this.textBoxMarginTop.TabIndex = 11;
            this.textBoxMarginTop.TextChanged += new System.EventHandler(this.textBoxMarginTop_TextChanged);
            // 
            // labelMarginBottom
            // 
            this.labelMarginBottom.Location = new System.Drawing.Point(273, 167);
            this.labelMarginBottom.Name = "labelMarginBottom";
            this.labelMarginBottom.Size = new System.Drawing.Size(86, 40);
            this.labelMarginBottom.TabIndex = 10;
            this.labelMarginBottom.Text = "下边距";
            this.labelMarginBottom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMarginTop
            // 
            this.labelMarginTop.Location = new System.Drawing.Point(275, 131);
            this.labelMarginTop.Name = "labelMarginTop";
            this.labelMarginTop.Size = new System.Drawing.Size(84, 40);
            this.labelMarginTop.TabIndex = 9;
            this.labelMarginTop.Text = "上边距";
            this.labelMarginTop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxKeepRadio
            // 
            this.checkBoxKeepRadio.AutoSize = true;
            this.checkBoxKeepRadio.Location = new System.Drawing.Point(154, 231);
            this.checkBoxKeepRadio.Name = "checkBoxKeepRadio";
            this.checkBoxKeepRadio.Size = new System.Drawing.Size(151, 24);
            this.checkBoxKeepRadio.TabIndex = 13;
            this.checkBoxKeepRadio.Text = "保持原图比例居中";
            this.checkBoxKeepRadio.UseVisualStyleBackColor = true;
            this.checkBoxKeepRadio.CheckedChanged += new System.EventHandler(this.checkBoxKeepRadio_CheckedChanged);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // FormPrintSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 303);
            this.Controls.Add(this.checkBoxKeepRadio);
            this.Controls.Add(this.textBoxMarginBottom);
            this.Controls.Add(this.textBoxMarginTop);
            this.Controls.Add(this.labelMarginBottom);
            this.Controls.Add(this.labelMarginTop);
            this.Controls.Add(this.textBoxMarginRight);
            this.Controls.Add(this.textBoxMarginLeft);
            this.Controls.Add(this.labelMarginRight);
            this.Controls.Add(this.labelMarginLeft);
            this.Controls.Add(this.buttonSettingPrinter);
            this.Controls.Add(this.comboBoxPaper);
            this.Controls.Add(this.comboBoxPrinter);
            this.Controls.Add(this.labelPaper);
            this.Controls.Add(this.labelPrinter);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(544, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(544, 350);
            this.Name = "FormPrintSetting";
            this.Text = "打印机设置";
            this.Load += new System.EventHandler(this.FormPrintSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPrinter;
        private System.Windows.Forms.Label labelPaper;
        private System.Windows.Forms.ComboBox comboBoxPrinter;
        private System.Windows.Forms.ComboBox comboBoxPaper;
        private System.Windows.Forms.Button buttonSettingPrinter;
        private System.Windows.Forms.Label labelMarginLeft;
        private System.Windows.Forms.Label labelMarginRight;
        private System.Windows.Forms.TextBox textBoxMarginLeft;
        private System.Windows.Forms.TextBox textBoxMarginRight;
        private System.Windows.Forms.TextBox textBoxMarginBottom;
        private System.Windows.Forms.TextBox textBoxMarginTop;
        private System.Windows.Forms.Label labelMarginBottom;
        private System.Windows.Forms.Label labelMarginTop;
        private System.Windows.Forms.CheckBox checkBoxKeepRadio;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
    }
}