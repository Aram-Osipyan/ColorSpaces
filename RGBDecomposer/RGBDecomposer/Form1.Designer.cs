namespace RGBDecomposer
{
    partial class Form1
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
            this.OriginalPicture = new System.Windows.Forms.PictureBox();
            this.RedPicture = new System.Windows.Forms.PictureBox();
            this.GreenPicture = new System.Windows.Forms.PictureBox();
            this.BluePicture = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gistogramR = new System.Windows.Forms.PictureBox();
            this.gistogramG = new System.Windows.Forms.PictureBox();
            this.gistogramB = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BluePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gistogramR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gistogramG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gistogramB)).BeginInit();
            this.SuspendLayout();
            // 
            // OriginalPicture
            // 
            this.OriginalPicture.Location = new System.Drawing.Point(12, 12);
            this.OriginalPicture.Name = "OriginalPicture";
            this.OriginalPicture.Size = new System.Drawing.Size(159, 163);
            this.OriginalPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OriginalPicture.TabIndex = 1;
            this.OriginalPicture.TabStop = false;
            // 
            // RedPicture
            // 
            this.RedPicture.Location = new System.Drawing.Point(243, 12);
            this.RedPicture.Name = "RedPicture";
            this.RedPicture.Size = new System.Drawing.Size(159, 163);
            this.RedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RedPicture.TabIndex = 2;
            this.RedPicture.TabStop = false;
            // 
            // GreenPicture
            // 
            this.GreenPicture.Location = new System.Drawing.Point(473, 12);
            this.GreenPicture.Name = "GreenPicture";
            this.GreenPicture.Size = new System.Drawing.Size(159, 163);
            this.GreenPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GreenPicture.TabIndex = 3;
            this.GreenPicture.TabStop = false;
            // 
            // BluePicture
            // 
            this.BluePicture.Location = new System.Drawing.Point(700, 12);
            this.BluePicture.Name = "BluePicture";
            this.BluePicture.Size = new System.Drawing.Size(159, 163);
            this.BluePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BluePicture.TabIndex = 4;
            this.BluePicture.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 468);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "Find Picture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.findPicture_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 468);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 38);
            this.button2.TabIndex = 8;
            this.button2.Text = "Confirm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gistogramR
            // 
            this.gistogramR.Location = new System.Drawing.Point(12, 194);
            this.gistogramR.Name = "gistogramR";
            this.gistogramR.Size = new System.Drawing.Size(256, 200);
            this.gistogramR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gistogramR.TabIndex = 9;
            this.gistogramR.TabStop = false;
            this.gistogramR.Click += new System.EventHandler(this.gistogram_Click);
            // 
            // gistogramG
            // 
            this.gistogramG.Location = new System.Drawing.Point(306, 194);
            this.gistogramG.Name = "gistogramG";
            this.gistogramG.Size = new System.Drawing.Size(256, 200);
            this.gistogramG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gistogramG.TabIndex = 10;
            this.gistogramG.TabStop = false;
            // 
            // gistogramB
            // 
            this.gistogramB.Location = new System.Drawing.Point(603, 194);
            this.gistogramB.Name = "gistogramB";
            this.gistogramB.Size = new System.Drawing.Size(256, 200);
            this.gistogramB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gistogramB.TabIndex = 11;
            this.gistogramB.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Red histogram";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Green histogram";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(673, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Blue histogram";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gistogramB);
            this.Controls.Add(this.gistogramG);
            this.Controls.Add(this.gistogramR);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BluePicture);
            this.Controls.Add(this.GreenPicture);
            this.Controls.Add(this.RedPicture);
            this.Controls.Add(this.OriginalPicture);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BluePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gistogramR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gistogramG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gistogramB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox OriginalPicture;
        private System.Windows.Forms.PictureBox RedPicture;
        private System.Windows.Forms.PictureBox GreenPicture;
        private System.Windows.Forms.PictureBox BluePicture;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox gistogramR;
        private System.Windows.Forms.PictureBox gistogramG;
        private System.Windows.Forms.PictureBox gistogramB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

