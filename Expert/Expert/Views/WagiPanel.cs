using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Expert
{
    public partial class WagiPanel : UserControl
    {
        private Form mainForm;

        private ButtonMenu buttonMenu;

        private int idCelu = 0;
        private int idKryterium = 0;

        private DataGridViewCell zaznaczonaKomorka = null;
        private DataGridViewCell poprzedniaZaznaczonaKomorka = null;

        private Dictionary<String, int> listaIdKryteriow = new Dictionary<String, int>();
        private Dictionary<int, String> listaNazwKryteriow = new Dictionary<int, string>();

        private TreeNode listaNodow = null;

        private bool czyZmieniono = false;

        private const int MAKSYMALNA_WAGA = 10;

        public WagiPanel()
        {
            InitializeComponent();
        }

        public WagiPanel(Form mainForm, KryteriumPanel kryteriumPanel)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            idCelu = kryteriumPanel.getCelID();
            problemTreeView.Nodes.Clear();
            wariantyListBox.Items.Clear();
            listaNodow = KryteriumController.pobierzDrzewo(idCelu);
            uzupelnijProblemWarianty();
            listaIdKryteriow = KryteriumController.pobierzListeIdKryteriow(idCelu);
            listaNazwKryteriow = KryteriumController.pobierzListeNazwKryteriow(idCelu);
            wartoscNumericUpDown.Maximum = MAKSYMALNA_WAGA;
            sliderTrackBar.SetRange(0, MAKSYMALNA_WAGA * 100);
        }

        public WagiPanel(Form mainForm, ButtonMenu buttonMenu, int idCelu)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.idCelu = idCelu;
            this.buttonMenu = buttonMenu;
            problemTreeView.Nodes.Clear();
            wariantyListBox.Items.Clear();
            listaNodow = KryteriumController.pobierzDrzewo(idCelu);
            uzupelnijProblemWarianty();
            listaIdKryteriow = KryteriumController.pobierzListeIdKryteriow(idCelu);
            listaNazwKryteriow = KryteriumController.pobierzListeNazwKryteriow(idCelu);
            wartoscNumericUpDown.Maximum = MAKSYMALNA_WAGA;
            sliderTrackBar.SetRange(0, MAKSYMALNA_WAGA * 100);
            buttonMenu.setControlEnable(buttonMenu.getButton("Dodaj"), false);
            buttonMenu.setControlEnable(buttonMenu.getButton("Usuń"), false);
            buttonMenu.setControlEnable(buttonMenu.getButton("Dalej"), false);
        }

        private void zatwierdzButton_Click(object sender, EventArgs e)
        {
            List<Waga> listaWag = stworzWagi();

            if (listaWag.Count > 0)
            {
                zapiszWagi(listaWag);
            }
        }

        private void uzupelnijProblemWarianty()
        {
            problemTreeView.Nodes.AddRange(new TreeNode[] { listaNodow });

            DataTable tabelaWariantow = KryteriumController.pobierzTabeleWariantow(idCelu);

            if (tabelaWariantow.Rows.Count > 0)
            {
                wariantyListBox.DataSource = tabelaWariantow;
                wariantyListBox.ValueMember = "ID_Wariantu";
                wariantyListBox.DisplayMember = "Nazwa";
            }
        }

        private void problemTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (czyZmieniono)
            {
                DialogResult result = MessageBox.Show("Czy chcesz zapisać ustalone wagi?", "Zapisz", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    List<Waga> listaWag = stworzWagi();

                    zapiszWagi(listaWag);
                }
            }
        }

        private void problemTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            wagiDataGridView.ClearSelection();
            wartoscNumericUpDown.Value = 0;
            sliderTrackBar.Value = 0;

            poprzedniaZaznaczonaKomorka = null;
            zaznaczonaKomorka = null;

            if (null != problemTreeView.SelectedNode)
            {
                czyZmieniono = false;
                wagiDataGridView.DataSource = null;
                try
                {
                    TreeNode item = problemTreeView.SelectedNode;
                    idKryterium = int.Parse(item.Name.ToString());

                    liczbowoLabel.Text = "Dokonaj oceny względem kryterium " + item.Text;
                    graficznieLabel.Text = "Dokonaj oceny względem kryterium " + item.Text;
                    slownieLabel.Text = "Dokonaj oceny względem kryterium " + item.Text;

                    stworzKolumnyDataGrid(GridViewController.stworzTabeleWag(idCelu, idKryterium, listaIdKryteriow));

                    wagiTabControl.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd przy tworzeniu identyfikatora danych! " + ex.ToString(), "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                wagiTabControl.Visible = false;
            }
        }

        private void wagiDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            zaznaczKomorkeDataGridView();
        }

        private void wagiDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            zaznaczKomorkeDataGridView();
        }

        private void wagiDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ustalWartoscKontrolek();
        }

        private void wagiDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ustalWartoscKontrolek();
            czyZmieniono = true;
        }

        private void wartoscNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (null != zaznaczonaKomorka)
            {
                if (!zaznaczonaKomorka.ReadOnly)
                {
                    int wartosc = Convert.ToInt32(double.Parse(wartoscNumericUpDown.Value.ToString()));
                    sliderTrackBar.Value = wartosc * 100;
                    wartoscSliderTextBox.Text = wartoscNumericUpDown.Value.ToString();
                    czyZmieniono = true;
                    zaznaczonaKomorka.Value = wartoscNumericUpDown.Value;
                }
                else
                {
                    wartoscNumericUpDown.Enabled = false;
                }
            }
        }

        private void wagiDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = wagiDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            double wartoscKomorki = 0.0;

            bool czyLiczba = double.TryParse(cell.Value.ToString(), out wartoscKomorki);

            if (czyLiczba && !cell.ReadOnly)
            {
                cell.ToolTipText = "Wartość wagi może wynosić maksymalnie: " + MAKSYMALNA_WAGA;
            }
            else if (cell.ReadOnly)
            {
                cell.ToolTipText = "Wartości tej komórki nie można edytować";
            }
        }

        private void wagiDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            if (null != wagiDataGridView.Rows[rowIndex].Cells[columnIndex])
            {
                poprzedniaZaznaczonaKomorka = wagiDataGridView.Rows[rowIndex].Cells[columnIndex];
            }
            else
            {
                poprzedniaZaznaczonaKomorka = null;
            }
        }

        private void sliderTrackBar_Scroll(object sender, EventArgs e)
        {
            if (null != zaznaczonaKomorka)
            {
                if (!zaznaczonaKomorka.ReadOnly)
                {
                    double wartosc = sliderTrackBar.Value / 100.00;
                    wartoscNumericUpDown.Value = decimal.Parse(wartosc.ToString());
                    wartoscSliderTextBox.Text = wartosc.ToString();
                    zaznaczonaKomorka.Value = wartosc;
                    czyZmieniono = true;
                }
                else
                {
                    sliderTrackBar.Enabled = false;
                }
            }
        }

        private void slownieListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != zaznaczonaKomorka && !zaznaczonaKomorka.ReadOnly)
            {
                decimal wartosc = stworzWageListy();
                zaznaczonaKomorka.Value = wartosc;
                wartoscNumericUpDown.Value = wartosc;
                double wartoscDouble = Convert.ToDouble(wartosc) * 100;
                sliderTrackBar.Value = int.Parse(wartoscDouble.ToString());
            }
        }

        private void obliczButton_Click(object sender, EventArgs e)
        {
            DataTable wagi = ObliczanieWag.ustalMacierzWag((DataTable)wagiDataGridView.DataSource);

            wagiDataGridView.DataSource = wagi;
        }

        private void zapiszWagi(IEnumerable<Waga> listaWag)
        {
            WagaController.dodajListeWag(listaWag);
            czyZmieniono = false;
        }

        private void stworzKolumnyDataGrid(DataTable tabelaWag)
        {
            wagiDataGridView.DataSource = tabelaWag;
            wagiDataGridView.AllowUserToAddRows = false;

            foreach (DataGridViewRow dr in wagiDataGridView.Rows)
            {
                foreach (DataGridViewColumn dc in wagiDataGridView.Columns)
                {
                    if ((dr.Cells[0].Value.ToString() == dc.HeaderCell.Value.ToString() && tabelaWag.Rows.Count != tabelaWag.Columns.Count)
                        || dc.Index == 0)
                    {
                        dr.Cells[dc.Index].ReadOnly = true;
                    }

                    dc.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        private void zaznaczKomorkeDataGridView()
        {
            wartoscNumericUpDown.Enabled = true;
            sliderTrackBar.Enabled = true;

            if (null != poprzedniaZaznaczonaKomorka && wagiDataGridView.SelectedCells.Count > 0 && poprzedniaZaznaczonaKomorka.RowIndex >= 0 && poprzedniaZaznaczonaKomorka.ColumnIndex > 0)
            {
                double wartosc = 0.0;
                bool czyLiczba = double.TryParse(poprzedniaZaznaczonaKomorka.Value.ToString(), out wartosc);

                if (czyLiczba)
                {
                    poprzedniaZaznaczonaKomorka.Value = wartosc;
                }
            }

            try
            {
                if (wagiDataGridView.SelectedCells.Count > 0 && wagiDataGridView.SelectedCells[0].ColumnIndex > 0)
                {
                    zaznaczonaKomorka = wagiDataGridView.SelectedCells[0];

                    int rowIndex = zaznaczonaKomorka.RowIndex;
                    int columnIndex = zaznaczonaKomorka.ColumnIndex;

                    String wierszText = wagiDataGridView.Rows[rowIndex].Cells[0].Value.ToString();
                    String kolumnaText = wagiDataGridView.Columns[columnIndex].HeaderText;

                    wierszTextBox.Text = wierszText;
                    kolumnaTextBox.Text = kolumnaText;
                    wierszSliderTextBox.Text = wierszText;
                    kolumnaSilderTextBox.Text = kolumnaText;
                    wierszSlownieTextBox.Text = wierszText;
                    kolumnaSlownieTextBox.Text = kolumnaText;

                    ustalWartoscKontrolek();
                }
                else if (wagiDataGridView.SelectedCells.Count > 1)
                {
                    MessageBox.Show("Można edytować wartość tylko jednej komórki!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void ustalWartoscKontrolek()
        {
            wartoscNumericUpDown.Enabled = true;
            sliderTrackBar.Enabled = true;

            if (null != zaznaczonaKomorka)
            {
                double wartoscKomorki = 0.0;

                bool czyWartosc = double.TryParse(zaznaczonaKomorka.Value.ToString().Replace('.', ','), out wartoscKomorki);

                if (czyWartosc)
                {
                    try
                    {
                        wartoscNumericUpDown.Value = Convert.ToDecimal(wartoscKomorki);
                        sliderTrackBar.Value = Convert.ToInt32(wartoscKomorki * 100);
                        wartoscSliderTextBox.Text = wartoscKomorki.ToString();
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        wartoscNumericUpDown.Value = 0;
                        sliderTrackBar.Value = 0;
                        zaznaczonaKomorka.Value = 0;
                        wartoscSliderTextBox.Text = "0";

                        MessageBox.Show("Maksymalna wartość wagi wynosi " + wartoscNumericUpDown.Maximum + "\n ", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        Console.WriteLine(ex.StackTrace);
                    }
                }
                else
                {
                    MessageBox.Show("Wartość komórki musi być typu liczbowego!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private List<Waga> stworzWagi()
        {
            List<Waga> listaWag = new List<Waga>();

            for (int i = 0; i < wagiDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < wagiDataGridView.Columns.Count; j++)
                {
                    if (j > 0)
                    {
                        decimal value = decimal.Parse(wagiDataGridView.Rows[i].Cells[j].Value.ToString(), NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol);

                        double doubleValue = Convert.ToDouble(value);

                        int idKolumny = listaIdKryteriow[wagiDataGridView.Columns[j].HeaderCell.Value.ToString()];
                        int idWiersza = listaIdKryteriow[wagiDataGridView.Rows[i].Cells[0].Value.ToString()];
                        int idGlowne = listaIdKryteriow[wagiDataGridView.Columns[0].HeaderCell.Value.ToString()];

                        listaWag.Add(WagaController.stworzWage(idGlowne, idWiersza, idKolumny, doubleValue));
                    }
                }
            }

            return listaWag;
        }

        private decimal stworzWageListy()
        {
            switch (slownieListBox.SelectedItem.ToString())
            {
                case "Brak":
                    return 1;
                case "Słaba":
                    return 3;
                case "Umiarkowana":
                    return 5;
                case "Silna":
                    return 7;
                case "Bardzo silna":
                    return 9;
                default:
                    return 0;
            }
        }

        private void zapiszButton_Click(object sender, EventArgs e)
        {
            DataTable tabelaWynikow = (DataTable)wagiDataGridView.DataSource;

            List<Wynik> listaWynikow = new List<Wynik>();

            if (null != problemTreeView.SelectedNode)
            {
                try
                {
                    foreach (DataRow dr in tabelaWynikow.Rows)
                    {
                        int idWiersza = listaIdKryteriow[dr[0].ToString()];
                        int idKolumny = listaIdKryteriow[wagiDataGridView.Columns[0].HeaderCell.Value.ToString()];

                        decimal value = decimal.Parse(dr["Waga"].ToString(), NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol);

                        double doubleValue = Convert.ToDouble(value);

                        Wynik wynik = WynikController.stworzWynik(idCelu, idWiersza, idKolumny, doubleValue);

                        listaWynikow.Add(wynik);
                    }

                    WynikController.dodajListeWynikow(listaWynikow);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd przy tworzeniu identyfikatora danych! " + ex.ToString(), "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void wagiButton_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(listaNazwKryteriow[idKryterium]);
            dt.Columns.Add("Waga");

            List<Kryterium> listaPodkryteriowWariantow = KryteriumController.pobierzListePodkryteriow(idKryterium, idCelu);

            if (listaPodkryteriowWariantow.Count == 0)
            {
                listaPodkryteriowWariantow = KryteriumController.pobierzListeWariantow(idKryterium);
            }

            List<Wynik> listaWynikow = WynikController.pobierzWynikiKryterium(idCelu, idKryterium, listaPodkryteriowWariantow);

            if (listaWynikow.Count > 0)
            {
                listaWynikow.ForEach(w =>
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = listaNazwKryteriow[w.Kryterium1];
                    dr["Waga"] = w.Waga;
                    dt.Rows.Add(dr);
                });

                if (dt.Rows.Count > 0)
                {
                    wagiDataGridView.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("Nie obliczono wyników dla danego kryterium!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void wynikButton_Click(object sender, EventArgs e)
        {
            List<Wynik> listaWynikow = WynikController.pobierzWynikiCelu(idCelu);
            List<Kryterium> listaWariantow = KryteriumController.pobierzListeWariantow(idCelu);
            Dictionary<int, decimal> listaWagWariantow = new Dictionary<int, decimal>();

            foreach (Kryterium kryteriumWariant in listaWariantow)
            {
                decimal waga = 0;
                decimal wagaMnozona = 1;

                List<Wynik> listaWagWariantu = listaWynikow.Where(w => w.Kryterium1 == kryteriumWariant.ID).Select(w => new Wynik { ID = w.ID, KryteriumGlowne = w.KryteriumGlowne, Kryterium1 = w.Kryterium1, Kryterium2 = w.Kryterium2, Waga = w.Waga }).ToList();

                List<Wynik> listaPosortowana = listaWagWariantu.OrderByDescending(o => o.ID).ThenByDescending(o => o.Kryterium1).ToList();

                foreach (Wynik w in listaPosortowana.OrderByDescending(o => o.Kryterium2))
                {
                    wagaMnozona = Convert.ToDecimal(w.Waga);

                    int idKryterium2 = w.Kryterium2;

                    do
                    {
                        Wynik wynikOjca = pobierzWage(idKryterium2, listaWynikow);

                        if (null != wynikOjca)
                        {
                            wagaMnozona = wagaMnozona * Convert.ToDecimal(wynikOjca.Waga);
                            idKryterium2 = wynikOjca.Kryterium2;
                        }
                        else
                        {
                            break;
                        }
                    } while (idKryterium2 != idCelu);

                    waga = waga + wagaMnozona;
                }

                listaWagWariantow.Add(kryteriumWariant.ID, waga);
            }

            WynikPanel wynikPanel = new WynikPanel(listaWagWariantow, idCelu, MAKSYMALNA_WAGA);
            mainForm.Controls.Add(wynikPanel);
            wynikPanel.Visible = true;
            Visible = false;
        }

        private Wynik pobierzWage(int idKryterium2, IEnumerable<Wynik> listaWynikow)
        {
            return listaWynikow.Where(w => w.Kryterium1 == idKryterium2).Select(w => new Wynik() { ID = w.ID, KryteriumGlowne = w.KryteriumGlowne, Kryterium1 = w.Kryterium1, Kryterium2 = w.Kryterium2, Waga = w.Waga }).FirstOrDefault();
        }
    }
}
