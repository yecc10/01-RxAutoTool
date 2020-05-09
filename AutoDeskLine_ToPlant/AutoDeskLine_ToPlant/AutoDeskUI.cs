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
    public partial class AutoDeskUI : Form
    {
        public AutoDeskUI()
        {
            InitializeComponent();
        }
        private void browseButton_Click(
         object sender, EventArgs e)
        {
            OpenFileDialog dlg =
              new OpenFileDialog();
            dlg.InitialDirectory =
              System.Environment.CurrentDirectory;

            dlg.Filter =
              "DWG files (*.dwg)|*.dwg|All files (*.*)|*.*";

            Cursor oc = Cursor;

            String fn = "";

            if (dlg.ShowDialog() ==
              DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                fn = dlg.FileName;
                Refresh();
            }
            if (fn != "")
                //this.drawingPath.Text = fn;

            Cursor = oc;
        }
        //private void loadButton_Click(
        //  object sender, EventArgs e)
        //{
        //    if (System.IO.File.Exists(drawingPath.Text))
        //        axAcCtrl1.Src = drawingPath.Text;
        //    else
        //        MessageBox.Show("File does not exist");
        //}

        //private void postButton_Click(
        //  object sender, EventArgs e)
        //{
        //    axAcCtrl1.PostCommand(cmdString.Text);
        //}
    }
}
