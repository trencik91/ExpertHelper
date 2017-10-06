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
        private ButtonMenu buttonMenu;

        private int celID = 0;
        private int kryteriumID = 0;
        private int wariantID = 0;
        private int selectedIndex = 0;
        private int liczbaPodkryteriow = 0;

        private const int PODKRYTERIA = 15;

        public KryteriumPanel()
        {
            InitializeComponent();
            pobierzCele();
        }

        public KryteriumPanel(Form mainForm, ButtonMenu buttonMenu)
        {
            InitializeComponent();
            pobierzCele();
            this.mainForm = mainForm;
            celRadioButton.Checked = true;
            this.buttonMenu = buttonMenu;
            buttonMenu.setKryteriumPanel(this);
            setButtonEnable("Dalej", false);
            this.Visible = true;
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
                KryteriumController.dodajKryterium(nazwaTextBox.Text, opisRichTextBox.Text, 0, false, 0);
            }
            else if (kryteriumRadioButton.Checked)
            {
                KryteriumController.dodajKryterium(nazwaTextBox.Text, opisRichTextBox.Text, kryteriumID, false, celID);
                KryteriumController.dodajLiczbePodkryteriow(kryteriumID, false);

                liczbaPodkryteriow++;
            }
            else if (wariantRadioButton.Checked)
            {
                KryteriumController.dodajKryterium(nazwaTextBox.Text, opisRichTextBox.Text, kryteriumID, true, celID);
                DataTable tabelaWariantow = KryteriumController.pobierzTabeleWariantow(kryteriumID);

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
                KryteriumController.edytujKryterium(kryteriumID, nazwaTextBox.Text, opisRichTextBox.Text, false);
            }
            else if (wariantRadioButton.Checked)
            {
                KryteriumController.edytujKryterium(wariantID, nazwaTextBox.Text, opisRichTextBox.Text, true);
            }

            pobierzCele();
            problemDataGridView.Rows[selectedIndex].Selected = true;
            wyczyscKontrolki();
        }

        private void wagiButton_Click(object sender, EventArgs e)
        {
            if (wariantyListBox.Items.Count > 1)
            {
                if (liczbaPodkryteriow >= 2)
                {
                    Visible = false;
                    WagiPanel wagiPanel = new WagiPanel(mainForm, buttonMenu, celID);
                    mainForm.Controls.Add(wagiPanel);
                    wagiPanel.Visible = true;
                    buttonMenu.setAktualnyPanel(wagiPanel);
                }
                else
                {
                    MessageBox.Show("Musisz dodać przynajmniej 2 podkryteria!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Musisz dodać przynajmniej 2 warianty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void problemDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            kryteriaTreeView.Nodes.Clear();
            wariantyListBox.DataSource = null;
            wyczyscKontrolki();
            dodajButton.Enabled = false;
            zapiszButton.Enabled = true;
            celRadioButton.Checked = true;
            ustalZaznaczenie(wariantRadioButton, kryteriumRadioButton);
            setButtonEnable("Usuń", false);

            if (problemDataGridView.SelectedRows.Count == 1)
            {
                try
                {
                    DataGridViewRow dataRow = problemDataGridView.SelectedRows[0];

                    kryteriumID = int.Parse(dataRow.Cells[1].Value.ToString());
                    celID = kryteriumID;
                    selectedIndex = problemDataGridView.SelectedRows[0].Index;

                    TreeNode listaNodow = KryteriumController.pobierzDrzewo(kryteriumID);
                    kryteriaTreeView.Nodes.AddRange(new TreeNode[] { listaNodow });

                    DataTable tabelaWariantow = KryteriumController.pobierzTabeleWariantow(kryteriumID);

                    if (tabelaWariantow.Rows.Count > 0)
                    {
                        wariantyListBox.DataSource = tabelaWariantow;
                        wariantyListBox.ValueMember = "ID_Wariantu";
                        wariantyListBox.DisplayMember = "Nazwa";
                        wariantyListBox.ClearSelected();
                    }

                    nazwaTextBox.Text = dataRow.Cells[3].Value.ToString();
                    opisRichTextBox.Text = dataRow.Cells[4].Value.ToString();

                    ustalLiczbePodkryteriow();
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
                    Kryterium wariant = KryteriumController.pobierzKryterium(wariantID, true);

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

        private void usunKryteriumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usunKryterium();
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
                setButtonEnable("Usuń", false);
            }
            else
            {
                ustalBlokadeKontrolek(true);
                setButtonEnable("Usuń", true);
                TreeNode item = kryteriaTreeView.SelectedNode;
                kryteriumID = int.Parse(item.Name.ToString());
                Kryterium kryterium = KryteriumController.pobierzKryterium(kryteriumID, db, false);

                if (null != kryterium)
                {
                    nazwaTextBox.Text = kryterium.Nazwa;
                    opisRichTextBox.AppendText(kryterium.Opis);
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

        private void ustalBlokadeKontrolek(bool czyOdblokowane)
        {
            dodajToolStripMenuItem.Enabled = czyOdblokowane;
            usunKryteriumToolStripMenuItem.Enabled = czyOdblokowane;
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
            if (null != kryteriaTreeView.SelectedNode)
            {
                ExpertHelperDataContext db = new ExpertHelperDataContext();

                TreeNode item = kryteriaTreeView.SelectedNode;
                int id = int.Parse(item.Name.ToString());

                DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczone kryterium i wszystkie jego podkryteria?", "Usuń", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    List<int> listaPodkryteriow = KryteriumController.stworzListeDoUsuniecia(id, celID);

                    foreach (int idPodkryterium in listaPodkryteriow)
                    {
                        KryteriumController.usunKryterium(idPodkryterium, db);
                    }
                }
            }

            pobierzCele();
        }

        private void dodajCelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wyczyscKontrolki();
            dodajButton.Enabled = true;
            zapiszButton.Enabled = false;
            celRadioButton.Checked = true;
            ustalZaznaczenie(wariantRadioButton, kryteriumRadioButton);
            nazwaTextBox.Focus();
        }

        private void ustalLiczbePodkryteriow()
        {
            if (kryteriaTreeView.Nodes.Count > 0)
            {
                TreeNode root = kryteriaTreeView.Nodes[0];

                if (null != root)
                {
                    liczbaPodkryteriow = root.Nodes.Count;
                }
                else
                {
                    liczbaPodkryteriow = 0;
                }
            }
        }

        public Button getButton(String nazwa)
        {
            switch (nazwa)
            {
                case "Dodaj":
                    return dodajButton;
                case "Zapisz":
                    return zapiszButton;
                case "Wagi":
                    return wagiButton;
                default:
                    return null;
            }
        }

        public RadioButton getRadioButton(String nazwa)
        {
            switch (nazwa)
            {
                case "Cel":
                    return celRadioButton;
                case "Kryterium":
                    return kryteriumRadioButton;
                case "Wariant":
                    return wariantRadioButton;
                default:
                    return null;
            }
        }

        public TextBox getNazwaTextBox()
        {
            return nazwaTextBox;
        }

        public void setCelID(int value)
        {
            celID = value;
        }

        public void setKryteriumID(int value)
        {
            kryteriumID = value;
        }

        public int getKryteriumID()
        {
            return kryteriumID;
        }

        public int getCelID()
        {
            return celID;
        }

        public TreeNode getSelectedNode()
        {
            return kryteriaTreeView.SelectedNode;
        }

        public void setButtonEnable(String nazwa, bool enable)
        {
            Button usunButton = buttonMenu.getButton(nazwa);

            if (null != usunButton)
            {
                usunButton.Enabled = enable;
            }
        }
    }
}
