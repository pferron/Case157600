namespace ResetUpdates
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDetectedVersionNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewVersionNumber = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkDeleteRsuFiles = new System.Windows.Forms.CheckBox();
            this.chkDeleteDbInstances = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detected Version Number";
            // 
            // txtDetectedVersionNumber
            // 
            this.txtDetectedVersionNumber.Location = new System.Drawing.Point(20, 46);
            this.txtDetectedVersionNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDetectedVersionNumber.Name = "txtDetectedVersionNumber";
            this.txtDetectedVersionNumber.ReadOnly = true;
            this.txtDetectedVersionNumber.Size = new System.Drawing.Size(192, 26);
            this.txtDetectedVersionNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "New Version Number";
            // 
            // txtNewVersionNumber
            // 
            this.txtNewVersionNumber.Location = new System.Drawing.Point(20, 117);
            this.txtNewVersionNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNewVersionNumber.Name = "txtNewVersionNumber";
            this.txtNewVersionNumber.Size = new System.Drawing.Size(192, 26);
            this.txtNewVersionNumber.TabIndex = 3;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(160, 256);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(112, 35);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(282, 256);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 35);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkDeleteRsuFiles
            // 
            this.chkDeleteRsuFiles.AutoSize = true;
            this.chkDeleteRsuFiles.Location = new System.Drawing.Point(20, 172);
            this.chkDeleteRsuFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDeleteRsuFiles.Name = "chkDeleteRsuFiles";
            this.chkDeleteRsuFiles.Size = new System.Drawing.Size(153, 24);
            this.chkDeleteRsuFiles.TabIndex = 6;
            this.chkDeleteRsuFiles.Text = "Purge RSU Files";
            this.chkDeleteRsuFiles.UseVisualStyleBackColor = true;
            // 
            // chkDeleteDbInstances
            // 
            this.chkDeleteDbInstances.AutoSize = true;
            this.chkDeleteDbInstances.Location = new System.Drawing.Point(20, 206);
            this.chkDeleteDbInstances.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDeleteDbInstances.Name = "chkDeleteDbInstances";
            this.chkDeleteDbInstances.Size = new System.Drawing.Size(221, 24);
            this.chkDeleteDbInstances.TabIndex = 7;
            this.chkDeleteDbInstances.Text = "Delete LocalDB Instances";
            this.chkDeleteDbInstances.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 312);
            this.Controls.Add(this.chkDeleteDbInstances);
            this.Controls.Add(this.chkDeleteRsuFiles);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtNewVersionNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDetectedVersionNumber);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LifePortraits RSU Reset Utility";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDetectedVersionNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewVersionNumber;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkDeleteRsuFiles;
        private System.Windows.Forms.CheckBox chkDeleteDbInstances;
    }
}

