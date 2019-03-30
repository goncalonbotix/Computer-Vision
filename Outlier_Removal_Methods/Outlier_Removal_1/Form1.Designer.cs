namespace Outlier_Removal_1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panShape1 = new System.Windows.Forms.Panel();
            this.panShape2 = new System.Windows.Forms.Panel();
            this.panShape3 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(65, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Initialize Shapes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(339, 380);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "Apply Transformation";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(562, 380);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 39);
            this.button3.TabIndex = 2;
            this.button3.Text = "Exhaustive Evaluation";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panShape1
            // 
            this.panShape1.Location = new System.Drawing.Point(12, 40);
            this.panShape1.Name = "panShape1";
            this.panShape1.Size = new System.Drawing.Size(231, 281);
            this.panShape1.TabIndex = 3;
            // 
            // panShape2
            // 
            this.panShape2.Location = new System.Drawing.Point(286, 40);
            this.panShape2.Name = "panShape2";
            this.panShape2.Size = new System.Drawing.Size(232, 281);
            this.panShape2.TabIndex = 4;
            // 
            // panShape3
            // 
            this.panShape3.Location = new System.Drawing.Point(562, 40);
            this.panShape3.Name = "panShape3";
            this.panShape3.Size = new System.Drawing.Size(226, 281);
            this.panShape3.TabIndex = 5;
            this.panShape3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(667, 380);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 39);
            this.button4.TabIndex = 6;
            this.button4.Text = "RANSAC";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panShape3);
            this.Controls.Add(this.panShape2);
            this.Controls.Add(this.panShape1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panShape1;
        private System.Windows.Forms.Panel panShape2;
        private System.Windows.Forms.Panel panShape3;
        private System.Windows.Forms.Button button4;
    }
}

