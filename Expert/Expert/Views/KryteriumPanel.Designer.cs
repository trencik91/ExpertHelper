﻿namespace Expert
{
    partial class KryteriumPanel
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
            this.components = new System.ComponentModel.Container();
            this.problemGroupBox = new System.Windows.Forms.GroupBox();
            this.problemDataGridView = new System.Windows.Forms.DataGridView();
            this.kryteriaGroupBox = new System.Windows.Forms.GroupBox();
            this.kryteriaListView = new System.Windows.Forms.ListView();
            this.wariantyGroupBox = new System.Windows.Forms.GroupBox();
            this.wariantyListBox = new System.Windows.Forms.ListBox();
            this.dodajGroupBox = new System.Windows.Forms.GroupBox();
            this.wagiButton = new System.Windows.Forms.Button();
            this.zapiszButton = new System.Windows.Forms.Button();
            this.dodajButton = new System.Windows.Forms.Button();
            this.opisRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nazwaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wariantRadioButton = new System.Windows.Forms.RadioButton();
            this.kryteriumRadioButton = new System.Windows.Forms.RadioButton();
            this.celRadioButton = new System.Windows.Forms.RadioButton();
            this.kryteriumContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dodajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usunKryteriumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.problemGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.problemDataGridView)).BeginInit();
            this.kryteriaGroupBox.SuspendLayout();
            this.wariantyGroupBox.SuspendLayout();
            this.dodajGroupBox.SuspendLayout();
            this.kryteriumContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // problemGroupBox
            // 
            this.problemGroupBox.Controls.Add(this.problemDataGridView);
            this.problemGroupBox.Location = new System.Drawing.Point(16, 58);
            this.problemGroupBox.Name = "problemGroupBox";
            this.problemGroupBox.Size = new System.Drawing.Size(354, 534);
            this.problemGroupBox.TabIndex = 0;
            this.problemGroupBox.TabStop = false;
            this.problemGroupBox.Text = "Problem";
            // 
            // problemDataGridView
            // 
            this.problemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.problemDataGridView.Location = new System.Drawing.Point(6, 19);
            this.problemDataGridView.Name = "problemDataGridView";
            this.problemDataGridView.Size = new System.Drawing.Size(342, 509);
            this.problemDataGridView.TabIndex = 0;
            this.problemDataGridView.SelectionChanged += new System.EventHandler(this.problemDataGridView_SelectionChanged);
            // 
            // kryteriaGroupBox
            // 
            this.kryteriaGroupBox.Controls.Add(this.kryteriaListView);
            this.kryteriaGroupBox.Location = new System.Drawing.Point(404, 58);
            this.kryteriaGroupBox.Name = "kryteriaGroupBox";
            this.kryteriaGroupBox.Size = new System.Drawing.Size(278, 270);
            this.kryteriaGroupBox.TabIndex = 1;
            this.kryteriaGroupBox.TabStop = false;
            this.kryteriaGroupBox.Text = "Kryteria";
            // 
            // kryteriaListView
            // 
            this.kryteriaListView.ContextMenuStrip = this.kryteriumContextMenuStrip;
            this.kryteriaListView.Location = new System.Drawing.Point(6, 19);
            this.kryteriaListView.Name = "kryteriaListView";
            this.kryteriaListView.Size = new System.Drawing.Size(266, 245);
            this.kryteriaListView.TabIndex = 0;
            this.kryteriaListView.UseCompatibleStateImageBehavior = false;
            this.kryteriaListView.SelectedIndexChanged += new System.EventHandler(this.kryteriaListView_SelectedIndexChanged);
            // 
            // wariantyGroupBox
            // 
            this.wariantyGroupBox.Controls.Add(this.wariantyListBox);
            this.wariantyGroupBox.Location = new System.Drawing.Point(404, 354);
            this.wariantyGroupBox.Name = "wariantyGroupBox";
            this.wariantyGroupBox.Size = new System.Drawing.Size(278, 232);
            this.wariantyGroupBox.TabIndex = 2;
            this.wariantyGroupBox.TabStop = false;
            this.wariantyGroupBox.Text = "Warianty";
            // 
            // wariantyListBox
            // 
            this.wariantyListBox.FormattingEnabled = true;
            this.wariantyListBox.Location = new System.Drawing.Point(6, 19);
            this.wariantyListBox.Name = "wariantyListBox";
            this.wariantyListBox.Size = new System.Drawing.Size(266, 199);
            this.wariantyListBox.TabIndex = 0;
            this.wariantyListBox.SelectedIndexChanged += new System.EventHandler(this.wariantyListBox_SelectedIndexChanged);
            // 
            // dodajGroupBox
            // 
            this.dodajGroupBox.Controls.Add(this.wagiButton);
            this.dodajGroupBox.Controls.Add(this.zapiszButton);
            this.dodajGroupBox.Controls.Add(this.dodajButton);
            this.dodajGroupBox.Controls.Add(this.opisRichTextBox);
            this.dodajGroupBox.Controls.Add(this.label2);
            this.dodajGroupBox.Controls.Add(this.nazwaTextBox);
            this.dodajGroupBox.Controls.Add(this.label1);
            this.dodajGroupBox.Controls.Add(this.wariantRadioButton);
            this.dodajGroupBox.Controls.Add(this.kryteriumRadioButton);
            this.dodajGroupBox.Controls.Add(this.celRadioButton);
            this.dodajGroupBox.Location = new System.Drawing.Point(717, 58);
            this.dodajGroupBox.Name = "dodajGroupBox";
            this.dodajGroupBox.Size = new System.Drawing.Size(294, 304);
            this.dodajGroupBox.TabIndex = 3;
            this.dodajGroupBox.TabStop = false;
            this.dodajGroupBox.Text = "Dodaj";
            // 
            // wagiButton
            // 
            this.wagiButton.Location = new System.Drawing.Point(9, 270);
            this.wagiButton.Name = "wagiButton";
            this.wagiButton.Size = new System.Drawing.Size(87, 23);
            this.wagiButton.TabIndex = 9;
            this.wagiButton.Text = "Ustal wagi";
            this.wagiButton.UseVisualStyleBackColor = true;
            this.wagiButton.Click += new System.EventHandler(this.wagiButton_Click);
            // 
            // zapiszButton
            // 
            this.zapiszButton.Location = new System.Drawing.Point(132, 270);
            this.zapiszButton.Name = "zapiszButton";
            this.zapiszButton.Size = new System.Drawing.Size(75, 23);
            this.zapiszButton.TabIndex = 8;
            this.zapiszButton.Text = "Zapisz";
            this.zapiszButton.UseVisualStyleBackColor = true;
            this.zapiszButton.Click += new System.EventHandler(this.zapiszButton_Click);
            // 
            // dodajButton
            // 
            this.dodajButton.Location = new System.Drawing.Point(213, 270);
            this.dodajButton.Name = "dodajButton";
            this.dodajButton.Size = new System.Drawing.Size(75, 23);
            this.dodajButton.TabIndex = 7;
            this.dodajButton.Text = "Dodaj";
            this.dodajButton.UseVisualStyleBackColor = true;
            this.dodajButton.Click += new System.EventHandler(this.dodajButton_Click);
            // 
            // opisRichTextBox
            // 
            this.opisRichTextBox.Location = new System.Drawing.Point(9, 113);
            this.opisRichTextBox.Name = "opisRichTextBox";
            this.opisRichTextBox.Size = new System.Drawing.Size(279, 151);
            this.opisRichTextBox.TabIndex = 6;
            this.opisRichTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Opis";
            // 
            // nazwaTextBox
            // 
            this.nazwaTextBox.Location = new System.Drawing.Point(9, 69);
            this.nazwaTextBox.Name = "nazwaTextBox";
            this.nazwaTextBox.Size = new System.Drawing.Size(279, 20);
            this.nazwaTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nazwa";
            // 
            // wariantRadioButton
            // 
            this.wariantRadioButton.AutoSize = true;
            this.wariantRadioButton.Location = new System.Drawing.Point(189, 19);
            this.wariantRadioButton.Name = "wariantRadioButton";
            this.wariantRadioButton.Size = new System.Drawing.Size(62, 17);
            this.wariantRadioButton.TabIndex = 2;
            this.wariantRadioButton.TabStop = true;
            this.wariantRadioButton.Text = "Wariant";
            this.wariantRadioButton.UseVisualStyleBackColor = true;
            this.wariantRadioButton.CheckedChanged += new System.EventHandler(this.wariantRadioButton_CheckedChanged);
            // 
            // kryteriumRadioButton
            // 
            this.kryteriumRadioButton.AutoSize = true;
            this.kryteriumRadioButton.Location = new System.Drawing.Point(86, 19);
            this.kryteriumRadioButton.Name = "kryteriumRadioButton";
            this.kryteriumRadioButton.Size = new System.Drawing.Size(68, 17);
            this.kryteriumRadioButton.TabIndex = 1;
            this.kryteriumRadioButton.TabStop = true;
            this.kryteriumRadioButton.Text = "Kryterium";
            this.kryteriumRadioButton.UseVisualStyleBackColor = true;
            this.kryteriumRadioButton.CheckedChanged += new System.EventHandler(this.kryteriumRadioButton_CheckedChanged);
            // 
            // celRadioButton
            // 
            this.celRadioButton.AutoSize = true;
            this.celRadioButton.Location = new System.Drawing.Point(6, 19);
            this.celRadioButton.Name = "celRadioButton";
            this.celRadioButton.Size = new System.Drawing.Size(40, 17);
            this.celRadioButton.TabIndex = 0;
            this.celRadioButton.TabStop = true;
            this.celRadioButton.Text = "Cel";
            this.celRadioButton.UseVisualStyleBackColor = true;
            this.celRadioButton.CheckedChanged += new System.EventHandler(this.celRadioButton_CheckedChanged);
            // 
            // kryteriumContextMenuStrip
            // 
            this.kryteriumContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajToolStripMenuItem,
            this.usunKryteriumToolStripMenuItem});
            this.kryteriumContextMenuStrip.Name = "kryteriumContextMenuStrip";
            this.kryteriumContextMenuStrip.Size = new System.Drawing.Size(160, 48);
            this.kryteriumContextMenuStrip.Text = "Dodaj kryterium";
            // 
            // dodajToolStripMenuItem
            // 
            this.dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
            this.dodajToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.dodajToolStripMenuItem.Text = "Dodaj kryterium";
            this.dodajToolStripMenuItem.Click += new System.EventHandler(this.dodajToolStripMenuItem_Click);
            // 
            // usunKryteriumToolStripMenuItem
            // 
            this.usunKryteriumToolStripMenuItem.Name = "usunKryteriumToolStripMenuItem";
            this.usunKryteriumToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.usunKryteriumToolStripMenuItem.Text = "Usuń";
            // 
            // KryteriumPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dodajGroupBox);
            this.Controls.Add(this.wariantyGroupBox);
            this.Controls.Add(this.kryteriaGroupBox);
            this.Controls.Add(this.problemGroupBox);
            this.Name = "KryteriumPanel";
            this.Size = new System.Drawing.Size(1026, 645);
            this.problemGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.problemDataGridView)).EndInit();
            this.kryteriaGroupBox.ResumeLayout(false);
            this.wariantyGroupBox.ResumeLayout(false);
            this.dodajGroupBox.ResumeLayout(false);
            this.dodajGroupBox.PerformLayout();
            this.kryteriumContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox problemGroupBox;
        private System.Windows.Forms.DataGridView problemDataGridView;
        private System.Windows.Forms.GroupBox kryteriaGroupBox;
        private System.Windows.Forms.ListView kryteriaListView;
        private System.Windows.Forms.GroupBox wariantyGroupBox;
        private System.Windows.Forms.ListBox wariantyListBox;
        private System.Windows.Forms.GroupBox dodajGroupBox;
        private System.Windows.Forms.RadioButton wariantRadioButton;
        private System.Windows.Forms.RadioButton kryteriumRadioButton;
        private System.Windows.Forms.RadioButton celRadioButton;
        private System.Windows.Forms.Button wagiButton;
        private System.Windows.Forms.Button zapiszButton;
        private System.Windows.Forms.Button dodajButton;
        private System.Windows.Forms.RichTextBox opisRichTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nazwaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip kryteriumContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usunKryteriumToolStripMenuItem;
    }
}
