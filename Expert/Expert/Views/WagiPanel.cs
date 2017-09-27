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
            ustalWartoscNumeric();
        }

        private void wagiDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ustalWartoscNumeric();
            czyZmieniono = true;
        }

        private void wartoscNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (null != zaznaczonaKomorka)
            {
                if (!zaznaczonaKomorka.ReadOnly)
                {
                    zaznaczonaKomorka.Value = wartoscNumericUpDown.Value;
                    czyZmieniono = true;
                }
                else
                {
                    wartoscNumericUpDown.Enabled = false;
                }
            }
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

            if (null != poprzedniaZaznaczonaKomorka && wagiDataGridView.SelectedCells.Count > 0 && poprzedniaZaznaczonaKomorka.RowIndex >= 0 && poprzedniaZaznaczonaKomorka.ColumnIndex > 0)
            {
                double wartosc = 0.0;
                bool czyLiczba = double.TryParse(poprzedniaZaznaczonaKomorka.Value.ToString(), out wartosc);

                if (czyLiczba)
                {
                    poprzedniaZaznaczonaKomorka.Value = wartosc;
                }
            }

            //wartoscNumericUpDown.Value = 0;

            try
            {
                if (wagiDataGridView.SelectedCells.Count > 0 && wagiDataGridView.SelectedCells[0].ColumnIndex > 0)
                {
                    zaznaczonaKomorka = wagiDataGridView.SelectedCells[0];

                    int rowIndex = zaznaczonaKomorka.RowIndex;
                    int columnIndex = zaznaczonaKomorka.ColumnIndex;

                    wierszTextBox.Text = wagiDataGridView.Rows[rowIndex].Cells[0].Value.ToString();
                    kolumnaTextBox.Text = wagiDataGridView.Columns[columnIndex].HeaderText;

                    ustalWartoscNumeric();
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

        private void ustalWartoscNumeric()
        {
            wartoscNumericUpDown.Enabled = true;

            if (null != zaznaczonaKomorka)
            {
                int wartoscKomorki = 0;

                bool czyWartosc = int.TryParse(zaznaczonaKomorka.Value.ToString(), out wartoscKomorki);

                if (czyWartosc)
                {
                    try
                    {
                        wartoscNumericUpDown.Value = wartoscKomorki;
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        wartoscNumericUpDown.Value = 0;
                        zaznaczonaKomorka.Value = 0;
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
    }
}
