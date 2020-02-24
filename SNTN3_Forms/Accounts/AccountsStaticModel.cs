using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNTN3_Forms.Accounts
{
    public static class AccountsStaticModel
    {
        /// <summary>
        /// Рисует на картинке прозрачную белую подложку под текст, расположенный на кнопке внизу
        /// </summary>
        /// <param name="image">Картинка, на которой необходимо нарисовать подложку</param>
        /// <param name="textSize">Размер текста в пунктах</param>
        public static void DrawTextBackground(Bitmap image, float textSize)
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

        private static readonly Size BtSize = new Size(200, 200);
        private const float textSize = 13;
        private static readonly Font Font = new Font(FontFamily.GenericSansSerif, textSize);

        /// <summary>
        /// Возвращает кнопку для переданного аккаунта
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static Button CreateAccountBt(Account account)
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
                Font = Font,
                ForeColor = Color.Black,
                Tag = account.Token
            };
            DrawTextBackground(accountBt.BackgroundImage as Bitmap, textSize);
            return accountBt;
        }

        /// <summary>
        /// Запрашивает информацию о переданных аккаунтах у ВК и возвращает их как класс Account
        /// </summary>
        /// <param name="accountsDict">Словарь ID\Token аккаунтов. Должен быть получен через AccountsDB.ReadAll()</param>
        /// <returns>Массив аккаунтов (ФИ, токен, ID, фото)</returns>
        public static Account[] GetAccountsInfoFromVk(VkNet.VkApi api, Dictionary<string, string> accountsDict)
        {
            List<Account> accounts = new List<Account>();
            if (accountsDict.Count > 0)
            {
                api.Authorize(new VkNet.Model.ApiAuthParams() { AccessToken = accountsDict.Values.ElementAt(0) });
                var users = api.Users.Get(accountsDict.Keys.Select(s => long.Parse(s)), VkNet.Enums.Filters.ProfileFields.Photo200);
                api.LogOut();

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
        public static Bitmap GetBitmapFromUri(Uri uri)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create(uri);
            System.Net.WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            return new Bitmap(responseStream);
        }
    }
}
