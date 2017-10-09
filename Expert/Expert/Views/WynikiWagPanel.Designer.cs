namespace Expert
{
    partial class WynikiWagPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.wynikiGroupBox = new System.Windows.Forms.GroupBox();
            this.wynikiDataGridView = new System.Windows.Forms.DataGridView();
            this.wagiGroupBox = new System.Windows.Forms.GroupBox();
            this.wagiDataGridView = new System.Windows.Forms.DataGridView();
            this.problemGroupBox = new System.Windows.Forms.GroupBox();
            this.problemDataGridView = new System.Windows.Forms.DataGridView();
            this.opisLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.wynikiGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wynikiDataGridView)).BeginInit();
            this.wagiGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wagiDataGridView)).BeginInit();
            this.problemGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.problemDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.opisLabel);
            this.panel1.Controls.Add(this.wynikiGroupBox);
            this.panel1.Controls.Add(this.wagiGroupBox);
            this.panel1.Controls.Add(this.problemGroupBox);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1026, 645);
            this.panel1.TabIndex = 0;
            // 
            // wynikiGroupBox
            // 
            this.wynikiGroupBox.Controls.Add(this.wynikiDataGridView);
            this.wynikiGroupBox.Location = new System.Drawing.Point(350, 434);
            this.wynikiGroupBox.Name = "wynikiGroupBox";
            this.wynikiGroupBox.Size = new System.Drawing.Size(638, 138);
            this.wynikiGroupBox.TabIndex = 3;
            this.wynikiGroupBox.TabStop = false;
            this.wynikiGroupBox.Text = "Wyniki";
            // 
            // wynikiDataGridView
            // 
            this.wynikiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wynikiDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wynikiDataGridView.Location = new System.Drawing.Point(3, 16);
            this.wynikiDataGridView.Name = "wynikiDataGridView";
            this.wynikiDataGridView.Size = new System.Drawing.Size(632, 119);
            this.wynikiDataGridView.TabIndex = 0;
            // 
            // wagiGroupBox
            // 
            this.wagiGroupBox.Controls.Add(this.wagiDataGridView);
            this.wagiGroupBox.Location = new System.Drawing.Point(350, 72);
            this.wagiGroupBox.Name = "wagiGroupBox";
            this.wagiGroupBox.Size = new System.Drawing.Size(644, 356);
            this.wagiGroupBox.TabIndex = 2;
            this.wagiGroupBox.TabStop = false;
            this.wagiGroupBox.Text = "Wagi";
            // 
            // wagiDataGridView
            // 
            this.wagiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wagiDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wagiDataGridView.Location = new System.Drawing.Point(3, 16);
            this.wagiDataGridView.Name = "wagiDataGridView";
            this.wagiDataGridView.Size = new System.Drawing.Size(638, 337);
            this.wagiDataGridView.TabIndex = 0;
            // 
            // problemGroupBox
            // 
            this.problemGroupBox.Controls.Add(this.problemDataGridView);
            this.problemGroupBox.Location = new System.Drawing.Point(16, 72);
            this.problemGroupBox.Name = "problemGroupBox";
            this.problemGroupBox.Size = new System.Drawing.Size(327, 503);
            this.problemGroupBox.TabIndex = 1;
            this.problemGroupBox.TabStop = false;
            this.problemGroupBox.Text = "Problem";
            // 
            // problemDataGridView
            // 
            this.problemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.problemDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.problemDataGridView.Location = new System.Drawing.Point(3, 16);
            this.problemDataGridView.Name = "problemDataGridView";
            this.problemDataGridView.Size = new System.Drawing.Size(321, 484);
            this.problemDataGridView.TabIndex = 0;
            this.problemDataGridView.SelectionChanged += new System.EventHandler(this.problemDataGridView_SelectionChanged);
            // 
            // opisLabel
            // 
            this.opisLabel.AutoSize = true;
            this.opisLabel.Location = new System.Drawing.Point(728, 575);
            this.opisLabel.Name = "opisLabel";
            this.opisLabel.Size = new System.Drawing.Size(258, 13);
            this.opisLabel.TabIndex = 4;
            this.opisLabel.Text = "Kolorem ZIELONYM oznaczono wariant wygrywający";
            // 
            // WynikiWagPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "WynikiWagPanel";
            this.Size = new System.Drawing.Size(1026, 645);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.wynikiGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wynikiDataGridView)).EndInit();
            this.wagiGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wagiDataGridView)).EndInit();
            this.problemGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.problemDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox problemGroupBox;
        private System.Windows.Forms.DataGridView problemDataGridView;
        private System.Windows.Forms.GroupBox wagiGroupBox;
        private System.Windows.Forms.DataGridView wagiDataGridView;
        private System.Windows.Forms.GroupBox wynikiGroupBox;
        private System.Windows.Forms.DataGridView wynikiDataGridView;
        private System.Windows.Forms.Label opisLabel;
    }
}
