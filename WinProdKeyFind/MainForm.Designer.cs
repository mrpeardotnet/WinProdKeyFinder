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
            this.btnCopyToClipboar = new System.Windows.Forms.Button();
            this.llWeb = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOfficeProductKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbWindowsProductKey
            // 
            this.tbWindowsProductKey.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbWindowsProductKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbWindowsProductKey.Location = new System.Drawing.Point(12, 35);
            this.tbWindowsProductKey.Name = "tbWindowsProductKey";
            this.tbWindowsProductKey.ReadOnly = true;
            this.tbWindowsProductKey.Size = new System.Drawing.Size(384, 26);
            this.tbWindowsProductKey.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Windows Product Key:";
            // 
            // btnCopyToClipboar
            // 
            this.btnCopyToClipboar.Location = new System.Drawing.Point(269, 133);
            this.btnCopyToClipboar.Name = "btnCopyToClipboar";
            this.btnCopyToClipboar.Size = new System.Drawing.Size(127, 23);
            this.btnCopyToClipboar.TabIndex = 3;
            this.btnCopyToClipboar.Text = "Copy key to clipboard";
            this.btnCopyToClipboar.UseVisualStyleBackColor = true;
            this.btnCopyToClipboar.Click += new System.EventHandler(this.btnCopyToClipboar_Click);
            // 
            // llWeb
            // 
            this.llWeb.AutoSize = true;
            this.llWeb.Location = new System.Drawing.Point(9, 138);
            this.llWeb.Name = "llWeb";
            this.llWeb.Size = new System.Drawing.Size(115, 13);
            this.llWeb.TabIndex = 9;
            this.llWeb.TabStop = true;
            this.llWeb.Text = "http://www.mrpear.net";
            this.llWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llWeb_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Office Product Key:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbOfficeProductKey
            // 
            this.tbOfficeProductKey.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbOfficeProductKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbOfficeProductKey.Location = new System.Drawing.Point(12, 93);
            this.tbOfficeProductKey.Name = "tbOfficeProductKey";
            this.tbOfficeProductKey.ReadOnly = true;
            this.tbOfficeProductKey.Size = new System.Drawing.Size(384, 26);
            this.tbOfficeProductKey.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 165);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbOfficeProductKey);
            this.Controls.Add(this.llWeb);
            this.Controls.Add(this.btnCopyToClipboar);
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
        private System.Windows.Forms.Button btnCopyToClipboar;
        private System.Windows.Forms.LinkLabel llWeb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbOfficeProductKey;
    }
}

