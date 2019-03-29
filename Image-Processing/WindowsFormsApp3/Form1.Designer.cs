namespace WindowsFormsApp3
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
            this.panShape1 = new System.Windows.Forms.Panel();
            this.panShape2 = new System.Windows.Forms.Panel();
            this.InitializeShapes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panShape1
            // 
            this.panShape1.Location = new System.Drawing.Point(31, 45);
            this.panShape1.Name = "panShape1";
            this.panShape1.Size = new System.Drawing.Size(333, 299);
            this.panShape1.TabIndex = 0;
            // 
            // panShape2
            // 
            this.panShape2.Location = new System.Drawing.Point(431, 45);
            this.panShape2.Name = "panShape2";
            this.panShape2.Size = new System.Drawing.Size(328, 299);
            this.panShape2.TabIndex = 1;
            // 
            // InitializeShapes
            // 
            this.InitializeShapes.Location = new System.Drawing.Point(110, 378);
            this.InitializeShapes.Name = "InitializeShapes";
            this.InitializeShapes.Size = new System.Drawing.Size(151, 42);
            this.InitializeShapes.TabIndex = 2;
            this.InitializeShapes.Text = "InitializeShapes";
            this.InitializeShapes.UseVisualStyleBackColor = true;
            this.InitializeShapes.Click += new System.EventHandler(this.InitializeShapes_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(517, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InitializeShapes);
            this.Controls.Add(this.panShape2);
            this.Controls.Add(this.panShape1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panShape1;
        private System.Windows.Forms.Panel panShape2;
        private System.Windows.Forms.Button InitializeShapes;
        private System.Windows.Forms.Button button1;
    }
}

