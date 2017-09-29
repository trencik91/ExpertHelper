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

        private int idCelu = 0;

        private DataGridViewCell zaznaczonaKomorka = null;
        private DataGridViewCell poprzedniaZaznaczonaKomorka = null;

        private Dictionary<String, int> listaIdKryteriow = new Dictionary<String, int>();

        private bool czyZmieniono = false;

        private const int MAKSYMALNA_WAGA = 10;

        public WagiPanel()
        {
            InitializeComponent();
        }

        public WagiPanel(Form mainForm, int idCelu)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.idCelu = idCelu;
            problemTreeView.Nodes.Clear();
            wariantyListBox.Items.Clear();
            uzupelnijProblemWarianty();
            listaIdKryteriow = KryteriumController.pobierzListeIdKryteriow();
            wartoscNumericUpDown.Maximum = MAKSYMALNA_WAGA;
            sliderTrackBar.SetRange(0, MAKSYMALNA_WAGA * 100);
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
            TreeNode listaNodow = KryteriumController.pobierzDrzewo(idCelu);
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
                    int id = int.Parse(item.Name.ToString());

                    liczbowoLabel.Text = "Dokonaj oceny względem kryterium " + item.Text;
                    graficznieLabel.Text = "Dokonaj oceny względem kryterium " + item.Text;
                    slownieLabel.Text = "Dokonaj oceny względem kryterium " + item.Text;

                    stworzKolumnyDataGrid(GridViewController.stworzTabeleWag(idCelu, id, listaIdKryteriow));

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
    }
}
