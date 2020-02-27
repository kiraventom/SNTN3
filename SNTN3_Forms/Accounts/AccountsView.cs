using SNTN3_Forms.Accounts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.IO;
using static SNTN3_Forms.Accounts.AccountsStaticModel;
using System.Windows.Forms;
using VkNet;
using System.Linq;

namespace SNTN3_Forms
{
    public partial class AccountsForm : Form
    {
        public AccountsForm(VkApi api)
        {
            InitializeComponent();
            try
            {
                Model = new AccountsModel(api, this, AccountsFLP);
            }
            catch (Flurl.Http.FlurlHttpException)
            {
                MessageBox.Show(
                    "Невозможно подключиться к vk.com. Проверьте интернет-подключение и попробуйте снова.",
                    "Ошибка подключения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
                return;
            }

            var buttons = Model.CreateAccountButtons();
            foreach (var button in buttons)
            {
                AccountsFLP.Controls.Add(button);
            }
        }

        private AccountsModel Model { get; }

        private void AddAccountBt_Click(object sender, EventArgs e)
        {
            Model.AddNewAccount();
        }
    }
}
