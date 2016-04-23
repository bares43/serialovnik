namespace Serialovnik.Forms
{
    partial class FormPopup
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
            this.msgLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // msgLBL
            // 
            this.msgLBL.AutoSize = true;
            this.msgLBL.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.msgLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.msgLBL.Location = new System.Drawing.Point(0, 0);
            this.msgLBL.Margin = new System.Windows.Forms.Padding(0);
            this.msgLBL.Name = "msgLBL";
            this.msgLBL.Padding = new System.Windows.Forms.Padding(10);
            this.msgLBL.Size = new System.Drawing.Size(20, 45);
            this.msgLBL.TabIndex = 0;
            this.msgLBL.Click += new System.EventHandler(this.FormPopup_Click);
            // 
            // FormPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(518, 57);
            this.Controls.Add(this.msgLBL);
            this.Name = "FormPopup";
            this.Text = "Právě hraje";
            this.Click += new System.EventHandler(this.FormPopup_Click);
            this.DoubleClick += new System.EventHandler(this.FormPopup_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label msgLBL;
    }
}