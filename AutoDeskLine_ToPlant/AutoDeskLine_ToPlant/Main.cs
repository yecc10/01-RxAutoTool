using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
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

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            System.Environment.Exit(0);
        }

        private void BollToAix_Click(object sender, EventArgs e)
        {
            this.Hide();
            CatiaQuickTool CQT = new CatiaQuickTool();
            CQT.Show();
        }
    }
}