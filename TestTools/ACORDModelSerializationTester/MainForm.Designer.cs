namespace WOW.Illustration.TestTools.ACORDModelSerializationTester
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
            this.testSamplesLocationLabel = new System.Windows.Forms.Label();
            this.testSamplesLocationTextBox = new System.Windows.Forms.TextBox();
            this.testSamplesLocationButton = new System.Windows.Forms.Button();
            this.beginTestButton = new System.Windows.Forms.Button();
            this.outputLocationButton = new System.Windows.Forms.Button();
            this.outputLocationTextBox = new System.Windows.Forms.TextBox();
            this.outputLocationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // testSamplesLocationLabel
            // 
            resources.ApplyResources(this.testSamplesLocationLabel, "testSamplesLocationLabel");
            this.testSamplesLocationLabel.Name = "testSamplesLocationLabel";
            // 
            // testSamplesLocationTextBox
            // 
            resources.ApplyResources(this.testSamplesLocationTextBox, "testSamplesLocationTextBox");
            this.testSamplesLocationTextBox.Name = "testSamplesLocationTextBox";
            // 
            // testSamplesLocationButton
            // 
            resources.ApplyResources(this.testSamplesLocationButton, "testSamplesLocationButton");
            this.testSamplesLocationButton.Name = "testSamplesLocationButton";
            this.testSamplesLocationButton.UseVisualStyleBackColor = true;
            this.testSamplesLocationButton.Click += new System.EventHandler(this.testSamplesLocationButton_Click);
            // 
            // beginTestButton
            // 
            resources.ApplyResources(this.beginTestButton, "beginTestButton");
            this.beginTestButton.Name = "beginTestButton";
            this.beginTestButton.UseVisualStyleBackColor = true;
            this.beginTestButton.Click += new System.EventHandler(this.beginTestButton_Click);
            // 
            // outputLocationButton
            // 
            resources.ApplyResources(this.outputLocationButton, "outputLocationButton");
            this.outputLocationButton.Name = "outputLocationButton";
            this.outputLocationButton.UseVisualStyleBackColor = true;
            this.outputLocationButton.Click += new System.EventHandler(this.outputLocationButton_Click);
            // 
            // outputLocationTextBox
            // 
            resources.ApplyResources(this.outputLocationTextBox, "outputLocationTextBox");
            this.outputLocationTextBox.Name = "outputLocationTextBox";
            // 
            // outputLocationLabel
            // 
            resources.ApplyResources(this.outputLocationLabel, "outputLocationLabel");
            this.outputLocationLabel.Name = "outputLocationLabel";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.outputLocationButton);
            this.Controls.Add(this.outputLocationTextBox);
            this.Controls.Add(this.outputLocationLabel);
            this.Controls.Add(this.beginTestButton);
            this.Controls.Add(this.testSamplesLocationButton);
            this.Controls.Add(this.testSamplesLocationTextBox);
            this.Controls.Add(this.testSamplesLocationLabel);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label testSamplesLocationLabel;
        private System.Windows.Forms.TextBox testSamplesLocationTextBox;
        private System.Windows.Forms.Button testSamplesLocationButton;
        private System.Windows.Forms.Button beginTestButton;
        private System.Windows.Forms.Button outputLocationButton;
        private System.Windows.Forms.TextBox outputLocationTextBox;
        private System.Windows.Forms.Label outputLocationLabel;
    }
}

