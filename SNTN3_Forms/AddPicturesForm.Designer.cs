namespace SNTN3_Forms
{
    partial class AddPicturesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPicturesForm));
            this.AccountNameL = new System.Windows.Forms.Label();
            this.PicturesFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.AddImagesBt = new System.Windows.Forms.Button();
            this.PrevStepBt = new System.Windows.Forms.Button();
            this.AddFolderBt = new System.Windows.Forms.Button();
            this.NextStepBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AccountNameL
            // 
            this.AccountNameL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountNameL.AutoSize = true;
            this.AccountNameL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AccountNameL.Location = new System.Drawing.Point(493, 16);
            this.AccountNameL.Margin = new System.Windows.Forms.Padding(47, 0, 4, 0);
            this.AccountNameL.Name = "AccountNameL";
            this.AccountNameL.Size = new System.Drawing.Size(221, 29);
            this.AccountNameL.TabIndex = 1;
            this.AccountNameL.Text = "Не авторизовано!";
            this.AccountNameL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PicturesFLP
            // 
            this.PicturesFLP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicturesFLP.AutoScroll = true;
            this.PicturesFLP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicturesFLP.Location = new System.Drawing.Point(0, 66);
            this.PicturesFLP.Margin = new System.Windows.Forms.Padding(0);
            this.PicturesFLP.Name = "PicturesFLP";
            this.PicturesFLP.Size = new System.Drawing.Size(726, 439);
            this.PicturesFLP.TabIndex = 1;
            // 
            // AddImagesBt
            // 
            this.AddImagesBt.BackColor = System.Drawing.Color.Khaki;
            this.AddImagesBt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddImagesBt.BackgroundImage")));
            this.AddImagesBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddImagesBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddImagesBt.Location = new System.Drawing.Point(15, 10);
            this.AddImagesBt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddImagesBt.Name = "AddImagesBt";
            this.AddImagesBt.Size = new System.Drawing.Size(55, 50);
            this.AddImagesBt.TabIndex = 0;
            this.AddImagesBt.UseVisualStyleBackColor = false;
            this.AddImagesBt.Click += new System.EventHandler(this.AddImagesBt_Click);
            // 
            // PrevStepBt
            // 
            this.PrevStepBt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PrevStepBt.BackColor = System.Drawing.Color.SkyBlue;
            this.PrevStepBt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PrevStepBt.BackgroundImage")));
            this.PrevStepBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PrevStepBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrevStepBt.Location = new System.Drawing.Point(300, 10);
            this.PrevStepBt.Margin = new System.Windows.Forms.Padding(13, 2, 3, 2);
            this.PrevStepBt.Name = "PrevStepBt";
            this.PrevStepBt.Size = new System.Drawing.Size(55, 50);
            this.PrevStepBt.TabIndex = 2;
            this.PrevStepBt.UseVisualStyleBackColor = false;
            this.PrevStepBt.Click += new System.EventHandler(this.PrevStepBt_Click);
            // 
            // AddFolderBt
            // 
            this.AddFolderBt.BackColor = System.Drawing.Color.Khaki;
            this.AddFolderBt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddFolderBt.BackgroundImage")));
            this.AddFolderBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddFolderBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddFolderBt.Location = new System.Drawing.Point(85, 10);
            this.AddFolderBt.Margin = new System.Windows.Forms.Padding(13, 2, 3, 2);
            this.AddFolderBt.Name = "AddFolderBt";
            this.AddFolderBt.Size = new System.Drawing.Size(55, 50);
            this.AddFolderBt.TabIndex = 0;
            this.AddFolderBt.UseVisualStyleBackColor = false;
            this.AddFolderBt.Click += new System.EventHandler(this.AddFolderBt_Click);
            // 
            // NextStepBt
            // 
            this.NextStepBt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NextStepBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.NextStepBt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NextStepBt.BackgroundImage")));
            this.NextStepBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.NextStepBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextStepBt.Location = new System.Drawing.Point(371, 10);
            this.NextStepBt.Margin = new System.Windows.Forms.Padding(13, 2, 3, 2);
            this.NextStepBt.Name = "NextStepBt";
            this.NextStepBt.Size = new System.Drawing.Size(55, 50);
            this.NextStepBt.TabIndex = 0;
            this.NextStepBt.UseVisualStyleBackColor = false;
            this.NextStepBt.Click += new System.EventHandler(this.NextStepBt_Click);
            // 
            // AddPicturesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 506);
            this.Controls.Add(this.AddImagesBt);
            this.Controls.Add(this.PrevStepBt);
            this.Controls.Add(this.AddFolderBt);
            this.Controls.Add(this.PicturesFLP);
            this.Controls.Add(this.AccountNameL);
            this.Controls.Add(this.NextStepBt);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(569, 101);
            this.Name = "AddPicturesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Скажи Немезиде Нет! 3.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddImagesBt;
        private System.Windows.Forms.Button AddFolderBt;
        private System.Windows.Forms.FlowLayoutPanel PicturesFLP;
        private System.Windows.Forms.Button NextStepBt;
        private System.Windows.Forms.Label AccountNameL;
        private System.Windows.Forms.Button PrevStepBt;
    }
}