using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNTN3_Forms
{
    public partial class CaptchaSolverForm : Form
    {
        public CaptchaSolverForm(Bitmap captcha)
        {
            InitializeComponent();
            if (captcha is null)
            {
                DialogResult = DialogResult.No;
                Close();
            }

            Captcha = captcha;
        }

        private Bitmap Captcha { get; }
        public string Solution { get; private set; }

        private void CaptchaSolverForm_Load(object sender, EventArgs e)
        {
            CaptchaPB.Image = Captcha;
        }

        private void ConfirmBt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CaptchaTB.Text))
            {
                return;
            }
            else
            {
                Solution = CaptchaTB.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void CaptchaSolverForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
