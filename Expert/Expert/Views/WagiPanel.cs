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

        private Dictionary<String, int> listaIdKryteriow = new Dictionary<String, int>();

        private bool czyZmieniono = false;

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
            if (null != problemTreeView.SelectedNode)
            {
                czyZmieniono = false;
                wagiDataGridView.DataSource = null;
                //try
                //{
                TreeNode item = problemTreeView.SelectedNode;
                int id = int.Parse(item.Name.ToString());

                stworzKolumnyDataGrid(GridViewController.stworzTabeleWag(idCelu, id, listaIdKryteriow));

                wagiTabControl.Visible = true;
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Błąd przy tworzeniu identyfikatora danych! " + ex.ToString(), "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
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
            if (zaznaczonaKomorka.ReadOnly)
            {
                MessageBox.Show("Wartości tej komórki nie można edytować!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                zaznaczonaKomorka.Value = wartoscNumericUpDown.Value;
                czyZmieniono = true;
            }
        }

        private void zapiszWagi(IEnumerable<Waga> listaWag)
        {
            WagaController.dodajListeWag(listaWag);
        }

        private void stworzKolumnyDataGrid(DataTable tabelaWag)
        {
            wagiDataGridView.DataSource = tabelaWag;
            wagiDataGridView.AllowUserToAddRows = false;

            foreach (DataGridViewRow dr in wagiDataGridView.Rows)
            {
                foreach (DataGridViewColumn dc in wagiDataGridView.Columns)
                {
                    if (dr.Cells[0].Value.ToString() == dc.HeaderCell.Value.ToString() && tabelaWag.Rows.Count != tabelaWag.Columns.Count)
                    {
                        dr.Cells[dc.Index].Value = 1;
                        dr.Cells[dc.Index].ReadOnly = true;
                    }
                    else if (dc.Index > 0)
                    {
                        dr.Cells[dc.Index].Value = 0;
                    }
                    else
                    {
                        dr.Cells[dc.Index].ReadOnly = true;
                    }

                    dc.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        private void zaznaczKomorkeDataGridView()
        {
            try
            {
                if (wagiDataGridView.SelectedCells[0].ColumnIndex > 0)
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
            int wartoscKomorki = 0;

            bool czyWartosc = int.TryParse(zaznaczonaKomorka.Value.ToString(), out wartoscKomorki);

            if (czyWartosc)
            {
                wartoscNumericUpDown.Value = wartoscKomorki;
            }
            else
            {
                MessageBox.Show("Wartość komórki musi być typu liczbowego!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        String wartosc = wagiDataGridView.Rows[i].Cells[j].Value.ToString();
                        wartosc = wartosc.Replace(',', '.');
                        decimal value = decimal.Parse(wartosc, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol);
                        value = decimal.Round(value, 10);
                        int idKolumny = listaIdKryteriow[wagiDataGridView.Columns[j].HeaderCell.Value.ToString()];
                        int idWiersza = listaIdKryteriow[wagiDataGridView.Rows[i].Cells[0].Value.ToString()];

                        listaWag.Add(WagaController.stworzWage(idWiersza, idKolumny, value));
                    }
                }
            }

            return listaWag;
        }
    }
}
