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

        private void kryteriaListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            wyczyscKontrolki();
            dodajButton.Enabled = false;
            zapiszButton.Enabled = true;

            if (kryteriaListView.SelectedItems.Count > 0)
            {
                ustalBlokadeKontrolek(false);
            }
            else
            {
                ustalBlokadeKontrolek(true);
                if (kryteriaListView.SelectedItems.Count == 1)
                {
                    ListViewItem item = (ListViewItem)kryteriaListView.SelectedItems[0];
                    kryteriumID = int.Parse(item.Tag.ToString());
                    Kryterium kryterium = KryteriumController.pobierzKryterium(kryteriumID, db);

                    if (null != kryterium)
                    {
                        nazwaTextBox.Text = kryterium.Nazwa;
                        opisRichTextBox.AppendText(kryterium.Opis);
                    }
                }
            }
        }

        private void problemDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            kryteriaListView.Items.Clear();
            wariantyListBox.Items.Clear();
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
                    kryteriaListView.Items.Add(listaNodow.ToString());
                    List<Wariant> listaWariantow = WariantController.pobierzListeWariantow(kryteriumID);

                    if (listaWariantow.Count > 0)
                    {
                        listaWariantow.ForEach(w => wariantyListBox.Items.Add(w));
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
                wariantID = int.Parse(wariantyListBox.SelectedItem.ToString());
                Wariant wariant = WariantController.pobierzWariant(wariantID);

                if (null != wariant)
                {
                    nazwaTextBox.Text = wariant.Nazwa;
                    opisRichTextBox.AppendText(wariant.Opis);
                }
            }
        }

        private void pobierzCele()
        {
            DataTable dt = KryteriumController.pobierzTabeleCelow();

            problemDataGridView.DataSource = dt;

            problemDataGridView.AllowUserToAddRows = true;

            if (problemDataGridView.Columns.Count > 1)
            {
                problemDataGridView.Columns[0].Width = 41;
                problemDataGridView.Columns[3].Width = 210;
                problemDataGridView.Columns[1].Visible = false;
                problemDataGridView.Columns[2].Visible = false;
                problemDataGridView.Columns[4].Visible = false;
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

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wyczyscKontrolki();
            kryteriumRadioButton.Checked = true;
            ustalZaznaczenie(celRadioButton, wariantRadioButton);
            dodajButton.Enabled = true;
            zapiszButton.Enabled = false;

            if (kryteriaListView.SelectedItems.Count > 0)
            {
                if (liczbaPodkryteriow < PODKRYTERIA)
                {
                    ListViewItem item = kryteriaListView.SelectedItems[0];

                    nazwaTextBox.Focus();

                    kryteriumID = int.Parse(item.Tag.ToString());
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
    }
}
