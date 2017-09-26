namespace Expert
{
    partial class WagiPanel
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
            this.problemGroupBox = new System.Windows.Forms.GroupBox();
            this.problemTreeView = new System.Windows.Forms.TreeView();
            this.wariantyGroupBox = new System.Windows.Forms.GroupBox();
            this.wariantyListBox = new System.Windows.Forms.ListBox();
            this.wagiGroupBox = new System.Windows.Forms.GroupBox();
            this.wagiDataGridView = new System.Windows.Forms.DataGridView();
            this.wagiTabControl = new System.Windows.Forms.TabControl();
            this.liczbowoTabPage = new System.Windows.Forms.TabPage();
            this.kolumnaTextBox = new System.Windows.Forms.TextBox();
            this.wierszTextBox = new System.Windows.Forms.TextBox();
            this.wartoscNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.graficznieTabPage = new System.Windows.Forms.TabPage();
            this.slownieTabPage = new System.Windows.Forms.TabPage();
            this.zatwierdzButton = new System.Windows.Forms.Button();
            this.problemGroupBox.SuspendLayout();
            this.wariantyGroupBox.SuspendLayout();
            this.wagiGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wagiDataGridView)).BeginInit();
            this.wagiTabControl.SuspendLayout();
            this.liczbowoTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wartoscNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // problemGroupBox
            // 
            this.problemGroupBox.Controls.Add(this.problemTreeView);
            this.problemGroupBox.Location = new System.Drawing.Point(3, 42);
            this.problemGroupBox.Name = "problemGroupBox";
            this.problemGroupBox.Size = new System.Drawing.Size(280, 296);
            this.problemGroupBox.TabIndex = 0;
            this.problemGroupBox.TabStop = false;
            this.problemGroupBox.Text = "Problem";
            // 
            // problemTreeView
            // 
            this.problemTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.problemTreeView.Location = new System.Drawing.Point(3, 16);
            this.problemTreeView.Name = "problemTreeView";
            this.problemTreeView.Size = new System.Drawing.Size(274, 277);
            this.problemTreeView.TabIndex = 0;
            this.problemTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.problemTreeView_BeforeSelect);
            this.problemTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.problemTreeView_AfterSelect);
            // 
            // wariantyGroupBox
            // 
            this.wariantyGroupBox.Controls.Add(this.wariantyListBox);
            this.wariantyGroupBox.Location = new System.Drawing.Point(9, 372);
            this.wariantyGroupBox.Name = "wariantyGroupBox";
            this.wariantyGroupBox.Size = new System.Drawing.Size(274, 213);
            this.wariantyGroupBox.TabIndex = 1;
            this.wariantyGroupBox.TabStop = false;
            this.wariantyGroupBox.Text = "Warianty";
            // 
            // wariantyListBox
            // 
            this.wariantyListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wariantyListBox.Enabled = false;
            this.wariantyListBox.FormattingEnabled = true;
            this.wariantyListBox.Location = new System.Drawing.Point(3, 16);
            this.wariantyListBox.Name = "wariantyListBox";
            this.wariantyListBox.Size = new System.Drawing.Size(268, 194);
            this.wariantyListBox.TabIndex = 0;
            // 
            // wagiGroupBox
            // 
            this.wagiGroupBox.Controls.Add(this.wagiDataGridView);
            this.wagiGroupBox.Location = new System.Drawing.Point(355, 42);
            this.wagiGroupBox.Name = "wagiGroupBox";
            this.wagiGroupBox.Size = new System.Drawing.Size(640, 296);
            this.wagiGroupBox.TabIndex = 2;
            this.wagiGroupBox.TabStop = false;
            this.wagiGroupBox.Text = "Wagi";
            // 
            // wagiDataGridView
            // 
            this.wagiDataGridView.AllowUserToAddRows = false;
            this.wagiDataGridView.AllowUserToDeleteRows = false;
            this.wagiDataGridView.AllowUserToResizeColumns = false;
            this.wagiDataGridView.AllowUserToResizeRows = false;
            this.wagiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wagiDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wagiDataGridView.Location = new System.Drawing.Point(3, 16);
            this.wagiDataGridView.Name = "wagiDataGridView";
            this.wagiDataGridView.Size = new System.Drawing.Size(634, 277);
            this.wagiDataGridView.TabIndex = 0;
            this.wagiDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.wagiDataGridView_CellBeginEdit);
            this.wagiDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.wagiDataGridView_CellEndEdit);
            this.wagiDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.wagiDataGridView_CellMouseClick);
            this.wagiDataGridView.SelectionChanged += new System.EventHandler(this.wagiDataGridView_SelectionChanged);
            // 
            // wagiTabControl
            // 
            this.wagiTabControl.Controls.Add(this.liczbowoTabPage);
            this.wagiTabControl.Controls.Add(this.graficznieTabPage);
            this.wagiTabControl.Controls.Add(this.slownieTabPage);
            this.wagiTabControl.Location = new System.Drawing.Point(355, 372);
            this.wagiTabControl.Name = "wagiTabControl";
            this.wagiTabControl.SelectedIndex = 0;
            this.wagiTabControl.Size = new System.Drawing.Size(640, 213);
            this.wagiTabControl.TabIndex = 3;
            this.wagiTabControl.Visible = false;
            // 
            // liczbowoTabPage
            // 
            this.liczbowoTabPage.Controls.Add(this.kolumnaTextBox);
            this.liczbowoTabPage.Controls.Add(this.wierszTextBox);
            this.liczbowoTabPage.Controls.Add(this.wartoscNumericUpDown);
            this.liczbowoTabPage.Location = new System.Drawing.Point(4, 22);
            this.liczbowoTabPage.Name = "liczbowoTabPage";
            this.liczbowoTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.liczbowoTabPage.Size = new System.Drawing.Size(632, 187);
            this.liczbowoTabPage.TabIndex = 0;
            this.liczbowoTabPage.Text = "Liczbowo";
            this.liczbowoTabPage.UseVisualStyleBackColor = true;
            // 
            // kolumnaTextBox
            // 
            this.kolumnaTextBox.Enabled = false;
            this.kolumnaTextBox.Location = new System.Drawing.Point(279, 42);
            this.kolumnaTextBox.Name = "kolumnaTextBox";
            this.kolumnaTextBox.Size = new System.Drawing.Size(100, 20);
            this.kolumnaTextBox.TabIndex = 2;
            // 
            // wierszTextBox
            // 
            this.wierszTextBox.Enabled = false;
            this.wierszTextBox.Location = new System.Drawing.Point(18, 42);
            this.wierszTextBox.Name = "wierszTextBox";
            this.wierszTextBox.Size = new System.Drawing.Size(100, 20);
            this.wierszTextBox.TabIndex = 1;
            // 
            // wartoscNumericUpDown
            // 
            this.wartoscNumericUpDown.Location = new System.Drawing.Point(136, 42);
            this.wartoscNumericUpDown.Name = "wartoscNumericUpDown";
            this.wartoscNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.wartoscNumericUpDown.TabIndex = 0;
            this.wartoscNumericUpDown.ValueChanged += new System.EventHandler(this.wartoscNumericUpDown_ValueChanged);
            // 
            // graficznieTabPage
            // 
            this.graficznieTabPage.Location = new System.Drawing.Point(4, 22);
            this.graficznieTabPage.Name = "graficznieTabPage";
            this.graficznieTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.graficznieTabPage.Size = new System.Drawing.Size(632, 187);
            this.graficznieTabPage.TabIndex = 1;
            this.graficznieTabPage.Text = "Graficznie";
            this.graficznieTabPage.UseVisualStyleBackColor = true;
            // 
            // slownieTabPage
            // 
            this.slownieTabPage.Location = new System.Drawing.Point(4, 22);
            this.slownieTabPage.Name = "slownieTabPage";
            this.slownieTabPage.Size = new System.Drawing.Size(632, 187);
            this.slownieTabPage.TabIndex = 2;
            this.slownieTabPage.Text = "Słownie";
            this.slownieTabPage.UseVisualStyleBackColor = true;
            // 
            // zatwierdzButton
            // 
            this.zatwierdzButton.Location = new System.Drawing.Point(920, 341);
            this.zatwierdzButton.Name = "zatwierdzButton";
            this.zatwierdzButton.Size = new System.Drawing.Size(75, 23);
            this.zatwierdzButton.TabIndex = 4;
            this.zatwierdzButton.Text = "Zatwierdź";
            this.zatwierdzButton.UseVisualStyleBackColor = true;
            this.zatwierdzButton.Click += new System.EventHandler(this.zatwierdzButton_Click);
            // 
            // WagiPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zatwierdzButton);
            this.Controls.Add(this.wagiTabControl);
            this.Controls.Add(this.wagiGroupBox);
            this.Controls.Add(this.wariantyGroupBox);
            this.Controls.Add(this.problemGroupBox);
            this.Name = "WagiPanel";
            this.Size = new System.Drawing.Size(1026, 645);
            this.problemGroupBox.ResumeLayout(false);
            this.wariantyGroupBox.ResumeLayout(false);
            this.wagiGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wagiDataGridView)).EndInit();
            this.wagiTabControl.ResumeLayout(false);
            this.liczbowoTabPage.ResumeLayout(false);
            this.liczbowoTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wartoscNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox problemGroupBox;
        private System.Windows.Forms.TreeView problemTreeView;
        private System.Windows.Forms.GroupBox wariantyGroupBox;
        private System.Windows.Forms.ListBox wariantyListBox;
        private System.Windows.Forms.GroupBox wagiGroupBox;
        private System.Windows.Forms.DataGridView wagiDataGridView;
        private System.Windows.Forms.TabControl wagiTabControl;
        private System.Windows.Forms.TabPage liczbowoTabPage;
        private System.Windows.Forms.TabPage graficznieTabPage;
        private System.Windows.Forms.TabPage slownieTabPage;
        private System.Windows.Forms.Button zatwierdzButton;
        private System.Windows.Forms.TextBox kolumnaTextBox;
        private System.Windows.Forms.TextBox wierszTextBox;
        private System.Windows.Forms.NumericUpDown wartoscNumericUpDown;
    }
}
