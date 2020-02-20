namespace SNTN3_Forms
{
    partial class TwoFactorForm
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
            this.CodeTB = new System.Windows.Forms.TextBox();
            this.CodeL = new System.Windows.Forms.Label();
            this.ConfirmBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CodeTB
            // 
            this.CodeTB.Location = new System.Drawing.Point(18, 77);
            this.CodeTB.Name = "CodeTB";
            this.CodeTB.Size = new System.Drawing.Size(142, 22);
            this.CodeTB.TabIndex = 0;
            // 
            // CodeL
            // 
            this.CodeL.AutoEllipsis = true;
            this.CodeL.Location = new System.Drawing.Point(11, 9);
            this.CodeL.Name = "CodeL";
            this.CodeL.Size = new System.Drawing.Size(157, 53);
            this.CodeL.TabIndex = 1;
            this.CodeL.Text = "Введите код двухфакторной авторизации";
            this.CodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfirmBt
            // 
            this.ConfirmBt.Location = new System.Drawing.Point(39, 119);
            this.ConfirmBt.Name = "ConfirmBt";
            this.ConfirmBt.Size = new System.Drawing.Size(101, 32);
            this.ConfirmBt.TabIndex = 2;
            this.ConfirmBt.Text = "Отправить";
            this.ConfirmBt.UseVisualStyleBackColor = true;
            this.ConfirmBt.Click += new System.EventHandler(this.ConfirmBt_Click);
            // 
            // TwoFactorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 165);
            this.Controls.Add(this.ConfirmBt);
            this.Controls.Add(this.CodeL);
            this.Controls.Add(this.CodeTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TwoFactorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ввод кода";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TwoFactorForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CodeTB;
        private System.Windows.Forms.Label CodeL;
        private System.Windows.Forms.Button ConfirmBt;
    }
}