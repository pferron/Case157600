namespace CommonIllustrationServiceTester
{
    partial class CISTestForm
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
            this.btnPlainRequest = new System.Windows.Forms.Button();
            this.tbResults = new System.Windows.Forms.TextBox();
            this.btnBadRequest1 = new System.Windows.Forms.Button();
            this.btnBadRequest2 = new System.Windows.Forms.Button();
            this.btnBadRequest3 = new System.Windows.Forms.Button();
            this.gbIul = new System.Windows.Forms.GroupBox();
            this.btnBadRequest4 = new System.Windows.Forms.Button();
            this.btnPermanentRatingRequest = new System.Windows.Forms.Button();
            this.btnCoverageRequest = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnWebServiceValidate = new System.Windows.Forms.RadioButton();
            this.rbtnValidateLocally = new System.Windows.Forms.RadioButton();
            this.btnLoadTitaniumIllusBasic = new System.Windows.Forms.Button();
            this.cbRegions = new System.Windows.Forms.ComboBox();
            this.lblRegion = new System.Windows.Forms.Label();
            this.btnLoadTitaniumGeneralCost = new System.Windows.Forms.Button();
            this.btnLoadTitaniumAmendCost = new System.Windows.Forms.Button();
            this.btnLoadTitaniumIllusRevised = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.gbIul.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlainRequest
            // 
            this.btnPlainRequest.Location = new System.Drawing.Point(5, 18);
            this.btnPlainRequest.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlainRequest.Name = "btnPlainRequest";
            this.btnPlainRequest.Size = new System.Drawing.Size(106, 30);
            this.btnPlainRequest.TabIndex = 0;
            this.btnPlainRequest.Text = "ValidPlainRequest";
            this.btnPlainRequest.UseVisualStyleBackColor = true;
            this.btnPlainRequest.Click += new System.EventHandler(this.btnPlainRequest_Click);
            // 
            // tbResults
            // 
            this.tbResults.Location = new System.Drawing.Point(8, 215);
            this.tbResults.Margin = new System.Windows.Forms.Padding(2);
            this.tbResults.Multiline = true;
            this.tbResults.Name = "tbResults";
            this.tbResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbResults.Size = new System.Drawing.Size(683, 162);
            this.tbResults.TabIndex = 1;
            // 
            // btnBadRequest1
            // 
            this.btnBadRequest1.Location = new System.Drawing.Point(6, 64);
            this.btnBadRequest1.Name = "btnBadRequest1";
            this.btnBadRequest1.Size = new System.Drawing.Size(105, 30);
            this.btnBadRequest1.TabIndex = 2;
            this.btnBadRequest1.Text = "BadRequest1";
            this.btnBadRequest1.UseVisualStyleBackColor = true;
            this.btnBadRequest1.Click += new System.EventHandler(this.btnBadTestCase1_Click);
            // 
            // btnBadRequest2
            // 
            this.btnBadRequest2.Location = new System.Drawing.Point(117, 64);
            this.btnBadRequest2.Name = "btnBadRequest2";
            this.btnBadRequest2.Size = new System.Drawing.Size(104, 30);
            this.btnBadRequest2.TabIndex = 3;
            this.btnBadRequest2.Text = "BadRequest2";
            this.btnBadRequest2.UseVisualStyleBackColor = true;
            this.btnBadRequest2.Click += new System.EventHandler(this.btnBadRequest2_Click);
            // 
            // btnBadRequest3
            // 
            this.btnBadRequest3.Location = new System.Drawing.Point(227, 64);
            this.btnBadRequest3.Name = "btnBadRequest3";
            this.btnBadRequest3.Size = new System.Drawing.Size(104, 30);
            this.btnBadRequest3.TabIndex = 4;
            this.btnBadRequest3.Text = "BadRequest3";
            this.btnBadRequest3.UseVisualStyleBackColor = true;
            this.btnBadRequest3.Click += new System.EventHandler(this.btnBadRequest3_Click);
            // 
            // gbIul
            // 
            this.gbIul.Controls.Add(this.btnBadRequest4);
            this.gbIul.Controls.Add(this.btnPermanentRatingRequest);
            this.gbIul.Controls.Add(this.btnBadRequest3);
            this.gbIul.Controls.Add(this.btnCoverageRequest);
            this.gbIul.Controls.Add(this.btnPlainRequest);
            this.gbIul.Controls.Add(this.btnBadRequest1);
            this.gbIul.Controls.Add(this.btnBadRequest2);
            this.gbIul.Location = new System.Drawing.Point(11, 99);
            this.gbIul.Name = "gbIul";
            this.gbIul.Size = new System.Drawing.Size(447, 100);
            this.gbIul.TabIndex = 6;
            this.gbIul.TabStop = false;
            this.gbIul.Text = "IUL";
            // 
            // btnBadRequest4
            // 
            this.btnBadRequest4.Location = new System.Drawing.Point(337, 64);
            this.btnBadRequest4.Name = "btnBadRequest4";
            this.btnBadRequest4.Size = new System.Drawing.Size(104, 30);
            this.btnBadRequest4.TabIndex = 7;
            this.btnBadRequest4.Text = "BadRequest4";
            this.btnBadRequest4.UseVisualStyleBackColor = true;
            this.btnBadRequest4.Click += new System.EventHandler(this.btnBadRequest4_Click);
            // 
            // btnPermanentRatingRequest
            // 
            this.btnPermanentRatingRequest.Location = new System.Drawing.Point(227, 18);
            this.btnPermanentRatingRequest.Name = "btnPermanentRatingRequest";
            this.btnPermanentRatingRequest.Size = new System.Drawing.Size(141, 30);
            this.btnPermanentRatingRequest.TabIndex = 6;
            this.btnPermanentRatingRequest.Text = "PermanentRatingRequest";
            this.btnPermanentRatingRequest.UseVisualStyleBackColor = true;
            this.btnPermanentRatingRequest.Click += new System.EventHandler(this.btnPermanentRatingRequest_Click);
            // 
            // btnCoverageRequest
            // 
            this.btnCoverageRequest.Location = new System.Drawing.Point(116, 18);
            this.btnCoverageRequest.Name = "btnCoverageRequest";
            this.btnCoverageRequest.Size = new System.Drawing.Size(105, 30);
            this.btnCoverageRequest.TabIndex = 5;
            this.btnCoverageRequest.Text = "CoverageRequest";
            this.btnCoverageRequest.UseVisualStyleBackColor = true;
            this.btnCoverageRequest.Click += new System.EventHandler(this.btnCoverageRequest_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnWebServiceValidate);
            this.panel1.Controls.Add(this.rbtnValidateLocally);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 33);
            this.panel1.TabIndex = 7;
            // 
            // rbtnWebServiceValidate
            // 
            this.rbtnWebServiceValidate.AutoSize = true;
            this.rbtnWebServiceValidate.Location = new System.Drawing.Point(128, 8);
            this.rbtnWebServiceValidate.Name = "rbtnWebServiceValidate";
            this.rbtnWebServiceValidate.Size = new System.Drawing.Size(134, 19);
            this.rbtnWebServiceValidate.TabIndex = 1;
            this.rbtnWebServiceValidate.TabStop = true;
            this.rbtnWebServiceValidate.Text = "WebServiceValidate";
            this.rbtnWebServiceValidate.UseVisualStyleBackColor = true;
            // 
            // rbtnValidateLocally
            // 
            this.rbtnValidateLocally.AutoSize = true;
            this.rbtnValidateLocally.Checked = true;
            this.rbtnValidateLocally.Location = new System.Drawing.Point(17, 9);
            this.rbtnValidateLocally.Name = "rbtnValidateLocally";
            this.rbtnValidateLocally.Size = new System.Drawing.Size(107, 19);
            this.rbtnValidateLocally.TabIndex = 0;
            this.rbtnValidateLocally.TabStop = true;
            this.rbtnValidateLocally.Text = "ValidateLocally";
            this.rbtnValidateLocally.UseVisualStyleBackColor = true;
            // 
            // btnLoadTitaniumIllusBasic
            // 
            this.btnLoadTitaniumIllusBasic.Location = new System.Drawing.Point(493, 61);
            this.btnLoadTitaniumIllusBasic.Name = "btnLoadTitaniumIllusBasic";
            this.btnLoadTitaniumIllusBasic.Size = new System.Drawing.Size(147, 23);
            this.btnLoadTitaniumIllusBasic.TabIndex = 8;
            this.btnLoadTitaniumIllusBasic.Text = "Load Titanium Illus Basic";
            this.btnLoadTitaniumIllusBasic.UseVisualStyleBackColor = true;
            this.btnLoadTitaniumIllusBasic.Click += new System.EventHandler(this.btnLoadTitaniumIllusBasic_Click);
            // 
            // cbRegions
            // 
            this.cbRegions.AllowDrop = true;
            this.cbRegions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegions.FormattingEnabled = true;
            this.cbRegions.Items.AddRange(new object[] {
            "Local",
            "Test",
            "UAT",
            "Model",
            "Prod",
            "INT"});
            this.cbRegions.Location = new System.Drawing.Point(432, 19);
            this.cbRegions.Name = "cbRegions";
            this.cbRegions.Size = new System.Drawing.Size(121, 21);
            this.cbRegions.TabIndex = 9;
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(344, 23);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(50, 15);
            this.lblRegion.TabIndex = 10;
            this.lblRegion.Text = "Region:";
            // 
            // btnLoadTitaniumGeneralCost
            // 
            this.btnLoadTitaniumGeneralCost.Location = new System.Drawing.Point(493, 119);
            this.btnLoadTitaniumGeneralCost.Name = "btnLoadTitaniumGeneralCost";
            this.btnLoadTitaniumGeneralCost.Size = new System.Drawing.Size(147, 23);
            this.btnLoadTitaniumGeneralCost.TabIndex = 11;
            this.btnLoadTitaniumGeneralCost.Text = "Load Titanium General Cost";
            this.btnLoadTitaniumGeneralCost.UseVisualStyleBackColor = true;
            this.btnLoadTitaniumGeneralCost.Click += new System.EventHandler(this.btnLoadTitaniumGeneralCost_Click);
            // 
            // btnLoadTitaniumAmendCost
            // 
            this.btnLoadTitaniumAmendCost.Location = new System.Drawing.Point(493, 90);
            this.btnLoadTitaniumAmendCost.Name = "btnLoadTitaniumAmendCost";
            this.btnLoadTitaniumAmendCost.Size = new System.Drawing.Size(147, 23);
            this.btnLoadTitaniumAmendCost.TabIndex = 12;
            this.btnLoadTitaniumAmendCost.Text = "Load Titanium Amend Cost";
            this.btnLoadTitaniumAmendCost.UseVisualStyleBackColor = true;
            this.btnLoadTitaniumAmendCost.Click += new System.EventHandler(this.btnLoadTitaniumAmendCost_Click_1);
            // 
            // btnLoadTitaniumIllusRevised
            // 
            this.btnLoadTitaniumIllusRevised.Location = new System.Drawing.Point(493, 148);
            this.btnLoadTitaniumIllusRevised.Name = "btnLoadTitaniumIllusRevised";
            this.btnLoadTitaniumIllusRevised.Size = new System.Drawing.Size(147, 23);
            this.btnLoadTitaniumIllusRevised.TabIndex = 13;
            this.btnLoadTitaniumIllusRevised.Text = "Load Titanium Illus Revised";
            this.btnLoadTitaniumIllusRevised.UseVisualStyleBackColor = true;
            this.btnLoadTitaniumIllusRevised.Click += new System.EventHandler(this.btnLoadTitaniumIllusRevised_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(493, 177);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(147, 23);
            this.btnBrowse.TabIndex = 14;
            this.btnBrowse.Text = "Browse and Load File";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // CISTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 384);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnLoadTitaniumIllusRevised);
            this.Controls.Add(this.btnLoadTitaniumAmendCost);
            this.Controls.Add(this.btnLoadTitaniumGeneralCost);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.cbRegions);
            this.Controls.Add(this.btnLoadTitaniumIllusBasic);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbIul);
            this.Controls.Add(this.tbResults);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CISTestForm";
            this.Text = "Form1";
            this.gbIul.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlainRequest;
        private System.Windows.Forms.TextBox tbResults;
        private System.Windows.Forms.Button btnBadRequest1;
        private System.Windows.Forms.Button btnBadRequest2;
        private System.Windows.Forms.Button btnBadRequest3;
        private System.Windows.Forms.GroupBox gbIul;
        private System.Windows.Forms.Button btnCoverageRequest;
        private System.Windows.Forms.Button btnPermanentRatingRequest;
        private System.Windows.Forms.Button btnBadRequest4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnWebServiceValidate;
        private System.Windows.Forms.RadioButton rbtnValidateLocally;
        private System.Windows.Forms.Button btnLoadTitaniumIllusBasic;
        private System.Windows.Forms.ComboBox cbRegions;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Button btnLoadTitaniumGeneralCost;
        private System.Windows.Forms.Button btnLoadTitaniumAmendCost;
        private System.Windows.Forms.Button btnLoadTitaniumIllusRevised;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnBrowse;
    }
}

