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

namespace AutoDeskLine_ToPlant
{
    public partial class CatiaQuickTool : Form
    {
        [DllImportAttribute("kernel32.dll", EntryPoint = "OpenProcess")]
        public static extern IntPtr OpenProcess
            (
             int dwDesiredAccess,
             bool bInheritHandle,
             int dwProcessId
            );
        /// <summary>
        /// 已打开的CAD图纸
        /// </summary>
        INFITF.Application TCatia;
        INFITF.Document TDocument;
        INFITF.Documents TDocuments;
        public CatiaQuickTool()
        {
            InitializeComponent();

        }
        private void TryRead_Click(object sender, EventArgs e)
        {
            if (SCATIA.Checked)
            { //catia
                try
                {
                    TCatia = (INFITF.Application)Marshal.GetActiveObject("CATIA.Application");
                }
                catch (Exception)
                {

                    Type oType = System.Type.GetTypeFromProgID("CATIA.Application");
                    TCatia = (INFITF.Application)Activator.CreateInstance(oType);
                    TCatia.Visible = true;
                }
            }
            else //Delmia 
            {
                try
                {
                    TCatia = (INFITF.Application)Marshal.GetActiveObject("DELMIA.Application");
                }
                catch (Exception)
                {

                    Type oType = System.Type.GetTypeFromProgID("DELMIA.Application");
                    TCatia = (INFITF.Application)Activator.CreateInstance(oType);
                    TCatia.Visible = true;
                }
            }
            TDocument = TCatia.ActiveDocument;
            TDocument.Activate();
            //INFITF.AnyObject obj = TDocument.Cameras;



        }

        private void CatiaQuickTool_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
