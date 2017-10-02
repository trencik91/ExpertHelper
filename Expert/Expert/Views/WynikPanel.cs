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
        private int idCelu;

        private Dictionary<int, decimal> listaWariantowWag = null;

        public WynikPanel()
        {
            InitializeComponent();
        }

        public WynikPanel(Dictionary<int, decimal> listaWariantowWag, int idCelu, int maksymalnaWaga)
        {
            InitializeComponent();
            this.maksymalnaWaga = maksymalnaWaga;
            this.listaWariantowWag = listaWariantowWag;
            this.idCelu = idCelu;
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

            Kryterium cel = KryteriumController.pobierzKryterium(idCelu, false);

            ChartArea area = new ChartArea("Ranking");
            area.AxisY.Interval = 0.1;
            area.AxisY.Maximum = 1;
            wynikChart.ChartAreas.Add(area);

            Legend legend = new Legend("Warianty");
            legend.LegendStyle = LegendStyle.Column;
            wynikChart.Legends.Add(legend);

            foreach (KeyValuePair<int, decimal> wariant in listaWariantowWag)
            {
                Kryterium kryterium = KryteriumController.pobierzKryterium(wariant.Key, db, true);

                Series wykres = new Series(kryterium.Nazwa, 1);
                wynikChart.Series.Add(wykres);
                wykres.ChartType = SeriesChartType.Column;
                wykres.ChartArea = "Ranking";

                wykres.Label = kryterium.Nazwa;

                wynikChart.Series[kryterium.Nazwa].Points.AddXY(kryterium.Nazwa, Math.Round(Convert.ToDouble(wariant.Value), 3));
                wynikChart.Series[kryterium.Nazwa].Points[0].AxisLabel = "Ranking końcowy";
                wynikChart.Series[kryterium.Nazwa].Label = wariant.Value.ToString();
            }

            Title tytul = new Title("Ranking końcowy dla celu: " + cel.Nazwa);
            Font font = new Font(tytul.Font.FontFamily, 20, FontStyle.Bold);
            tytul.Font = font;

            wynikChart.Titles.Add(tytul);

            wynikChart.Visible = true;
        }
    }
}
