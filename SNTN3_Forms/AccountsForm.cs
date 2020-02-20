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

        private readonly Size BtSize = new Size(200, 200);

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

        /// <summary>
        /// Рисует на картинке прозрачную белую подложку под текст, расположенный на кнопке внизу
        /// </summary>
        /// <param name="image">Картинка, на которой необходимо нарисовать подложку</param>
        /// <param name="textSize">Размер текста в пунктах</param>
        private void DrawTextBackground(Bitmap image, float textSize)
        {
            const double coef = 2.3; // Хорошо бы брать его не с потолка, но больше неоткуда
            int textBackgroundHeight = image.Height - (int)Math.Round(textSize * coef);
            var rect = new Rectangle(
                new Point(0, textBackgroundHeight),
                new Size(image.Width, textBackgroundHeight));
            // if account doesn't have a profile pic, VK returns image which has PixelFormat == Format8bppIndexed
            // Such images don't support drawing background on them neither need it
            if (image.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
            {
                return;
            }
            using (Graphics g = Graphics.FromImage(image))
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(192, 255, 255, 255)), rect);
            }
        }

        /// <summary>
        /// Возвращает кнопку для переданного аккаунта
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        private Button CreateAccountBt(Account account)
        {
            const float textSize = 13;
            Button accountBt = new Button()
            {
                Text = account.Name,
                FlatStyle = FlatStyle.Flat,
                BackgroundImage = account.ProfilePic,
                BackgroundImageLayout = ImageLayout.Center,
                Size = BtSize,
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

        /// <summary>
        /// Запрашивает информацию о переданных аккаунтах у ВК и возвращает их как класс Account
        /// </summary>
        /// <param name="accountsDict">Словарь ID\Token аккаунтов. Должен быть получен через AccountsDB.ReadAll()</param>
        /// <returns>Массив аккаунтов (ФИ, токен, ID, фото)</returns>
        private Account[] GetAccountsInfoFromVk(Dictionary<string, string> accountsDict)
        {
            List<Account> accounts = new List<Account>();
            if (accountsDict.Count > 0)
            {
                Api.Authorize(new VkNet.Model.ApiAuthParams() { AccessToken = accountsDict.Values.ElementAt(0) });
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

        /// <summary>
        /// Возвращает объект Bitmap из изображения по переданному URL
        /// </summary>
        /// <param name="uri">URL к изображению</param>
        /// <returns>Объект Bitmap</returns>
        private static Bitmap GetBitmapFromUri(Uri uri)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create(uri);
            System.Net.WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            return new Bitmap(responseStream);
        }

        #endregion
    }
}
