namespace ScatterBot
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRestartServices = new System.Windows.Forms.CheckBox();
            this.chkSyncRSUFolders = new System.Windows.Forms.CheckBox();
            this.chkWebServerVersion = new System.Windows.Forms.CheckBox();
            this.chkLifeServerVersion = new System.Windows.Forms.CheckBox();
            this.chkAppServerVersion = new System.Windows.Forms.CheckBox();
            this.clstServerList = new System.Windows.Forms.CheckedListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMasterServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.clstServerList);
            this.splitContainer1.Panel1.Controls.Add(this.btnClose);
            this.splitContainer1.Panel1.Controls.Add(this.btnExecute);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtMasterServer);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtOutput);
            this.splitContainer1.Size = new System.Drawing.Size(624, 442);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRestartServices);
            this.groupBox1.Controls.Add(this.chkSyncRSUFolders);
            this.groupBox1.Controls.Add(this.chkWebServerVersion);
            this.groupBox1.Controls.Add(this.chkLifeServerVersion);
            this.groupBox1.Controls.Add(this.chkAppServerVersion);
            this.groupBox1.Location = new System.Drawing.Point(179, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 188);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ScatterBot Options";
            // 
            // chkRestartServices
            // 
            this.chkRestartServices.AutoSize = true;
            this.chkRestartServices.Location = new System.Drawing.Point(17, 153);
            this.chkRestartServices.Name = "chkRestartServices";
            this.chkRestartServices.Size = new System.Drawing.Size(104, 17);
            this.chkRestartServices.TabIndex = 17;
            this.chkRestartServices.Text = "Restart Services";
            this.chkRestartServices.UseVisualStyleBackColor = true;
            // 
            // chkSyncRSUFolders
            // 
            this.chkSyncRSUFolders.AutoSize = true;
            this.chkSyncRSUFolders.Location = new System.Drawing.Point(17, 121);
            this.chkSyncRSUFolders.Name = "chkSyncRSUFolders";
            this.chkSyncRSUFolders.Size = new System.Drawing.Size(126, 17);
            this.chkSyncRSUFolders.TabIndex = 16;
            this.chkSyncRSUFolders.Text = "Copy RSU packages";
            this.chkSyncRSUFolders.UseVisualStyleBackColor = true;
            // 
            // chkWebServerVersion
            // 
            this.chkWebServerVersion.AutoSize = true;
            this.chkWebServerVersion.Location = new System.Drawing.Point(17, 89);
            this.chkWebServerVersion.Name = "chkWebServerVersion";
            this.chkWebServerVersion.Size = new System.Drawing.Size(167, 17);
            this.chkWebServerVersion.TabIndex = 15;
            this.chkWebServerVersion.Text = "Copy Web Server Version File";
            this.chkWebServerVersion.UseVisualStyleBackColor = true;
            // 
            // chkLifeServerVersion
            // 
            this.chkLifeServerVersion.AutoSize = true;
            this.chkLifeServerVersion.Location = new System.Drawing.Point(17, 57);
            this.chkLifeServerVersion.Name = "chkLifeServerVersion";
            this.chkLifeServerVersion.Size = new System.Drawing.Size(161, 17);
            this.chkLifeServerVersion.TabIndex = 14;
            this.chkLifeServerVersion.Text = "Copy Life Server Version File";
            this.chkLifeServerVersion.UseVisualStyleBackColor = true;
            // 
            // chkAppServerVersion
            // 
            this.chkAppServerVersion.AutoSize = true;
            this.chkAppServerVersion.Location = new System.Drawing.Point(17, 25);
            this.chkAppServerVersion.Name = "chkAppServerVersion";
            this.chkAppServerVersion.Size = new System.Drawing.Size(163, 17);
            this.chkAppServerVersion.TabIndex = 13;
            this.chkAppServerVersion.Text = "Copy App Server Version File";
            this.chkAppServerVersion.UseVisualStyleBackColor = true;
            // 
            // clstServerList
            // 
            this.clstServerList.CheckOnClick = true;
            this.clstServerList.FormattingEnabled = true;
            this.clstServerList.Location = new System.Drawing.Point(12, 73);
            this.clstServerList.Name = "clstServerList";
            this.clstServerList.Size = new System.Drawing.Size(160, 124);
            this.clstServerList.TabIndex = 13;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(537, 174);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(456, 174);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 10;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Target Servers:";
            // 
            // txtMasterServer
            // 
            this.txtMasterServer.Location = new System.Drawing.Point(12, 26);
            this.txtMasterServer.Name = "txtMasterServer";
            this.txtMasterServer.ReadOnly = true;
            this.txtMasterServer.Size = new System.Drawing.Size(160, 20);
            this.txtMasterServer.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Master Server Hostname:";
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.White;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(624, 234);
            this.txtOutput.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScatterBot: RSU Server Distributor";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckedListBox clstServerList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMasterServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkRestartServices;
        private System.Windows.Forms.CheckBox chkSyncRSUFolders;
        private System.Windows.Forms.CheckBox chkWebServerVersion;
        private System.Windows.Forms.CheckBox chkLifeServerVersion;
        private System.Windows.Forms.CheckBox chkAppServerVersion;
        private System.Windows.Forms.TextBox txtOutput;
    }
}

