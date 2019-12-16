namespace BesPrinter
{
    partial class FormViewImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormViewImage));
            this.buttonNextOne = new System.Windows.Forms.Button();
            this.buttonLastOne = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.timerOnFirstRefresh = new System.Windows.Forms.Timer(this.components);
            this.buttonPrintSetting = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNextOne
            // 
            resources.ApplyResources(this.buttonNextOne, "buttonNextOne");
            this.buttonNextOne.BackColor = System.Drawing.Color.Transparent;
            this.buttonNextOne.BackgroundImage = global::BesPrinter.Properties.Resources.nextOne;
            this.buttonNextOne.Name = "buttonNextOne";
            this.buttonNextOne.UseVisualStyleBackColor = false;
            this.buttonNextOne.Click += new System.EventHandler(this.buttonNextOne_Click);
            // 
            // buttonLastOne
            // 
            resources.ApplyResources(this.buttonLastOne, "buttonLastOne");
            this.buttonLastOne.BackColor = System.Drawing.Color.Transparent;
            this.buttonLastOne.BackgroundImage = global::BesPrinter.Properties.Resources.lastOne;
            this.buttonLastOne.CausesValidation = false;
            this.buttonLastOne.Name = "buttonLastOne";
            this.buttonLastOne.UseVisualStyleBackColor = false;
            this.buttonLastOne.Click += new System.EventHandler(this.buttonLastOne_Click);
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // timerOnFirstRefresh
            // 
            this.timerOnFirstRefresh.Tick += new System.EventHandler(this.timerOnFirstRefresh_Tick);
            // 
            // buttonPrintSetting
            // 
            resources.ApplyResources(this.buttonPrintSetting, "buttonPrintSetting");
            this.buttonPrintSetting.Name = "buttonPrintSetting";
            this.buttonPrintSetting.UseVisualStyleBackColor = true;
            this.buttonPrintSetting.Click += new System.EventHandler(this.buttonPrintSetting_Click);
            // 
            // buttonPrint
            // 
            resources.ApplyResources(this.buttonPrint, "buttonPrint");
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // FormViewImage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonPrintSetting);
            this.Controls.Add(this.buttonNextOne);
            this.Controls.Add(this.buttonLastOne);
            this.Controls.Add(this.pictureBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormViewImage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormViewImage_FormClosed);
            this.Shown += new System.EventHandler(this.FormViewImage_Shown);
            this.SizeChanged += new System.EventHandler(this.FormViewImage_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonLastOne;
        private System.Windows.Forms.Button buttonNextOne;
        private System.Windows.Forms.Timer timerOnFirstRefresh;
        private System.Windows.Forms.Button buttonPrintSetting;
        private System.Windows.Forms.Button buttonPrint;
    }
}