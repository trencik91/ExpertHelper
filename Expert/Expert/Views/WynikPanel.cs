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
        private ButtonMenu buttonMenu;

        private int maksymalnaWaga;
        private int idCelu;

        private Dictionary<int, decimal> listaWariantowWag = null;

        public WynikPanel()
        {
            InitializeComponent();
        }

        public WynikPanel(Dictionary<int, decimal> listaWariantowWag, int idCelu, int maksymalnaWaga, ButtonMenu buttonMenu)
        {
            InitializeComponent();
            this.buttonMenu = buttonMenu;
            this.maksymalnaWaga = maksymalnaWaga;
            this.listaWariantowWag = listaWariantowWag;
            this.idCelu = idCelu;
            WykresController.setChartData(wynikChart, idCelu, listaWariantowWag);
        }

        private void zapiszButton_Click(object sender, EventArgs e)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            foreach (KeyValuePair<int, decimal> wariant in listaWariantowWag)
            {
                WynikCeluController.dodajWynikCelu(idCelu, wariant.Key, wariant.Value, db);
            }
        }
    }
}
