namespace SNTN3_Forms
{
    partial class AccountsForm
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
            this.AccountsFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.ChooseAccountL = new System.Windows.Forms.Label();
            this.AddAccountBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AccountsFLP
            // 
            this.AccountsFLP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountsFLP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AccountsFLP.Location = new System.Drawing.Point(0, 66);
            this.AccountsFLP.Margin = new System.Windows.Forms.Padding(0);
            this.AccountsFLP.Name = "AccountsFLP";
            this.AccountsFLP.Size = new System.Drawing.Size(844, 388);
            this.AccountsFLP.TabIndex = 1;
            // 
            // ChooseAccountL
            // 
            this.ChooseAccountL.AutoSize = true;
            this.ChooseAccountL.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseAccountL.Location = new System.Drawing.Point(15, 17);
            this.ChooseAccountL.Name = "ChooseAccountL";
            this.ChooseAccountL.Size = new System.Drawing.Size(234, 33);
            this.ChooseAccountL.TabIndex = 0;
            this.ChooseAccountL.Text = "Выбор аккаунта";
            // 
            // AddAccountBt
            // 
            this.AddAccountBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddAccountBt.BackColor = System.Drawing.Color.PaleTurquoise;
            this.AddAccountBt.BackgroundImage = global::SNTN3_Forms.Properties.Resources.AddUserIcon;
            this.AddAccountBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddAccountBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAccountBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddAccountBt.Location = new System.Drawing.Point(776, 14);
            this.AddAccountBt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddAccountBt.Name = "AddAccountBt";
            this.AddAccountBt.Size = new System.Drawing.Size(55, 50);
            this.AddAccountBt.TabIndex = 1;
            this.AddAccountBt.UseVisualStyleBackColor = false;
            this.AddAccountBt.Click += new System.EventHandler(this.AddAccountBt_Click);
            // 
            // AccountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 455);
            this.Controls.Add(this.AddAccountBt);
            this.Controls.Add(this.ChooseAccountL);
            this.Controls.Add(this.AccountsFLP);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(354, 105);
            this.Name = "AccountsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Скажи Немезиде Нет! 3.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel AccountsFLP;
        private System.Windows.Forms.Label ChooseAccountL;
        private System.Windows.Forms.Button AddAccountBt;
    }
}

