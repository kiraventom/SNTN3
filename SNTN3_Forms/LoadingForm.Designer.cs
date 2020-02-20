namespace SNTN3_Forms
{
    partial class LoadingForm
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
            this.MainPBr = new System.Windows.Forms.ProgressBar();
            this.DetailsL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MainPBr
            // 
            this.MainPBr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPBr.Location = new System.Drawing.Point(12, 38);
            this.MainPBr.Name = "MainPBr";
            this.MainPBr.Size = new System.Drawing.Size(290, 23);
            this.MainPBr.TabIndex = 0;
            // 
            // DetailsL
            // 
            this.DetailsL.AutoSize = true;
            this.DetailsL.Location = new System.Drawing.Point(12, 9);
            this.DetailsL.Name = "DetailsL";
            this.DetailsL.Size = new System.Drawing.Size(164, 17);
            this.DetailsL.TabIndex = 1;
            this.DetailsL.Text = "Пост на 8 апреля 13:45";
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 73);
            this.Controls.Add(this.DetailsL);
            this.Controls.Add(this.MainPBr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoadingForm";
            this.Load += new System.EventHandler(this.LoadingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar MainPBr;
        private System.Windows.Forms.Label DetailsL;
    }
}