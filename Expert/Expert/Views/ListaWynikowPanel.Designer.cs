namespace Expert
{
    partial class ListaWynikowPanel
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.panel1 = new System.Windows.Forms.Panel();
            this.wynikGroupBox = new System.Windows.Forms.GroupBox();
            this.wynikChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.problemGroupBox = new System.Windows.Forms.GroupBox();
            this.problemDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.wynikGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wynikChart)).BeginInit();
            this.problemGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.problemDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.wynikGroupBox);
            this.panel1.Controls.Add(this.problemGroupBox);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1026, 645);
            this.panel1.TabIndex = 0;
            // 
            // wynikGroupBox
            // 
            this.wynikGroupBox.Controls.Add(this.wynikChart);
            this.wynikGroupBox.Location = new System.Drawing.Point(372, 72);
            this.wynikGroupBox.Name = "wynikGroupBox";
            this.wynikGroupBox.Size = new System.Drawing.Size(622, 500);
            this.wynikGroupBox.TabIndex = 1;
            this.wynikGroupBox.TabStop = false;
            this.wynikGroupBox.Text = "Wyniki";
            // 
            // wynikChart
            // 
            chartArea1.Name = "ChartArea1";
            this.wynikChart.ChartAreas.Add(chartArea1);
            this.wynikChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wynikChart.Location = new System.Drawing.Point(3, 16);
            this.wynikChart.Name = "wynikChart";
            this.wynikChart.Size = new System.Drawing.Size(616, 481);
            this.wynikChart.TabIndex = 2;
            this.wynikChart.Text = "Wynik";
            // 
            // problemGroupBox
            // 
            this.problemGroupBox.Controls.Add(this.problemDataGridView);
            this.problemGroupBox.Location = new System.Drawing.Point(16, 72);
            this.problemGroupBox.Name = "problemGroupBox";
            this.problemGroupBox.Size = new System.Drawing.Size(327, 503);
            this.problemGroupBox.TabIndex = 0;
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
            // ListaWynikowPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ListaWynikowPanel";
            this.Size = new System.Drawing.Size(1026, 645);
            this.panel1.ResumeLayout(false);
            this.wynikGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wynikChart)).EndInit();
            this.problemGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.problemDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox problemGroupBox;
        private System.Windows.Forms.DataGridView problemDataGridView;
        private System.Windows.Forms.GroupBox wynikGroupBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart wynikChart;
    }
}
