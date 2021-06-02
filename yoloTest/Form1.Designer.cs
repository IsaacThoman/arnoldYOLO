
namespace yoloTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.checkBoxDOIR = new System.Windows.Forms.CheckBox();
            this.piCam1Box = new System.Windows.Forms.CheckBox();
            this.piCam3Box = new System.Windows.Forms.CheckBox();
            this.piCam2Box = new System.Windows.Forms.CheckBox();
            this.flip12Pi = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.piFlip13 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(427, 500);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(427, 529);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Detect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(346, 502);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Webcam";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(508, 529);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(136, 19);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "PC Webcam enabled";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(346, 528);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Pi cameras";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(508, 504);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(78, 19);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Pi camera";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // checkBoxDOIR
            // 
            this.checkBoxDOIR.AutoSize = true;
            this.checkBoxDOIR.Location = new System.Drawing.Point(508, 554);
            this.checkBoxDOIR.Name = "checkBoxDOIR";
            this.checkBoxDOIR.Size = new System.Drawing.Size(144, 19);
            this.checkBoxDOIR.TabIndex = 7;
            this.checkBoxDOIR.Text = "Do Image Recognition";
            this.checkBoxDOIR.UseVisualStyleBackColor = true;
            this.checkBoxDOIR.CheckedChanged += new System.EventHandler(this.checkBoxDOIR_CheckedChanged);
            // 
            // piCam1Box
            // 
            this.piCam1Box.AutoSize = true;
            this.piCam1Box.Checked = true;
            this.piCam1Box.CheckState = System.Windows.Forms.CheckState.Checked;
            this.piCam1Box.Location = new System.Drawing.Point(13, 503);
            this.piCam1Box.Name = "piCam1Box";
            this.piCam1Box.Size = new System.Drawing.Size(67, 19);
            this.piCam1Box.TabIndex = 8;
            this.piCam1Box.Text = "piCam1";
            this.piCam1Box.UseVisualStyleBackColor = true;
            // 
            // piCam3Box
            // 
            this.piCam3Box.AutoSize = true;
            this.piCam3Box.Checked = true;
            this.piCam3Box.CheckState = System.Windows.Forms.CheckState.Checked;
            this.piCam3Box.Location = new System.Drawing.Point(12, 554);
            this.piCam3Box.Name = "piCam3Box";
            this.piCam3Box.Size = new System.Drawing.Size(67, 19);
            this.piCam3Box.TabIndex = 9;
            this.piCam3Box.Text = "piCam3";
            this.piCam3Box.UseVisualStyleBackColor = true;
            // 
            // piCam2Box
            // 
            this.piCam2Box.AutoSize = true;
            this.piCam2Box.Checked = true;
            this.piCam2Box.CheckState = System.Windows.Forms.CheckState.Checked;
            this.piCam2Box.Location = new System.Drawing.Point(12, 531);
            this.piCam2Box.Name = "piCam2Box";
            this.piCam2Box.Size = new System.Drawing.Size(67, 19);
            this.piCam2Box.TabIndex = 10;
            this.piCam2Box.Text = "piCam2";
            this.piCam2Box.UseVisualStyleBackColor = true;
            // 
            // flip12Pi
            // 
            this.flip12Pi.AutoSize = true;
            this.flip12Pi.Location = new System.Drawing.Point(99, 503);
            this.flip12Pi.Name = "flip12Pi";
            this.flip12Pi.Size = new System.Drawing.Size(86, 19);
            this.flip12Pi.TabIndex = 11;
            this.flip12Pi.Text = "Flip 1 and 2";
            this.flip12Pi.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(99, 533);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(129, 19);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "Flip 2 and 3 (janker)";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // piFlip13
            // 
            this.piFlip13.AutoSize = true;
            this.piFlip13.Location = new System.Drawing.Point(99, 558);
            this.piFlip13.Name = "piFlip13";
            this.piFlip13.Size = new System.Drawing.Size(86, 19);
            this.piFlip13.TabIndex = 13;
            this.piFlip13.Text = "Flip 1 and 3";
            this.piFlip13.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 602);
            this.Controls.Add(this.piFlip13);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.flip12Pi);
            this.Controls.Add(this.piCam2Box);
            this.Controls.Add(this.piCam3Box);
            this.Controls.Add(this.piCam1Box);
            this.Controls.Add(this.checkBoxDOIR);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox checkBoxDOIR;
        private System.Windows.Forms.CheckBox piCam1Box;
        private System.Windows.Forms.CheckBox piCam3Box;
        private System.Windows.Forms.CheckBox piCam2Box;
        private System.Windows.Forms.CheckBox flip12Pi;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox piFlip13;
    }
}

