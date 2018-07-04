namespace XORdecryptor
{
    partial class mainForm
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
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.processBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.inputRegex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordRegex = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // outputBox
            // 
            this.outputBox.DetectUrls = false;
            this.outputBox.Location = new System.Drawing.Point(12, 31);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(300, 407);
            this.outputBox.TabIndex = 0;
            this.outputBox.Text = "";
            // 
            // processBtn
            // 
            this.processBtn.Location = new System.Drawing.Point(318, 101);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(144, 23);
            this.processBtn.TabIndex = 6;
            this.processBtn.Text = "Process";
            this.processBtn.UseVisualStyleBackColor = true;
            this.processBtn.Click += new System.EventHandler(this.processBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input Regex:";
            // 
            // inputRegex
            // 
            this.inputRegex.Location = new System.Drawing.Point(318, 31);
            this.inputRegex.Name = "inputRegex";
            this.inputRegex.Size = new System.Drawing.Size(144, 20);
            this.inputRegex.TabIndex = 1;
            this.inputRegex.Text = "(\\w|\\s)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password Regex:";
            // 
            // passwordRegex
            // 
            this.passwordRegex.Location = new System.Drawing.Point(318, 75);
            this.passwordRegex.Name = "passwordRegex";
            this.passwordRegex.Size = new System.Drawing.Size(144, 20);
            this.passwordRegex.TabIndex = 3;
            this.passwordRegex.Text = "\\w";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(318, 130);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(144, 23);
            this.progressBar.TabIndex = 7;
            this.progressBar.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "XORed strings (hex):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(318, 423);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Created by Zaczero (GitHub)";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.processBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordRegex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputRegex);
            this.Controls.Add(this.outputBox);
            this.Name = "mainForm";
            this.Text = "XORdecryptor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.Button processBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputRegex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordRegex;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

