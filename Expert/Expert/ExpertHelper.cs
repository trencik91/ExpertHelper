using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expert
{
    public partial class ExpertHelper : Form
    {
        public ExpertHelper()
        {
            InitializeComponent();
            MainPanel mainPanel = new MainPanel(this);
            ButtonMenu buttonMenu = new ButtonMenu(this);
            KryteriumPanel kryteriumPanel = new KryteriumPanel(this, buttonMenu);
            WagiPanel wagiPanel = new WagiPanel(this, kryteriumPanel);
            WynikPanel wynikPanel = new WynikPanel();
            this.Controls.Add(mainPanel);
            mainPanel.Visible = true;
        }
    }
}
