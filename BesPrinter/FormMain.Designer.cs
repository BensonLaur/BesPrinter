namespace BesPrinter
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelPath = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.listViewImage = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.buttonPrintSetting = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonSelectFloder = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTipFormMain = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox_batch = new System.Windows.Forms.CheckBox();
            this.label_total_count_tip = new System.Windows.Forms.Label();
            this.label_count_once_tip = new System.Windows.Forms.Label();
            this.textBox_count_once = new System.Windows.Forms.TextBox();
            this.label_current_batch_tip = new System.Windows.Forms.Label();
            this.label_total_count = new System.Windows.Forms.Label();
            this.label_current_batch = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPath
            // 
            resources.ApplyResources(this.labelPath, "labelPath");
            this.labelPath.Name = "labelPath";
            this.toolTipFormMain.SetToolTip(this.labelPath, resources.GetString("labelPath.ToolTip"));
            // 
            // textBoxPath
            // 
            resources.ApplyResources(this.textBoxPath, "textBoxPath");
            this.textBoxPath.CausesValidation = false;
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.toolTipFormMain.SetToolTip(this.textBoxPath, resources.GetString("textBoxPath.ToolTip"));
            // 
            // buttonSelectFile
            // 
            resources.ApplyResources(this.buttonSelectFile, "buttonSelectFile");
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.toolTipFormMain.SetToolTip(this.buttonSelectFile, resources.GetString("buttonSelectFile.ToolTip"));
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // listViewImage
            // 
            resources.ApplyResources(this.listViewImage, "listViewImage");
            this.listViewImage.LargeImageList = this.imageList;
            this.listViewImage.Name = "listViewImage";
            this.listViewImage.ShowItemToolTips = true;
            this.listViewImage.SmallImageList = this.imageList;
            this.listViewImage.StateImageList = this.imageList;
            this.toolTipFormMain.SetToolTip(this.listViewImage, resources.GetString("listViewImage.ToolTip"));
            this.listViewImage.UseCompatibleStateImageBehavior = false;
            this.listViewImage.View = System.Windows.Forms.View.List;
            this.listViewImage.DoubleClick += new System.EventHandler(this.ListViewItemDoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "bmp.png");
            this.imageList.Images.SetKeyName(1, "png.png");
            this.imageList.Images.SetKeyName(2, "jpg.png");
            this.imageList.Images.SetKeyName(3, "jpeg.png");
            this.imageList.Images.SetKeyName(4, "svg.png");
            this.imageList.Images.SetKeyName(5, "emf.png");
            this.imageList.Images.SetKeyName(6, "image.png");
            // 
            // buttonPrintSetting
            // 
            resources.ApplyResources(this.buttonPrintSetting, "buttonPrintSetting");
            this.buttonPrintSetting.Name = "buttonPrintSetting";
            this.toolTipFormMain.SetToolTip(this.buttonPrintSetting, resources.GetString("buttonPrintSetting.ToolTip"));
            this.buttonPrintSetting.UseVisualStyleBackColor = true;
            this.buttonPrintSetting.Click += new System.EventHandler(this.buttonPrintSetting_Click);
            // 
            // buttonPrint
            // 
            resources.ApplyResources(this.buttonPrint, "buttonPrint");
            this.buttonPrint.Name = "buttonPrint";
            this.toolTipFormMain.SetToolTip(this.buttonPrint, resources.GetString("buttonPrint.ToolTip"));
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonSelectFloder
            // 
            resources.ApplyResources(this.buttonSelectFloder, "buttonSelectFloder");
            this.buttonSelectFloder.Name = "buttonSelectFloder";
            this.toolTipFormMain.SetToolTip(this.buttonSelectFloder, resources.GetString("buttonSelectFloder.ToolTip"));
            this.buttonSelectFloder.UseVisualStyleBackColor = true;
            this.buttonSelectFloder.Click += new System.EventHandler(this.buttonSelectFloder_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // folderBrowserDialog
            // 
            resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
            // 
            // toolTipFormMain
            // 
            this.toolTipFormMain.AutomaticDelay = 100;
            this.toolTipFormMain.AutoPopDelay = 5000;
            this.toolTipFormMain.InitialDelay = 50;
            this.toolTipFormMain.ReshowDelay = 20;
            this.toolTipFormMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipFormMain.ToolTipTitle = "Tip";
            // 
            // checkBox_batch
            // 
            resources.ApplyResources(this.checkBox_batch, "checkBox_batch");
            this.checkBox_batch.Name = "checkBox_batch";
            this.toolTipFormMain.SetToolTip(this.checkBox_batch, resources.GetString("checkBox_batch.ToolTip"));
            this.checkBox_batch.UseVisualStyleBackColor = true;
            this.checkBox_batch.CheckedChanged += new System.EventHandler(this.checkBox_batch_CheckedChanged);
            // 
            // label_total_count_tip
            // 
            resources.ApplyResources(this.label_total_count_tip, "label_total_count_tip");
            this.label_total_count_tip.CausesValidation = false;
            this.label_total_count_tip.Name = "label_total_count_tip";
            this.toolTipFormMain.SetToolTip(this.label_total_count_tip, resources.GetString("label_total_count_tip.ToolTip"));
            // 
            // label_count_once_tip
            // 
            resources.ApplyResources(this.label_count_once_tip, "label_count_once_tip");
            this.label_count_once_tip.CausesValidation = false;
            this.label_count_once_tip.Name = "label_count_once_tip";
            this.toolTipFormMain.SetToolTip(this.label_count_once_tip, resources.GetString("label_count_once_tip.ToolTip"));
            // 
            // textBox_count_once
            // 
            resources.ApplyResources(this.textBox_count_once, "textBox_count_once");
            this.textBox_count_once.Name = "textBox_count_once";
            this.toolTipFormMain.SetToolTip(this.textBox_count_once, resources.GetString("textBox_count_once.ToolTip"));
            this.textBox_count_once.TextChanged += new System.EventHandler(this.textBox_count_once_TextChanged);
            // 
            // label_current_batch_tip
            // 
            resources.ApplyResources(this.label_current_batch_tip, "label_current_batch_tip");
            this.label_current_batch_tip.CausesValidation = false;
            this.label_current_batch_tip.Name = "label_current_batch_tip";
            this.toolTipFormMain.SetToolTip(this.label_current_batch_tip, resources.GetString("label_current_batch_tip.ToolTip"));
            // 
            // label_total_count
            // 
            resources.ApplyResources(this.label_total_count, "label_total_count");
            this.label_total_count.CausesValidation = false;
            this.label_total_count.Name = "label_total_count";
            this.toolTipFormMain.SetToolTip(this.label_total_count, resources.GetString("label_total_count.ToolTip"));
            // 
            // label_current_batch
            // 
            resources.ApplyResources(this.label_current_batch, "label_current_batch");
            this.label_current_batch.CausesValidation = false;
            this.label_current_batch.Name = "label_current_batch";
            this.toolTipFormMain.SetToolTip(this.label_current_batch, resources.GetString("label_current_batch.ToolTip"));
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_current_batch);
            this.Controls.Add(this.textBox_count_once);
            this.Controls.Add(this.label_total_count);
            this.Controls.Add(this.label_current_batch_tip);
            this.Controls.Add(this.label_count_once_tip);
            this.Controls.Add(this.label_total_count_tip);
            this.Controls.Add(this.checkBox_batch);
            this.Controls.Add(this.buttonSelectFloder);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonPrintSetting);
            this.Controls.Add(this.listViewImage);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.labelPath);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.toolTipFormMain.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.ListView listViewImage;
        private System.Windows.Forms.Button buttonPrintSetting;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonSelectFloder;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolTip toolTipFormMain;
        private System.Windows.Forms.CheckBox checkBox_batch;
        private System.Windows.Forms.Label label_total_count_tip;
        private System.Windows.Forms.Label label_count_once_tip;
        private System.Windows.Forms.TextBox textBox_count_once;
        private System.Windows.Forms.Label label_current_batch_tip;
        private System.Windows.Forms.Label label_total_count;
        private System.Windows.Forms.Label label_current_batch;
    }
}

