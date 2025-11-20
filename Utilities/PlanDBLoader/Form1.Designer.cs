namespace PlanDBLoader
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(421, 84);
            this.btnBrowseFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseFolder.TabIndex = 60;
            this.btnBrowseFolder.Text = "Browse";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 69;
            this.label4.Text = "Location of Folder";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(16, 87);
            this.txtOutputPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(397, 20);
            this.txtOutputPath.TabIndex = 59;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(143, 140);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 68;
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.SystemColors.Control;
            this.btnRun.Location = new System.Drawing.Point(421, 125);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 34);
            this.btnRun.TabIndex = 67;
            this.btnRun.Text = "Go";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Location = new System.Drawing.Point(421, 34);
            this.btnBrowseFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseFile.TabIndex = 57;
            this.btnBrowseFile.Text = "Browse";
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Location of Plans DB Script";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(16, 37);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(397, 20);
            this.txtPath.TabIndex = 56;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 178);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnBrowseFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "PlansDB Loader";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
    }
}

