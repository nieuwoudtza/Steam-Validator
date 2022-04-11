namespace Steam_Validator
{
    partial class CfrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CfrmMain));
            this.lblLibFoldersPath = new System.Windows.Forms.Label();
            this.txtLibFoldersPath = new System.Windows.Forms.TextBox();
            this.btnSelectLibFoldersPath = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.nuMaxTries = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nuMaxTries)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLibFoldersPath
            // 
            this.lblLibFoldersPath.AutoSize = true;
            this.lblLibFoldersPath.Location = new System.Drawing.Point(12, 15);
            this.lblLibFoldersPath.Name = "lblLibFoldersPath";
            this.lblLibFoldersPath.Size = new System.Drawing.Size(86, 13);
            this.lblLibFoldersPath.TabIndex = 0;
            this.lblLibFoldersPath.Text = "libraryfolders.vdf:";
            // 
            // txtLibFoldersPath
            // 
            this.txtLibFoldersPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLibFoldersPath.Location = new System.Drawing.Point(104, 12);
            this.txtLibFoldersPath.Name = "txtLibFoldersPath";
            this.txtLibFoldersPath.ReadOnly = true;
            this.txtLibFoldersPath.Size = new System.Drawing.Size(313, 20);
            this.txtLibFoldersPath.TabIndex = 0;
            this.txtLibFoldersPath.TabStop = false;
            this.txtLibFoldersPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSelectLibFoldersPath
            // 
            this.btnSelectLibFoldersPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectLibFoldersPath.Location = new System.Drawing.Point(419, 11);
            this.btnSelectLibFoldersPath.Name = "btnSelectLibFoldersPath";
            this.btnSelectLibFoldersPath.Size = new System.Drawing.Size(24, 22);
            this.btnSelectLibFoldersPath.TabIndex = 0;
            this.btnSelectLibFoldersPath.Text = "...";
            this.btnSelectLibFoldersPath.UseVisualStyleBackColor = true;
            this.btnSelectLibFoldersPath.Click += new System.EventHandler(this.BtnSelectLibFoldersPath_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerify.Location = new System.Drawing.Point(371, 47);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(72, 27);
            this.btnVerify.TabIndex = 1;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.BtnVerify_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "libraryfolders.vdf|libraryfolders.vdf";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Note: Run Steam as Administrator to prevent confirmation dialogs from interruptin" +
    "g the process.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nuMaxTries
            // 
            this.nuMaxTries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nuMaxTries.Location = new System.Drawing.Point(296, 53);
            this.nuMaxTries.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuMaxTries.Name = "nuMaxTries";
            this.nuMaxTries.Size = new System.Drawing.Size(69, 20);
            this.nuMaxTries.TabIndex = 3;
            this.nuMaxTries.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nuMaxTries.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max Tries:";
            // 
            // CfrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 81);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nuMaxTries);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnSelectLibFoldersPath);
            this.Controls.Add(this.txtLibFoldersPath);
            this.Controls.Add(this.lblLibFoldersPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CfrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steam Validator";
            ((System.ComponentModel.ISupportInitialize)(this.nuMaxTries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLibFoldersPath;
        private System.Windows.Forms.TextBox txtLibFoldersPath;
        private System.Windows.Forms.Button btnSelectLibFoldersPath;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nuMaxTries;
        private System.Windows.Forms.Label label2;
    }
}

