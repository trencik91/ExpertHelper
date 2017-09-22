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
            this.Controls.Add(mainPanel);
            mainPanel.Visible = true;
        }
    }
}
