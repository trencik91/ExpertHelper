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
                try
                {
                    TreeNode item = problemTreeView.SelectedNode;
                    int id = int.Parse(item.Name.ToString());

                    stworzKolumnyDataGrid(GridViewController.stworzTabeleWag(idCelu, id));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd przy tworzeniu identyfikatora danych! " + ex.ToString(), "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                }
            }
        }
    }
}
