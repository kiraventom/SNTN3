namespace SNTN3_Forms
{
    partial class PostingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostingForm));
            this.StartingDayL = new System.Windows.Forms.Label();
            this.StartingTimeL = new System.Windows.Forms.Label();
            this.PostsCountL = new System.Windows.Forms.Label();
            this.TimeBetweenL = new System.Windows.Forms.Label();
            this.MainP = new System.Windows.Forms.Panel();
            this.InL = new System.Windows.Forms.Label();
            this.HoursL = new System.Windows.Forms.Label();
            this.StartingTimeNUD = new System.Windows.Forms.NumericUpDown();
            this.TimeBetweenNUD = new System.Windows.Forms.NumericUpDown();
            this.PostsCountNUD = new System.Windows.Forms.NumericUpDown();
            this.StartingDateDP = new System.Windows.Forms.DateTimePicker();
            this.GroupsCB = new System.Windows.Forms.ComboBox();
            this.WhichGroupL = new System.Windows.Forms.Label();
            this.SaveSettingsBt = new System.Windows.Forms.Button();
            this.PrevStepBt = new System.Windows.Forms.Button();
            this.PostBt = new System.Windows.Forms.Button();
            this.MainP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartingTimeNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBetweenNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostsCountNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // StartingDayL
            // 
            this.StartingDayL.AutoSize = true;
            this.StartingDayL.Location = new System.Drawing.Point(12, 47);
            this.StartingDayL.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.StartingDayL.Name = "StartingDayL";
            this.StartingDayL.Size = new System.Drawing.Size(150, 17);
            this.StartingDayL.TabIndex = 0;
            this.StartingDayL.Text = "С какого дня начать?";
            // 
            // StartingTimeL
            // 
            this.StartingTimeL.AutoSize = true;
            this.StartingTimeL.Location = new System.Drawing.Point(12, 79);
            this.StartingTimeL.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.StartingTimeL.Name = "StartingTimeL";
            this.StartingTimeL.Size = new System.Drawing.Size(226, 17);
            this.StartingTimeL.TabIndex = 1;
            this.StartingTimeL.Text = "Во сколько делать первый пост?";
            // 
            // PostsCountL
            // 
            this.PostsCountL.AutoSize = true;
            this.PostsCountL.Location = new System.Drawing.Point(12, 111);
            this.PostsCountL.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.PostsCountL.Name = "PostsCountL";
            this.PostsCountL.Size = new System.Drawing.Size(254, 17);
            this.PostsCountL.TabIndex = 2;
            this.PostsCountL.Text = "Сколько постов должно быть в день?";
            // 
            // TimeBetweenL
            // 
            this.TimeBetweenL.AutoSize = true;
            this.TimeBetweenL.Location = new System.Drawing.Point(12, 143);
            this.TimeBetweenL.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.TimeBetweenL.Name = "TimeBetweenL";
            this.TimeBetweenL.Size = new System.Drawing.Size(341, 17);
            this.TimeBetweenL.TabIndex = 3;
            this.TimeBetweenL.Text = "Сколько часов должно проходить между постами?";
            // 
            // MainP
            // 
            this.MainP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainP.Controls.Add(this.InL);
            this.MainP.Controls.Add(this.HoursL);
            this.MainP.Controls.Add(this.StartingTimeNUD);
            this.MainP.Controls.Add(this.TimeBetweenNUD);
            this.MainP.Controls.Add(this.PostsCountNUD);
            this.MainP.Controls.Add(this.StartingDateDP);
            this.MainP.Controls.Add(this.GroupsCB);
            this.MainP.Controls.Add(this.WhichGroupL);
            this.MainP.Controls.Add(this.StartingDayL);
            this.MainP.Controls.Add(this.StartingTimeL);
            this.MainP.Controls.Add(this.PostsCountL);
            this.MainP.Controls.Add(this.TimeBetweenL);
            this.MainP.Location = new System.Drawing.Point(0, 66);
            this.MainP.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.MainP.Name = "MainP";
            this.MainP.Size = new System.Drawing.Size(516, 195);
            this.MainP.TabIndex = 6;
            // 
            // InL
            // 
            this.InL.AutoSize = true;
            this.InL.Location = new System.Drawing.Point(348, 78);
            this.InL.Name = "InL";
            this.InL.Size = new System.Drawing.Size(17, 17);
            this.InL.TabIndex = 11;
            this.InL.Text = "В";
            // 
            // HoursL
            // 
            this.HoursL.AutoSize = true;
            this.HoursL.Location = new System.Drawing.Point(473, 79);
            this.HoursL.Name = "HoursL";
            this.HoursL.Size = new System.Drawing.Size(31, 17);
            this.HoursL.TabIndex = 11;
            this.HoursL.Text = "час";
            // 
            // StartingTimeNUD
            // 
            this.StartingTimeNUD.Location = new System.Drawing.Point(371, 77);
            this.StartingTimeNUD.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.StartingTimeNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StartingTimeNUD.Name = "StartingTimeNUD";
            this.StartingTimeNUD.Size = new System.Drawing.Size(96, 22);
            this.StartingTimeNUD.TabIndex = 10;
            this.StartingTimeNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StartingTimeNUD.ValueChanged += new System.EventHandler(this.StartingTimeNUD_ValueChanged);
            // 
            // TimeBetweenNUD
            // 
            this.TimeBetweenNUD.Location = new System.Drawing.Point(408, 143);
            this.TimeBetweenNUD.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.TimeBetweenNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimeBetweenNUD.Name = "TimeBetweenNUD";
            this.TimeBetweenNUD.Size = new System.Drawing.Size(96, 22);
            this.TimeBetweenNUD.TabIndex = 9;
            this.TimeBetweenNUD.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.TimeBetweenNUD.ValueChanged += new System.EventHandler(this.TimeBetweenNUD_ValueChanged);
            // 
            // PostsCountNUD
            // 
            this.PostsCountNUD.Location = new System.Drawing.Point(408, 111);
            this.PostsCountNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PostsCountNUD.Name = "PostsCountNUD";
            this.PostsCountNUD.Size = new System.Drawing.Size(96, 22);
            this.PostsCountNUD.TabIndex = 8;
            this.PostsCountNUD.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.PostsCountNUD.ValueChanged += new System.EventHandler(this.PostsCountNUD_ValueChanged);
            // 
            // StartingDateDP
            // 
            this.StartingDateDP.Location = new System.Drawing.Point(304, 42);
            this.StartingDateDP.Name = "StartingDateDP";
            this.StartingDateDP.Size = new System.Drawing.Size(200, 22);
            this.StartingDateDP.TabIndex = 6;
            // 
            // GroupsCB
            // 
            this.GroupsCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupsCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupsCB.FormattingEnabled = true;
            this.GroupsCB.Location = new System.Drawing.Point(304, 12);
            this.GroupsCB.Name = "GroupsCB";
            this.GroupsCB.Size = new System.Drawing.Size(200, 24);
            this.GroupsCB.TabIndex = 5;
            // 
            // WhichGroupL
            // 
            this.WhichGroupL.AutoSize = true;
            this.WhichGroupL.Location = new System.Drawing.Point(12, 15);
            this.WhichGroupL.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.WhichGroupL.Name = "WhichGroupL";
            this.WhichGroupL.Size = new System.Drawing.Size(174, 17);
            this.WhichGroupL.TabIndex = 4;
            this.WhichGroupL.Text = "В какой паблик постить?";
            // 
            // SaveSettingsBt
            // 
            this.SaveSettingsBt.BackColor = System.Drawing.Color.White;
            this.SaveSettingsBt.BackgroundImage = global::SNTN3_Forms.Properties.Resources.SaveIcon;
            this.SaveSettingsBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SaveSettingsBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveSettingsBt.Location = new System.Drawing.Point(15, 11);
            this.SaveSettingsBt.Margin = new System.Windows.Forms.Padding(13, 2, 3, 2);
            this.SaveSettingsBt.Name = "SaveSettingsBt";
            this.SaveSettingsBt.Size = new System.Drawing.Size(55, 50);
            this.SaveSettingsBt.TabIndex = 7;
            this.SaveSettingsBt.UseVisualStyleBackColor = false;
            this.SaveSettingsBt.Visible = false;
            this.SaveSettingsBt.Click += new System.EventHandler(this.SaveSettingsBt_Click);
            // 
            // PrevStepBt
            // 
            this.PrevStepBt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PrevStepBt.BackColor = System.Drawing.Color.SkyBlue;
            this.PrevStepBt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PrevStepBt.BackgroundImage")));
            this.PrevStepBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PrevStepBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrevStepBt.Location = new System.Drawing.Point(194, 11);
            this.PrevStepBt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrevStepBt.Name = "PrevStepBt";
            this.PrevStepBt.Size = new System.Drawing.Size(55, 50);
            this.PrevStepBt.TabIndex = 4;
            this.PrevStepBt.UseVisualStyleBackColor = false;
            this.PrevStepBt.Click += new System.EventHandler(this.PrevStepBt_Click);
            // 
            // PostBt
            // 
            this.PostBt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PostBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PostBt.BackgroundImage = global::SNTN3_Forms.Properties.Resources.PostIcon;
            this.PostBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PostBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PostBt.Location = new System.Drawing.Point(265, 11);
            this.PostBt.Margin = new System.Windows.Forms.Padding(13, 2, 3, 2);
            this.PostBt.Name = "PostBt";
            this.PostBt.Size = new System.Drawing.Size(55, 50);
            this.PostBt.TabIndex = 5;
            this.PostBt.UseVisualStyleBackColor = false;
            this.PostBt.Click += new System.EventHandler(this.PostBt_Click);
            // 
            // PostingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 260);
            this.Controls.Add(this.SaveSettingsBt);
            this.Controls.Add(this.MainP);
            this.Controls.Add(this.PrevStepBt);
            this.Controls.Add(this.PostBt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PostingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Скажи Немезиде Нет! 3.0";
            this.Load += new System.EventHandler(this.PostingForm_Load);
            this.MainP.ResumeLayout(false);
            this.MainP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartingTimeNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBetweenNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostsCountNUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label StartingDayL;
        private System.Windows.Forms.Label StartingTimeL;
        private System.Windows.Forms.Label PostsCountL;
        private System.Windows.Forms.Label TimeBetweenL;
        private System.Windows.Forms.Button PrevStepBt;
        private System.Windows.Forms.Button PostBt;
        private System.Windows.Forms.Panel MainP;
        private System.Windows.Forms.Label WhichGroupL;
        private System.Windows.Forms.ComboBox GroupsCB;
        private System.Windows.Forms.DateTimePicker StartingDateDP;
        private System.Windows.Forms.NumericUpDown TimeBetweenNUD;
        private System.Windows.Forms.NumericUpDown PostsCountNUD;
        private System.Windows.Forms.NumericUpDown StartingTimeNUD;
        private System.Windows.Forms.Label HoursL;
        private System.Windows.Forms.Button SaveSettingsBt;
        private System.Windows.Forms.Label InL;
    }
}