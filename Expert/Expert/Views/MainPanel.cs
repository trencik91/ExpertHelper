﻿using System;
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
    }
}
