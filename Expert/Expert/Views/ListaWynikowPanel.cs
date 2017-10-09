using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expert
{
    public partial class ListaWynikowPanel : UserControl
    {
        private Form mainForm;
        private ButtonMenu buttonMenu;
        private Dictionary<int, decimal> listaWariantowWag = new Dictionary<int, decimal>();

        public ListaWynikowPanel()
        {
            InitializeComponent();
        }

        public ListaWynikowPanel(Form mainForm, ButtonMenu buttonMenu)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.buttonMenu = buttonMenu;
            mainForm.Controls.Add(buttonMenu);
            buttonMenu.Visible = true;
            pobierzCele();
        }

        private void problemDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            if (problemDataGridView.SelectedRows.Count == 1)
            {
                try
                {
                    DataGridViewRow dataRow = problemDataGridView.SelectedRows[0];

                    int idCelu = int.Parse(dataRow.Cells[1].Value.ToString());

                    listaWariantowWag = WynikCeluController.pobierzMapeWynikow(idCelu, db);

                    WykresController.setChartData(wynikChart, idCelu, listaWariantowWag);

                    if(listaWariantowWag.Count == 0)
                    {
                        MessageBox.Show("Brak wyników dla danego celu!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Zaznacz wiersz z danymi!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void pobierzCele()
        {
            DataTable dt = KryteriumController.pobierzTabeleCelow();

            problemDataGridView.DataSource = dt;

            problemDataGridView.AllowUserToAddRows = true;
            problemDataGridView.AllowUserToResizeColumns = false;

            if (problemDataGridView.Columns.Count > 1)
            {
                problemDataGridView.Columns[0].Width = 43;
                problemDataGridView.Columns[3].Width = 235;
                problemDataGridView.Columns[1].Visible = false;
                problemDataGridView.Columns[2].Visible = false;
                problemDataGridView.Columns[4].Visible = false;
                problemDataGridView.Columns[5].Visible = false;
                problemDataGridView.Columns[6].Visible = false;
                problemDataGridView.Columns[7].Visible = false;
            }
        }
    }
}
