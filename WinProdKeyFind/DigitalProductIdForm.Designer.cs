namespace WinProdKeyFind
{
    partial class DigitalProductIdForm
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
            this.tbDigitalProductId = new System.Windows.Forms.TextBox();
            this.labDigitalProductId = new System.Windows.Forms.Label();
            this.btnParseDigitalProductId = new System.Windows.Forms.Button();
            this.tbProductKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearDigitalProductId = new System.Windows.Forms.Button();
            this.llShowDigitalProductIdExample = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.cbDigitalProductIdVersion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbDigitalProductId
            // 
            this.tbDigitalProductId.Location = new System.Drawing.Point(12, 25);
            this.tbDigitalProductId.Multiline = true;
            this.tbDigitalProductId.Name = "tbDigitalProductId";
            this.tbDigitalProductId.Size = new System.Drawing.Size(467, 127);
            this.tbDigitalProductId.TabIndex = 0;
            this.tbDigitalProductId.TextChanged += new System.EventHandler(this.tbDigitalProductId_TextChanged);
            // 
            // labDigitalProductId
            // 
            this.labDigitalProductId.AutoSize = true;
            this.labDigitalProductId.Location = new System.Drawing.Point(9, 8);
            this.labDigitalProductId.Name = "labDigitalProductId";
            this.labDigitalProductId.Size = new System.Drawing.Size(214, 13);
            this.labDigitalProductId.TabIndex = 1;
            this.labDigitalProductId.Text = "DigitalProductId key (exported from registry):";
            // 
            // btnParseDigitalProductId
            // 
            this.btnParseDigitalProductId.Location = new System.Drawing.Point(176, 157);
            this.btnParseDigitalProductId.Name = "btnParseDigitalProductId";
            this.btnParseDigitalProductId.Size = new System.Drawing.Size(126, 23);
            this.btnParseDigitalProductId.TabIndex = 2;
            this.btnParseDigitalProductId.Text = "Parse DigitalProductId";
            this.btnParseDigitalProductId.UseVisualStyleBackColor = true;
            this.btnParseDigitalProductId.Click += new System.EventHandler(this.btnParseDigitalProductId_Click);
            // 
            // tbProductKey
            // 
            this.tbProductKey.BackColor = System.Drawing.SystemColors.Window;
            this.tbProductKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbProductKey.Location = new System.Drawing.Point(12, 236);
            this.tbProductKey.Name = "tbProductKey";
            this.tbProductKey.ReadOnly = true;
            this.tbProductKey.Size = new System.Drawing.Size(467, 29);
            this.tbProductKey.TabIndex = 3;
            this.tbProductKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Windows Product Key:";
            // 
            // btnClearDigitalProductId
            // 
            this.btnClearDigitalProductId.Location = new System.Drawing.Point(323, 157);
            this.btnClearDigitalProductId.Name = "btnClearDigitalProductId";
            this.btnClearDigitalProductId.Size = new System.Drawing.Size(75, 23);
            this.btnClearDigitalProductId.TabIndex = 5;
            this.btnClearDigitalProductId.Text = "Clear input";
            this.btnClearDigitalProductId.UseVisualStyleBackColor = true;
            this.btnClearDigitalProductId.Click += new System.EventHandler(this.btnClearDigitalProductId_Click);
            // 
            // llShowDigitalProductIdExample
            // 
            this.llShowDigitalProductIdExample.Location = new System.Drawing.Point(233, 2);
            this.llShowDigitalProductIdExample.Name = "llShowDigitalProductIdExample";
            this.llShowDigitalProductIdExample.Size = new System.Drawing.Size(246, 20);
            this.llShowDigitalProductIdExample.TabIndex = 6;
            this.llShowDigitalProductIdExample.TabStop = true;
            this.llShowDigitalProductIdExample.Text = "Show me DigitalProductId format example";
            this.llShowDigitalProductIdExample.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.llShowDigitalProductIdExample.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowDigitalProductIdExample_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(404, 157);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(345, 207);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(134, 23);
            this.btnCopyToClipboard.TabIndex = 8;
            this.btnCopyToClipboard.Text = "Copy key to clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // cbDigitalProductIdVersion
            // 
            this.cbDigitalProductIdVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDigitalProductIdVersion.FormattingEnabled = true;
            this.cbDigitalProductIdVersion.Items.AddRange(new object[] {
            "Up to Windows 7 (old)",
            "Windows 8 and newer (new)"});
            this.cbDigitalProductIdVersion.Location = new System.Drawing.Point(12, 158);
            this.cbDigitalProductIdVersion.Name = "cbDigitalProductIdVersion";
            this.cbDigitalProductIdVersion.Size = new System.Drawing.Size(158, 21);
            this.cbDigitalProductIdVersion.TabIndex = 9;
            // 
            // DigitalProductIdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 277);
            this.Controls.Add(this.cbDigitalProductIdVersion);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.llShowDigitalProductIdExample);
            this.Controls.Add(this.btnClearDigitalProductId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbProductKey);
            this.Controls.Add(this.btnParseDigitalProductId);
            this.Controls.Add(this.labDigitalProductId);
            this.Controls.Add(this.tbDigitalProductId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DigitalProductIdForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Decode Windows Product Key from DigitalProductId value";
            this.Load += new System.EventHandler(this.DigitalProductIdForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDigitalProductId;
        private System.Windows.Forms.Label labDigitalProductId;
        private System.Windows.Forms.Button btnParseDigitalProductId;
        private System.Windows.Forms.TextBox tbProductKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearDigitalProductId;
        private System.Windows.Forms.LinkLabel llShowDigitalProductIdExample;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.ComboBox cbDigitalProductIdVersion;
    }
}