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
        private int maksymalnaWaga;
        private Dictionary<int, decimal> listaWariantowWag = null;

        public WynikPanel()
        {
            InitializeComponent();
        }

        public WynikPanel(Dictionary<int, decimal> listaWariantowWag, int maksymalnaWaga)
        {
            InitializeComponent();
            this.maksymalnaWaga = maksymalnaWaga;
            this.listaWariantowWag = listaWariantowWag;
            setChartData();
        }

        private void setChartData()
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

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

            ChartArea area = new ChartArea("Wykres");
            wynikChart.ChartAreas.Add(area);

            foreach (KeyValuePair<int, decimal> wariant in listaWariantowWag)
            {
                Kryterium kryterium = KryteriumController.pobierzKryterium(wariant.Key, db, true);

                Series wykres = new Series(kryterium.Nazwa, maksymalnaWaga);
                wynikChart.Series.Add(wykres);
                wykres.ChartType = SeriesChartType.StackedBar;

                Legend legend = new Legend(kryterium.Nazwa);
                wykres.Legend = legend.Name;

                wykres.ChartArea = "Wykres";
                wynikChart.Series[kryterium.Nazwa].Points.AddXY(kryterium.Nazwa, Convert.ToDouble(wariant.Value));
            }

            wynikChart.Visible = true;
        }
    }
}
