namespace Webcam
{
    partial class Form1
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.confirmCameraButton = new System.Windows.Forms.Button();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.photo = new System.Windows.Forms.Button();
            this.buttonGray = new System.Windows.Forms.Button();
            this.buttonRecord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(18, 18);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 28);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(210, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // confirmCameraButton
            // 
            this.confirmCameraButton.Location = new System.Drawing.Point(210, 58);
            this.confirmCameraButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.confirmCameraButton.Name = "confirmCameraButton";
            this.confirmCameraButton.Size = new System.Drawing.Size(112, 35);
            this.confirmCameraButton.TabIndex = 2;
            this.confirmCameraButton.Text = "Confirm";
            this.confirmCameraButton.UseVisualStyleBackColor = true;
            this.confirmCameraButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // previewBox
            // 
            this.previewBox.Location = new System.Drawing.Point(366, 58);
            this.previewBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(764, 586);
            this.previewBox.TabIndex = 3;
            this.previewBox.TabStop = false;
            // 
            // photo
            // 
            this.photo.Location = new System.Drawing.Point(366, 14);
            this.photo.Name = "photo";
            this.photo.Size = new System.Drawing.Size(75, 36);
            this.photo.TabIndex = 4;
            this.photo.Text = "Zdjecie";
            this.photo.UseVisualStyleBackColor = true;
            this.photo.Click += new System.EventHandler(this.buttonPhoto_Click);
            // 
            // buttonGray
            // 
            this.buttonGray.Location = new System.Drawing.Point(199, 101);
            this.buttonGray.Name = "buttonGray";
            this.buttonGray.Size = new System.Drawing.Size(132, 46);
            this.buttonGray.TabIndex = 5;
            this.buttonGray.Text = "Czarno/Biały";
            this.buttonGray.UseVisualStyleBackColor = true;
            this.buttonGray.Click += new System.EventHandler(this.buttonGray_Click);
            // 
            // buttonRecord
            // 
            this.buttonRecord.Location = new System.Drawing.Point(543, 14);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(123, 36);
            this.buttonRecord.TabIndex = 6;
            this.buttonRecord.Text = "Nagrywanie";
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.buttonRecord);
            this.Controls.Add(this.buttonGray);
            this.Controls.Add(this.photo);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.confirmCameraButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button confirmCameraButton;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.Button photo;
        private System.Windows.Forms.Button buttonGray;
        private System.Windows.Forms.Button buttonRecord;
    }
}

