using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Expert
{
    public partial class WynikPanel : UserControl
    {
        private Dictionary<int, decimal> listaWariantowWag = null;

        public WynikPanel()
        {
            InitializeComponent();
        }

        public WynikPanel(Dictionary<int, decimal> listaWariantowWag)
        {
            this.listaWariantowWag = listaWariantowWag;
            setChartData();
        }

        private void setChartData()
        {
            wynikChart = new Chart();

            DataTable dt = new DataTable();
            dt.Columns.Add("Wariant");
            dt.Columns.Add("Waga");

            foreach (KeyValuePair<int, decimal> wariant in listaWariantowWag)
            {
                DataRow dr = dt.NewRow();
                dr["Wariant"] = wariant.Key;
                dr["Waga"] = wariant.Value;
                dt.Rows.Add(dr);
            }

            var enumerableTable = (dt as IListSource).GetList();

            for(int i = 0; i<dt.Rows.Count;i++)
            {
                wynikChart.Series.Add(dt.Rows[i]["Wariant"].ToString());
                wynikChart.Series["Wariant"].ChartType = SeriesChartType.Column;
                wynikChart.Series[i].Points.AddY(dt.Rows[i]["Waga"].ToString());
                wynikChart.Series["Series2"].ChartArea = "Wariant";
            }

            this.Controls.Add(wynikChart);

            wynikChart.Visible = true;
        }
    }
}
