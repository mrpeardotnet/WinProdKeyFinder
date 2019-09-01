using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

            // possible key locations
            string[] keyPaths =
            {
                @"Software\Microsoft\Windows NT\CurrentVersion",
                @"Software\Microsoft\Windows NT\CurrentVersion\DefaultProductKey",
                @"Software\Microsoft\Windows NT\CurrentVersion\DefaultProductKey2"
            };

            // getting all possible keys and presenting them as a string with NewLine as separator
            var keys = keyPaths.Select(KeyDecoder.GetWindowsProductKeyFromRegistry)
                .Where(key => key != "Failed to get DigitalProductId from registry")
                .Distinct()
                .Aggregate<string>((first, second) => first + Environment.NewLine + second);

            // get the current Windows Product Keys and display them
            tbWindowsProductKey.Text = keys;
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

            // create timer that will revert button to original state after some delay
            var timer = new Timer(750);
            timer.Elapsed += (o, args) =>
            {
                var copyToClipboard = new Action(() =>
                {
                    btnCopyToClipboard.Text = _copyBtnText;
                    btnCopyToClipboard.Enabled = true;
                });

                // check if we need to call invoke
                // (needed when the control was created on different thread then the timer event is currently running)
                if (btnCopyToClipboard.InvokeRequired)
                {
                    btnCopyToClipboard.Invoke(copyToClipboard);
                }
                else
                {
                    copyToClipboard();
                }
            };

            // enable the timer (this will start the timer)
            timer.Enabled = true;
            // run the timer only once
            timer.AutoReset = false;
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
