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

            this.label1 = new System.Windows.Forms.Label();
            this.colorDeltaLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();

            this.photo = new System.Windows.Forms.Button();
            this.buttonGray = new System.Windows.Forms.Button();
            this.buttonRecord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
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
<<<<<<< HEAD
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Różnica kolorów";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // colorDeltaLabel
            // 
            this.colorDeltaLabel.AutoSize = true;
            this.colorDeltaLabel.Font = new System.Drawing.Font("Red Hat Mono", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.colorDeltaLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.colorDeltaLabel.Location = new System.Drawing.Point(15, 369);
            this.colorDeltaLabel.Name = "colorDeltaLabel";
            this.colorDeltaLabel.Size = new System.Drawing.Size(272, 38);
            this.colorDeltaLabel.TabIndex = 5;
            this.colorDeltaLabel.Text = "Różnica kolorów";
            this.colorDeltaLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 454);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Trigger Threshold";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(22, 494);
            this.trackBar1.Maximum = 1500000;
            this.trackBar1.Minimum = 200000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(300, 69);
            this.trackBar1.SmallChange = 1000;
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Value = 400000;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 543);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Bardzo czuły";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 543);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nieczuły";
=======
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
>>>>>>> screenshots
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
<<<<<<< HEAD
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.colorDeltaLabel);
            this.Controls.Add(this.label1);
=======
            this.Controls.Add(this.buttonRecord);
            this.Controls.Add(this.buttonGray);
            this.Controls.Add(this.photo);
>>>>>>> screenshots
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.confirmCameraButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button confirmCameraButton;
        private System.Windows.Forms.PictureBox previewBox;
<<<<<<< HEAD
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label colorDeltaLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
=======
        private System.Windows.Forms.Button photo;
        private System.Windows.Forms.Button buttonGray;
        private System.Windows.Forms.Button buttonRecord;
>>>>>>> screenshots
    }
}

