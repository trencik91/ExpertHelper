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
    public partial class WagiPanel : UserControl
    {
        private Form mainForm;

        private int idCelu = 0;

        private DataGridViewCell zaznaczonaKomorka = null;

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
        }

        private void zatwierdzButton_Click(object sender, EventArgs e)
        {

        }

        private void uzupelnijProblemWarianty()
        {
            TreeNode listaNodow = KryteriumController.pobierzDrzewo(idCelu);
            problemTreeView.Nodes.AddRange(new TreeNode[] { listaNodow });

            DataTable tabelaWariantow = WariantController.pobierzTabeleWariantow(idCelu);

            if (tabelaWariantow.Rows.Count > 0)
            {
                wariantyListBox.DataSource = tabelaWariantow;
                wariantyListBox.ValueMember = "ID_Wariantu";
                wariantyListBox.DisplayMember = "Nazwa";
            }
        }

        private void problemTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (null != problemTreeView.SelectedNode)
            {
                wagiDataGridView.DataSource = null;
                try
                {
                    TreeNode item = problemTreeView.SelectedNode;
                    int id = int.Parse(item.Name.ToString());

                    stworzKolumnyDataGrid(GridViewController.stworzTabeleWag(idCelu, id));

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
            }
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
    }
}
