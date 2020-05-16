using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CATIA_APP_ITF;
using SURFACEMACHINING;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Diagnostics;
using INFITF;
using MECMOD;
using PARTITF;
using ProductStructureTypeLib;
using SPATypeLib;
using NavigatorTypeLib;


namespace AutoDeskLine_ToPlant
{
    public partial class CatiaQuickTool : Form
    {
        INFITF.Application CatApplication;
        ProductDocument CatDocument;
        public CatiaQuickTool()
        {
            InitializeComponent();

        }
        private void TryRead_Click(object sender, EventArgs e)
        {
            try
            {
               CatApplication = (INFITF.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Catia.Application");
            }
            catch (Exception)
            {

                throw;
            }
            // 获取当前活动ProductDocument
            CatDocument =(ProductDocument) CatApplication.ActiveDocument;


        }

        private void CatiaQuickTool_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
