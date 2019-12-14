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
            resources.ApplyResources(this.labelPrinter, "labelPrinter");
            this.labelPrinter.Name = "labelPrinter";
            // 
            // labelPaper
            // 
            resources.ApplyResources(this.labelPaper, "labelPaper");
            this.labelPaper.Name = "labelPaper";
            // 
            // comboBoxPrinter
            // 
            resources.ApplyResources(this.comboBoxPrinter, "comboBoxPrinter");
            this.comboBoxPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrinter.FormattingEnabled = true;
            this.comboBoxPrinter.Name = "comboBoxPrinter";
            // 
            // comboBoxPaper
            // 
            resources.ApplyResources(this.comboBoxPaper, "comboBoxPaper");
            this.comboBoxPaper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPaper.FormattingEnabled = true;
            this.comboBoxPaper.Name = "comboBoxPaper";
            this.comboBoxPaper.SelectedIndexChanged += new System.EventHandler(this.comboBoxPaper_SelectedIndexChanged);
            // 
            // buttonSettingPrinter
            // 
            resources.ApplyResources(this.buttonSettingPrinter, "buttonSettingPrinter");
            this.buttonSettingPrinter.Name = "buttonSettingPrinter";
            this.buttonSettingPrinter.UseVisualStyleBackColor = true;
            this.buttonSettingPrinter.Click += new System.EventHandler(this.buttonSettingPrinter_Click);
            // 
            // labelMarginLeft
            // 
            resources.ApplyResources(this.labelMarginLeft, "labelMarginLeft");
            this.labelMarginLeft.Name = "labelMarginLeft";
            // 
            // labelMarginRight
            // 
            resources.ApplyResources(this.labelMarginRight, "labelMarginRight");
            this.labelMarginRight.Name = "labelMarginRight";
            // 
            // textBoxMarginLeft
            // 
            resources.ApplyResources(this.textBoxMarginLeft, "textBoxMarginLeft");
            this.textBoxMarginLeft.Name = "textBoxMarginLeft";
            this.textBoxMarginLeft.TextChanged += new System.EventHandler(this.textBoxMarginLeft_TextChanged);
            // 
            // textBoxMarginRight
            // 
            resources.ApplyResources(this.textBoxMarginRight, "textBoxMarginRight");
            this.textBoxMarginRight.Name = "textBoxMarginRight";
            this.textBoxMarginRight.TextChanged += new System.EventHandler(this.textBoxMarginRight_TextChanged);
            // 
            // textBoxMarginBottom
            // 
            resources.ApplyResources(this.textBoxMarginBottom, "textBoxMarginBottom");
            this.textBoxMarginBottom.Name = "textBoxMarginBottom";
            this.textBoxMarginBottom.TextChanged += new System.EventHandler(this.textBoxMarginBottom_TextChanged);
            // 
            // textBoxMarginTop
            // 
            resources.ApplyResources(this.textBoxMarginTop, "textBoxMarginTop");
            this.textBoxMarginTop.Name = "textBoxMarginTop";
            this.textBoxMarginTop.TextChanged += new System.EventHandler(this.textBoxMarginTop_TextChanged);
            // 
            // labelMarginBottom
            // 
            resources.ApplyResources(this.labelMarginBottom, "labelMarginBottom");
            this.labelMarginBottom.Name = "labelMarginBottom";
            // 
            // labelMarginTop
            // 
            resources.ApplyResources(this.labelMarginTop, "labelMarginTop");
            this.labelMarginTop.Name = "labelMarginTop";
            // 
            // checkBoxKeepRadio
            // 
            resources.ApplyResources(this.checkBoxKeepRadio, "checkBoxKeepRadio");
            this.checkBoxKeepRadio.Name = "checkBoxKeepRadio";
            this.checkBoxKeepRadio.UseVisualStyleBackColor = true;
            this.checkBoxKeepRadio.CheckedChanged += new System.EventHandler(this.checkBoxKeepRadio_CheckedChanged);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(this.printPreviewDialog, "printPreviewDialog");
            this.printPreviewDialog.Name = "printPreviewDialog";
            // 
            // FormPrintSetting
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrintSetting";
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