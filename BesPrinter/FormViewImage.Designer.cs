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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNextOne
            // 
            this.buttonNextOne.BackColor = System.Drawing.Color.Transparent;
            this.buttonNextOne.BackgroundImage = global::BesPrinter.Properties.Resources.nextOne;
            this.buttonNextOne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNextOne.Location = new System.Drawing.Point(310, 509);
            this.buttonNextOne.Name = "buttonNextOne";
            this.buttonNextOne.Size = new System.Drawing.Size(32, 32);
            this.buttonNextOne.TabIndex = 1;
            this.buttonNextOne.UseVisualStyleBackColor = false;
            this.buttonNextOne.Click += new System.EventHandler(this.buttonNextOne_Click);
            // 
            // buttonLastOne
            // 
            this.buttonLastOne.BackColor = System.Drawing.Color.Transparent;
            this.buttonLastOne.BackgroundImage = global::BesPrinter.Properties.Resources.lastOne;
            this.buttonLastOne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLastOne.CausesValidation = false;
            this.buttonLastOne.Location = new System.Drawing.Point(269, 509);
            this.buttonLastOne.Name = "buttonLastOne";
            this.buttonLastOne.Size = new System.Drawing.Size(32, 32);
            this.buttonLastOne.TabIndex = 2;
            this.buttonLastOne.UseVisualStyleBackColor = false;
            this.buttonLastOne.Click += new System.EventHandler(this.buttonLastOne_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(558, 491);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // timerOnFirstRefresh
            // 
            this.timerOnFirstRefresh.Tick += new System.EventHandler(this.timerOnFirstRefresh_Tick);
            // 
            // FormViewImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.Controls.Add(this.buttonNextOne);
            this.Controls.Add(this.buttonLastOne);
            this.Controls.Add(this.pictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
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
    }
}