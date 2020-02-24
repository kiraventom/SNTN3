using System;
using System.Windows.Forms;
using VkNet;

namespace SNTN3_Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Hide();
            Api = new VkApi(null, new Captcha.CaptchaSolver());
        }

        public VkApi Api { get; }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var accountsForm = new AccountsForm(Api);
            if (accountsForm.DialogResult != DialogResult.Abort)
            {
                accountsForm.ShowDialog();
            }
            Close();
        }
    }
}
