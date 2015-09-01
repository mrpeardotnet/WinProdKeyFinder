using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace WinProdKeyFind
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            var assemblyName = AssemblyName.GetAssemblyName(Assembly.GetExecutingAssembly().Location);
            Text = String.Format("{0} v{1}.{2}", Text, assemblyName.Version.Major, assemblyName.Version.Minor);
            GetKey();
        }
        private void GetKey()
        {
            tbWindowsProductKey.Text = KeyDecoder.GetWindowsProductKey();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string CopyBtnText;
        private void btnCopyToClipboar_Click(object sender, EventArgs e)
        {
            tbWindowsProductKey.SelectionStart = 0;
            tbWindowsProductKey.SelectionLength = tbWindowsProductKey.Text.Length;
            tbWindowsProductKey.Copy();
            CopyBtnText = (sender as Button).Text;
            (sender as Button).Text = @"Copied...";
            (sender as Button).Enabled = false;
            var t = new Timer(750);
            t.Elapsed += t_Elapsed;
            t.Enabled = true;
            t.AutoReset = false;
        }

        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            btnCopyToClipboar.Text = CopyBtnText;
            btnCopyToClipboar.Enabled = true;
        }

        private void llWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.mrpear.net");
        }
    }
}
