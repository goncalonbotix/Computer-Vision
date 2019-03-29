namespace WindowsFormsComputerVision1
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.OriginalPicBox = new System.Windows.Forms.PictureBox();
            this.ResultPicBox = new System.Windows.Forms.PictureBox();
            this.SizeInfo = new System.Windows.Forms.TextBox();
            this.Grayscale = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(180, 414);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Load Image";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(378, 414);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 29);
            this.button3.TabIndex = 2;
            this.button3.Text = "Brighten";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(551, 414);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 29);
            this.button4.TabIndex = 3;
            this.button4.Text = "Contrast";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(679, 414);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(97, 29);
            this.button5.TabIndex = 4;
            this.button5.Text = "Histogram Equalization";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // OriginalPicBox
            // 
            this.OriginalPicBox.Location = new System.Drawing.Point(25, 39);
            this.OriginalPicBox.Name = "OriginalPicBox";
            this.OriginalPicBox.Size = new System.Drawing.Size(384, 365);
            this.OriginalPicBox.TabIndex = 5;
            this.OriginalPicBox.TabStop = false;
            this.OriginalPicBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ResultPicBox
            // 
            this.ResultPicBox.Location = new System.Drawing.Point(425, 39);
            this.ResultPicBox.Name = "ResultPicBox";
            this.ResultPicBox.Size = new System.Drawing.Size(351, 355);
            this.ResultPicBox.TabIndex = 6;
            this.ResultPicBox.TabStop = false;
            // 
            // SizeInfo
            // 
            this.SizeInfo.Location = new System.Drawing.Point(25, 13);
            this.SizeInfo.Name = "SizeInfo";
            this.SizeInfo.Size = new System.Drawing.Size(100, 20);
            this.SizeInfo.TabIndex = 7;
            // 
            // Grayscale
            // 
            this.Grayscale.Location = new System.Drawing.Point(25, 414);
            this.Grayscale.Name = "Grayscale";
            this.Grayscale.Size = new System.Drawing.Size(100, 26);
            this.Grayscale.TabIndex = 8;
            this.Grayscale.Text = "Grayscale";
            this.Grayscale.UseVisualStyleBackColor = true;
            this.Grayscale.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(525, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Grayscale);
            this.Controls.Add(this.SizeInfo);
            this.Controls.Add(this.ResultPicBox);
            this.Controls.Add(this.OriginalPicBox);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox OriginalPicBox;
        private System.Windows.Forms.PictureBox ResultPicBox;
        private System.Windows.Forms.TextBox SizeInfo;
        private System.Windows.Forms.Button Grayscale;
        private System.Windows.Forms.Button button1;
    }
}

