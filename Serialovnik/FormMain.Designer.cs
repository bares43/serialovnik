namespace Serialovnik
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.serials = new System.Windows.Forms.ListBox();
            this.random = new System.Windows.Forms.Button();
            this.goOn = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.repeat = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // serials
            // 
            this.serials.FormattingEnabled = true;
            this.serials.Location = new System.Drawing.Point(12, 12);
            this.serials.Name = "serials";
            this.serials.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.serials.Size = new System.Drawing.Size(179, 238);
            this.serials.TabIndex = 0;
            this.serials.SelectedIndexChanged += new System.EventHandler(this.serials_SelectedIndexChanged);
            this.serials.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.serials_MouseDoubleClick);
            // 
            // random
            // 
            this.random.Enabled = false;
            this.random.Location = new System.Drawing.Point(197, 12);
            this.random.Name = "random";
            this.random.Size = new System.Drawing.Size(75, 23);
            this.random.TabIndex = 1;
            this.random.Text = "Náhodně";
            this.random.UseVisualStyleBackColor = true;
            this.random.Click += new System.EventHandler(this.random_Click);
            // 
            // goOn
            // 
            this.goOn.Enabled = false;
            this.goOn.Location = new System.Drawing.Point(197, 41);
            this.goOn.Name = "goOn";
            this.goOn.Size = new System.Drawing.Size(75, 23);
            this.goOn.TabIndex = 2;
            this.goOn.Text = "Pokračovat";
            this.goOn.UseVisualStyleBackColor = true;
            this.goOn.Click += new System.EventHandler(this.goon_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(197, 140);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 3;
            this.add.Text = "Přidat";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(197, 169);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(75, 23);
            this.remove.TabIndex = 4;
            this.remove.Text = "Odebrat";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // settings
            // 
            this.settings.Location = new System.Drawing.Point(197, 198);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(75, 23);
            this.settings.TabIndex = 5;
            this.settings.Text = "Nastavení";
            this.settings.UseVisualStyleBackColor = true;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // repeat
            // 
            this.repeat.Enabled = false;
            this.repeat.Location = new System.Drawing.Point(197, 70);
            this.repeat.Name = "repeat";
            this.repeat.Size = new System.Drawing.Size(75, 23);
            this.repeat.TabIndex = 6;
            this.repeat.Text = "Zopakovat";
            this.repeat.UseVisualStyleBackColor = true;
            this.repeat.Click += new System.EventHandler(this.repeat_Click);
            // 
            // about
            // 
            this.about.Location = new System.Drawing.Point(197, 227);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(75, 23);
            this.about.TabIndex = 7;
            this.about.Text = "O aplikaci";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 261);
            this.Controls.Add(this.about);
            this.Controls.Add(this.repeat);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.add);
            this.Controls.Add(this.goOn);
            this.Controls.Add(this.random);
            this.Controls.Add(this.serials);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(295, 300);
            this.MinimumSize = new System.Drawing.Size(295, 300);
            this.Name = "FormMain";
            this.Text = "Seriálovník";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox serials;
        private System.Windows.Forms.Button random;
        private System.Windows.Forms.Button goOn;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.Button repeat;
        private System.Windows.Forms.Button about;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

