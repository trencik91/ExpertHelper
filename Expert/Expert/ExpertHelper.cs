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
            ButtonMenu buttonMenu = new ButtonMenu(this);
            MainPanel mainPanel = new MainPanel(this, buttonMenu);
            mainPanel.Visible = true;
        }
    }
}
