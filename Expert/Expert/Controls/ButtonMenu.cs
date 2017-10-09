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
        private WynikPanel wynikPanel;

        private object aktualnyPanel;
        private object poprzedniPanel;

        public ButtonMenu()
        {
            InitializeComponent();
        }

        public ButtonMenu(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            Location = new Point(16, 4);
            Visible = true;
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

        public void setPoprzedniPanel(object poprzedniPanel)
        {
            this.poprzedniPanel = poprzedniPanel;
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

        public void setWynikPanel(WynikPanel wynikPanel)
        {
            this.wynikPanel = wynikPanel;
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

            if (aktualnyPanel == mainPanel)
            {
                kryteriumPanel.Visible = false;

                if (null != wagiPanel)
                {
                    wagiPanel.Visible = false;
                }

                mainPanel.Visible = true;
                setPoprzedniPanel(mainPanel);
            }
            else if (aktualnyPanel == kryteriumPanel)
            {
                kryteriumPanel.Visible = false;
                Visible = false;

                if (mainPanel != null)
                {
                    mainPanel.Visible = true;
                }
                else
                {
                    mainPanel = new MainPanel(mainForm, this);
                    mainForm.Controls.Add(mainPanel);
                    mainPanel.Visible = true;
                }

                setAktualnyPanel(mainPanel);
                setPoprzedniPanel(kryteriumPanel);
            }
            else if (aktualnyPanel == wagiPanel)
            {
                wagiPanel.Visible = false;

                if (null != mainPanel)
                {
                    mainPanel.Visible = false;
                }

                kryteriumPanel.Visible = true;
                setAktualnyPanel(kryteriumPanel);
                setPoprzedniPanel(wagiPanel);
            }
            else if (aktualnyPanel == wynikPanel)
            {
                wynikPanel.Visible = false;

                if (null != mainPanel)
                {
                    mainPanel.Visible = false;
                }

                wagiPanel.Visible = true;
                setAktualnyPanel(wagiPanel);
                setPoprzedniPanel(wynikPanel);
            }
        }

        private void dalejButton_Click(object sender, EventArgs e)
        {
            ustalDalejPanele();
            dalejButton.Enabled = false;
        }

        private void ustalDalejPanele()
        {
            ustalDalejKryterium();
            ustalDalejWagi();
            ustalDalejWynik();
        }

        private void ustalDalejKryterium()
        {
            if (null != kryteriumPanel && poprzedniPanel == kryteriumPanel)
            {
                kryteriumPanel.Visible = true;
                setAktualnyPanel(kryteriumPanel);

                if (null != wagiPanel)
                {
                    wagiPanel.Visible = false;
                }

                if (null != wynikPanel)
                {
                    wynikPanel.Visible = false;
                }

                if (null != mainPanel)
                {
                    mainPanel.Visible = false;
                }
            }
        }

        private void ustalDalejWagi()
        {
            if (null != wagiPanel && poprzedniPanel == wagiPanel)
            {
                wagiPanel.Visible = true;
                setAktualnyPanel(wagiPanel);

                if (null != kryteriumPanel)
                {
                    kryteriumPanel.Visible = false;
                }

                if (null != wynikPanel)
                {
                    wynikPanel.Visible = false;
                }

                if (null != mainPanel)
                {
                    mainPanel.Visible = false;
                }
            }
        }

        private void ustalDalejWynik()
        {
            if (null != wynikPanel && poprzedniPanel == wynikPanel)
            {
                wynikPanel.Visible = true;
                setAktualnyPanel(wynikPanel);

                if (null != kryteriumPanel)
                {
                    kryteriumPanel.Visible = false;
                }

                if (null != wagiPanel)
                {
                    wagiPanel.Visible = false;
                }

                if (null != mainPanel)
                {
                    mainPanel.Visible = false;
                }
            }
        }
    }
}
