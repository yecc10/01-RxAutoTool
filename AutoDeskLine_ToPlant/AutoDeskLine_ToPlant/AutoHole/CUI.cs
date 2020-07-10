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
        enum RxHoleType { PinHole, NSmoothHole, ISmoothHole, ThreadHole }//PinHole销孔  NormarlSmoothHole 光孔 Inner SmoothHole 沉头孔  ThreadHole 螺纹孔

        /// <summary>
        /// 新增孔
        /// </summary>
        /// <param name="UserSelected">用户选择的3个参考</param>
        /// <param name="tform">父级窗体</param>
        /// <param name="AbortHole">是否对装配零件直接打孔</param>
        public void CreateNwThroughtHole(Reference[] UserSelected, Form tform, bool AbortHole,object[] UserSelectedValue)
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
            Hole Nwhole = shapeFactory.AddNewHoleWith2Constraints(Convert.ToDouble(HolePoint[0]), Convert.ToDouble(HolePoint[1]), Convert.ToDouble(HolePoint[2]), UserSelected[0], UserSelected[1], UserSelected[2], 50);//创建过孔
            RxSetHoleType(Nwhole, 10, Weight / 2, 9, RxHoleType.NSmoothHole);
            Spart.Update();
            Hole NwPinHole = shapeFactory.AddNewHoleWith2Constraints(Convert.ToDouble(HolePoint[0]) + 5, Convert.ToDouble(HolePoint[1]) + 5, Convert.ToDouble(HolePoint[2]), UserSelected[0], UserSelected[1], UserSelected[2], 50);//创建销孔
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
            if (AbortHole)
            {
                CreateThreadHole(Spart, UserSelected,UserSelectedValue,WeightEdge, LengthEdge, Weight, Length, JianDis);
            }
        }

        /// <summary>
        /// 创建螺纹孔安装面
        /// </summary>
        /// <param name="Spart">对象零件</param>
        /// <param name="UserSelected">用户选择参考对象2边1面</param>
        /// <param name="WeightEdge">宽边</param>
        /// <param name="LengthEdge">长边</param>
        /// <param name="Weight">宽边宽度</param>
        /// <param name="Length">长边长度</param>
        /// <param name="JianDis">孔间距</param>
        public void CreateThreadHole(Part Spart, Reference[] UserSelected, object[] UserSelectedValue, Edge WeightEdge, Edge LengthEdge, double Weight, double Length, double JianDis)
        {
            //对与孔装配的零件执行打孔
            object[] SHolePoint = new object[3];
            Selection SelectArc = CatActiveDoc.Selection;
            SelectArc.Clear();
            var Result = SelectArc.SelectElement2(InputObjectType(2), "请选择子零件孔支持面！", true);
            if (Result == "Cancel" || SelectArc == null || SelectArc.Count2 == 0)
            {
                return;
            }
            Reference SonReface = SelectArc.Item(1).Reference;
            GetProductByFace SGPB = new GetProductByFace();
            Part SonPart = SGPB.GetPart((Face)SelectArc.Item(1).Value);
            SelectArc.Item(1).GetCoordinates(SHolePoint);
            SelectArc.Clear();
            ShapeFactory NextshapeFactory = (ShapeFactory)SonPart.ShapeFactory;
            HybridShapeFactory NextHyShapeFactory = (HybridShapeFactory)SonPart.HybridShapeFactory;
            try
            {
                Reference Wref = null;
                Reference Lref = null;
                try
                {
                    //object[] LinePoint = new object[12];
                    //object[] LineDirection = new object[12];
                    //SPAWorkbench TheSPAWorkbench = (SPAWorkbench)CatActiveDoc.GetWorkbench("SPAWorkbench");
                    //Measurable LengthA = TheSPAWorkbench.GetMeasurable((Edge);
                    //Measurable LengthB = TheSPAWorkbench.GetMeasurable(LengthEdge);
                    //LengthA.GetMinimumDistancePoints(, LinePoint);
                    //LengthA.GetDirection(LineDirection);
                    //NextHyShapeFactory.AddNewLineNormal(SonReface, 10, 10, true);
                    Edge WeightEdgeT = (Edge)UserSelectedValue[0];
                    Edge LengthEdgeT = (Edge)UserSelectedValue[0];
                    string WeightEdgeName = WeightEdgeT.get_Name();
                    string LengthEdgeTName = LengthEdgeT.get_Name();
                    Wref = SonPart.CreateReferenceFromName(WeightEdgeName);
                    Lref = SonPart.CreateReferenceFromName(LengthEdgeTName);
                    WeightEdgeName = Wref.get_Name();
                    LengthEdgeTName = Lref.get_Name();
                    SelectArc.Add(WeightEdgeT);
                    SelectArc.Add(LengthEdgeT);
                    SelectArc.PasteLink();
                }
                catch (Exception e)
                {
                    throw e;
                }
                Hole SonNwhole = NextshapeFactory.AddNewHoleWith2Constraints(Convert.ToDouble(SHolePoint[0]), Convert.ToDouble(SHolePoint[1]), Convert.ToDouble(SHolePoint[2]), Wref, Lref, SonReface, 50);//创建过孔
                try
                {
                    RxSetHoleType(SonNwhole, 10, Weight / 2, 9, RxHoleType.NSmoothHole);
                }
                catch (Exception)
                {
                    RxSetHoleType(SonPart, SonNwhole, 10, Weight / 2, 9, RxHoleType.NSmoothHole, WeightEdge, LengthEdge);
                }
                SonPart.Update();
                Hole SonNwPinHole = NextshapeFactory.AddNewHoleWith2Constraints(Convert.ToDouble(SHolePoint[0]) + 5, Convert.ToDouble(SHolePoint[1]) + 5, Convert.ToDouble(SHolePoint[2]), UserSelected[0], UserSelected[1], SonReface, 50);//创建销孔
                RxSetHoleType(SonNwPinHole, 10, Weight / 2 + JianDis, 8, RxHoleType.PinHole);
                SonPart.Update();
                if (Length <= 60)
                {
                    RectPattern RPhole = NextshapeFactory.AddNewRectPattern(SonNwhole, 2, 1, JianDis * 2, 20, 1, 1, LengthEdge, WeightEdge, true, true, 0); //阵列过孔
                    RPhole.FirstRectangularPatternParameters = CatRectangularPatternParameters.catInstancesandSpacing;
                    RPhole.SecondRectangularPatternParameters = CatRectangularPatternParameters.catInstancesandSpacing;
                    Spart.Update();
                }
                else
                {
                    RectPattern RPhole = NextshapeFactory.AddNewRectPattern(SonNwhole, 2, 1, JianDis * 2, 20, 1, 1, LengthEdge, WeightEdge, true, true, 0); //阵列过孔
                    RPhole.FirstRectangularPatternParameters = CatRectangularPatternParameters.catInstancesandSpacing;
                    RPhole.SecondRectangularPatternParameters = CatRectangularPatternParameters.catInstancesandSpacing;

                    RectPattern RPinhole = NextshapeFactory.AddNewRectPattern(SonNwPinHole, 2, 1, JianDis * 2, 20, 1, 1, LengthEdge, WeightEdge, true, true, 0); //阵列过孔
                    RPinhole.FirstRectangularPatternParameters = CatRectangularPatternParameters.catInstancesandSpacing;
                    RPinhole.SecondRectangularPatternParameters = CatRectangularPatternParameters.catInstancesandSpacing;
                    Spart.Update();
                }
            }
            catch (Exception)
            {
                throw;
                MessageBox.Show("打孔失败！请确定选择是否有误！");
            }
        }
        /// <summary>
        /// 提取边到新Part
        /// </summary>
        /// <param name="Spart">新Part</param>
        /// <param name="UserSelected">用户选择的参考边</param>
        /// <returns>创建的新边</returns>
        public HybridShapeExtract NwExtraEdge(Part Spart, Reference UserSelected)
        {
            HybridShapeFactory PartShape = (HybridShapeFactory)Spart.ShapeFactory;
            HybridShapeExtract extractWeightEdge = PartShape.AddNewExtract(UserSelected);
            extractWeightEdge.PropagationType = 3;
            extractWeightEdge.ComplementaryExtract = false; //补充模式
            extractWeightEdge.IsFederated = false;
            HybridBodies PartHybodies = Spart.HybridBodies;
            HybridBody PartHyBody = PartHybodies.Item(1);
            PartHyBody.AppendHybridShape(extractWeightEdge);
            Spart.InWorkObject = extractWeightEdge;
            Spart.Update();
            return extractWeightEdge;
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
        /// 设置无尺寸约束的孔属性
        /// </summary>
        /// <param name="Nwhole">孔对象</param>
        /// <param name="LengthDis">孔距离长边距离</param>
        /// <param name="WeightDis">孔距离短边距离</param>
        /// <param name="Diameter">孔直径</param>
        /// <param name="HoleType">孔类型</param>
        /// <param name="Comstraints">1:宽边，2：长边</param>
        private void RxSetHoleType(Part Tpart, Hole Nwhole, double LengthDis, double WeightDis, double Diameter, RxHoleType HoleType, Edge WidthEdge, Edge LengthEdge)
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
            int Cont = Hosketch.GeometricElements.Count;
            string Type = Hosketch.GeometricElements.Item(2).get_Name();
            Point2D HoleCenterPoint = (Point2D)Hosketch.GeometricElements.Item(2);
            Reference refPoint = Tpart.CreateReferenceFromObject(HoleCenterPoint);
            if (HoleConstraint.Count < 3)
            {
                Tpart.InWorkObject = Hosketch;
                Factory2D factory2D = Hosketch.OpenEdition();
                GeometricElements geWidthEdge = factory2D.CreateProjections(WidthEdge);
                GeometricElements geLengthEdge = factory2D.CreateProjections(LengthEdge);
                Geometry2D geoWidthEdge = (Geometry2D)geWidthEdge.Item("标记.1");
                Geometry2D geoLengthEdge = (Geometry2D)geLengthEdge.Item("标记.1");
                geoWidthEdge.Construction = true;
                geoLengthEdge.Construction = true;
                Reference EpWidth = Tpart.CreateReferenceFromObject(geoWidthEdge);
                Reference EpLength = Tpart.CreateReferenceFromObject(geoLengthEdge);
                //geo1.Construction = true;
                Constraint holeConstraintL = HoleConstraint.AddBiEltCst(CatConstraintType.catCstTypeDistance, refPoint, EpWidth);
                Constraint holeConstraintW = HoleConstraint.AddBiEltCst(CatConstraintType.catCstTypeDistance, refPoint, EpLength);
                holeConstraintL.Dimension.Value = WeightDis; //孔距离宽边的距离
                holeConstraintW.Dimension.Value = LengthDis; //孔距离长边的距离
                Hosketch.CloseEdition();
            }
            else
            {
                HoleConstraint.Item(1).Dimension.Value = WeightDis; //孔距离宽边的距离
                HoleConstraint.Item(2).Dimension.Value = LengthDis; //孔距离长边的距离
            }

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
                case RxHoleType.NSmoothHole: //光孔
                    HoleSet.SetVisibleColor(167, 230, 182, 0);
                    break;
                case RxHoleType.ISmoothHole: //沉头孔
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
                        return new object[] { "Part" };
                    }
                case 9: //Product
                    {
                        return new object[] { "Product" };
                    }
                case 10: //Line
                    {
                        return new object[] { "Line" };
                    }
                case 11: //line2d
                    {
                        return new object[] { "Line2D" };
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
