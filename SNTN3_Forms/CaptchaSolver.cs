using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace SNTN3_Forms.Captcha
{
    public class CaptchaSolver : VkNet.Utils.AntiCaptcha.ICaptchaSolver
    {
        public CaptchaSolver() { }

        public string Solve(string url)
        {
            Bitmap captcha = DownloadCaptchaFromVk(url);
            if (captcha != null)
            {
                string solution = null;
                var captchaSolverForm = new CaptchaSolverForm(captcha);
                if (captchaSolverForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    solution = captchaSolverForm.Solution;
                }

                return solution;
            }
            else
            {
                return null;
            }

        }

        private Bitmap DownloadCaptchaFromVk(string captchaUrl)
        {
            using (WebClient client = new WebClient())
            {
                using (Stream s = client.OpenRead(captchaUrl))
                {
                    var imageData = client.DownloadData(captchaUrl);
                    using (var ms = new MemoryStream(imageData))
                    {
                        return new Bitmap(ms);
                    }
                }
            }
        }

        public void CaptchaIsFalse()
        {
            
        }
    }
}