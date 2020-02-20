namespace SNTN3_Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ToneGB = new System.Windows.Forms.GroupBox();
            this.ToneBottomLimitNUD = new System.Windows.Forms.NumericUpDown();
            this.ToneUpLimitNUD = new System.Windows.Forms.NumericUpDown();
            this.ToneBottomLimitL = new System.Windows.Forms.Label();
            this.ToneUpLimitL = new System.Windows.Forms.Label();
            this.BrightnessGB = new System.Windows.Forms.GroupBox();
            this.BrightnessUpLimitL = new System.Windows.Forms.Label();
            this.BrightnessBottomLimit = new System.Windows.Forms.Label();
            this.BrightnessUpLimitNUD = new System.Windows.Forms.NumericUpDown();
            this.BrightnessBottomLimitNUD = new System.Windows.Forms.NumericUpDown();
            this.FramesGB = new System.Windows.Forms.GroupBox();
            this.FramesUpLimitL = new System.Windows.Forms.Label();
            this.FramesBottomLimitL = new System.Windows.Forms.Label();
            this.FramesUpLimitNUD = new System.Windows.Forms.NumericUpDown();
            this.FramesBottomLimitNUD = new System.Windows.Forms.NumericUpDown();
            this.SaveSettingsBt = new System.Windows.Forms.Button();
            this.ToneGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToneBottomLimitNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToneUpLimitNUD)).BeginInit();
            this.BrightnessGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessUpLimitNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessBottomLimitNUD)).BeginInit();
            this.FramesGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FramesUpLimitNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FramesBottomLimitNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // ToneGB
            // 
            this.ToneGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToneGB.Controls.Add(this.ToneUpLimitL);
            this.ToneGB.Controls.Add(this.ToneBottomLimitL);
            this.ToneGB.Controls.Add(this.ToneUpLimitNUD);
            this.ToneGB.Controls.Add(this.ToneBottomLimitNUD);
            this.ToneGB.Location = new System.Drawing.Point(13, 13);
            this.ToneGB.Name = "ToneGB";
            this.ToneGB.Size = new System.Drawing.Size(417, 86);
            this.ToneGB.TabIndex = 0;
            this.ToneGB.TabStop = false;
            this.ToneGB.Text = "Тон";
            // 
            // ToneBottomLimitNUD
            // 
            this.ToneBottomLimitNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToneBottomLimitNUD.Location = new System.Drawing.Point(319, 21);
            this.ToneBottomLimitNUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ToneBottomLimitNUD.Name = "ToneBottomLimitNUD";
            this.ToneBottomLimitNUD.Size = new System.Drawing.Size(92, 22);
            this.ToneBottomLimitNUD.TabIndex = 0;
            this.ToneBottomLimitNUD.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.ToneBottomLimitNUD.ValueChanged += new System.EventHandler(this.ToneBottomLimitNUD_ValueChanged);
            // 
            // ToneUpLimitNUD
            // 
            this.ToneUpLimitNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ToneUpLimitNUD.Location = new System.Drawing.Point(319, 58);
            this.ToneUpLimitNUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ToneUpLimitNUD.Name = "ToneUpLimitNUD";
            this.ToneUpLimitNUD.Size = new System.Drawing.Size(92, 22);
            this.ToneUpLimitNUD.TabIndex = 0;
            this.ToneUpLimitNUD.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.ToneUpLimitNUD.ValueChanged += new System.EventHandler(this.ToneUpLimitNUD_ValueChanged);
            // 
            // ToneBottomLimitL
            // 
            this.ToneBottomLimitL.AutoSize = true;
            this.ToneBottomLimitL.Location = new System.Drawing.Point(6, 24);
            this.ToneBottomLimitL.Name = "ToneBottomLimitL";
            this.ToneBottomLimitL.Size = new System.Drawing.Size(230, 17);
            this.ToneBottomLimitL.TabIndex = 1;
            this.ToneBottomLimitL.Text = "Минимальная прозрачность тона";
            // 
            // ToneUpLimitL
            // 
            this.ToneUpLimitL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ToneUpLimitL.AutoSize = true;
            this.ToneUpLimitL.Location = new System.Drawing.Point(6, 61);
            this.ToneUpLimitL.Name = "ToneUpLimitL";
            this.ToneUpLimitL.Size = new System.Drawing.Size(236, 17);
            this.ToneUpLimitL.TabIndex = 1;
            this.ToneUpLimitL.Text = "Максимальная прозрачность тона";
            // 
            // BrightnessGB
            // 
            this.BrightnessGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BrightnessGB.Controls.Add(this.BrightnessUpLimitL);
            this.BrightnessGB.Controls.Add(this.BrightnessBottomLimit);
            this.BrightnessGB.Controls.Add(this.BrightnessUpLimitNUD);
            this.BrightnessGB.Controls.Add(this.BrightnessBottomLimitNUD);
            this.BrightnessGB.Location = new System.Drawing.Point(13, 105);
            this.BrightnessGB.Name = "BrightnessGB";
            this.BrightnessGB.Size = new System.Drawing.Size(417, 86);
            this.BrightnessGB.TabIndex = 0;
            this.BrightnessGB.TabStop = false;
            this.BrightnessGB.Text = "Яркость";
            // 
            // BrightnessUpLimitL
            // 
            this.BrightnessUpLimitL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BrightnessUpLimitL.AutoSize = true;
            this.BrightnessUpLimitL.Location = new System.Drawing.Point(6, 61);
            this.BrightnessUpLimitL.Name = "BrightnessUpLimitL";
            this.BrightnessUpLimitL.Size = new System.Drawing.Size(238, 17);
            this.BrightnessUpLimitL.TabIndex = 1;
            this.BrightnessUpLimitL.Text = "Максимальное изменение яркости";
            // 
            // BrightnessBottomLimit
            // 
            this.BrightnessBottomLimit.AutoSize = true;
            this.BrightnessBottomLimit.Location = new System.Drawing.Point(6, 24);
            this.BrightnessBottomLimit.Name = "BrightnessBottomLimit";
            this.BrightnessBottomLimit.Size = new System.Drawing.Size(232, 17);
            this.BrightnessBottomLimit.TabIndex = 1;
            this.BrightnessBottomLimit.Text = "Минимальное изменение яркости";
            // 
            // BrightnessUpLimitNUD
            // 
            this.BrightnessUpLimitNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BrightnessUpLimitNUD.Location = new System.Drawing.Point(319, 58);
            this.BrightnessUpLimitNUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BrightnessUpLimitNUD.Name = "BrightnessUpLimitNUD";
            this.BrightnessUpLimitNUD.Size = new System.Drawing.Size(92, 22);
            this.BrightnessUpLimitNUD.TabIndex = 0;
            this.BrightnessUpLimitNUD.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.BrightnessUpLimitNUD.ValueChanged += new System.EventHandler(this.BrightnessUpLimitNUD_ValueChanged);
            // 
            // BrightnessBottomLimitNUD
            // 
            this.BrightnessBottomLimitNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrightnessBottomLimitNUD.Location = new System.Drawing.Point(319, 21);
            this.BrightnessBottomLimitNUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BrightnessBottomLimitNUD.Name = "BrightnessBottomLimitNUD";
            this.BrightnessBottomLimitNUD.Size = new System.Drawing.Size(92, 22);
            this.BrightnessBottomLimitNUD.TabIndex = 0;
            this.BrightnessBottomLimitNUD.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.BrightnessBottomLimitNUD.ValueChanged += new System.EventHandler(this.BrightnessBottomLimitNUD_ValueChanged);
            // 
            // FramesGB
            // 
            this.FramesGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FramesGB.Controls.Add(this.FramesUpLimitL);
            this.FramesGB.Controls.Add(this.FramesBottomLimitL);
            this.FramesGB.Controls.Add(this.FramesUpLimitNUD);
            this.FramesGB.Controls.Add(this.FramesBottomLimitNUD);
            this.FramesGB.Location = new System.Drawing.Point(13, 197);
            this.FramesGB.Name = "FramesGB";
            this.FramesGB.Size = new System.Drawing.Size(417, 86);
            this.FramesGB.TabIndex = 0;
            this.FramesGB.TabStop = false;
            this.FramesGB.Text = "Рамки";
            // 
            // FramesUpLimitL
            // 
            this.FramesUpLimitL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FramesUpLimitL.AutoSize = true;
            this.FramesUpLimitL.Location = new System.Drawing.Point(6, 61);
            this.FramesUpLimitL.Name = "FramesUpLimitL";
            this.FramesUpLimitL.Size = new System.Drawing.Size(297, 17);
            this.FramesUpLimitL.TabIndex = 1;
            this.FramesUpLimitL.Text = "Максимальный размер рамок (в процентах)";
            // 
            // FramesBottomLimitL
            // 
            this.FramesBottomLimitL.AutoSize = true;
            this.FramesBottomLimitL.Location = new System.Drawing.Point(6, 24);
            this.FramesBottomLimitL.Name = "FramesBottomLimitL";
            this.FramesBottomLimitL.Size = new System.Drawing.Size(291, 17);
            this.FramesBottomLimitL.TabIndex = 1;
            this.FramesBottomLimitL.Text = "Минимальный размер рамок (в процентах)";
            // 
            // FramesUpLimitNUD
            // 
            this.FramesUpLimitNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FramesUpLimitNUD.Location = new System.Drawing.Point(319, 58);
            this.FramesUpLimitNUD.Name = "FramesUpLimitNUD";
            this.FramesUpLimitNUD.Size = new System.Drawing.Size(92, 22);
            this.FramesUpLimitNUD.TabIndex = 0;
            this.FramesUpLimitNUD.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.FramesUpLimitNUD.ValueChanged += new System.EventHandler(this.FramesUpLimitNUD_ValueChanged);
            // 
            // FramesBottomLimitNUD
            // 
            this.FramesBottomLimitNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FramesBottomLimitNUD.Location = new System.Drawing.Point(319, 21);
            this.FramesBottomLimitNUD.Name = "FramesBottomLimitNUD";
            this.FramesBottomLimitNUD.Size = new System.Drawing.Size(92, 22);
            this.FramesBottomLimitNUD.TabIndex = 0;
            this.FramesBottomLimitNUD.ValueChanged += new System.EventHandler(this.FramesBottomLimitNUD_ValueChanged);
            // 
            // SaveSettingsBt
            // 
            this.SaveSettingsBt.BackColor = System.Drawing.Color.White;
            this.SaveSettingsBt.BackgroundImage = global::SNTN3_Forms.Properties.Resources.SaveIcon;
            this.SaveSettingsBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SaveSettingsBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveSettingsBt.Location = new System.Drawing.Point(194, 297);
            this.SaveSettingsBt.Margin = new System.Windows.Forms.Padding(13, 2, 3, 2);
            this.SaveSettingsBt.Name = "SaveSettingsBt";
            this.SaveSettingsBt.Size = new System.Drawing.Size(55, 50);
            this.SaveSettingsBt.TabIndex = 1;
            this.SaveSettingsBt.UseVisualStyleBackColor = false;
            this.SaveSettingsBt.Click += new System.EventHandler(this.SaveSettingsBt_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 358);
            this.Controls.Add(this.SaveSettingsBt);
            this.Controls.Add(this.FramesGB);
            this.Controls.Add(this.BrightnessGB);
            this.Controls.Add(this.ToneGB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки случайных параметров";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ToneGB.ResumeLayout(false);
            this.ToneGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToneBottomLimitNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToneUpLimitNUD)).EndInit();
            this.BrightnessGB.ResumeLayout(false);
            this.BrightnessGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessUpLimitNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessBottomLimitNUD)).EndInit();
            this.FramesGB.ResumeLayout(false);
            this.FramesGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FramesUpLimitNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FramesBottomLimitNUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ToneGB;
        private System.Windows.Forms.Label ToneUpLimitL;
        private System.Windows.Forms.Label ToneBottomLimitL;
        private System.Windows.Forms.NumericUpDown ToneUpLimitNUD;
        private System.Windows.Forms.NumericUpDown ToneBottomLimitNUD;
        private System.Windows.Forms.GroupBox BrightnessGB;
        private System.Windows.Forms.Label BrightnessUpLimitL;
        private System.Windows.Forms.Label BrightnessBottomLimit;
        private System.Windows.Forms.NumericUpDown BrightnessUpLimitNUD;
        private System.Windows.Forms.NumericUpDown BrightnessBottomLimitNUD;
        private System.Windows.Forms.GroupBox FramesGB;
        private System.Windows.Forms.Label FramesUpLimitL;
        private System.Windows.Forms.Label FramesBottomLimitL;
        private System.Windows.Forms.NumericUpDown FramesUpLimitNUD;
        private System.Windows.Forms.NumericUpDown FramesBottomLimitNUD;
        private System.Windows.Forms.Button SaveSettingsBt;
    }
}