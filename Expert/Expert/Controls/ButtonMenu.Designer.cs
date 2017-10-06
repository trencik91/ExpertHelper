namespace Expert
{
    partial class ButtonMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonMenuPanel = new System.Windows.Forms.Panel();
            this.dalejButton = new System.Windows.Forms.Button();
            this.wsteczButton = new System.Windows.Forms.Button();
            this.usunButton = new System.Windows.Forms.Button();
            this.dodajButton = new System.Windows.Forms.Button();
            this.buttonMenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonMenuPanel
            // 
            this.buttonMenuPanel.Controls.Add(this.dalejButton);
            this.buttonMenuPanel.Controls.Add(this.wsteczButton);
            this.buttonMenuPanel.Controls.Add(this.usunButton);
            this.buttonMenuPanel.Controls.Add(this.dodajButton);
            this.buttonMenuPanel.Location = new System.Drawing.Point(3, 3);
            this.buttonMenuPanel.Name = "buttonMenuPanel";
            this.buttonMenuPanel.Size = new System.Drawing.Size(963, 49);
            this.buttonMenuPanel.TabIndex = 5;
            // 
            // dalejButton
            // 
            this.dalejButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dalejButton.Image = global::Expert.Properties.Resources.right;
            this.dalejButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.dalejButton.Location = new System.Drawing.Point(347, 3);
            this.dalejButton.Name = "dalejButton";
            this.dalejButton.Size = new System.Drawing.Size(89, 42);
            this.dalejButton.TabIndex = 3;
            this.dalejButton.Text = "Dalej";
            this.dalejButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dalejButton.UseVisualStyleBackColor = true;
            // 
            // wsteczButton
            // 
            this.wsteczButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.wsteczButton.Image = global::Expert.Properties.Resources.left;
            this.wsteczButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.wsteczButton.Location = new System.Drawing.Point(232, 3);
            this.wsteczButton.Name = "wsteczButton";
            this.wsteczButton.Size = new System.Drawing.Size(109, 42);
            this.wsteczButton.TabIndex = 2;
            this.wsteczButton.Text = "Wstecz";
            this.wsteczButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.wsteczButton.UseVisualStyleBackColor = true;
            this.wsteczButton.Click += new System.EventHandler(this.wsteczButton_Click);
            // 
            // usunButton
            // 
            this.usunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.usunButton.Image = global::Expert.Properties.Resources.delete1;
            this.usunButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.usunButton.Location = new System.Drawing.Point(134, 3);
            this.usunButton.Name = "usunButton";
            this.usunButton.Size = new System.Drawing.Size(92, 42);
            this.usunButton.TabIndex = 1;
            this.usunButton.Text = "Usuń";
            this.usunButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.usunButton.UseVisualStyleBackColor = true;
            this.usunButton.Click += new System.EventHandler(this.usunButton_Click);
            // 
            // dodajButton
            // 
            this.dodajButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dodajButton.Image = global::Expert.Properties.Resources.plus;
            this.dodajButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.dodajButton.Location = new System.Drawing.Point(3, 3);
            this.dodajButton.Name = "dodajButton";
            this.dodajButton.Size = new System.Drawing.Size(125, 42);
            this.dodajButton.TabIndex = 0;
            this.dodajButton.Text = "Dodaj cel";
            this.dodajButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dodajButton.UseVisualStyleBackColor = true;
            this.dodajButton.Click += new System.EventHandler(this.dodajButton_Click);
            // 
            // ButtonMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonMenuPanel);
            this.Name = "ButtonMenu";
            this.Size = new System.Drawing.Size(968, 58);
            this.buttonMenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonMenuPanel;
        private System.Windows.Forms.Button usunButton;
        private System.Windows.Forms.Button dodajButton;
        private System.Windows.Forms.Button wsteczButton;
        private System.Windows.Forms.Button dalejButton;
    }
}
