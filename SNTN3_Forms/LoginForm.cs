using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using VkNet;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNTN3_Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm(VkApi api)
        {
            InitializeComponent();
            _api = api;
        }

        private VkApi _api { get; }

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
                _api.Authorize(new VkNet.Model.ApiAuthParams()
                {
                    ApplicationId = 7289220,
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
                MessageBox.Show("Неправильный логин или пароль. Если они точно правильные, попробуйте ещё раз через несколько минут.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
