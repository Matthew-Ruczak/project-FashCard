﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flash_Card
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnOpenExistingFlashCard_Click(object sender, EventArgs e)
        {
            UsingFlashCards frm = new UsingFlashCards();
            frm.Show();
        }
    }
}
