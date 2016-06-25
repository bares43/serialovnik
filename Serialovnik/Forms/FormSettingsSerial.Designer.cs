namespace Serialovnik.Forms
{
    partial class FormSettingsSerial
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.browse = new System.Windows.Forms.Button();
            this.path = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Název";
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(310, 61);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 1;
            this.save.Text = "Uložit";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(81, 6);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(304, 20);
            this.name.TabIndex = 2;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(15, 37);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(34, 13);
            this.pathLabel.TabIndex = 3;
            this.pathLabel.Text = "Cesta";
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(310, 32);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 4;
            this.browse.Text = "Procházet";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Location = new System.Drawing.Point(81, 33);
            this.path.MaximumSize = new System.Drawing.Size(200, 0);
            this.path.MinimumSize = new System.Drawing.Size(200, 0);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(200, 13);
            this.path.TabIndex = 5;
            this.path.Text = "cesta";
            // 
            // FormSettingsSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 97);
            this.Controls.Add(this.path);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.name);
            this.Controls.Add(this.save);
            this.Controls.Add(this.nameLabel);
            this.MaximizeBox = false;
            this.Name = "FormSettingsSerial";
            this.Text = "Nastavení seriálu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Label path;
    }
}