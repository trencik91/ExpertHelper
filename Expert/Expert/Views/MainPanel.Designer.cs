﻿namespace Expert
{
    partial class MainPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPanel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dodajCelButton = new System.Windows.Forms.Button();
            this.listaWynikowButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.zakonczButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.zakonczButton);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.listaWynikowButton);
            this.panel1.Controls.Add(this.dodajCelButton);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1026, 648);
            this.panel1.TabIndex = 0;
            // 
            // dodajCelButton
            // 
            this.dodajCelButton.Location = new System.Drawing.Point(270, 192);
            this.dodajCelButton.Name = "dodajCelButton";
            this.dodajCelButton.Size = new System.Drawing.Size(521, 64);
            this.dodajCelButton.TabIndex = 1;
            this.dodajCelButton.Text = "Dodaj Cel";
            this.dodajCelButton.UseVisualStyleBackColor = true;
            this.dodajCelButton.Click += new System.EventHandler(this.dodajCelButton_Click);
            // 
            // listaWynikowButton
            // 
            this.listaWynikowButton.Location = new System.Drawing.Point(270, 262);
            this.listaWynikowButton.Name = "listaWynikowButton";
            this.listaWynikowButton.Size = new System.Drawing.Size(521, 64);
            this.listaWynikowButton.TabIndex = 2;
            this.listaWynikowButton.Text = "Lista wyników";
            this.listaWynikowButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(270, 332);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(521, 64);
            this.button2.TabIndex = 3;
            this.button2.Text = "Dodaj Cel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // zakonczButton
            // 
            this.zakonczButton.Location = new System.Drawing.Point(270, 493);
            this.zakonczButton.Name = "zakonczButton";
            this.zakonczButton.Size = new System.Drawing.Size(521, 64);
            this.zakonczButton.TabIndex = 4;
            this.zakonczButton.Text = "Zakończ";
            this.zakonczButton.UseVisualStyleBackColor = true;
            this.zakonczButton.Click += new System.EventHandler(this.zakonczButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = global::Expert.Properties.Resources.nazwa;
            this.pictureBox2.Location = new System.Drawing.Point(406, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(385, 127);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Expert.Properties.Resources.logo;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(270, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 127);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(442, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Program wspomagający podejmowanie decyzji wielokryterialnych";
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "MainPanel";
            this.Size = new System.Drawing.Size(1026, 645);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button dodajCelButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button zakonczButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button listaWynikowButton;
        private System.Windows.Forms.Label label1;
    }
}
