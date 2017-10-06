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
    public partial class ButtonMenu : UserControl
    {
        private Form mainForm;
        private KryteriumPanel kryteriumPanel;
        private WagiPanel wagiPanel;
        private MainPanel mainPanel;

        private object aktualnyPanel;

        public ButtonMenu()
        {
            InitializeComponent();
        }

        public ButtonMenu(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            mainForm.Controls.Add(buttonMenuPanel);
            buttonMenuPanel.Location = new Point(19, 4);
            usunButton.Enabled = false;
        }

        public Panel getPanel()
        {
            return buttonMenuPanel;
        }

        private void dodajButton_Click(object sender, EventArgs e)
        {
            setRadioButtonChecked(kryteriumPanel.getRadioButton("Cel"), true);

            setTextBoxTextFocus(kryteriumPanel.getNazwaTextBox());

            setControlEnable(kryteriumPanel.getButton("Dodaj"), true);
            setControlEnable(kryteriumPanel.getButton("Zapisz"), false);

            kryteriumPanel.setCelID(0);
            kryteriumPanel.setKryteriumID(0);
        }

        private void usunButton_Click(object sender, EventArgs e)
        {
            ExpertHelperDataContext db = new ExpertHelperDataContext();

            TreeNode selectedNode = kryteriumPanel.getSelectedNode();
            int celID = kryteriumPanel.getCelID();

            if (null != selectedNode)
            {
                int kryteriumID = int.Parse(selectedNode.Name.ToString());

                DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczone kryterium i wszystkie jego podkryteria?", "Usuń", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    List<int> listaPodkryteriow = KryteriumController.stworzListeDoUsuniecia(kryteriumID, celID);

                    foreach (int idPodkryterium in listaPodkryteriow)
                    {
                        KryteriumController.usunKryterium(idPodkryterium, db);
                    }

                    kryteriumPanel.pobierzCele();
                }
            }
        }

        public void setTextBoxTextFocus(Control textBox)
        {
            if (null != textBox)
            {
                textBox.Text = String.Empty;
                textBox.Focus();
            }
        }

        public void setRadioButtonChecked(RadioButton radioButton, bool check)
        {
            if (null != radioButton)
            {
                radioButton.Checked = check;
            }
        }

        public void setControlEnable(Control control, bool enabled)
        {
            if (null != control)
            {
                control.Enabled = enabled;
            }
        }

        public void setAktualnyPanel(object aktualnyPanel)
        {
            this.aktualnyPanel = aktualnyPanel;
        }

        public void setWagiPanel(WagiPanel wagiPanel)
        {
            this.wagiPanel = wagiPanel;
        }

        public void setMainPanel(MainPanel mainPanel)
        {
            this.mainPanel = mainPanel;
        }

        public void setKryteriumPanel(KryteriumPanel kryteriumPanel)
        {
            this.kryteriumPanel = kryteriumPanel;
        }

        public Button getButton(String nazwa)
        {
            switch (nazwa)
            {
                case "Dodaj":
                    return dodajButton;
                case "Usuń":
                    return usunButton;
                case "Wstecz":
                    return wsteczButton;
                case "Dalej":
                    return dalejButton;
                default:
                    return null;
            }
        }

        private void wsteczButton_Click(object sender, EventArgs e)
        {
            dalejButton.Enabled = true;

            if (aktualnyPanel == kryteriumPanel)
            {
                kryteriumPanel.Visible = false;
                Visible = false;
                mainPanel.Visible = true;
                setAktualnyPanel(mainPanel);
            }
            else if (aktualnyPanel == wagiPanel)
            {
                wagiPanel.Visible = false;
                mainPanel.Visible = false;
                kryteriumPanel.Visible = true;
                setAktualnyPanel(kryteriumPanel);
            }
            else if (aktualnyPanel == mainPanel)
            {
                kryteriumPanel.Visible = false;

                if (null != wagiPanel)
                {
                    wagiPanel.Visible = false;
                }

                mainPanel.Visible = true;
            }
        }

        public void ustalPanel(object panel)
        {
            setAktualnyPanel(panel);
        }
    }
}
