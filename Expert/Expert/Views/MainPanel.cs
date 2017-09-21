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
            this.Visible = false;
            KryteriumPanel kryteriumPanel = new KryteriumPanel(mainForm);
            mainForm.Controls.Add(kryteriumPanel);
            kryteriumPanel.Visible = true;
        }
    }
}
