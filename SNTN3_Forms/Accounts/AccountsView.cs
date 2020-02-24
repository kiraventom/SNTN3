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
            Api = api;
            try
            {
                Model = new AccountsModel(Api, Accounts_CollectionChanged);
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

            var buttons = Model.CreateAccountButtons(AccountBt_MouseUp);
            foreach (var button in buttons)
            {
                AccountsFLP.Controls.Add(button);
            }
        }

        private VkApi Api { get; }
        private AccountsModel Model { get; }

        private void AddAccountBt_Click(object sender, EventArgs e)
        {
            Model.AddNewAccount();
        }

        private void AccountBt_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Button bt)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Api.Authorize(new VkNet.Model.ApiAuthParams() { AccessToken = bt.Tag.ToString() });
                    Hide();
                    AddPicturesForm addPicturesForm = new AddPicturesForm(Api);
                    addPicturesForm.ShowDialog();
                    if (addPicturesForm.DialogResult == DialogResult.No)
                    {
                        Api.LogOut();
                        Show();
                    }
                    else
                    {
                        Close();
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    var dr = MessageBox.Show(
                        "Удалить аккаунт из приложения?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Model.Accounts.Remove(Model.Accounts.Single(acc => acc.Token == bt.Tag.ToString()));
                    }
                }
            }
        }

        private void Accounts_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Account newAccount in e.NewItems)
                {
                    var accountBt = CreateAccountBt(newAccount);
                    accountBt.MouseUp += AccountBt_MouseUp;
                    AccountsFLP.Controls.Add(accountBt);
                    Model.AccountsDB.Add(newAccount.ID, newAccount.Token);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Account oldAccount in e.OldItems)
                {
                    AccountsFLP.Controls.Remove(AccountsFLP.Controls.OfType<Button>().Single(bt => bt.Tag.ToString() == oldAccount.Token));
                    Model.AccountsDB.Remove(oldAccount.ID);
                }
            }
        }
    }
}
