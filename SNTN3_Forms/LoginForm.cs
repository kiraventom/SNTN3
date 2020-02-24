using System;
using System.Windows.Forms;
using VkNet;

namespace SNTN3_Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm(VkApi api)
        {
            InitializeComponent();
            Api = api;
        }

        private VkApi Api { get; }
        private const int SntnAppId = 7289220;

        private void AuthorizeBt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTB.Text) || string.IsNullOrWhiteSpace(PasswordTB.Text))
            {
                return;
            }

            string login = LoginTB.Text;
            string password = PasswordTB.Text;

            try
            {
                Api.Authorize(new VkNet.Model.ApiAuthParams()
                {
                    ApplicationId = SntnAppId,
                    Login = login,
                    Password = password,
                    Settings = VkNet.Enums.Filters.Settings.Groups | 
                               VkNet.Enums.Filters.Settings.Photos |
                               VkNet.Enums.Filters.Settings.Wall |
                               VkNet.Enums.Filters.Settings.Offline,
                    TwoFactorAuthorization = () =>
                    {
                        var twoFactorForm = new TwoFactorForm();
                        twoFactorForm.ShowDialog();
                        return twoFactorForm.Code;
                    }
                });
            }
            catch (VkNet.Exception.VkAuthorizationException)
            {
                MessageBox.Show("Неправильный логин/пароль или ошибка ВК", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
