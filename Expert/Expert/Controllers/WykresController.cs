using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Expert
{
    class WykresController
    {
        protected WykresController()
        {

        }

        public static void setChartData(Chart wynikChart, int idCelu, Dictionary<int, decimal> listaWariantowWag)
        {
            wynikChart.ChartAreas.Clear();
            wynikChart.Legends.Clear();
            wynikChart.Series.Clear();
            wynikChart.Titles.Clear();

            ExpertHelperDataContext db = new ExpertHelperDataContext();

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
