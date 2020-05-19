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
            CatApplication.set_Caption("正在运行瑞祥快速建模工具！");
            // 获取当前活动ProductDocument
            try
            {
                CatDocument = (ProductDocument)CatApplication.ActiveDocument;
            }
            catch (Exception)
            {
                CatDocument = (ProductDocument)CatApplication.Documents.Add("Product");
                try
                {
                    CatDocument.set_Name("RxProduct");
                }
                catch (Exception)
                {
                    MessageBox.Show("未检测到活动Product,正在为您创建，请手动辅助完成！");
                    return;
                }
                MessageBox.Show("未检测到活动Product,已自动为您创建对象！");
            }
            // 添加一个新零件
            string Name = "NewPoint";
            Part PartID;
            try
            {
                PartID=((PartDocument)CatApplication.Documents.Item(Name + ".CATPart")).Part;
            }
            catch (Exception)
            {
               CatDocument.Product.Products.AddNewComponent("Part", Name);
               PartID = ((PartDocument)CatApplication.Documents.Item(Name + ".CATPart")).Part;

            }
            Selection SelectArc = CatDocument.Selection;
            if (SelectArc.Count < 1)
            {
                MessageBox.Show("请先选择对象后再点此命令！");
                return;
            }
            int ERR = 0;
            for (int i = 1; i < SelectArc.Count; i++)
            {
                    HybridShapeFactory PartHyb = (HybridShapeFactory)PartID.HybridShapeFactory;
                    Reference PointRef = SelectArc.Item(i).Reference;
                    HybridShapePointCenter NewPoint = PartHyb.AddNewPointCenter(PointRef);
                    NewPoint.set_Name("YPoint_" + i);
                    HybridBodies Hybs = PartID.HybridBodies;
                    HybridBody Hyb = Hybs.Item("几何图形集.1");
                    Hyb.AppendHybridShape(NewPoint);
                    PartID.InWorkObject = NewPoint;
                try
                {
                    PartID.Update();
                }
                catch (Exception)
                {
                    ERR+=1;
                }
            }
            if (ERR>0)
            {
                MessageBox.Show("共计:" + ERR + "个点创建新参考点失败！");
            }

        }

        private void CatiaQuickTool_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
