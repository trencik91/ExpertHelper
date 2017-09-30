namespace Expert
{
    partial class WynikPanel
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.wagiPanel = new System.Windows.Forms.Panel();
            this.wynikChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.wagiPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wynikChart)).BeginInit();
            this.SuspendLayout();
            // 
            // wagiPanel
            // 
            this.wagiPanel.Controls.Add(this.wynikChart);
            this.wagiPanel.Location = new System.Drawing.Point(0, 3);
            this.wagiPanel.Name = "wagiPanel";
            this.wagiPanel.Size = new System.Drawing.Size(1026, 645);
            this.wagiPanel.TabIndex = 0;
            // 
            // wynikChart
            // 
            chartArea1.Name = "ChartArea1";
            this.wynikChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.wynikChart.Legends.Add(legend1);
            this.wynikChart.Location = new System.Drawing.Point(0, 3);
            this.wynikChart.Name = "wynikChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.wynikChart.Series.Add(series1);
            this.wynikChart.Size = new System.Drawing.Size(1026, 636);
            this.wynikChart.TabIndex = 0;
            this.wynikChart.Text = "Wynik";
            // 
            // WynikPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wagiPanel);
            this.Name = "WynikPanel";
            this.Size = new System.Drawing.Size(1026, 645);
            this.wagiPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wynikChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel wagiPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart wynikChart;
    }
}
