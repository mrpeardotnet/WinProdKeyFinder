namespace WinProdKeyFind
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
            this.tbWindowsProductKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.llWeb = new System.Windows.Forms.LinkLabel();
            this.btnFromProductKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbWindowsProductKey
            // 
            this.tbWindowsProductKey.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbWindowsProductKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbWindowsProductKey.Location = new System.Drawing.Point(12, 35);
            this.tbWindowsProductKey.Name = "tbWindowsProductKey";
            this.tbWindowsProductKey.ReadOnly = true;
            this.tbWindowsProductKey.Size = new System.Drawing.Size(407, 29);
            this.tbWindowsProductKey.TabIndex = 0;
            this.tbWindowsProductKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "This machine Windows Product Key:";
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(292, 88);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(127, 23);
            this.btnCopyToClipboard.TabIndex = 3;
            this.btnCopyToClipboard.Text = "Copy key to clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // llWeb
            // 
            this.llWeb.AutoSize = true;
            this.llWeb.Location = new System.Drawing.Point(9, 93);
            this.llWeb.Name = "llWeb";
            this.llWeb.Size = new System.Drawing.Size(115, 13);
            this.llWeb.TabIndex = 9;
            this.llWeb.TabStop = true;
            this.llWeb.Text = "http://www.mrpear.net";
            this.llWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llWeb_LinkClicked);
            // 
            // btnFromProductKey
            // 
            this.btnFromProductKey.Location = new System.Drawing.Point(153, 88);
            this.btnFromProductKey.Name = "btnFromProductKey";
            this.btnFromProductKey.Size = new System.Drawing.Size(133, 23);
            this.btnFromProductKey.TabIndex = 10;
            this.btnFromProductKey.Text = "Decode DigitalProductId";
            this.btnFromProductKey.UseVisualStyleBackColor = true;
            this.btnFromProductKey.Click += new System.EventHandler(this.btnFromProductKey_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 123);
            this.Controls.Add(this.btnFromProductKey);
            this.Controls.Add(this.llWeb);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbWindowsProductKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Windows Product Key Finder";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbWindowsProductKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.LinkLabel llWeb;
        private System.Windows.Forms.Button btnFromProductKey;
    }
}

