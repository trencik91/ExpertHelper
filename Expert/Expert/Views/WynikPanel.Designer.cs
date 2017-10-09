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
            this.wynikChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.wynikChart.ChartAreas.Add(chartArea1);
            this.wynikChart.Location = new System.Drawing.Point(0, 57);
            this.wynikChart.Name = "wynikChart";
            this.wynikChart.Size = new System.Drawing.Size(1026, 518);
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
