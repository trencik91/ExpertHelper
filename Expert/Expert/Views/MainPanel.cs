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

        public MainPanel(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void dodajCelButton_Click(object sender, EventArgs e)
        {
            Visible = false;
            buttonMenu = new ButtonMenu(mainForm);
            buttonMenu.setMainPanel(this);
            KryteriumPanel kryteriumPanel = new KryteriumPanel(mainForm, buttonMenu);
            mainForm.Controls.Add(kryteriumPanel);
            buttonMenu.setAktualnyPanel(kryteriumPanel);
            buttonMenu.Visible = true;
            kryteriumPanel.Visible = true;
        }

        private void zakonczButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz zakończyć pracę w programie?", "Zakończ pracę", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                mainForm.Close();
            }
        }
    }
}
