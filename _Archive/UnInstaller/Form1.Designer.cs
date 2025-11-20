namespace uninstall
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
            this.btnUninstall = new System.Windows.Forms.Button();
            this.lvInstalled = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbProviders = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnUninstall
            // 
            this.btnUninstall.Location = new System.Drawing.Point(534, 438);
            this.btnUninstall.Margin = new System.Windows.Forms.Padding(4);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(100, 26);
            this.btnUninstall.TabIndex = 0;
            this.btnUninstall.Text = "Uninstall";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // lvInstalled
            // 
            this.lvInstalled.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvInstalled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvInstalled.HideSelection = false;
            this.lvInstalled.Location = new System.Drawing.Point(13, 67);
            this.lvInstalled.Margin = new System.Windows.Forms.Padding(4);
            this.lvInstalled.MultiSelect = false;
            this.lvInstalled.Name = "lvInstalled";
            this.lvInstalled.Size = new System.Drawing.Size(620, 351);
            this.lvInstalled.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvInstalled.TabIndex = 1;
            this.lvInstalled.UseCompatibleStateImageBehavior = false;
            this.lvInstalled.View = System.Windows.Forms.View.Details;
            this.lvInstalled.SelectedIndexChanged += new System.EventHandler(this.lvInstalled_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Program Name";
            this.columnHeader1.Width = 615;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(13, 438);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 26);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "WMI Provider:";
            // 
            // lbProviders
            // 
            this.lbProviders.FormattingEnabled = true;
            this.lbProviders.ItemHeight = 15;
            this.lbProviders.Location = new System.Drawing.Point(114, 10);
            this.lbProviders.Name = "lbProviders";
            this.lbProviders.Size = new System.Drawing.Size(322, 49);
            this.lbProviders.TabIndex = 4;
            this.lbProviders.SelectedIndexChanged += new System.EventHandler(this.lbProviders_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 477);
            this.Controls.Add(this.lbProviders);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lvInstalled);
            this.Controls.Add(this.btnUninstall);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Uninstaller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.ListView lvInstalled;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbProviders;
    }
}

