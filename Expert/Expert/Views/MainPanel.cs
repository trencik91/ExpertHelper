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
            KryteriumPanel kryteriumPanel = new KryteriumPanel(mainForm);
            mainForm.Controls.Add(kryteriumPanel);
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
