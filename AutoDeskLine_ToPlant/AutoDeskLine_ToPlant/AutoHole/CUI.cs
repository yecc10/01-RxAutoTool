using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Windows.Forms;

namespace AutoDeskLine_ToPlant
{
    class RxCatApp
    {
        private INFITF.Application CatApplication;
        private Document CatDocument;
        private Documents CatDocuments;
        private ProductDocument CatActiveDoc;
        public void SetApplication(INFITF.Application APP, Document CatDoc, ProductDocument CatADoc, Documents CatDocs)
        {
            CatApplication = APP;
            CatActiveDoc = CatADoc;
            CatDocument = CatDoc;
            CatDocuments = CatDocs;
        }
        /// <summary>
        /// 新增销孔
        /// </summary>
        /// <returns></returns>
        public void CreateNwPinHole(Reference[] UserSelected)
        {
            object[] HolePoint = new object[3];
            Edge ed1 = (Edge)UserSelected[0];
            Edge ed2 = (Edge)UserSelected[1];
            SPAWorkbench TheSPAWorkbench = (SPAWorkbench)CatDocument.GetWorkbench("SPAWorkbench");
            Measurable LengthA = TheSPAWorkbench.GetMeasurable(ed1);
            Measurable LengthB = TheSPAWorkbench.GetMeasurable(ed2);
            double Weight = LengthA.Length <= LengthB.Length ? LengthA.Length : LengthB.Length;
            double Length = LengthA.Length >= LengthB.Length ? LengthA.Length : LengthB.Length;
            double JianDis;
            if (Length <= 45)
            {
                JianDis = 12.5;
            }
            else if (Length <= 60 && Length > 45)
            {
                JianDis = 15;
            }
            else if (Length >= 65)
            {
                JianDis = 12.5;
            }
            JianDis = Length <= 50 && Length > 45 ? 12.5 : 12.5;
            GetProductByFace GPB = new GetProductByFace();
            Part Spart = GPB.GetPart((Face)UserSelected[2]);
            ShapeFactory shapeFactory = (ShapeFactory)Spart.ShapeFactory;
            Hole Nwhole = shapeFactory.AddNewHoleWith2Constraints(Convert.ToDouble(HolePoint[0]), Convert.ToDouble(HolePoint[1]), Convert.ToDouble(HolePoint[2]), UserSelected[0], UserSelected[1], UserSelected[2], 10);
            Nwhole.Type = CatHoleType.catSimpleHole;
            Nwhole.AnchorMode = CatHoleAnchorMode.catExtremPointHoleAnchor;
            Nwhole.BottomType = CatHoleBottomType.catVHoleBottom;
            Limit BottomLimit = Nwhole.BottomLimit;
            BottomLimit.LimitMode = CatLimitMode.catOffsetLimit;
            Nwhole.Diameter.Value = 8;
            Nwhole.BottomAngle.Value = 120;
            Nwhole.ThreadingMode = CatHoleThreadingMode.catSmoothHoleThreading;
            Sketch Hosketch = Nwhole.Sketch;
            MECMOD.Constraints HoleConstraint = Hosketch.Constraints;
            HoleConstraint.Item(1).Dimension.Value = 10;
            HoleConstraint.Item(2).Dimension.Value = Weight / 2;
            //HoleConstraint.Item(2).Dimension.Value = 10;
            Nwhole.ThreadSide = CatHoleThreadSide.catRightThreadSide;
            Spart.Update();
        }
        /// <summary>
        /// 新增过孔
        /// </summary>
        /// <returns></returns>
        public void CreateNwThroughtHole(Reference[] UserSelected)
        {
            object[] HolePoint = new object[3];
            Edge ed1 = (Edge)UserSelected[0];
            Edge ed2 = (Edge)UserSelected[1];
            SPAWorkbench TheSPAWorkbench = (SPAWorkbench)CatDocument.GetWorkbench("SPAWorkbench");
            Measurable LengthA = TheSPAWorkbench.GetMeasurable(ed1);
            Measurable LengthB = TheSPAWorkbench.GetMeasurable(ed2);
            double Weight = LengthA.Length <= LengthB.Length ? LengthA.Length : LengthB.Length;
            double Length = LengthA.Length >= LengthB.Length ? LengthA.Length : LengthB.Length;
            double JianDis;
            if (Length <= 45)
            {
                JianDis = 12.5;
            }
            else if (Length <= 60 && Length > 45)
            {
                JianDis = 15;
            }
            else if (Length >= 65)
            {
                JianDis = 12.5;
            }
            JianDis = Length <= 50 && Length > 45 ? 12.5 : 12.5;
            GetProductByFace GPB = new GetProductByFace();
            Part Spart = GPB.GetPart((Face)UserSelected[2]);
            ShapeFactory shapeFactory = (ShapeFactory)Spart.ShapeFactory;
            Hole Nwhole = shapeFactory.AddNewHoleWith2Constraints(Convert.ToDouble(HolePoint[0]), Convert.ToDouble(HolePoint[1]), Convert.ToDouble(HolePoint[2]), UserSelected[0], UserSelected[1], UserSelected[2], 10);
            Nwhole.Type = CatHoleType.catSimpleHole;
            Nwhole.AnchorMode = CatHoleAnchorMode.catExtremPointHoleAnchor;
            Nwhole.BottomType = CatHoleBottomType.catVHoleBottom;
            Limit BottomLimit = Nwhole.BottomLimit;
            BottomLimit.LimitMode = CatLimitMode.catOffsetLimit;
            Nwhole.Diameter.Value = 8;
            Nwhole.BottomAngle.Value = 120;
            Nwhole.ThreadingMode = CatHoleThreadingMode.catSmoothHoleThreading;
            Sketch Hosketch = Nwhole.Sketch;
            MECMOD.Constraints HoleConstraint = Hosketch.Constraints;
            HoleConstraint.Item(1).Dimension.Value = 10;
            HoleConstraint.Item(2).Dimension.Value = Weight / 2;
            //HoleConstraint.Item(2).Dimension.Value = 10;
            Nwhole.ThreadSide = CatHoleThreadSide.catRightThreadSide;
            BottomLimit.LimitMode = CatLimitMode.catUpThruNextLimit;
            ChangeHoleColor(Nwhole);
            Spart.Update();
        }
        /// <summary>
        /// 隐藏孔创建的草图并修改孔颜色
        /// </summary>
        /// <param name="Thole">目标孔</param>
        private void ChangeHoleColor(Hole Thole)
        {
            GetProductByFace GPB = new GetProductByFace();
            //隐藏孔创建的草图并修改孔颜色
            Selection HoleSelection = GPB.CatActiveDoc.Selection;
            VisPropertySet HoleSet = HoleSelection.VisProperties;
            Sketch HoleSketch = Thole.Sketch;
            HoleSelection.Add(HoleSketch);
            HoleSet.SetShow(CatVisPropertyShow.catVisPropertyNoShowAttr);
            HoleSelection.Clear();
            HoleSelection.Add(Thole);
            HoleSet.SetVisibleColor(100, 100, 0, 0);
            HoleSelection.Clear();
        }
        /// <summary>
        /// 新增螺纹孔
        /// </summary>
        /// <returns></returns>
        public void CreateNwHelicallHole(Reference[] UserSelected)
        {
            object[] HolePoint = new object[3];
            Edge ed1 = (Edge)UserSelected[0];
            Edge ed2 = (Edge)UserSelected[1];
            SPAWorkbench TheSPAWorkbench = (SPAWorkbench)CatDocument.GetWorkbench("SPAWorkbench");
            Measurable LengthA = TheSPAWorkbench.GetMeasurable(ed1);
            Measurable LengthB = TheSPAWorkbench.GetMeasurable(ed2);
            double Weight = LengthA.Length <= LengthB.Length ? LengthA.Length : LengthB.Length;
            double Length = LengthA.Length >= LengthB.Length ? LengthA.Length : LengthB.Length;
            double JianDis;
            if (Length <= 45)
            {
                JianDis = 12.5;
            }
            else if (Length <= 60 && Length > 45)
            {
                JianDis = 15;
            }
            else if (Length >= 65)
            {
                JianDis = 12.5;
            }
            JianDis = Length <= 50 && Length > 45 ? 12.5 : 12.5;
            GetProductByFace GPB = new GetProductByFace();
            Part Spart = GPB.GetPart((Face)UserSelected[2]);
            ShapeFactory shapeFactory = (ShapeFactory)Spart.ShapeFactory;
            Hole Nwhole = shapeFactory.AddNewHoleWith2Constraints(Convert.ToDouble(HolePoint[0]), Convert.ToDouble(HolePoint[1]), Convert.ToDouble(HolePoint[2]), UserSelected[0], UserSelected[1], UserSelected[2], 10);
            Nwhole.Type = CatHoleType.catSimpleHole;
            Nwhole.AnchorMode = CatHoleAnchorMode.catExtremPointHoleAnchor;
            Nwhole.BottomType = CatHoleBottomType.catVHoleBottom;
            Limit BottomLimit = Nwhole.BottomLimit;
            BottomLimit.LimitMode = CatLimitMode.catOffsetLimit;
            Nwhole.Diameter.Value = 8;
            Nwhole.BottomAngle.Value = 120;
            Nwhole.ThreadingMode = CatHoleThreadingMode.catSmoothHoleThreading;
            Sketch Hosketch = Nwhole.Sketch;
            MECMOD.Constraints HoleConstraint = Hosketch.Constraints;
            HoleConstraint.Item(1).Dimension.Value = 10;
            HoleConstraint.Item(2).Dimension.Value = Weight / 2;
            //HoleConstraint.Item(2).Dimension.Value = 10;
            Nwhole.ThreadSide = CatHoleThreadSide.catRightThreadSide;
            Spart.Update();
        }
        private bool InitCatEnv(Form Window)
        {
            INFITF.Application CatApp;
            ProductDocument CatActiveDoc;
            try
            {
                CatApp = (INFITF.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Catia.Application");
            }
            catch (Exception)
            {
                Window.WindowState = FormWindowState.Normal;
                Window.StartPosition = FormStartPosition.CenterScreen;
                MessageBox.Show("未检测到打开的CATIA!,请重新运行CATIA!");
                return false;
                //throw;
            }
            CatApp.set_Caption("正在运行瑞祥快速建模工具！");
            // 获取当前活动ProductDocument
            try
            {
                CatActiveDoc = (ProductDocument)CatApp.ActiveDocument;
            }
            catch (Exception)
            {
                CatActiveDoc = (ProductDocument)CatApp.Documents.Add("Product");
                try
                {
                    CatActiveDoc.Product.set_PartNumber("RxProduct");
                }
                catch (Exception)
                {
                    MessageBox.Show("未检测到活动Product,正在为您创建，请手动辅助完成！");
                    return false;
                }
                //MessageBox.Show("未检测到活动Product,已自动为您创建对象！");
            }
            SetApplication(CatApp, null, CatActiveDoc, null);
            return true;
        }
    }
    class GetProductByFace : RxCatApp
    {
        private Face pSelectedFace;
        private Pad pSPad;
        private Shapes pShape;
        private Body pSBody;
        private Bodies pSbodys;
        private Part pSpart;
        /// <summary>
        /// 根据选择的面初始化其整个Part的父级
        /// </summary>
        /// <param name="SelectedFace">选择的面</param>
        public void CaculateObject(Face SelectedFace)
        {
            pSelectedFace = SelectedFace;
            pSPad = (Pad)SelectedFace.Parent;
            pShape = (Shapes)pSPad.Parent;
            pSBody = (Body)pShape.Parent;
            pSbodys = (Bodies)pSBody.Parent;
            pSpart = (Part)pSbodys.Parent;
        }
        /// <summary>
        /// 通过面获取其面的Part
        /// </summary>
        /// <param name="SelectedFace">选择的面</param>
        /// <returns></returns>
        public Part GetPart(Face SelectedFace)
        {
            CaculateObject(SelectedFace);
            return pSpart;
        }
    }
}
