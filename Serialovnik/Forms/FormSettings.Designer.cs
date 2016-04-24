namespace Serialovnik.Forms
{
    partial class FormSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.prms = new System.Windows.Forms.TextBox();
            this.browse = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.showPlayPopup = new System.Windows.Forms.CheckBox();
            this.timeout = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Přehrávač";
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Location = new System.Drawing.Point(75, 9);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(0, 15);
            this.path.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parametry";
            // 
            // prms
            // 
            this.prms.Location = new System.Drawing.Point(78, 31);
            this.prms.Name = "prms";
            this.prms.Size = new System.Drawing.Size(211, 20);
            this.prms.TabIndex = 3;
            this.prms.Text = "{FILE} --fullscreen vlc://quit";
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(295, 29);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 4;
            this.browse.Text = "Procházet";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(295, 174);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 5;
            this.ok.Text = "Uložit";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Doba zobrazení popupu (v ms)";
            // 
            // showPlayPopup
            // 
            this.showPlayPopup.AutoSize = true;
            this.showPlayPopup.Location = new System.Drawing.Point(15, 83);
            this.showPlayPopup.Name = "showPlayPopup";
            this.showPlayPopup.Size = new System.Drawing.Size(174, 19);
            this.showPlayPopup.TabIndex = 8;
            this.showPlayPopup.Text = "Zobrazit popup při spuštění";
            this.showPlayPopup.UseVisualStyleBackColor = true;
            // 
            // timeout
            // 
            this.timeout.Location = new System.Drawing.Point(193, 105);
            this.timeout.Name = "timeout";
            this.timeout.Size = new System.Drawing.Size(100, 20);
            this.timeout.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Je potřeba zadat {FILE}, které bude nahrazeno názvem souboru.";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 209);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timeout);
            this.Controls.Add(this.showPlayPopup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.prms);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.path);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(398, 250);
            this.MinimumSize = new System.Drawing.Size(398, 250);
            this.Name = "FormSettings";
            this.Text = "Nastavení";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox prms;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox showPlayPopup;
        private System.Windows.Forms.TextBox timeout;
        private System.Windows.Forms.Label label2;
    }
}