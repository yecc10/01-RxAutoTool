using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDeskLine_ToPlant
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void CreateFence_Click(object sender, EventArgs e)
        {
            this.Hide();
            DrawFence DF = new DrawFence();
            DF.ShowDialog();
        }

        private void CreateTrack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AutoDesKToPlant ATP = new AutoDesKToPlant();
            ATP.ShowDialog();
        }
    }
}
