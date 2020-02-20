namespace SNTN3_Forms
{
    partial class LoginForm
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
            this.LoginL = new System.Windows.Forms.Label();
            this.LoginTB = new System.Windows.Forms.TextBox();
            this.PasswordL = new System.Windows.Forms.Label();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.AuthorizeBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginL
            // 
            this.LoginL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LoginL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginL.Location = new System.Drawing.Point(84, 8);
            this.LoginL.Name = "LoginL";
            this.LoginL.Size = new System.Drawing.Size(90, 24);
            this.LoginL.TabIndex = 0;
            this.LoginL.Text = "Логин";
            this.LoginL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginTB
            // 
            this.LoginTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginTB.Location = new System.Drawing.Point(13, 35);
            this.LoginTB.Name = "LoginTB";
            this.LoginTB.Size = new System.Drawing.Size(234, 22);
            this.LoginTB.TabIndex = 1;
            this.LoginTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PasswordL
            // 
            this.PasswordL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PasswordL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordL.Location = new System.Drawing.Point(74, 66);
            this.PasswordL.Name = "PasswordL";
            this.PasswordL.Size = new System.Drawing.Size(110, 24);
            this.PasswordL.TabIndex = 0;
            this.PasswordL.Text = "Пароль";
            this.PasswordL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PasswordTB
            // 
            this.PasswordTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTB.Location = new System.Drawing.Point(13, 93);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(234, 22);
            this.PasswordTB.TabIndex = 1;
            this.PasswordTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PasswordTB.UseSystemPasswordChar = true;
            // 
            // AuthorizeBt
            // 
            this.AuthorizeBt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthorizeBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AuthorizeBt.Location = new System.Drawing.Point(13, 137);
            this.AuthorizeBt.Name = "AuthorizeBt";
            this.AuthorizeBt.Size = new System.Drawing.Size(234, 38);
            this.AuthorizeBt.TabIndex = 2;
            this.AuthorizeBt.Text = "Авторизоваться";
            this.AuthorizeBt.UseVisualStyleBackColor = true;
            this.AuthorizeBt.Click += new System.EventHandler(this.AuthorizeBt_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 187);
            this.Controls.Add(this.AuthorizeBt);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.PasswordL);
            this.Controls.Add(this.LoginTB);
            this.Controls.Add(this.LoginL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(277, 230);
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить новый аккаунт";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label LoginL;
        protected System.Windows.Forms.TextBox LoginTB;
        protected System.Windows.Forms.Label PasswordL;
        protected System.Windows.Forms.TextBox PasswordTB;
        protected System.Windows.Forms.Button AuthorizeBt;
    }
}