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
    public partial class TwoFactorForm : Form
    {
        public TwoFactorForm()
        {
            InitializeComponent();
        }

        public string Code { get; private set; } 

        private void ConfirmBt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CodeTB.Text) || CodeTB.Text.Any(c => !char.IsDigit(c)))
            {
                return;
            }

            Code = CodeTB.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void TwoFactorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
