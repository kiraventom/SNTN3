namespace SNTN3_Forms
{
    partial class CaptchaSolverForm
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
            this.CaptchaPB = new System.Windows.Forms.PictureBox();
            this.CaptchaTB = new System.Windows.Forms.TextBox();
            this.ConfirmBt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaPB)).BeginInit();
            this.SuspendLayout();
            // 
            // CaptchaPB
            // 
            this.CaptchaPB.Location = new System.Drawing.Point(12, 12);
            this.CaptchaPB.Name = "CaptchaPB";
            this.CaptchaPB.Size = new System.Drawing.Size(240, 89);
            this.CaptchaPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CaptchaPB.TabIndex = 0;
            this.CaptchaPB.TabStop = false;
            // 
            // CaptchaTB
            // 
            this.CaptchaTB.Location = new System.Drawing.Point(12, 107);
            this.CaptchaTB.Name = "CaptchaTB";
            this.CaptchaTB.Size = new System.Drawing.Size(240, 22);
            this.CaptchaTB.TabIndex = 1;
            // 
            // ConfirmBt
            // 
            this.ConfirmBt.Location = new System.Drawing.Point(78, 135);
            this.ConfirmBt.Name = "ConfirmBt";
            this.ConfirmBt.Size = new System.Drawing.Size(100, 23);
            this.ConfirmBt.TabIndex = 2;
            this.ConfirmBt.Text = "Отправить";
            this.ConfirmBt.UseVisualStyleBackColor = true;
            this.ConfirmBt.Click += new System.EventHandler(this.ConfirmBt_Click);
            // 
            // CaptchaSolverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 167);
            this.Controls.Add(this.ConfirmBt);
            this.Controls.Add(this.CaptchaTB);
            this.Controls.Add(this.CaptchaPB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CaptchaSolverForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Капча";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CaptchaSolverForm_FormClosed);
            this.Load += new System.EventHandler(this.CaptchaSolverForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CaptchaPB;
        private System.Windows.Forms.TextBox CaptchaTB;
        private System.Windows.Forms.Button ConfirmBt;
    }
}