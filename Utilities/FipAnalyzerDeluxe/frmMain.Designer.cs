namespace FipAnalyzerDeluxe
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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboIllustrationType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboBillMode = new System.Windows.Forms.ComboBox();
            this.cboBillType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkListDividendOptions = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkListRiders = new System.Windows.Forms.CheckedListBox();
            this.chkFlatExtra = new System.Windows.Forms.CheckBox();
            this.chkTableRating = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboRatingClass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.dataResults = new System.Windows.Forms.DataGridView();
            this.lblFipCount = new System.Windows.Forms.Label();
            this.lblResultCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboSignedState = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboAgeGroup = new System.Windows.Forms.ComboBox();
            this.chkCostBenefit = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.grpBox.SuspendLayout();
            this.tabResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataResults)).BeginInit();
            this.SuspendLayout();
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select a target FIP folder";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(537, 407);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(456, 407);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 5;
            this.btnScan.Text = "Scan Folder";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabOptions);
            this.tabControl.Controls.Add(this.tabResults);
            this.tabControl.Location = new System.Drawing.Point(13, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(599, 388);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 6;
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.grpBox);
            this.tabOptions.Controls.Add(this.btnSelectFolder);
            this.tabOptions.Controls.Add(this.txtFolderPath);
            this.tabOptions.Controls.Add(this.label1);
            this.tabOptions.Location = new System.Drawing.Point(4, 22);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(591, 362);
            this.tabOptions.TabIndex = 0;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.chkCostBenefit);
            this.grpBox.Controls.Add(this.cboAgeGroup);
            this.grpBox.Controls.Add(this.label10);
            this.grpBox.Controls.Add(this.cboSignedState);
            this.grpBox.Controls.Add(this.label9);
            this.grpBox.Controls.Add(this.cboProductType);
            this.grpBox.Controls.Add(this.label8);
            this.grpBox.Controls.Add(this.label7);
            this.grpBox.Controls.Add(this.cboIllustrationType);
            this.grpBox.Controls.Add(this.label6);
            this.grpBox.Controls.Add(this.cboBillMode);
            this.grpBox.Controls.Add(this.cboBillType);
            this.grpBox.Controls.Add(this.label4);
            this.grpBox.Controls.Add(this.chkListDividendOptions);
            this.grpBox.Controls.Add(this.label3);
            this.grpBox.Controls.Add(this.chkListRiders);
            this.grpBox.Controls.Add(this.chkFlatExtra);
            this.grpBox.Controls.Add(this.chkTableRating);
            this.grpBox.Controls.Add(this.label5);
            this.grpBox.Controls.Add(this.cboRatingClass);
            this.grpBox.Controls.Add(this.label2);
            this.grpBox.Location = new System.Drawing.Point(6, 52);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(579, 304);
            this.grpBox.TabIndex = 7;
            this.grpBox.TabStop = false;
            this.grpBox.Text = "Analysis Options";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Illustration Type";
            // 
            // cboIllustrationType
            // 
            this.cboIllustrationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIllustrationType.FormattingEnabled = true;
            this.cboIllustrationType.Location = new System.Drawing.Point(6, 88);
            this.cboIllustrationType.Name = "cboIllustrationType";
            this.cboIllustrationType.Size = new System.Drawing.Size(121, 21);
            this.cboIllustrationType.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(429, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Bill Mode";
            // 
            // cboBillMode
            // 
            this.cboBillMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBillMode.FormattingEnabled = true;
            this.cboBillMode.Location = new System.Drawing.Point(432, 88);
            this.cboBillMode.Name = "cboBillMode";
            this.cboBillMode.Size = new System.Drawing.Size(121, 21);
            this.cboBillMode.TabIndex = 12;
            // 
            // cboBillType
            // 
            this.cboBillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBillType.FormattingEnabled = true;
            this.cboBillType.Location = new System.Drawing.Point(290, 88);
            this.cboBillType.Name = "cboBillType";
            this.cboBillType.Size = new System.Drawing.Size(121, 21);
            this.cboBillType.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Bill Type";
            // 
            // chkListDividendOptions
            // 
            this.chkListDividendOptions.CheckOnClick = true;
            this.chkListDividendOptions.FormattingEnabled = true;
            this.chkListDividendOptions.Items.AddRange(new object[] {
            "Cash",
            "Left with Woodmen",
            "Reduce Premiums",
            "Paid-up Additional Insurance (IL)"});
            this.chkListDividendOptions.Location = new System.Drawing.Point(7, 200);
            this.chkListDividendOptions.Name = "chkListDividendOptions";
            this.chkListDividendOptions.Size = new System.Drawing.Size(188, 64);
            this.chkListDividendOptions.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Dividend Options";
            // 
            // chkListRiders
            // 
            this.chkListRiders.CheckOnClick = true;
            this.chkListRiders.FormattingEnabled = true;
            this.chkListRiders.Items.AddRange(new object[] {
            "Accelerated Benefit",
            "Accidental Death",
            "Waiver of Premium",
            "Applicant Waiver"});
            this.chkListRiders.Location = new System.Drawing.Point(221, 200);
            this.chkListRiders.Name = "chkListRiders";
            this.chkListRiders.Size = new System.Drawing.Size(188, 64);
            this.chkListRiders.TabIndex = 7;
            // 
            // chkFlatExtra
            // 
            this.chkFlatExtra.AutoSize = true;
            this.chkFlatExtra.Location = new System.Drawing.Point(10, 139);
            this.chkFlatExtra.Name = "chkFlatExtra";
            this.chkFlatExtra.Size = new System.Drawing.Size(70, 17);
            this.chkFlatExtra.TabIndex = 6;
            this.chkFlatExtra.Text = "Flat Extra";
            this.chkFlatExtra.UseVisualStyleBackColor = true;
            // 
            // chkTableRating
            // 
            this.chkTableRating.AutoSize = true;
            this.chkTableRating.Location = new System.Drawing.Point(10, 119);
            this.chkTableRating.Name = "chkTableRating";
            this.chkTableRating.Size = new System.Drawing.Size(87, 17);
            this.chkTableRating.TabIndex = 5;
            this.chkTableRating.Text = "Table Rating";
            this.chkTableRating.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Riders";
            // 
            // cboRatingClass
            // 
            this.cboRatingClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRatingClass.FormattingEnabled = true;
            this.cboRatingClass.Location = new System.Drawing.Point(148, 88);
            this.cboRatingClass.Name = "cboRatingClass";
            this.cboRatingClass.Size = new System.Drawing.Size(121, 21);
            this.cboRatingClass.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rating Class";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(312, 25);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(73, 21);
            this.btnSelectFolder.TabIndex = 6;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(6, 25);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(300, 20);
            this.txtFolderPath.TabIndex = 5;
            this.txtFolderPath.TextChanged += new System.EventHandler(this.txtFolderPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select a target folder containing *.FIP files to analyze.";
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.dataResults);
            this.tabResults.Location = new System.Drawing.Point(4, 22);
            this.tabResults.Name = "tabResults";
            this.tabResults.Padding = new System.Windows.Forms.Padding(3);
            this.tabResults.Size = new System.Drawing.Size(591, 362);
            this.tabResults.TabIndex = 1;
            this.tabResults.Text = "Results";
            this.tabResults.UseVisualStyleBackColor = true;
            // 
            // dataResults
            // 
            this.dataResults.AllowUserToAddRows = false;
            this.dataResults.AllowUserToDeleteRows = false;
            this.dataResults.AllowUserToResizeColumns = false;
            this.dataResults.AllowUserToResizeRows = false;
            this.dataResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataResults.Location = new System.Drawing.Point(3, 3);
            this.dataResults.Name = "dataResults";
            this.dataResults.ReadOnly = true;
            this.dataResults.RowHeadersVisible = false;
            this.dataResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataResults.ShowCellErrors = false;
            this.dataResults.ShowCellToolTips = false;
            this.dataResults.ShowEditingIcon = false;
            this.dataResults.Size = new System.Drawing.Size(585, 356);
            this.dataResults.TabIndex = 0;
            this.dataResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataResults_CellDoubleClick);
            // 
            // lblFipCount
            // 
            this.lblFipCount.AutoSize = true;
            this.lblFipCount.Location = new System.Drawing.Point(10, 412);
            this.lblFipCount.Name = "lblFipCount";
            this.lblFipCount.Size = new System.Drawing.Size(49, 13);
            this.lblFipCount.TabIndex = 8;
            this.lblFipCount.Text = "FipCount";
            // 
            // lblResultCount
            // 
            this.lblResultCount.AutoSize = true;
            this.lblResultCount.Location = new System.Drawing.Point(241, 412);
            this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.Size = new System.Drawing.Size(65, 13);
            this.lblResultCount.TabIndex = 9;
            this.lblResultCount.Text = "ResultCount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Product Type";
            // 
            // cboProductType
            // 
            this.cboProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Location = new System.Drawing.Point(6, 38);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(121, 21);
            this.cboProductType.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(148, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Signed State";
            // 
            // cboSignedState
            // 
            this.cboSignedState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSignedState.FormattingEnabled = true;
            this.cboSignedState.Location = new System.Drawing.Point(148, 38);
            this.cboSignedState.Name = "cboSignedState";
            this.cboSignedState.Size = new System.Drawing.Size(121, 21);
            this.cboSignedState.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(290, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Age";
            // 
            // cboAgeGroup
            // 
            this.cboAgeGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgeGroup.FormattingEnabled = true;
            this.cboAgeGroup.Location = new System.Drawing.Point(290, 38);
            this.cboAgeGroup.Name = "cboAgeGroup";
            this.cboAgeGroup.Size = new System.Drawing.Size(121, 21);
            this.cboAgeGroup.TabIndex = 21;
            // 
            // chkCostBenefit
            // 
            this.chkCostBenefit.AutoSize = true;
            this.chkCostBenefit.Location = new System.Drawing.Point(148, 119);
            this.chkCostBenefit.Name = "chkCostBenefit";
            this.chkCostBenefit.Size = new System.Drawing.Size(92, 17);
            this.chkCostBenefit.TabIndex = 22;
            this.chkCostBenefit.Text = "Cost && Benefit";
            this.chkCostBenefit.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.lblResultCount);
            this.Controls.Add(this.lblFipCount);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FIP Analyzer Deluxe";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl.ResumeLayout(false);
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
            this.grpBox.ResumeLayout(false);
            this.grpBox.PerformLayout();
            this.tabResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabResults;
        private System.Windows.Forms.DataGridView dataResults;
        private System.Windows.Forms.ComboBox cboRatingClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFipCount;
        private System.Windows.Forms.Label lblResultCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboBillMode;
        private System.Windows.Forms.ComboBox cboBillType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox chkListDividendOptions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox chkListRiders;
        private System.Windows.Forms.CheckBox chkFlatExtra;
        private System.Windows.Forms.CheckBox chkTableRating;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboIllustrationType;
        private System.Windows.Forms.ComboBox cboProductType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboSignedState;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboAgeGroup;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkCostBenefit;
    }
}

