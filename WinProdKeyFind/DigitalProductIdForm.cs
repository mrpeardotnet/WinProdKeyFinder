using System;
using System.Windows.Forms;
using System.Linq;
using Timer = System.Timers.Timer;

namespace WinProdKeyFind
{
    /// <summary>
    /// Form that decodes DigitalProductId string exported from registry and shows it as Windows Product Key.
    /// </summary>
    public partial class DigitalProductIdForm : Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DigitalProductIdForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler that clears DigitalProductId textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearDigitalProductId_Click(object sender, EventArgs e)
        {
            tbDigitalProductId.Clear();
            tbProductKey.Clear();
        }

        /// <summary>
        /// Event hanlder that closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Private Helper Methods

        /// <summary>
        /// Enables or disables form buttons depending on state of the form data
        /// </summary>
        private void SetButtonsEnabled()
        {
            btnParseDigitalProductId.Enabled = !String.IsNullOrEmpty(tbDigitalProductId.Text);
            btnClearDigitalProductId.Enabled = !String.IsNullOrEmpty(tbDigitalProductId.Text);
        }

        #endregion

        /// <summary>
        /// Event handler that is fired when DigitalProductId textbox text is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbDigitalProductId_TextChanged(object sender, EventArgs e)
        {
            tbProductKey.Clear();
            btnCopyToClipboard.Enabled = false;
            SetButtonsEnabled();
        }

        /// <summary>
        /// Event handler that is fired when the DigitalProductIdForm was loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DigitalProductIdForm_Load(object sender, EventArgs e)
        {
            SetButtonsEnabled();
            cbDigitalProductIdVersion.SelectedIndex = 1;
            btnCopyToClipboard.Enabled = false;
        }

        private string _copyBtnText;
        /// <summary>
        /// Event handler that copies ProductKey textbox to the clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            // focus product key textbox (better visual feeling)
            tbProductKey.Focus();

            // set selection (select all)
            tbProductKey.SelectionStart= 0;
            tbProductKey.SelectionLength = tbProductKey.Text.Length;
            // copy selection to the clipboard
            tbProductKey.Copy();

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
        /// Event handler that fills example of DigitalProductId into DigitalProductId textbox.
        /// This DigitalProductId example is generic product key of Windows 10 Pro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llShowDigitalProductIdExample_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Generic Windows 10 Pro key (upgrade key) example
            tbDigitalProductId.Text =
                "\"DigitalProductId\"=hex:a4,00,00,00,03,00,00,00,30,30,33,33,30,2d,38,30,30,30,\\\r\n" +
                "  30,2d,30,30,30,30,30,2d,41,41,33,32,38,00,ec,0c,00,00,5b,54,48,5d,58,31,39,\\\r\n" +
                "  2d,39,38,38,34,31,00,00,00,ec,0c,00,00,00,00,a8,d2,7b,6e,89,81,4f,6d,09,00,\\\r\n" +
                "  00,00,00,00,f0,87,99,58,20,9a,d7,4d,00,00,00,00,00,00,00,00,00,00,00,00,00,\\\r\n" +
                "  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\\\r\n" +
                "  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\\\r\n" +
                "  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,ff,a1,85,e6";

            // set the correct DigitalProductId version (Windows 8 or newer).
            cbDigitalProductIdVersion.SelectedIndex = 1;
        }

        /// <summary>
        /// Event handler that decodes DigitalProductId and shows result in ProductKey textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParseDigitalProductId_Click(object sender, EventArgs e)
        {
            // Try to decode input string and detect, if the string is in expected format.
            // Maybe some regex would do it better? ;)
            //
            
            // let wrap everything we do with input string into try/catch to display error
            // message when anything fails
            try
            {
                // First try to split the string into the key and value
                var keyValue = tbDigitalProductId.Text.Trim().Split('=');

                // Get the key
                var key = keyValue[0].Trim();

                // Is this a valid key
                if (!key.Equals("\"DigitalProductId\""))
                {
                    SetParseErrorMessage();
                    return;
                }

                // Get the value and remove unwanted characters...
                var value = keyValue[1].Replace("\\\r\n", "").Replace(" ", "").Trim();

                // Regedit hex value?
                if (!value.StartsWith("hex:", StringComparison.InvariantCultureIgnoreCase))
                {
                    SetParseErrorMessage();
                    return;
                }

                // Convert comma delimited string hex values into byte array
                var hexValues = value.Remove(0, 4).Split(',');

                // crete byte array from hex values
                var byteValues = hexValues.Select(s => Convert.ToByte(s.ToUpper(), 16)).ToArray();
                tbProductKey.Text = KeyDecoder.GetWindowsProductKeyFromDigitalProductId(
                    byteValues,
                    cbDigitalProductIdVersion.SelectedIndex == 0
                        ? DigitalProductIdVersion.UpToWindows7
                        : DigitalProductIdVersion.Windows8AndUp);
                btnCopyToClipboard.Enabled = true;
            }
            catch (Exception)
            {
                SetParseErrorMessage();
            }

        }

        /// <summary>
        /// Helper method that displays invlaid DigitalProductId error message in the product key text box
        /// </summary>
        private void SetParseErrorMessage()
        {
            tbProductKey.Text = @"Invalid DigitalProductId";
        }
    }
}
