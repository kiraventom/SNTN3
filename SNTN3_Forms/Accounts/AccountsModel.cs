using System;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet;
using static SNTN3_Forms.Accounts.AccountsStaticModel;
using System.Collections.Specialized;

namespace SNTN3_Forms.Accounts
{
    public class AccountsModel
    {
        public AccountsModel(VkApi api, Form accountsForm, FlowLayoutPanel accountsFLP)
        {
            Api = api;
            AccountsForm = accountsForm;
            AccountsFLP = accountsFLP;
            AccountsDB = new AccountsDB();
            Account[] accounts = GetAccountsInfoFromVk(Api, AccountsDB.ReadAll());
            Accounts = new ObservableCollection<Account>(accounts);
            Accounts.CollectionChanged += Accounts_CollectionChanged;
        }


        #region Свойства

        private VkApi Api { get; }
        public AccountsDB AccountsDB { get; }
        public ObservableCollection<Account> Accounts { get; }
        private Form AccountsForm { get; }
        private FlowLayoutPanel AccountsFLP { get; }

        #endregion

        public Button[] CreateAccountButtons()
        {
            var buttons = new List<Button>();
            foreach (var account in Accounts)
            {
                var accountBt = CreateAccountBt(account, AccountBt_MouseUp);
                buttons.Add(accountBt);
            }
            return buttons.ToArray();
        }

        public void AddNewAccount()
        {
            var loginForm = new LoginForm(Api);
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                var user = Api.Users.Get(Array.Empty<long>(), VkNet.Enums.Filters.ProfileFields.Photo200)[0];
                var account = new Account(Api.Token, user.FirstName + " " + user.LastName, user.Id.ToString(), GetBitmapFromUri(user.Photo200));
                Accounts.Add(account);
                Api.LogOut();
            }
        }

        private void AccountBt_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Button bt)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Api.Authorize(new VkNet.Model.ApiAuthParams() { AccessToken = bt.Tag.ToString() });
                    AccountsForm.Hide();
                    AddPicturesForm addPicturesForm = new AddPicturesForm(Api);
                    addPicturesForm.ShowDialog();
                    if (addPicturesForm.DialogResult == DialogResult.No)
                    {
                        Api.LogOut();
                        AccountsForm.Show();
                    }
                    else
                    {
                        AccountsForm.Close();
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
                        Accounts.Remove(Accounts.Single(acc => acc.Token == bt.Tag.ToString()));
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
                    var accountBt = CreateAccountBt(newAccount, AccountBt_MouseUp);
                    AccountsFLP.Controls.Add(accountBt);
                    AccountsDB.Add(newAccount.ID, newAccount.Token);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Account oldAccount in e.OldItems)
                {
                    AccountsFLP.Controls.Remove(AccountsFLP.Controls.OfType<Button>().Single(bt => bt.Tag.ToString() == oldAccount.Token));
                    AccountsDB.Remove(oldAccount.ID);
                }
            }
        }
    }
}
