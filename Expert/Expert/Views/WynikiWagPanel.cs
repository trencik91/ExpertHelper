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
    public partial class WynikiWagPanel : UserControl
    {
        private Form mainForm;
        private ButtonMenu buttonMenu;

        public WynikiWagPanel()
        {
            InitializeComponent();
        }

        public WynikiWagPanel(Form mainForm, ButtonMenu buttonMenu)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.buttonMenu = buttonMenu;
            mainForm.Controls.Add(buttonMenu);
            buttonMenu.Visible = true;
            pobierzCele();
        }

        private void pobierzCele()
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

        private void problemDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (problemDataGridView.SelectedRows.Count == 1)
            {
                try
                {
                    DataGridViewRow dataRow = problemDataGridView.SelectedRows[0];

                int idCelu = int.Parse(dataRow.Cells[1].Value.ToString());

                pobierzKryteriaDlaCelu(idCelu);
                pobierzWynikiDlaCelu(idCelu);
                }
                catch
                {
                    MessageBox.Show("Zaznacz wiersz z danymi!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pobierzKryteriaDlaCelu(int idCelu)
        {
            Dictionary<int, String> listaKryteriow = KryteriumController.pobierzListeNazwKryteriow(idCelu);

            List<Wynik> listaWynikow = new List<Wynik>();

            DataTable dt = stworzStruktureWag();

            foreach (KeyValuePair<int, String> kryterium in listaKryteriow)
            {
                listaWynikow.AddRange(WynikController.pobierzWynikiCelu(kryterium.Key));
            }

            int lp = 1;

            foreach (Wynik w in listaWynikow)
            {
                DataRow dr = dt.NewRow();
                dr["Lp"] = lp;
                dr["Kryterium"] = listaKryteriow[w.Kryterium1];
                dr["Względem"] = listaKryteriow[w.Kryterium2];
                dr["Waga"] = w.Waga;

                dt.Rows.Add(dr);

                lp++;
            }

            wagiDataGridView.DataSource = dt;
        }

        private void pobierzWynikiDlaCelu(int idCelu)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            Dictionary<int, String> listaKryteriow = KryteriumController.pobierzListeNazwKryteriow(idCelu);

            List<WynikCelu> listaWynikowCelu = WynikCeluController.pobierzListeWynikow(idCelu, db);

            if (listaWynikowCelu.Count > 0)
            {
                double max = listaWynikowCelu.Max(w => w.Waga);

                DataTable dt = stworzStruktureWynikow(listaWynikowCelu, listaKryteriow, idCelu);

                DataRow dr = dt.NewRow();

                dr[listaKryteriow[idCelu]] = "Wynik";

                foreach (WynikCelu w in listaWynikowCelu)
                {
                    dr[listaKryteriow[w.ID_Wariantu]] = w.Waga;
                }

                dt.Rows.Add(dr);

                wynikiDataGridView.DataSource = dt;

                foreach (DataGridViewRow row in wynikiDataGridView.Rows)
                {
                    foreach (DataGridViewColumn col in wynikiDataGridView.Columns)
                    {
                        object value = wynikiDataGridView.Rows[row.Index].Cells[col.Index].Value;

                        if (null != value && value.ToString() == max.ToString())
                        {
                            wynikiDataGridView.Rows[row.Index].Cells[col.Index].Style.BackColor = Color.LightGreen;
                        }
                    }
                }
            }
        }

        private DataTable stworzStruktureWag()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Lp");
            dt.Columns.Add("Kryterium");
            dt.Columns.Add("Względem");
            dt.Columns.Add("Waga");

            return dt;
        }

        private DataTable stworzStruktureWynikow(List<WynikCelu> listaWynikowCelu, Dictionary<int, String> listaKryteriow, int idCelu)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(listaKryteriow[idCelu]);

            foreach (WynikCelu w in listaWynikowCelu)
            {
                dt.Columns.Add(listaKryteriow[w.ID_Wariantu]);
            }

            return dt;
        }
    }
}
