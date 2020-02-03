namespace MoveFilesWithHash
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
            this.txtInputTxt = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowseForInput = new System.Windows.Forms.Button();
            this.btnBrowseForOutput = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // txtInputTxt
            // 
            this.txtInputTxt.Location = new System.Drawing.Point(12, 12);
            this.txtInputTxt.Name = "txtInputTxt";
            this.txtInputTxt.Size = new System.Drawing.Size(320, 22);
            this.txtInputTxt.TabIndex = 3;
            this.txtInputTxt.Text = "C:\\Users\\ralph\\source\\repos\\MoveFilesWithHash\\MoveFilesWithHash\\bin\\Debug\\moveme";
            // 
            // btnBrowseForInput
            // 
            this.btnBrowseForInput.Location = new System.Drawing.Point(338, 11);
            this.btnBrowseForInput.Name = "btnBrowseForInput";
            this.btnBrowseForInput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseForInput.TabIndex = 4;
            this.btnBrowseForInput.Text = "Browse";
            this.btnBrowseForInput.UseVisualStyleBackColor = true;
            this.btnBrowseForInput.Click += new System.EventHandler(this.btnBrowseForInput_Click);
            // 
            // btnBrowseForOutput
            // 
            this.btnBrowseForOutput.Location = new System.Drawing.Point(338, 55);
            this.btnBrowseForOutput.Name = "btnBrowseForOutput";
            this.btnBrowseForOutput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseForOutput.TabIndex = 5;
            this.btnBrowseForOutput.Text = "Browse";
            this.btnBrowseForOutput.UseVisualStyleBackColor = true;
            this.btnBrowseForOutput.Click += new System.EventHandler(this.btnBrowseForOutput_Click);
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(12, 55);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(320, 22);
            this.txtOutputPath.TabIndex = 6;
            this.txtOutputPath.Text = "C:\\Users\\ralph\\source\\repos\\MoveFilesWithHash\\MoveFilesWithHash\\bin\\Debug\\tohere";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(401, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Move Files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 123);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(401, 23);
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 158);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.btnBrowseForOutput);
            this.Controls.Add(this.btnBrowseForInput);
            this.Controls.Add(this.txtInputTxt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtInputTxt;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnBrowseForInput;
        private System.Windows.Forms.Button btnBrowseForOutput;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

