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
    public partial class KryteriumPanel : UserControl
    {
        private Form mainForm;

        private int kryteriumID = 0;
        private int wariantID = 0;
        private int selectedIndex = 0;
        private int liczbaPodkryteriow = 0;
        private int liczbaZaglebienDrzewa = 0;

        private const int PODKRYTERIA = 9;
        private const int ZAGLEBIENIA = 3;

        public KryteriumPanel()
        {
            InitializeComponent();
            pobierzCele();
        }

        public KryteriumPanel(Form mainForm)
        {
            InitializeComponent();
            pobierzCele();
            this.mainForm = mainForm;
            celRadioButton.Checked = true;
        }

        private void celRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (celRadioButton.Checked)
            {
                ustalZaznaczenie(kryteriumRadioButton, wariantRadioButton);
            }
        }

        private void kryteriumRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (kryteriumRadioButton.Checked)
            {
                ustalZaznaczenie(celRadioButton, wariantRadioButton);
            }
        }

        private void wariantRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (wariantRadioButton.Checked)
            {
                ustalZaznaczenie(celRadioButton, kryteriumRadioButton);
            }
        }

        private void dodajButton_Click(object sender, EventArgs e)
        {
            if (celRadioButton.Checked)
            {
                KryteriumController.dodajKryterium(nazwaTextBox.Text, opisRichTextBox.Text, 0);
            }
            else if (kryteriumRadioButton.Checked)
            {
                KryteriumController.dodajKryterium(nazwaTextBox.Text, opisRichTextBox.Text, kryteriumID);
                KryteriumController.dodajLiczbePodkryteriow(kryteriumID);

                liczbaPodkryteriow++;
            }
            else if (wariantRadioButton.Checked)
            {
                WariantController.dodajWariant(nazwaTextBox.Text, opisRichTextBox.Text, kryteriumID);
                DataTable tabelaWariantow = WariantController.pobierzTabeleWariantow(kryteriumID);

                if (tabelaWariantow.Rows.Count > 0)
                {
                    wariantyListBox.DataSource = tabelaWariantow;
                    wariantyListBox.ValueMember = "ID_Wariantu";
                    wariantyListBox.DisplayMember = "Nazwa";
                    wariantyListBox.ClearSelected();
                }
            }

            pobierzCele();
            problemDataGridView.Rows[selectedIndex].Selected = true;
            wyczyscKontrolki();
        }

        private void zapiszButton_Click(object sender, EventArgs e)
        {
            if (celRadioButton.Checked || kryteriumRadioButton.Checked)
            {
                KryteriumController.edytujKryterium(kryteriumID, nazwaTextBox.Text, opisRichTextBox.Text);
            }
            else if (wariantRadioButton.Checked)
            {
                WariantController.edytujWariant(wariantID, nazwaTextBox.Text, opisRichTextBox.Text);
            }

            pobierzCele();
            problemDataGridView.Rows[selectedIndex].Selected = true;
            wyczyscKontrolki();
        }

        private void wagiButton_Click(object sender, EventArgs e)
        {

        }

        private void problemDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            kryteriaTreeView.Nodes.Clear();
            wariantyListBox.DataSource = null;
            wyczyscKontrolki();
            dodajButton.Enabled = false;
            zapiszButton.Enabled = true;

            if (problemDataGridView.SelectedRows.Count == 1)
            {
                try
                {
                    DataGridViewRow dataRow = problemDataGridView.SelectedRows[0];

                    kryteriumID = int.Parse(dataRow.Cells[1].Value.ToString());
                    selectedIndex = problemDataGridView.SelectedRows[0].Index;

                    TreeNode listaNodow = KryteriumController.pobierzDrzewo(kryteriumID);
                    kryteriaTreeView.Nodes.AddRange(new TreeNode[] { listaNodow });

                    DataTable tabelaWariantow = WariantController.pobierzTabeleWariantow(kryteriumID);

                    if (tabelaWariantow.Rows.Count > 0)
                    {
                        wariantyListBox.DataSource = tabelaWariantow;
                        wariantyListBox.ValueMember = "ID_Wariantu";
                        wariantyListBox.DisplayMember = "Nazwa";

                    }

                    nazwaTextBox.Text = dataRow.Cells[3].Value.ToString();
                    opisRichTextBox.Text = dataRow.Cells[4].Value.ToString();

                    wagiButton.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Zaznacz wiersz z danymi!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void wariantyListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            wyczyscKontrolki();

            if (null != wariantyListBox.SelectedValue)
            {
                bool czyLiczba = int.TryParse(wariantyListBox.SelectedValue.ToString(), out wariantID);

                if (czyLiczba)
                {
                    Wariant wariant = WariantController.pobierzWariant(wariantID);

                    if (null != wariant)
                    {
                        nazwaTextBox.Text = wariant.Nazwa;
                        opisRichTextBox.AppendText(wariant.Opis);
                    }
                }
            }
        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wyczyscKontrolki();
            kryteriumRadioButton.Checked = true;
            ustalZaznaczenie(celRadioButton, wariantRadioButton);
            dodajButton.Enabled = true;
            zapiszButton.Enabled = false;

            if (kryteriaTreeView.SelectedNode != null)
            {
                if (liczbaPodkryteriow < PODKRYTERIA)
                {
                    TreeNode item = kryteriaTreeView.SelectedNode;

                    nazwaTextBox.Focus();

                    kryteriumID = int.Parse(item.Name.ToString());
                }
                else
                {
                    MessageBox.Show("Maksymalna liczba podkryteriów wynosi " + PODKRYTERIA + "!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Zaznacz wiersz z danymi!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dodajWariantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wyczyscKontrolki();
            dodajButton.Enabled = true;
            zapiszButton.Enabled = false;
            wariantRadioButton.Checked = true;
            ustalZaznaczenie(celRadioButton, kryteriumRadioButton);
            nazwaTextBox.Focus();
        }

        private void kryteriaTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            wyczyscKontrolki();
            dodajButton.Enabled = false;
            zapiszButton.Enabled = true;

            if (kryteriaTreeView.SelectedNode == null)
            {
                ustalBlokadeKontrolek(false);
            }
            else
            {
                ustalBlokadeKontrolek(true);
                TreeNode item = kryteriaTreeView.SelectedNode;
                kryteriumID = int.Parse(item.Name.ToString());
                Console.WriteLine("kryterium " + kryteriumID);
                Kryterium kryterium = KryteriumController.pobierzKryterium(kryteriumID, db);

                if (null != kryterium)
                {
                    nazwaTextBox.Text = kryterium.Nazwa;
                    opisRichTextBox.AppendText(kryterium.Opis);
                }
            }
        }

        private void pobierzCele()
        {
            DataTable dt = KryteriumController.pobierzTabeleCelow();

            problemDataGridView.DataSource = dt;

            problemDataGridView.AllowUserToAddRows = true;
            problemDataGridView.AllowUserToResizeColumns = false;

            if (problemDataGridView.Columns.Count > 1)
            {
                problemDataGridView.Columns[0].Width = 41;
                problemDataGridView.Columns[3].Width = 258;
                problemDataGridView.Columns[1].Visible = false;
                problemDataGridView.Columns[2].Visible = false;
                problemDataGridView.Columns[4].Visible = false;
                problemDataGridView.Columns[5].Visible = false;
            }
        }

        private void ustalBlokadeKontrolek(bool czyOdblokowane)
        {
            //dodajPodkryteriumMenuItem.IsEnabled = czyOdblokowane;
            //usunMenuItem.IsEnabled = czyOdblokowane;
            //ustalWagiButton.IsEnabled = czyOdblokowane;
        }

        private void wyczyscKontrolki()
        {
            nazwaTextBox.Clear();
            opisRichTextBox.Clear();
        }

        private void ustalZaznaczenie(RadioButton radioFalse, RadioButton radioFalseDwa)
        {
            radioFalse.Checked = false;
            radioFalseDwa.Checked = false;
        }

        private void usunKryterium()
        {
            //if (kryteriaListView.SelectedItems.Count > 0)
            //{
            //    int id = int.Parse(((TreeViewItem)kryteriumTreeView.SelectedItem).Uid);

            //    MessageBoxResult resutlt = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczone kryterium i wszystkie jego podkryteria?", "Usuń", MessageBoxButton.YesNo, MessageBoxImage.Question);

            //    if (resutlt == MessageBoxResult.Yes)
            //    {
            //        List<int> listaPodkryteriow = KryteriumController.stworzListeDoUsuniecia(id);

            //        foreach (int idPodkryterium in listaPodkryteriow)
            //        {
            //            KryteriumController.usunKryterium(idPodkryterium);
            //        }
            //    }
            //}
        }

        private void wariantyListBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
