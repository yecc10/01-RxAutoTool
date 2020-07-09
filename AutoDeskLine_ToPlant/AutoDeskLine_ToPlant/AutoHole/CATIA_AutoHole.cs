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
using KnowledgewareTypeLib;
using HybridShapeTypeLib;
using System.IO;
using DNBPert;
using CATMat;
using FittingTypeLib;
using DNBASY;
using NPOI.POIFS.Properties;

namespace AutoDeskLine_ToPlant
{
    public partial class CATIA_AutoHole : Form
    {
        public CATIA_AutoHole()
        {
            InitializeComponent();
            timer.Enabled = true;
        }
        /// <summary>
        /// 设置单排规制块的空，且自动识别空间距是15/12.5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawHole_A_Click(object sender, EventArgs e)
        {
            GetProductByFace GPB = new GetProductByFace();
            if (GPB.CatActiveDoc == null)
            {
                GPB.InitCatEnv(this);
            }
            this.WindowState = FormWindowState.Minimized;
            Selection SelectArc = GPB.CatActiveDoc.Selection;
            SelectArc.Clear();
            Reference[] RefEdege = new Reference[3];
            object[] HolePoint = new object[6];
            for (int OP = 0; OP < 999; OP++) //执行重复选择 直到用于取消
            {
                for (int i = 1; i <= 3; i++)
                {
                    var Result = SelectArc.SelectElement2(GPB.InputObjectType(i <= 2 ? 3 : 2), i <= 2 ? "请选择第" + i + "一个边线" : "请选择孔所在面", true);
                    if (Result == "Cancel")
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.StartPosition = FormStartPosition.CenterScreen;
                        this.TopMost = true;
                        return;
                    }
                    if (SelectArc == null || SelectArc.Count2 == 0)
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.StartPosition = FormStartPosition.CenterScreen;
                        this.TopMost = true;
                        return;
                    }
                    switch (i)
                    {
                        case 1:
                            {
                                RefEdege[0] = SelectArc.Item(1).Reference;
                                SelectArc.Clear();
                                break;
                            }
                        case 2:
                            {
                                RefEdege[1] = SelectArc.Item(1).Reference;
                                SelectArc.Clear();
                                break;
                            }
                        case 3:
                            {
                                RefEdege[2] = SelectArc.Item(1).Reference;
                                SelectArc.Item(1).GetCoordinates(HolePoint);
                                break;
                            }
                        default:
                            break;
                    }
                }
                GPB.CreateNwThroughtHole(RefEdege, this);
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Text = "本技术由瑞祥工业数字化_叶朝成提供|SystemTime:" + DateTime.Now;
        }
    }
}
