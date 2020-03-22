using System;
using System.Windows.Forms;

namespace SNTN3_Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ToneBottomLimitNUD.Value = Properties.Settings.Default.ToneBottomLimit;
            ToneUpLimitNUD.Value = Properties.Settings.Default.ToneUpLimit;
            BrightnessBottomLimitNUD.Value = Properties.Settings.Default.BrightnessBottomLimit;
            BrightnessUpLimitNUD.Value = Properties.Settings.Default.BrightnessUpLimit;
            FramesBottomLimitNUD.Value = Properties.Settings.Default.FramesBottomLimit;
            FramesUpLimitNUD.Value = Properties.Settings.Default.FramesUpLimit;
        }

        private void SaveSettingsBt_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ToneBottomLimit = (int)ToneBottomLimitNUD.Value;
            Properties.Settings.Default.ToneUpLimit = (int)ToneUpLimitNUD.Value;
            Properties.Settings.Default.BrightnessBottomLimit = (int)BrightnessBottomLimitNUD.Value;
            Properties.Settings.Default.BrightnessUpLimit = (int)BrightnessUpLimitNUD.Value;
            Properties.Settings.Default.FramesBottomLimit = (int)FramesBottomLimitNUD.Value;
            Properties.Settings.Default.FramesUpLimit = (int)FramesUpLimitNUD.Value;
            Properties.Settings.Default.Save();
            Close();
        }

        private void ToneBottomLimitNUD_ValueChanged(object sender, EventArgs e)
        {
            ToneUpLimitNUD.Minimum = ToneBottomLimitNUD.Value;
        }

        private void ToneUpLimitNUD_ValueChanged(object sender, EventArgs e)
        {
            ToneBottomLimitNUD.Maximum = ToneUpLimitNUD.Value;
        }

        private void BrightnessBottomLimitNUD_ValueChanged(object sender, EventArgs e)
        {
            BrightnessUpLimitNUD.Minimum = BrightnessBottomLimitNUD.Value;
        }

        private void BrightnessUpLimitNUD_ValueChanged(object sender, EventArgs e)
        {
            BrightnessBottomLimitNUD.Maximum = BrightnessUpLimitNUD.Value;
        }

        private void FramesBottomLimitNUD_ValueChanged(object sender, EventArgs e)
        {
            FramesUpLimitNUD.Minimum = FramesBottomLimitNUD.Value;
        }

        private void FramesUpLimitNUD_ValueChanged(object sender, EventArgs e)
        {
            FramesBottomLimitNUD.Maximum = FramesUpLimitNUD.Value;
        }
    }
}
