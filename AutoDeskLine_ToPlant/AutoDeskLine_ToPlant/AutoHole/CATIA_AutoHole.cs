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

namespace AutoDeskLine_ToPlant
{
    public partial class CATIA_AutoHole : Form
    {
        INFITF.Application CatApplication;
        ProductDocument CatDocument;
        System.Data.DataTable datatable = new System.Data.DataTable();
        System.Data.DataColumn dataColum;
        DataRow DataRow;
        DataView dataview;
        Part PartID;

        AnyObject[] GetRepeatRef = new AnyObject[99];
        int RepeatNum = 0;

        /// <summary>
        /// Value=1->Read Point;Value=2->AnyPoint
        /// </summary>
        int ReadType = 0;
        public CATIA_AutoHole()
        {
            InitializeComponent();
        }
        private bool InitCatEnv()
        {
            try
            {
                CatApplication = (INFITF.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Catia.Application");
            }
            catch (Exception)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
                MessageBox.Show("未检测到打开的CATIA!,请重新运行CATIA!");
                return false;
                //throw;
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
                    CatDocument.Product.set_PartNumber("RxProduct");
                }
                catch (Exception)
                {
                    MessageBox.Show("未检测到活动Product,正在为您创建，请手动辅助完成！");
                    return false;
                }
                //MessageBox.Show("未检测到活动Product,已自动为您创建对象！");
            }
            // 添加一个新零件
            string Name = "RXFastDesignTool";
            try
            {
                PartID = ((PartDocument)CatApplication.Documents.Item(Name + ".CATPart")).Part;
            }
            catch (Exception)
            {
                try
                {
                    CatDocument.Product.Products.AddNewComponent("Part", Name);
                }
                catch (Exception)
                {
                    return false;
                    // throw;
                }
                PartID = ((PartDocument)CatApplication.Documents.Item(Name + ".CATPart")).Part;
            }
            return true;
        }
        private Selection GetSelect()
        {
            this.WindowState = FormWindowState.Minimized;
            try
            {
                CatApplication = (INFITF.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Catia.Application");
            }
            catch (Exception)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
                MessageBox.Show("未检测到打开的CATIA!,请重新运行CATIA!");
                return null;
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
                    CatDocument.Product.set_PartNumber("RxProduct");
                }
                catch (Exception)
                {
                    MessageBox.Show("未检测到活动Product,正在为您创建，请手动辅助完成！");
                    return null;
                }
                //MessageBox.Show("未检测到活动Product,已自动为您创建对象！");
            }
            // 添加一个新零件
            string Name = "RXFastDesignTool";
            try
            {
                Selection FindPart = CatApplication.ActiveDocument.Selection;
                FindPart.Search("Name=RXFastDesignTool,all");
                if (FindPart.Count2 > 0)
                {
                    PartID = (Part)FindPart.Item2(1).Value; //仅拾取带个并对第一个进行操作
                }
                else
                {
                    try
                    {
                        CatDocument.Product.Products.AddNewComponent("Part", Name);
                    }
                    catch (Exception)
                    {
                        return null;
                        // throw;
                    }
                    PartID = ((PartDocument)CatApplication.Documents.Item(Name + ".CATPart")).Part;
                    OriginElements Tpart = PartID.OriginElements;
                    AnyObject dxy = Tpart.PlaneXY;
                    AnyObject dyz = Tpart.PlaneYZ;
                    AnyObject dzx = Tpart.PlaneZX;
                    Selection SelectT = CatDocument.Selection;
                    VisPropertySet VP = SelectT.VisProperties;
                    SelectT.Add(dxy);
                    SelectT.Add(dyz);
                    SelectT.Add(dzx);
                    VP = (VisPropertySet)VP.Parent;
                    VP.SetShow(CatVisPropertyShow.catVisPropertyNoShowAttr);
                    SelectT.Clear();
                }
            }
            catch (Exception)
            {
                return null;
            }
            try
            {
                CatDocument.Product.ApplyWorkMode(CatWorkModeType.DESIGN_MODE);
            }
            catch (Exception)
            {
                Console.WriteLine("Change Design Model Faild!");
            }
            Selection SelectArc = CatDocument.Selection;
            SelectArc.Clear();
            var Result = SelectArc.SelectElement3(InputObjectType(0), "请选择曲面", true, CATMultiSelectionMode.CATMultiSelTriggWhenSelPerf, false);
            if (Result == "Cancel")
            {
                return null;
            }
            if (SelectArc.Count < 1)
            {
                MessageBox.Show("请先选择对象后再点此命令！");
                return null;
            }
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            return SelectArc;
        }
        /// <summary>
        /// 设置CATIA 拾取对象类型
        /// 0：GetAnyObject；1：GetPoint；2:Face；3:Edge；4:Pad；5:sketch；6:Shape；7:Bodies；8:Part；9：Product
        /// </summary>
        /// <returns>:</returns>
        [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)]
        public object[] InputObjectType(int ReadType)
        {
            switch (ReadType)
            {
                case 0: //GetAnyObject
                    {
                        return new object[] { "AnyObject" };
                    }
                case 1: //GetPoint
                    {
                        return new object[] { "Point", "Symmetry", "Translate" };
                    }
                case 2: //Face
                    {
                        return new object[] { "Face" };
                    }
                case 3: //Edge
                    {
                        return new object[] { "Edge" };
                    }
                case 4: //Pad
                    {
                        return new object[] { "Pad" };
                    }
                case 5: //sketch
                    {
                        return new object[] { "sketch" };
                    }
                case 6: //Shape
                    {
                        return new object[] { "Shape" };
                    }
                case 7: //Bodies
                    {
                        return new object[] { "Bodies" };
                    }
                case 8: //Part
                    {
                        return new object[] { "Product" };
                    }
                case 9: //Product
                    {
                        return new object[] { "Product" };
                    }
                default:
                    return new object[] { "AnyObject" };
            }
        }

        /// <summary>
        /// 设置单排规制块的空，且自动识别空间距是15/12.5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawHole_A_Click(object sender, EventArgs e)
        {
            if (CatDocument == null)
            {
                InitCatEnv();
            }
            this.WindowState = FormWindowState.Minimized;
            RepeatNum = 0;
            Array.Clear(GetRepeatRef, 0, GetRepeatRef.Length);
            ReadType = 2;
            Selection SelectArc = CatDocument.Selection;
            SelectArc.Clear();
            Reference RefEdegeA=null,RefEdegeB = null, ReFace = null;
            for (int i = 1; i <=3; i++)
            {
                var Result = SelectArc.SelectElement2(InputObjectType(i <= 2 ?3:2),i<=2?"请选择第"+i+"一个边线": "请选择孔所在面", true);
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
                            RefEdegeA = SelectArc.Item(1).Reference;
                            SelectArc.Clear();
                            break;
                        }
                    case 2:
                        {
                            RefEdegeB = SelectArc.Item(1).Reference;
                            SelectArc.Clear();
                            break;
                        }
                    case 3:
                        {
                            ReFace = SelectArc.Item(1).Reference;
                            break;
                        }
                    default:
                        break;
                }
            }
            Face Cface = (Face)SelectArc.Item(1).Value;
            var Gname = Cface.get_Name();
            Product CProduct = (Product)SelectArc.Item(1).LeafProduct;
            string PartName = CProduct.get_PartNumber();
            Product FProduct =(Product)CProduct.Parent;
            //Gname = FProduct.get_Name();
            //Part CPart=;
            var str = FProduct.Products.Count;
            Part CPart = ((PartDocument)FProduct.Products.GetItem(PartName+".CATPart")).Part;
             HybridShapeFactory PartHyb = (HybridShapeFactory)PartID.HybridShapeFactory;
            SPAWorkbench TheSPAWorkbench = (SPAWorkbench)CatDocument.GetWorkbench("SPAWorkbench");
            String Name = string.Empty;
            //Shape GE = (Shape)SelectArc.Item(i).Value;
            //Name = GE.get_Name();
            //Pad Spad = (Pad)GE.GetItem("Face1");
            //Name = Spad.get_Name();
            VisPropertySet VPS = SelectArc.VisProperties;
            VPS.SetVisibleColor(255, 0, 0, 0);
            
        }
    }
}
