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
        public INFITF.Application CatApplication;
        public Document CatDocument;
        public Documents CatDocuments;
        public ProductDocument CatActiveDoc;

        public void SetApplication(INFITF.Application APP, Document CatDoc, ProductDocument CatADoc, Documents CatDocs)
        {
            CatApplication = APP;
            CatActiveDoc = CatADoc;
            CatDocument = CatDoc;
            CatDocuments = CatDocs;
        }
        enum RxHoleType { PinHole, SmoothHole, ThreadHole }
        /// <summary>
        /// 新增过孔
        /// </summary>
        /// <returns></returns>
        public void CreateNwThroughtHole(Reference[] UserSelected, Form tform)
        {
            object[] HolePoint = new object[3];
            Edge ed1 = (Edge)UserSelected[0];
            Edge ed2 = (Edge)UserSelected[1];

            if (CatActiveDoc == null)
            {
                InitCatEnv(tform);
            }
            SPAWorkbench TheSPAWorkbench = (SPAWorkbench)CatActiveDoc.GetWorkbench("SPAWorkbench");
            Measurable LengthA = TheSPAWorkbench.GetMeasurable(ed1);
            Measurable LengthB = TheSPAWorkbench.GetMeasurable(ed2);
            Edge LengthEdge = LengthA.Length >= LengthB.Length ? ed1 : ed2;//获取长边
            Edge WeightEdge = LengthA.Length <= LengthB.Length ? ed1 : ed2;//获取短边
            double Weight = LengthA.Length <= LengthB.Length ? LengthA.Length : LengthB.Length;
            double Length = LengthA.Length >= LengthB.Length ? LengthA.Length : LengthB.Length;
            double JianDis = 0;
            if (Length <= 45)
            {
                JianDis = 12.5;
            }
            else if (Length <= 60 && Length > 45)
            {
                JianDis = 15;
            }
            else if (Length > 60)
            {
                JianDis = 15;
            }
            GetProductByFace GPB = new GetProductByFace();
            Part Spart = GPB.GetPart((Face)UserSelected[2]);
            ShapeFactory shapeFactory = (ShapeFactory)Spart.ShapeFactory;
            Hole Nwhole = shapeFactory.AddNewHoleWith2Constraints(Convert.ToDouble(HolePoint[0]), Convert.ToDouble(HolePoint[1]), Convert.ToDouble(HolePoint[2]), UserSelected[0], UserSelected[1], UserSelected[2], 10);//创建过孔
            RxSetHoleType(Nwhole, 10, Weight / 2, 9, RxHoleType.SmoothHole);
            Spart.Update();
            Hole NwPinHole = shapeFactory.AddNewHoleWith2Constraints(Convert.ToDouble(HolePoint[0]) + 5, Convert.ToDouble(HolePoint[1]) + 5, Convert.ToDouble(HolePoint[2]), UserSelected[0], UserSelected[1], UserSelected[2], 10);//创建销孔
            RxSetHoleType(NwPinHole, 10, Weight / 2 + JianDis, 8, RxHoleType.PinHole);
            Spart.Update();
            if (Length <= 60)
            {
                RectPattern RPhole = shapeFactory.AddNewRectPattern(Nwhole, 2, 1, JianDis * 2, 20, 1, 1, LengthEdge, WeightEdge, true, true, 0); //阵列过孔
                RPhole.FirstRectangularPatternParameters = CatRectangularPatternParameters.catInstancesandSpacing;
                RPhole.SecondRectangularPatternParameters = CatRectangularPatternParameters.catInstancesandSpacing;
                Spart.Update();
            }
            else
            {
                RectPattern RPhole = shapeFactory.AddNewRectPattern(Nwhole, 2, 1, JianDis * 2, 20, 1, 1, LengthEdge, WeightEdge, true, true, 0); //阵列过孔
                RPhole.FirstRectangularPatternParameters = CatRectangularPatternParameters.catInstancesandSpacing;
                RPhole.SecondRectangularPatternParameters = CatRectangularPatternParameters.catInstancesandSpacing;

                RectPattern RPinhole = shapeFactory.AddNewRectPattern(NwPinHole, 2, 1, JianDis * 2, 20, 1, 1, LengthEdge, WeightEdge, true, true, 0); //阵列过孔
                RPinhole.FirstRectangularPatternParameters = CatRectangularPatternParameters.catInstancesandSpacing;
                RPinhole.SecondRectangularPatternParameters = CatRectangularPatternParameters.catInstancesandSpacing;
                Spart.Update();
            }
        }
        /// <summary>
        ///  瑞祥API设置孔属性
        /// </summary>
        /// <param name="Nwhole">孔对象</param>
        /// <param name="LengthDis">孔距离长边距离</param>
        /// <param name="WeightDis">孔距离短边距离</param>
        /// <param name="Diameter">孔直径</param>
        /// <param name="HoleType">孔类型</param>
        private void RxSetHoleType(Hole Nwhole, double LengthDis, double WeightDis, double Diameter, RxHoleType HoleType)
        {
            Nwhole.Type = CatHoleType.catSimpleHole;
            Nwhole.AnchorMode = CatHoleAnchorMode.catExtremPointHoleAnchor;
            Nwhole.BottomType = CatHoleBottomType.catVHoleBottom;
            Limit BottomLimit = Nwhole.BottomLimit;
            BottomLimit.LimitMode = CatLimitMode.catOffsetLimit;
            Nwhole.Diameter.Value = Diameter;
            Nwhole.BottomAngle.Value = 120;
            Nwhole.ThreadingMode = CatHoleThreadingMode.catSmoothHoleThreading;
            Sketch Hosketch = Nwhole.Sketch;
            MECMOD.Constraints HoleConstraint = Hosketch.Constraints;
            HoleConstraint.Item(1).Dimension.Value = WeightDis; //孔距离宽边的距离
            HoleConstraint.Item(2).Dimension.Value = LengthDis; //孔距离长边的距离
            //HoleConstraint.Item(2).Dimension.Value = 10;
            Nwhole.ThreadSide = CatHoleThreadSide.catRightThreadSide;
            BottomLimit.LimitMode = CatLimitMode.catUpThruNextLimit;
            ChangeHoleColor(Nwhole, HoleType);
        }

        /// <summary>
        /// 隐藏孔创建的草图并修改孔颜色
        /// </summary>
        /// <param name="Thole">目标孔</param>
        private void ChangeHoleColor(Hole Thole, RxHoleType HoleType)
        {
            //隐藏孔创建的草图并修改孔颜色
            Selection HoleSelection = CatActiveDoc.Selection;
            HoleSelection.Clear();
            VisPropertySet HoleSet = HoleSelection.VisProperties;
            Sketch HoleSketch = Thole.Sketch;
            HoleSelection.Add(HoleSketch);
            HoleSet.SetShow(CatVisPropertyShow.catVisPropertyNoShowAttr);
            HoleSelection.Clear();
            HoleSelection.Add(Thole);
            switch (HoleType)
            {
                case RxHoleType.PinHole: //销孔
                    HoleSet.SetVisibleColor(251, 146, 248, 0);
                    break;
                case RxHoleType.SmoothHole: //光孔 沉头孔
                    HoleSet.SetVisibleColor(167, 230, 182, 0);
                    break;
                case RxHoleType.ThreadHole: //螺纹孔
                    HoleSet.SetVisibleColor(128, 0, 255, 0);
                    break;
                default:
                    break;
            }
            HoleSelection.Clear();
        }
        public bool InitCatEnv(Form Window)
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
