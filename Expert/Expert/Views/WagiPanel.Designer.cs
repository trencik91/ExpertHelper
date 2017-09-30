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
            this.liczbowoLabel = new System.Windows.Forms.Label();
            this.kolumnaTextBox = new System.Windows.Forms.TextBox();
            this.wierszTextBox = new System.Windows.Forms.TextBox();
            this.wartoscNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.graficznieTabPage = new System.Windows.Forms.TabPage();
            this.graficznieLabel = new System.Windows.Forms.Label();
            this.wartoscSliderTextBox = new System.Windows.Forms.TextBox();
            this.sliderTrackBar = new System.Windows.Forms.TrackBar();
            this.kolumnaSilderTextBox = new System.Windows.Forms.TextBox();
            this.wierszSliderTextBox = new System.Windows.Forms.TextBox();
            this.slownieTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.kolumnaSlownieTextBox = new System.Windows.Forms.TextBox();
            this.wierszSlownieTextBox = new System.Windows.Forms.TextBox();
            this.slownieLabel = new System.Windows.Forms.Label();
            this.slownieListBox = new System.Windows.Forms.ListBox();
            this.zatwierdzButton = new System.Windows.Forms.Button();
            this.obliczButton = new System.Windows.Forms.Button();
            this.zapiszButton = new System.Windows.Forms.Button();
            this.wagiButton = new System.Windows.Forms.Button();
            this.wynikButton = new System.Windows.Forms.Button();
            this.problemGroupBox.SuspendLayout();
            this.wariantyGroupBox.SuspendLayout();
            this.wagiGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wagiDataGridView)).BeginInit();
            this.wagiTabControl.SuspendLayout();
            this.liczbowoTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wartoscNumericUpDown)).BeginInit();
            this.graficznieTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTrackBar)).BeginInit();
            this.slownieTabPage.SuspendLayout();
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
            this.wagiDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.wagiDataGridView_CellFormatting);
            this.wagiDataGridView.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.wagiDataGridView_CellLeave);
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
            this.liczbowoTabPage.Controls.Add(this.liczbowoLabel);
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
            // liczbowoLabel
            // 
            this.liczbowoLabel.AutoSize = true;
            this.liczbowoLabel.Location = new System.Drawing.Point(6, 12);
            this.liczbowoLabel.Name = "liczbowoLabel";
            this.liczbowoLabel.Size = new System.Drawing.Size(177, 13);
            this.liczbowoLabel.TabIndex = 3;
            this.liczbowoLabel.Text = "Dokonaj oceny względem kryterium ";
            // 
            // kolumnaTextBox
            // 
            this.kolumnaTextBox.Enabled = false;
            this.kolumnaTextBox.Location = new System.Drawing.Point(279, 42);
            this.kolumnaTextBox.Name = "kolumnaTextBox";
            this.kolumnaTextBox.Size = new System.Drawing.Size(100, 20);
            this.kolumnaTextBox.TabIndex = 2;
            this.kolumnaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // wierszTextBox
            // 
            this.wierszTextBox.Enabled = false;
            this.wierszTextBox.Location = new System.Drawing.Point(9, 42);
            this.wierszTextBox.Name = "wierszTextBox";
            this.wierszTextBox.Size = new System.Drawing.Size(100, 20);
            this.wierszTextBox.TabIndex = 1;
            this.wierszTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // wartoscNumericUpDown
            // 
            this.wartoscNumericUpDown.DecimalPlaces = 2;
            this.wartoscNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.wartoscNumericUpDown.Location = new System.Drawing.Point(133, 42);
            this.wartoscNumericUpDown.Name = "wartoscNumericUpDown";
            this.wartoscNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.wartoscNumericUpDown.TabIndex = 0;
            this.wartoscNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.wartoscNumericUpDown.ValueChanged += new System.EventHandler(this.wartoscNumericUpDown_ValueChanged);
            // 
            // graficznieTabPage
            // 
            this.graficznieTabPage.Controls.Add(this.graficznieLabel);
            this.graficznieTabPage.Controls.Add(this.wartoscSliderTextBox);
            this.graficznieTabPage.Controls.Add(this.sliderTrackBar);
            this.graficznieTabPage.Controls.Add(this.kolumnaSilderTextBox);
            this.graficznieTabPage.Controls.Add(this.wierszSliderTextBox);
            this.graficznieTabPage.Location = new System.Drawing.Point(4, 22);
            this.graficznieTabPage.Name = "graficznieTabPage";
            this.graficznieTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.graficznieTabPage.Size = new System.Drawing.Size(632, 187);
            this.graficznieTabPage.TabIndex = 1;
            this.graficznieTabPage.Text = "Graficznie";
            this.graficznieTabPage.UseVisualStyleBackColor = true;
            // 
            // graficznieLabel
            // 
            this.graficznieLabel.AutoSize = true;
            this.graficznieLabel.Location = new System.Drawing.Point(6, 13);
            this.graficznieLabel.Name = "graficznieLabel";
            this.graficznieLabel.Size = new System.Drawing.Size(177, 13);
            this.graficznieLabel.TabIndex = 7;
            this.graficznieLabel.Text = "Dokonaj oceny względem kryterium ";
            // 
            // wartoscSliderTextBox
            // 
            this.wartoscSliderTextBox.Enabled = false;
            this.wartoscSliderTextBox.Location = new System.Drawing.Point(296, 118);
            this.wartoscSliderTextBox.Name = "wartoscSliderTextBox";
            this.wartoscSliderTextBox.Size = new System.Drawing.Size(37, 20);
            this.wartoscSliderTextBox.TabIndex = 6;
            this.wartoscSliderTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sliderTrackBar
            // 
            this.sliderTrackBar.Location = new System.Drawing.Point(171, 67);
            this.sliderTrackBar.Name = "sliderTrackBar";
            this.sliderTrackBar.Size = new System.Drawing.Size(284, 45);
            this.sliderTrackBar.TabIndex = 5;
            this.sliderTrackBar.Scroll += new System.EventHandler(this.sliderTrackBar_Scroll);
            // 
            // kolumnaSilderTextBox
            // 
            this.kolumnaSilderTextBox.Enabled = false;
            this.kolumnaSilderTextBox.Location = new System.Drawing.Point(484, 67);
            this.kolumnaSilderTextBox.Name = "kolumnaSilderTextBox";
            this.kolumnaSilderTextBox.Size = new System.Drawing.Size(121, 20);
            this.kolumnaSilderTextBox.TabIndex = 4;
            this.kolumnaSilderTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // wierszSliderTextBox
            // 
            this.wierszSliderTextBox.Enabled = false;
            this.wierszSliderTextBox.Location = new System.Drawing.Point(9, 67);
            this.wierszSliderTextBox.Name = "wierszSliderTextBox";
            this.wierszSliderTextBox.Size = new System.Drawing.Size(121, 20);
            this.wierszSliderTextBox.TabIndex = 3;
            this.wierszSliderTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // slownieTabPage
            // 
            this.slownieTabPage.Controls.Add(this.label1);
            this.slownieTabPage.Controls.Add(this.kolumnaSlownieTextBox);
            this.slownieTabPage.Controls.Add(this.wierszSlownieTextBox);
            this.slownieTabPage.Controls.Add(this.slownieLabel);
            this.slownieTabPage.Controls.Add(this.slownieListBox);
            this.slownieTabPage.Location = new System.Drawing.Point(4, 22);
            this.slownieTabPage.Name = "slownieTabPage";
            this.slownieTabPage.Size = new System.Drawing.Size(632, 187);
            this.slownieTabPage.TabIndex = 2;
            this.slownieTabPage.Text = "Słownie";
            this.slownieTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "w stosunku do:";
            // 
            // kolumnaSlownieTextBox
            // 
            this.kolumnaSlownieTextBox.Location = new System.Drawing.Point(260, 142);
            this.kolumnaSlownieTextBox.Name = "kolumnaSlownieTextBox";
            this.kolumnaSlownieTextBox.Size = new System.Drawing.Size(100, 20);
            this.kolumnaSlownieTextBox.TabIndex = 10;
            this.kolumnaSlownieTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // wierszSlownieTextBox
            // 
            this.wierszSlownieTextBox.Location = new System.Drawing.Point(260, 28);
            this.wierszSlownieTextBox.Name = "wierszSlownieTextBox";
            this.wierszSlownieTextBox.Size = new System.Drawing.Size(100, 20);
            this.wierszSlownieTextBox.TabIndex = 9;
            this.wierszSlownieTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // slownieLabel
            // 
            this.slownieLabel.AutoSize = true;
            this.slownieLabel.Location = new System.Drawing.Point(3, 12);
            this.slownieLabel.Name = "slownieLabel";
            this.slownieLabel.Size = new System.Drawing.Size(177, 13);
            this.slownieLabel.TabIndex = 8;
            this.slownieLabel.Text = "Dokonaj oceny względem kryterium ";
            // 
            // slownieListBox
            // 
            this.slownieListBox.FormattingEnabled = true;
            this.slownieListBox.Items.AddRange(new object[] {
            "Brak",
            "Słaba",
            "Umiarkowana",
            "Silna",
            "Bardzo silna"});
            this.slownieListBox.Location = new System.Drawing.Point(260, 54);
            this.slownieListBox.Name = "slownieListBox";
            this.slownieListBox.Size = new System.Drawing.Size(100, 82);
            this.slownieListBox.TabIndex = 0;
            this.slownieListBox.SelectedIndexChanged += new System.EventHandler(this.slownieListBox_SelectedIndexChanged);
            // 
            // zatwierdzButton
            // 
            this.zatwierdzButton.Location = new System.Drawing.Point(588, 341);
            this.zatwierdzButton.Name = "zatwierdzButton";
            this.zatwierdzButton.Size = new System.Drawing.Size(75, 23);
            this.zatwierdzButton.TabIndex = 4;
            this.zatwierdzButton.Text = "Zatwierdź";
            this.zatwierdzButton.UseVisualStyleBackColor = true;
            this.zatwierdzButton.Click += new System.EventHandler(this.zatwierdzButton_Click);
            // 
            // obliczButton
            // 
            this.obliczButton.Location = new System.Drawing.Point(669, 341);
            this.obliczButton.Name = "obliczButton";
            this.obliczButton.Size = new System.Drawing.Size(75, 23);
            this.obliczButton.TabIndex = 5;
            this.obliczButton.Text = "Oblicz wagi";
            this.obliczButton.UseVisualStyleBackColor = true;
            this.obliczButton.Click += new System.EventHandler(this.obliczButton_Click);
            // 
            // zapiszButton
            // 
            this.zapiszButton.Location = new System.Drawing.Point(750, 341);
            this.zapiszButton.Name = "zapiszButton";
            this.zapiszButton.Size = new System.Drawing.Size(75, 23);
            this.zapiszButton.TabIndex = 6;
            this.zapiszButton.Text = "Zapisz wagi";
            this.zapiszButton.UseVisualStyleBackColor = true;
            this.zapiszButton.Click += new System.EventHandler(this.zapiszButton_Click);
            // 
            // wagiButton
            // 
            this.wagiButton.Location = new System.Drawing.Point(355, 341);
            this.wagiButton.Name = "wagiButton";
            this.wagiButton.Size = new System.Drawing.Size(75, 23);
            this.wagiButton.TabIndex = 7;
            this.wagiButton.Text = "Wagi";
            this.wagiButton.UseVisualStyleBackColor = true;
            this.wagiButton.Click += new System.EventHandler(this.wagiButton_Click);
            // 
            // wynikButton
            // 
            this.wynikButton.Location = new System.Drawing.Point(920, 343);
            this.wynikButton.Name = "wynikButton";
            this.wynikButton.Size = new System.Drawing.Size(75, 23);
            this.wynikButton.TabIndex = 8;
            this.wynikButton.Text = "Wynik";
            this.wynikButton.UseVisualStyleBackColor = true;
            this.wynikButton.Click += new System.EventHandler(this.wynikButton_Click);
            // 
            // WagiPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wynikButton);
            this.Controls.Add(this.wagiButton);
            this.Controls.Add(this.zapiszButton);
            this.Controls.Add(this.obliczButton);
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
            this.graficznieTabPage.ResumeLayout(false);
            this.graficznieTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTrackBar)).EndInit();
            this.slownieTabPage.ResumeLayout(false);
            this.slownieTabPage.PerformLayout();
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
        private System.Windows.Forms.TrackBar sliderTrackBar;
        private System.Windows.Forms.TextBox kolumnaSilderTextBox;
        private System.Windows.Forms.TextBox wierszSliderTextBox;
        private System.Windows.Forms.TextBox wartoscSliderTextBox;
        private System.Windows.Forms.Label liczbowoLabel;
        private System.Windows.Forms.Label graficznieLabel;
        private System.Windows.Forms.ListBox slownieListBox;
        private System.Windows.Forms.Label slownieLabel;
        private System.Windows.Forms.TextBox kolumnaSlownieTextBox;
        private System.Windows.Forms.TextBox wierszSlownieTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button obliczButton;
        private System.Windows.Forms.Button zapiszButton;
        private System.Windows.Forms.Button wagiButton;
        private System.Windows.Forms.Button wynikButton;
    }
}
