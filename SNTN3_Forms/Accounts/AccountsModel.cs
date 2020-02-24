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
        public AccountsModel(VkApi api, NotifyCollectionChangedEventHandler collectionHandler)
        {
            Api = api;
            AccountsDB = new AccountsDB();
            Account[] accounts = GetAccountsInfoFromVk(Api, AccountsDB.ReadAll());
            Accounts = new ObservableCollection<Account>(accounts);
            Accounts.CollectionChanged += collectionHandler;
        }

        public Button[] CreateAccountButtons(MouseEventHandler mouseUpHandler)
        {
            var buttons = new List<Button>();
            foreach (var account in Accounts)
            {
                var accountBt = CreateAccountBt(account);
                accountBt.MouseUp += mouseUpHandler;
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

        #region Свойства

        private VkApi Api { get; }
        public AccountsDB AccountsDB { get; }
        public ObservableCollection<Account> Accounts { get; }

        #endregion
    }
}
