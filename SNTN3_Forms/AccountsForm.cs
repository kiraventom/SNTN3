using SNTN3_Forms.Accounts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VkNet;

namespace SNTN3_Forms
{
    public partial class AccountsForm : Form
    {
        public AccountsForm(VkApi api)
        {
            InitializeComponent();
            Api = api;
            AccountsDB = new AccountsDB();
            Accounts = new ObservableCollection<Account>();
            Account[] accounts = Array.Empty<Account>();
            try
            {
                accounts = GetAccountsInfoFromVk(AccountsDB.ReadAll());
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

            foreach (var account in accounts)
            {
                Accounts.Add(account);
                var accountBt = CreateAccountBt(account);
                AccountsFLP.Controls.Add(accountBt);
            }
            Accounts.CollectionChanged += Accounts_CollectionChanged;
        }

        #region Свойства

        private VkApi Api { get; }
        private AccountsDB AccountsDB { get; }
        private ObservableCollection<Account> Accounts { get; }

        #endregion

        #region Обработчики событий

        #region Обработчики событий коллекций

        private void Accounts_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Account newAccount in e.NewItems)
                {
                    var accountBt = CreateAccountBt(newAccount);
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

        #endregion

        #region Обработчики событий контролов

        private void AddAccountBt_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(Api);
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                var user = Api.Users.Get(Array.Empty<long>(), VkNet.Enums.Filters.ProfileFields.Photo200)[0];
                Accounts.Add(new Account(Api.Token, user.FirstName + " " + user.LastName, user.Id.ToString(), GetBitmapFromUri(user.Photo200)));
                Api.LogOut();
            }
        }

        #endregion

        #endregion

        #region Методы

        private void DrawTextBackground(Bitmap image, float textSize)
        {
            const double coef = 2.3;
            int textBackgroundHeight = image.Height - (int)Math.Round(textSize * coef);
            var rect = new Rectangle(
                new Point(0, textBackgroundHeight),
                new Size(image.Width, textBackgroundHeight));
            using (Graphics g = Graphics.FromImage(image))
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(192, 255, 255, 255)), rect);
            }
        }

        private Button CreateAccountBt(Account account)
        {
            const float textSize = 13;
            Button accountBt = new Button()
            {
                Text = account.Name,
                FlatStyle = FlatStyle.Flat,
                BackgroundImage = account.ProfilePic,
                BackgroundImageLayout = ImageLayout.Center,
                Size = new Size(200, 200),
                TextAlign = ContentAlignment.BottomCenter,
                Font = new Font(Font.Name, textSize, Font.Style),
                ForeColor = Color.Black,
                Tag = account.Token
            };
            DrawTextBackground(accountBt.BackgroundImage as Bitmap, textSize);
            accountBt.MouseUp += (s, ea) =>
            {
                if (ea.Button == MouseButtons.Left)
                {
                    Api.Authorize(new VkNet.Model.ApiAuthParams() { AccessToken = accountBt.Tag.ToString() });
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
                if (ea.Button == MouseButtons.Right)
                {
                    var dr = MessageBox.Show(
                        "Удалить аккаунт из приложения?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Accounts.Remove(Accounts.Single(acc => acc.Token == accountBt.Tag.ToString()));
                    }
                }
            };
            return accountBt;
        }

        private Account[] GetAccountsInfoFromVk(Dictionary<string, string> accountsDict)
        {
            List<Account> accounts = new List<Account>();
            if (accountsDict.Count > 0)
            {
                const string SNTN3Token = "1ee52fedde978f3e1b35b01d04c967c3724db43202f2ff77e0eda111a659279759df8ab5520bffaff3bd3";
                Api.Authorize(new VkNet.Model.ApiAuthParams() { AccessToken = SNTN3Token });
                var users = Api.Users.Get(accountsDict.Keys.Select(s => long.Parse(s)), VkNet.Enums.Filters.ProfileFields.Photo200);
                Api.LogOut();

                for (int i = 0; i < users.Count; ++i)
                {
                    accounts.Add(new Account(
                        accountsDict.Values.ElementAt(i), 
                        users[i].FirstName + " " + users[i].LastName,
                        accountsDict.Keys.ElementAt(i),
                        GetBitmapFromUri(users[i].Photo200))); 
                }
            }
            return accounts.ToArray();
        }

        private Bitmap GetBitmapFromUri(Uri uri)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create(uri);
            System.Net.WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            return new Bitmap(responseStream);
        }

        #endregion
    }
}
