namespace WOW.Illustration.Utilities.ValuesOutputComparer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblFiles = new System.Windows.Forms.Label();
            this.splMain = new System.Windows.Forms.SplitContainer();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.lblSourceDirectory = new System.Windows.Forms.Label();
            this.txtSourceDirectory = new System.Windows.Forms.TextBox();
            this.staMainStatus = new System.Windows.Forms.StatusStrip();
            this.pnlStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlDetail = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblDecimalPlaces = new System.Windows.Forms.Label();
            this.nudDecimalPlaces = new System.Windows.Forms.NumericUpDown();
            this.chkRelevantOnly = new System.Windows.Forms.CheckBox();
            this.chkExcludeLastColumnError = new System.Windows.Forms.CheckBox();
            this.chkReformatFiles = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.Panel1.SuspendLayout();
            this.splMain.Panel2.SuspendLayout();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.staMainStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDecimalPlaces)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFiles
            // 
            resources.ApplyResources(this.lblFiles, "lblFiles");
            this.lblFiles.Name = "lblFiles";
            // 
            // splMain
            // 
            resources.ApplyResources(this.splMain, "splMain");
            this.splMain.Name = "splMain";
            // 
            // splMain.Panel1
            // 
            this.splMain.Panel1.Controls.Add(this.lstFiles);
            // 
            // splMain.Panel2
            // 
            this.splMain.Panel2.Controls.Add(this.dgvResults);
            // 
            // lstFiles
            // 
            resources.ApplyResources(this.lstFiles, "lstFiles");
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.SelectedValueChanged += new System.EventHandler(this.lstFiles_SelectedValueChanged);
            this.lstFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstFiles_MouseDoubleClick);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvResults, "dgvResults");
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            // 
            // lblSourceDirectory
            // 
            resources.ApplyResources(this.lblSourceDirectory, "lblSourceDirectory");
            this.lblSourceDirectory.Name = "lblSourceDirectory";
            // 
            // txtSourceDirectory
            // 
            resources.ApplyResources(this.txtSourceDirectory, "txtSourceDirectory");
            this.txtSourceDirectory.Name = "txtSourceDirectory";
            // 
            // staMainStatus
            // 
            this.staMainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pnlStatus,
            this.pnlDetail});
            resources.ApplyResources(this.staMainStatus, "staMainStatus");
            this.staMainStatus.Name = "staMainStatus";
            // 
            // pnlStatus
            // 
            this.pnlStatus.Name = "pnlStatus";
            resources.ApplyResources(this.pnlStatus, "pnlStatus");
            this.pnlStatus.Spring = true;
            // 
            // pnlDetail
            // 
            this.pnlDetail.Name = "pnlDetail";
            resources.ApplyResources(this.pnlDetail, "pnlDetail");
            this.pnlDetail.Spring = true;
            // 
            // btnCompare
            // 
            resources.ApplyResources(this.btnCompare, "btnCompare");
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnBrowse
            // 
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.Image = global::WOW.Illustration.Utilities.ValuesOutputComparer.Properties.Resources.Search16;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblDecimalPlaces
            // 
            resources.ApplyResources(this.lblDecimalPlaces, "lblDecimalPlaces");
            this.lblDecimalPlaces.Name = "lblDecimalPlaces";
            // 
            // nudDecimalPlaces
            // 
            resources.ApplyResources(this.nudDecimalPlaces, "nudDecimalPlaces");
            this.nudDecimalPlaces.Maximum = new decimal(new int[] {
            28,
            0,
            0,
            0});
            this.nudDecimalPlaces.Name = "nudDecimalPlaces";
            // 
            // chkRelevantOnly
            // 
            resources.ApplyResources(this.chkRelevantOnly, "chkRelevantOnly");
            this.chkRelevantOnly.Checked = true;
            this.chkRelevantOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRelevantOnly.Name = "chkRelevantOnly";
            this.chkRelevantOnly.UseVisualStyleBackColor = true;
            // 
            // chkExcludeLastColumnError
            // 
            resources.ApplyResources(this.chkExcludeLastColumnError, "chkExcludeLastColumnError");
            this.chkExcludeLastColumnError.Checked = true;
            this.chkExcludeLastColumnError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeLastColumnError.Name = "chkExcludeLastColumnError";
            this.chkExcludeLastColumnError.UseVisualStyleBackColor = true;
            // 
            // chkReformatFiles
            // 
            resources.ApplyResources(this.chkReformatFiles, "chkReformatFiles");
            this.chkReformatFiles.Checked = true;
            this.chkReformatFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReformatFiles.Name = "chkReformatFiles";
            this.chkReformatFiles.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Name = "btnExport";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.chkReformatFiles);
            this.Controls.Add(this.chkExcludeLastColumnError);
            this.Controls.Add(this.chkRelevantOnly);
            this.Controls.Add(this.nudDecimalPlaces);
            this.Controls.Add(this.lblDecimalPlaces);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.staMainStatus);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtSourceDirectory);
            this.Controls.Add(this.lblSourceDirectory);
            this.Controls.Add(this.splMain);
            this.Controls.Add(this.lblFiles);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splMain.Panel1.ResumeLayout(false);
            this.splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.staMainStatus.ResumeLayout(false);
            this.staMainStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDecimalPlaces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.SplitContainer splMain;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Label lblSourceDirectory;
        private System.Windows.Forms.TextBox txtSourceDirectory;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.StatusStrip staMainStatus;
        private System.Windows.Forms.ToolStripStatusLabel pnlStatus;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.ToolStripStatusLabel pnlDetail;
        private System.Windows.Forms.Label lblDecimalPlaces;
        private System.Windows.Forms.NumericUpDown nudDecimalPlaces;
        private System.Windows.Forms.CheckBox chkRelevantOnly;
        private System.Windows.Forms.CheckBox chkExcludeLastColumnError;
        private System.Windows.Forms.CheckBox chkReformatFiles;
        private System.Windows.Forms.Button btnExport;
    }
}

