namespace SNTN3_Forms
{
    partial class EditPicturesForm
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
            SNTN3_Forms.PictureEdit.PictureEditParams pictureEditParams1 = new SNTN3_Forms.PictureEdit.PictureEditParams();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPicturesForm));
            this.EditGB = new System.Windows.Forms.GroupBox();
            this.editPreviewPB1 = new SNTN3_Forms.EditPreviewPB();
            this.SaveBt = new System.Windows.Forms.Button();
            this.BrightnessColorBt = new System.Windows.Forms.Button();
            this.FramesTBr = new System.Windows.Forms.TrackBar();
            this.ToneColorBt = new System.Windows.Forms.Button();
            this.BrightnessTBr = new System.Windows.Forms.TrackBar();
            this.ToneTBr = new System.Windows.Forms.TrackBar();
            this.FramesCB = new System.Windows.Forms.CheckBox();
            this.BrightnessCB = new System.Windows.Forms.CheckBox();
            this.ToneCB = new System.Windows.Forms.CheckBox();
            this.FlipCB = new System.Windows.Forms.CheckBox();
            this.PicturesFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.SettingsBt = new System.Windows.Forms.Button();
            this.RegenerateEditParamsBt = new System.Windows.Forms.Button();
            this.PrevStepBt = new System.Windows.Forms.Button();
            this.NextStepBt = new System.Windows.Forms.Button();
            this.EditGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editPreviewPB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FramesTBr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessTBr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToneTBr)).BeginInit();
            this.SuspendLayout();
            // 
            // EditGB
            // 
            this.EditGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditGB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EditGB.Controls.Add(this.editPreviewPB1);
            this.EditGB.Controls.Add(this.SaveBt);
            this.EditGB.Controls.Add(this.BrightnessColorBt);
            this.EditGB.Controls.Add(this.FramesTBr);
            this.EditGB.Controls.Add(this.ToneColorBt);
            this.EditGB.Controls.Add(this.BrightnessTBr);
            this.EditGB.Controls.Add(this.ToneTBr);
            this.EditGB.Controls.Add(this.FramesCB);
            this.EditGB.Controls.Add(this.BrightnessCB);
            this.EditGB.Controls.Add(this.ToneCB);
            this.EditGB.Controls.Add(this.FlipCB);
            this.EditGB.Enabled = false;
            this.EditGB.Location = new System.Drawing.Point(559, 70);
            this.EditGB.Margin = new System.Windows.Forms.Padding(4);
            this.EditGB.Name = "EditGB";
            this.EditGB.Padding = new System.Windows.Forms.Padding(4);
            this.EditGB.Size = new System.Drawing.Size(312, 617);
            this.EditGB.TabIndex = 0;
            this.EditGB.TabStop = false;
            this.EditGB.Text = "Панель редактирования";
            // 
            // editPreviewPB1
            // 
            this.editPreviewPB1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editPreviewPB1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.editPreviewPB1.Location = new System.Drawing.Point(16, 307);
            this.editPreviewPB1.Name = "editPreviewPB1";
            pictureEditParams1.Brightness = null;
            pictureEditParams1.Frames = null;
            pictureEditParams1.IsFlipped = false;
            pictureEditParams1.Tone = null;
            this.editPreviewPB1.PicEditParams = pictureEditParams1;
            this.editPreviewPB1.Size = new System.Drawing.Size(102, 82);
            this.editPreviewPB1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.editPreviewPB1.TabIndex = 9;
            this.editPreviewPB1.TabStop = false;
            // 
            // SaveBt
            // 
            this.SaveBt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBt.BackColor = System.Drawing.Color.LightGreen;
            this.SaveBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBt.Location = new System.Drawing.Point(16, 574);
            this.SaveBt.Margin = new System.Windows.Forms.Padding(4, 25, 4, 4);
            this.SaveBt.Name = "SaveBt";
            this.SaveBt.Size = new System.Drawing.Size(280, 28);
            this.SaveBt.TabIndex = 5;
            this.SaveBt.Text = "Сохранить изменения";
            this.SaveBt.UseVisualStyleBackColor = false;
            this.SaveBt.Visible = false;
            this.SaveBt.Click += new System.EventHandler(this.SaveBt_Click);
            // 
            // BrightnessColorBt
            // 
            this.BrightnessColorBt.BackColor = System.Drawing.Color.White;
            this.BrightnessColorBt.Enabled = false;
            this.BrightnessColorBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrightnessColorBt.Location = new System.Drawing.Point(16, 187);
            this.BrightnessColorBt.Margin = new System.Windows.Forms.Padding(4);
            this.BrightnessColorBt.Name = "BrightnessColorBt";
            this.BrightnessColorBt.Size = new System.Drawing.Size(33, 28);
            this.BrightnessColorBt.TabIndex = 4;
            this.BrightnessColorBt.UseVisualStyleBackColor = false;
            this.BrightnessColorBt.Click += new System.EventHandler(this.BrightnessColorBt_Click);
            // 
            // FramesTBr
            // 
            this.FramesTBr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FramesTBr.AutoSize = false;
            this.FramesTBr.Enabled = false;
            this.FramesTBr.Location = new System.Drawing.Point(16, 272);
            this.FramesTBr.Margin = new System.Windows.Forms.Padding(4);
            this.FramesTBr.Maximum = 100;
            this.FramesTBr.Name = "FramesTBr";
            this.FramesTBr.Size = new System.Drawing.Size(288, 28);
            this.FramesTBr.TabIndex = 3;
            this.FramesTBr.TickStyle = System.Windows.Forms.TickStyle.None;
            this.FramesTBr.Scroll += new System.EventHandler(this.FramesTBr_Scroll);
            // 
            // ToneColorBt
            // 
            this.ToneColorBt.Enabled = false;
            this.ToneColorBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToneColorBt.Location = new System.Drawing.Point(16, 102);
            this.ToneColorBt.Margin = new System.Windows.Forms.Padding(4);
            this.ToneColorBt.Name = "ToneColorBt";
            this.ToneColorBt.Size = new System.Drawing.Size(33, 28);
            this.ToneColorBt.TabIndex = 4;
            this.ToneColorBt.UseVisualStyleBackColor = true;
            this.ToneColorBt.Click += new System.EventHandler(this.ToneColorBt_Click);
            // 
            // BrightnessTBr
            // 
            this.BrightnessTBr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BrightnessTBr.AutoSize = false;
            this.BrightnessTBr.Enabled = false;
            this.BrightnessTBr.LargeChange = 25;
            this.BrightnessTBr.Location = new System.Drawing.Point(57, 187);
            this.BrightnessTBr.Margin = new System.Windows.Forms.Padding(4);
            this.BrightnessTBr.Maximum = 255;
            this.BrightnessTBr.Name = "BrightnessTBr";
            this.BrightnessTBr.Size = new System.Drawing.Size(247, 28);
            this.BrightnessTBr.TabIndex = 3;
            this.BrightnessTBr.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BrightnessTBr.Scroll += new System.EventHandler(this.BrightnessTBr_Scroll);
            // 
            // ToneTBr
            // 
            this.ToneTBr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToneTBr.AutoSize = false;
            this.ToneTBr.Enabled = false;
            this.ToneTBr.LargeChange = 25;
            this.ToneTBr.Location = new System.Drawing.Point(57, 102);
            this.ToneTBr.Margin = new System.Windows.Forms.Padding(4);
            this.ToneTBr.Maximum = 255;
            this.ToneTBr.Name = "ToneTBr";
            this.ToneTBr.Size = new System.Drawing.Size(247, 28);
            this.ToneTBr.TabIndex = 3;
            this.ToneTBr.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ToneTBr.Scroll += new System.EventHandler(this.ToneTBr_Scroll);
            // 
            // FramesCB
            // 
            this.FramesCB.AutoSize = true;
            this.FramesCB.Location = new System.Drawing.Point(16, 244);
            this.FramesCB.Margin = new System.Windows.Forms.Padding(4, 25, 4, 4);
            this.FramesCB.Name = "FramesCB";
            this.FramesCB.Size = new System.Drawing.Size(71, 21);
            this.FramesCB.TabIndex = 2;
            this.FramesCB.Tag = "Frames";
            this.FramesCB.Text = "Рамки";
            this.FramesCB.UseVisualStyleBackColor = true;
            this.FramesCB.CheckedChanged += new System.EventHandler(this.FramesCB_CheckedChanged);
            this.FramesCB.Click += new System.EventHandler(this.FramesCB_Click);
            // 
            // BrightnessCB
            // 
            this.BrightnessCB.AutoSize = true;
            this.BrightnessCB.Location = new System.Drawing.Point(16, 159);
            this.BrightnessCB.Margin = new System.Windows.Forms.Padding(4, 25, 4, 4);
            this.BrightnessCB.Name = "BrightnessCB";
            this.BrightnessCB.Size = new System.Drawing.Size(84, 21);
            this.BrightnessCB.TabIndex = 2;
            this.BrightnessCB.Tag = "Brightness";
            this.BrightnessCB.Text = "Яркость";
            this.BrightnessCB.UseVisualStyleBackColor = true;
            this.BrightnessCB.CheckedChanged += new System.EventHandler(this.BrightnessCB_CheckedChanged);
            this.BrightnessCB.Click += new System.EventHandler(this.BrightnessCB_Click);
            // 
            // ToneCB
            // 
            this.ToneCB.AutoSize = true;
            this.ToneCB.Location = new System.Drawing.Point(16, 74);
            this.ToneCB.Margin = new System.Windows.Forms.Padding(4, 25, 4, 4);
            this.ToneCB.Name = "ToneCB";
            this.ToneCB.Size = new System.Drawing.Size(55, 21);
            this.ToneCB.TabIndex = 2;
            this.ToneCB.Tag = "Tone";
            this.ToneCB.Text = "Тон";
            this.ToneCB.UseVisualStyleBackColor = true;
            this.ToneCB.CheckedChanged += new System.EventHandler(this.ToneCB_CheckedChanged);
            this.ToneCB.Click += new System.EventHandler(this.ToneCB_Click);
            // 
            // FlipCB
            // 
            this.FlipCB.AutoSize = true;
            this.FlipCB.Location = new System.Drawing.Point(16, 25);
            this.FlipCB.Margin = new System.Windows.Forms.Padding(4);
            this.FlipCB.Name = "FlipCB";
            this.FlipCB.Size = new System.Drawing.Size(93, 21);
            this.FlipCB.TabIndex = 0;
            this.FlipCB.Tag = "Flip";
            this.FlipCB.Text = "Отразить";
            this.FlipCB.UseVisualStyleBackColor = true;
            this.FlipCB.Click += new System.EventHandler(this.FlipCB_Click);
            // 
            // PicturesFLP
            // 
            this.PicturesFLP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicturesFLP.AutoScroll = true;
            this.PicturesFLP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicturesFLP.Location = new System.Drawing.Point(0, 70);
            this.PicturesFLP.Margin = new System.Windows.Forms.Padding(0);
            this.PicturesFLP.Name = "PicturesFLP";
            this.PicturesFLP.Size = new System.Drawing.Size(555, 631);
            this.PicturesFLP.TabIndex = 2;
            this.PicturesFLP.Click += new System.EventHandler(this.PicturesFLP_Click);
            // 
            // SettingsBt
            // 
            this.SettingsBt.BackColor = System.Drawing.Color.Silver;
            this.SettingsBt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SettingsBt.BackgroundImage")));
            this.SettingsBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SettingsBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsBt.Location = new System.Drawing.Point(93, 14);
            this.SettingsBt.Margin = new System.Windows.Forms.Padding(20, 2, 3, 2);
            this.SettingsBt.Name = "SettingsBt";
            this.SettingsBt.Size = new System.Drawing.Size(55, 50);
            this.SettingsBt.TabIndex = 1;
            this.SettingsBt.UseVisualStyleBackColor = false;
            this.SettingsBt.Click += new System.EventHandler(this.SettingsBt_Click);
            // 
            // RegenerateEditParamsBt
            // 
            this.RegenerateEditParamsBt.BackColor = System.Drawing.Color.Violet;
            this.RegenerateEditParamsBt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RegenerateEditParamsBt.BackgroundImage")));
            this.RegenerateEditParamsBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RegenerateEditParamsBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegenerateEditParamsBt.Location = new System.Drawing.Point(15, 14);
            this.RegenerateEditParamsBt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegenerateEditParamsBt.Name = "RegenerateEditParamsBt";
            this.RegenerateEditParamsBt.Size = new System.Drawing.Size(55, 50);
            this.RegenerateEditParamsBt.TabIndex = 1;
            this.RegenerateEditParamsBt.UseVisualStyleBackColor = false;
            this.RegenerateEditParamsBt.Click += new System.EventHandler(this.RegenerateEditParamsBt_Click);
            // 
            // PrevStepBt
            // 
            this.PrevStepBt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PrevStepBt.BackColor = System.Drawing.Color.SkyBlue;
            this.PrevStepBt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PrevStepBt.BackgroundImage")));
            this.PrevStepBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PrevStepBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrevStepBt.Location = new System.Drawing.Point(381, 11);
            this.PrevStepBt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrevStepBt.Name = "PrevStepBt";
            this.PrevStepBt.Size = new System.Drawing.Size(55, 50);
            this.PrevStepBt.TabIndex = 1;
            this.PrevStepBt.UseVisualStyleBackColor = false;
            this.PrevStepBt.Click += new System.EventHandler(this.PrevStepBt_Click);
            // 
            // NextStepBt
            // 
            this.NextStepBt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NextStepBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.NextStepBt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NextStepBt.BackgroundImage")));
            this.NextStepBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.NextStepBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextStepBt.Location = new System.Drawing.Point(452, 11);
            this.NextStepBt.Margin = new System.Windows.Forms.Padding(13, 2, 3, 2);
            this.NextStepBt.Name = "NextStepBt";
            this.NextStepBt.Size = new System.Drawing.Size(55, 50);
            this.NextStepBt.TabIndex = 1;
            this.NextStepBt.UseVisualStyleBackColor = false;
            this.NextStepBt.Click += new System.EventHandler(this.NextStepBt_Click);
            // 
            // EditPicturesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 702);
            this.Controls.Add(this.PicturesFLP);
            this.Controls.Add(this.EditGB);
            this.Controls.Add(this.SettingsBt);
            this.Controls.Add(this.RegenerateEditParamsBt);
            this.Controls.Add(this.PrevStepBt);
            this.Controls.Add(this.NextStepBt);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(306, 745);
            this.Name = "EditPicturesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Скажи Немезиде Нет! 3.0";
            this.EditGB.ResumeLayout(false);
            this.EditGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editPreviewPB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FramesTBr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessTBr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToneTBr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NextStepBt;
        private System.Windows.Forms.Button PrevStepBt;
        private System.Windows.Forms.GroupBox EditGB;
        private System.Windows.Forms.CheckBox BrightnessCB;
        private System.Windows.Forms.CheckBox ToneCB;
        private System.Windows.Forms.CheckBox FlipCB;
        private System.Windows.Forms.CheckBox FramesCB;
        private System.Windows.Forms.Button ToneColorBt;
        private System.Windows.Forms.TrackBar ToneTBr;
        private System.Windows.Forms.Button BrightnessColorBt;
        private System.Windows.Forms.TrackBar FramesTBr;
        private System.Windows.Forms.TrackBar BrightnessTBr;
        private System.Windows.Forms.Button SaveBt;
        private System.Windows.Forms.Button RegenerateEditParamsBt;
        private System.Windows.Forms.FlowLayoutPanel PicturesFLP;
        private System.Windows.Forms.Button SettingsBt;
        private EditPreviewPB editPreviewPB1;
    }
}