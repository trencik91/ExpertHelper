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

        public ButtonMenu()
        {
            InitializeComponent();
        }

        public ButtonMenu(Form mainForm, KryteriumPanel kryteriumPanel)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.kryteriumPanel = kryteriumPanel;
            mainForm.Controls.Add(buttonMenuPanel);
            buttonMenuPanel.Location = new Point(19, 4);
            usunButton.Enabled = false;
        }

        public Panel getPanel()
        {
            return this.buttonMenuPanel;
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

        private void setTextBoxTextFocus(Control textBox)
        {
            if (null != textBox)
            {
                textBox.Text = String.Empty;
                textBox.Focus();
            }
        }

        private void setRadioButtonChecked(RadioButton radioButton, bool check)
        {
            if (null != radioButton)
            {
                radioButton.Checked = check;
            }
        }

        private void setControlEnable(Control control, bool enabled)
        {
            if (null != control)
            {
                control.Enabled = enabled;
            }
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
    }
}
