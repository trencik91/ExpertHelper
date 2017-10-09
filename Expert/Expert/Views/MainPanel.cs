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
    public partial class MainPanel : UserControl
    {
        private Form mainForm;
        private ButtonMenu buttonMenu;

        public MainPanel()
        {
            InitializeComponent();
        }

        public MainPanel(Form mainForm, ButtonMenu buttonMenu)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.buttonMenu = buttonMenu;
            mainForm.Controls.Add(this);
        }

        private void dodajCelButton_Click(object sender, EventArgs e)
        {
            Visible = false;
            KryteriumPanel kryteriumPanel = new KryteriumPanel(mainForm, buttonMenu);
            mainForm.Controls.Add(kryteriumPanel);
            buttonMenu.setAktualnyPanel(kryteriumPanel);
            buttonMenu.setControlEnable(buttonMenu.getButton("Dodaj"), true);
            buttonMenu.setControlEnable(buttonMenu.getButton("Usuń"), false);
            buttonMenu.setControlEnable(buttonMenu.getButton("Wstecz"), true);
            buttonMenu.setControlEnable(buttonMenu.getButton("Dalej"), false);
            kryteriumPanel.Visible = true;
            buttonMenu.Visible = true;
        }

        private void zakonczButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz zakończyć pracę w programie?", "Zakończ pracę", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                mainForm.Close();
            }
        }

        private void listaWynikowButton_Click(object sender, EventArgs e)
        {
            Visible = false;
            ListaWynikowPanel listaWynikow = new ListaWynikowPanel(mainForm, buttonMenu);
            mainForm.Controls.Add(listaWynikow);
            buttonMenu.setListaWynikowPanel(listaWynikow);
            buttonMenu.setAktualnyPanel(listaWynikow);
            buttonMenu.setControlEnable(buttonMenu.getButton("Dodaj"), false);
            buttonMenu.setControlEnable(buttonMenu.getButton("Usuń"), false);
            buttonMenu.setControlEnable(buttonMenu.getButton("Wstecz"), true);
            buttonMenu.setControlEnable(buttonMenu.getButton("Dalej"), false);
            listaWynikow.Visible = true;
            buttonMenu.Visible = true;
        }

        private void listaWynikowWagButton_Click(object sender, EventArgs e)
        {
            Visible = false;
            WynikiWagPanel wynikiWagPanel = new WynikiWagPanel(mainForm, buttonMenu);
            mainForm.Controls.Add(wynikiWagPanel);
            buttonMenu.setWynikiWagPanel(wynikiWagPanel);
            buttonMenu.setAktualnyPanel(wynikiWagPanel);
            buttonMenu.setControlEnable(buttonMenu.getButton("Dodaj"), false);
            buttonMenu.setControlEnable(buttonMenu.getButton("Usuń"), false);
            buttonMenu.setControlEnable(buttonMenu.getButton("Wstecz"), true);
            buttonMenu.setControlEnable(buttonMenu.getButton("Dalej"), false);
            wynikiWagPanel.Visible = true;
            buttonMenu.Visible = true;
        }
    }
}
