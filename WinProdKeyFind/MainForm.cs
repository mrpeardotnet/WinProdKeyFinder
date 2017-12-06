using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace WinProdKeyFind
{
    /// <summary>
    /// Application main form
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Default constructor for this form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler that is fired when this form is shown.
        /// Changes window title and gets current Windows Product Key.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            // get the assembly information to display current version in the title of the window
            var assemblyName = AssemblyName.GetAssemblyName(Assembly.GetExecutingAssembly().Location);

            // format window title text (append version to the current title)
            Text = $@"{Text} v{assemblyName.Version.Major}.{assemblyName.Version.Minor}";

            // get the current Windows Product Key and display it
            tbWindowsProductKey.Text = KeyDecoder.GetWindowsProductKeyFromRegistry();
        }

        private string _copyBtnText;
        /// <summary>
        /// Event handler that copies Windows Product Key value from the text box into clipboard on button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            // set selection (select all)
            tbWindowsProductKey.SelectionStart = 0;
            tbWindowsProductKey.SelectionLength = tbWindowsProductKey.Text.Length;
            // copy selection to the clipboard
            tbWindowsProductKey.Copy();

            // make some visual action with the button:
            // display "Copied..." and disable button for a while
            if (!(sender is Button senderButton))
                return;
            _copyBtnText = senderButton.Text;
            senderButton.Text = @"Copied...";
            senderButton.Enabled = false;
            var t = new Timer(750);
            t.Elapsed += (o, args) =>
            {
                btnCopyToClipboard.Text = _copyBtnText;
                btnCopyToClipboard.Enabled = true;
            };
            t.Enabled = true;
            t.AutoReset = false;
        }

        /// <summary>
        /// Event handler that opens web URL in the default browser on web link clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.mrpear.net");
        }

        /// <summary>
        /// Event handler that opens <see cref="DigitalProductIdForm"/> form on button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFromProductKey_Click(object sender, EventArgs e)
        {
            var form = new DigitalProductIdForm();
            form.ShowDialog();
        }
    }
}
