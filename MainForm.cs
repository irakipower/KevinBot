using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KevinBot.App;
using KevinBot.Network;

namespace KevinBot
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        IDManager IDM = new IDManager();
        Commander Cmdr = new Commander();
        Status Stat = new Status();
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Online
            IDM.GenerateID(10);
            Stat.Online();
            Cmdr.Enable();
        }
        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            // Offline
            Stat.Offline();
        }
    }
}
