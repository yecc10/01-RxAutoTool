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

namespace AutoDeskLine_ToPlant
{
    public partial class CatiaQuickTool : Form
    {
        INFITF.Application CatApplication;
        ProductDocument CatDocument;
        System.Data.DataTable datatable = new System.Data.DataTable();
        System.Data.DataColumn dataColum;
        DataRow DataRow;
        DataView dataview;
        Part PartID;
        /// <summary>
        /// Value=1->Read Point;Value=2->AnyPoint
        /// </summary>
        int ReadType = 0;
        public CatiaQuickTool()
        {
            InitializeComponent();
            timer.Enabled = true;
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "序号";
            datatable.Columns.Add(dataColum);

            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "名称";
            datatable.Columns.Add(dataColum);

            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "X坐标";
            datatable.Columns.Add(dataColum);

            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "Y坐标";
            datatable.Columns.Add(dataColum);

            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "Z坐标";
            datatable.Columns.Add(dataColum);

            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "RX";
            datatable.Columns.Add(dataColum);

            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "RY";
            datatable.Columns.Add(dataColum);

            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "RZ";
            datatable.Columns.Add(dataColum);
        }
        private void TryRead_Click(object sender, EventArgs e)
        {
            ReadType = 2;
            Selection SelectArc = GetSelect();
            if (SelectArc == null || SelectArc.Count2 == 0)
            {
                return;
            }
            int ERR = 0;
            object[] PointCoord = new object[] { -99, -99, -99 };
            for (int i = 1; i <= SelectArc.Count2; i++)
            {
                HybridShapeFactory PartHyb = (HybridShapeFactory)PartID.HybridShapeFactory;
                SPAWorkbench TheSPAWorkbench = (SPAWorkbench)CatDocument.GetWorkbench("SPAWorkbench");
                Reference referenceObject = SelectArc.Item(i).Reference;
                Measurable TheMeasurable = TheSPAWorkbench.GetMeasurable(referenceObject);
                TheMeasurable.GetPoint(PointCoord); //读取选择的曲面坐标
                var TName = referenceObject.get_Name(); //读取选择的曲面名称
                HybridShapePointCoord NewPoint = PartHyb.AddNewPointCoord(Convert.ToDouble(PointCoord[0]), Convert.ToDouble(PointCoord[1]), Convert.ToDouble(PointCoord[2]));
                if (KeepName.Checked)
                {
                    NewPoint.set_Name(TName);
                }
                else
                {
                    NewPoint.set_Name("YPoint_" + i);
                }
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
                    ERR += 1;
                }
            }
            if (ERR > 0)
            {
                MessageBox.Show("共计:" + ERR + "个点创建新参考点失败！");
            }

        }

        private void CatiaQuickTool_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)]
        public object[] InputObjectType()
        {
            switch (ReadType)
            {
                case 1: //GetPoint
                    {
                        return new object[] { "Point", "Symmetry", "Translate" };
                    }
                case 2: //GetAnyObject
                    {
                     return new object[] { "AnyObject" };
                    }
                default:
                    return new object[] { "AnyObject" };
            }
        }

        private void OutToEXcel_Click(object sender, EventArgs e)
        {
            RxDataOprator.ExcelOprator.SaveExcelForLvSport(this.DataGrid, "Cad路径坐标值");
        }

        private void BollToPoint_Click(object sender, EventArgs e)
        {
            ReadType = 2;
            Selection SelectArc = GetSelect();
            if (SelectArc == null || SelectArc.Count2==0)
            {
                return;
            }
            int ERR = 0;
            object[] PointCoord = new object[] { -99, -99, -99 };
            for (int i = 1; i <= SelectArc.Count2; i++)
            {
                HybridShapeFactory PartHyb = (HybridShapeFactory)PartID.HybridShapeFactory;
                SPAWorkbench TheSPAWorkbench = (SPAWorkbench)CatDocument.GetWorkbench("SPAWorkbench");
                Reference referenceObject = SelectArc.Item(i).Reference;
                Measurable TheMeasurable = TheSPAWorkbench.GetMeasurable(referenceObject);
                TheMeasurable.GetPoint(PointCoord); //读取选择的曲面坐标
                var TName = referenceObject.get_Name(); //读取选择的曲面名称
                HybridShapePointCoord NewPoint = PartHyb.AddNewPointCoord(Convert.ToDouble(PointCoord[0]), Convert.ToDouble(PointCoord[1]), Convert.ToDouble(PointCoord[2]));
                if (KeepName.Checked)
                {
                    NewPoint.set_Name(TName);
                }
                else
                {
                    NewPoint.set_Name("Rx_" + i);
                }
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
                    ERR += 1;
                }
            }
            if (ERR > 0)
            {
                MessageBox.Show("共计:" + ERR + "个点创建新参考点失败！");
            }

        }

        private void AutoHole_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private bool WriteObjectToDataGrid(string Name, object[] PointData)
        {
            try
            {
                int keepValuePoint = Convert.ToInt16(2);
                DataRow = datatable.NewRow();
                DataRow["序号"] = DataGrid.RowCount + 1;
                DataRow["名称"] = Name;//Convert.ToDouble(PointCoord[0]), Convert.ToDouble(PointData[1]), Convert.ToDouble(PointData[2])
                DataRow["X坐标"] = Math.Round(Convert.ToDouble(PointData[0]), keepValuePoint);
                DataRow["Y坐标"] = Math.Round(Convert.ToDouble(PointData[1]), keepValuePoint);
                DataRow["Z坐标"] = Math.Round(Convert.ToDouble(PointData[2]), keepValuePoint);
                DataRow["RX"] = Math.Round(Convert.ToDouble(PointData[3]), keepValuePoint); ;
                DataRow["RY"] = Math.Round(Convert.ToDouble(PointData[4]), keepValuePoint); ;
                DataRow["RZ"] = Math.Round(Convert.ToDouble(PointData[5]), keepValuePoint); ;
                datatable.Rows.Add(DataRow);
                dataview = new DataView(datatable);
                DataGrid.DataSource = dataview;
                DataGrid.Update();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }

        }

        private void ReadCoord_Click(object sender, EventArgs e)
        {
            ReadType = 2;
            Selection SelectArc = GetSelect();
            if (SelectArc == null || SelectArc.Count2 == 0)
            {
                return;
            }
            int ERR = 0;
            object[] PointCoord = new object[] { -99, -99, -99, -99, -99, -99 };
            for (int i = 1; i <= SelectArc.Count2; i++)
            {
                HybridShapeFactory PartHyb = (HybridShapeFactory)PartID.HybridShapeFactory;
                SPAWorkbench TheSPAWorkbench = (SPAWorkbench)CatDocument.GetWorkbench("SPAWorkbench");
                Reference referenceObject = SelectArc.Item(i).Reference;
                Measurable TheMeasurable = TheSPAWorkbench.GetMeasurable(referenceObject);
                var TName = referenceObject.get_Name(); //读取选择的曲面名称
                try
                {
                    TheMeasurable.GetPoint(PointCoord); //读取选择的曲面坐标
                }
                catch (Exception)
                {
                    ERR += 1;
                }
                if (!KeepName.Checked)
                {
                    TName = "Rx_" + (DataGrid.RowCount + 1);
                }
                WriteObjectToDataGrid(TName, PointCoord);
            }
            if (ERR > 0)
            {
                MessageBox.Show("共计:" + ERR + "个点创建新参考点失败！");
            }
        }

        private void ClearAllData_Click(object sender, EventArgs e)
        {
            datatable.Clear();
            dataview = new DataView(datatable);
            DataGrid.DataSource = dataview;
            DataGrid.Update();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.FindForm().Text = "瑞祥快捷设计中心 BY_安徽瑞祥工业【工厂仿真组】叶朝成_当前时间: " + DateTime.Now.ToString();
        }

        private void PointToCoord_Click(object sender, EventArgs e)
        {
            ReadType = 1;
            Selection SelectArc = GetSelect();
            if (SelectArc == null || SelectArc.Count2 == 0)
            {
                return;
            }
            int ERR = 0;
            object[] PointCoord = new object[] { -99, -99, -99, -99, -99, -99 };
            for (int i = 1; i <= SelectArc.Count2; i++)
            {
                HybridShapeFactory PartHyb = (HybridShapeFactory)PartID.HybridShapeFactory;
                SPAWorkbench TheSPAWorkbench = (SPAWorkbench)CatDocument.GetWorkbench("SPAWorkbench");
                Reference referenceObject = SelectArc.Item(i).Reference;
                Measurable TheMeasurable = TheSPAWorkbench.GetMeasurable(referenceObject);
                TheMeasurable.GetPoint(PointCoord); //读取选择的曲面坐标
                var TName = referenceObject.get_Name(); //读取选择的曲面名称
                if (!KeepName.Checked)
                {
                    TName = "Rx_" + (DataGrid.RowCount + 1);
                }
                WriteObjectToDataGrid(TName, PointCoord);
            }
            if (ERR > 0)
            {
                MessageBox.Show("共计:" + ERR + "个点创建新参考点失败！");
            }
        }
        /// <summary>
        /// 连接CATIA COM 并获得选择集
        /// </summary>
        /// <returns></returns>
        private Selection GetSelect()
        {
            this.WindowState = FormWindowState.Minimized;
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
                    return null;
                }
                MessageBox.Show("未检测到活动Product,已自动为您创建对象！");
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
                VP =(VisPropertySet) VP.Parent;
                VP.SetShow(CatVisPropertyShow.catVisPropertyNoShowAttr);
                SelectT.Clear();
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
            var Result = SelectArc.SelectElement3(InputObjectType(), "请选择曲面", true, CATMultiSelectionMode.CATMultiSelTriggWhenSelPerf, false);
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

        private bool GetSelect(bool InitFrame)
        {
            this.WindowState = FormWindowState.Minimized;
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
                    return true;
                }
                MessageBox.Show("未检测到活动Product,已自动为您创建对象！");
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
            try
            {
                CatDocument.Product.ApplyWorkMode(CatWorkModeType.DESIGN_MODE);
            }
            catch (Exception)
            {
                Console.WriteLine("Change Design Model Faild!");
            }
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            return true;
        }

        [STAThread]
        private void Aix_To_Ball_Click(object sender, EventArgs e)
        {
            ReadAixPoint.BackColor = SystemColors.ActiveCaption;
            System.Threading.Thread importThread = new System.Threading.Thread(new ThreadStart(xlsPath));
            importThread.SetApartmentState(ApartmentState.STA); //重点
            importThread.Start();
        }
        public void xlsPath()
        {
            CheckForIllegalCrossThreadCalls = false;
            string Path = string.Empty;
            OpenFileDialog XlsFile = new OpenFileDialog();
            XlsFile.InitialDirectory = "C:\\Users\\Administrator\\Desktop\\";
            XlsFile.Filter = "EXCEL files (*.xls,*.xlsx)|*.xls;*.xlsx";
            XlsFile.FilterIndex = 2;
            XlsFile.RestoreDirectory = true;
            XlsFile.Multiselect = false;
            if (XlsFile.ShowDialog() == DialogResult.OK)
            {
                RxDataOprator.ExcelOprator.ReadXlsData(XlsFile.FileName,DataGrid);
                DataGrid.Update();
                ReadAixPoint.BackColor = Color.Green;
            }
        }

        private void Creat3dPoint_Click(object sender, EventArgs e)
        {
            Creat3dPoint.BackColor = SystemColors.ActiveCaption;
            ReadType = 2;
            bool SelectArc = GetSelect(false);
            if (SelectArc ==false)
            {
                return;
            }
            int ERR = 0;

            for (int i = 0; i < DataGrid.RowCount; i++)
            {
                HybridShapeFactory PartHyb = (HybridShapeFactory)PartID.HybridShapeFactory;
                var TName = DataGrid.Rows[i].Cells[1].Value.ToString(); //读取选择的曲面名称
                HybridShapePointCoord NewPoint = PartHyb.AddNewPointCoord(Convert.ToDouble(DataGrid.Rows[i].Cells[2].Value.ToString()), Convert.ToDouble(DataGrid.Rows[i].Cells[3].Value.ToString()), Convert.ToDouble(DataGrid.Rows[i].Cells[4].Value.ToString()));
                if (KeepName.Checked)
                {
                    NewPoint.set_Name(TName);
                }
                else
                {
                    NewPoint.set_Name("Rx_" + (i+1));
                }
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
                    ERR += 1;
                }
            }
            if (ERR > 0)
            {
                MessageBox.Show("共计:" + ERR + "个点创建新参考点失败！");
            }
            Creat3dPoint.BackColor = Color.Green;
        }

        private void Creat3dBall_Click(object sender, EventArgs e)
        {
            Creat3dPoint.BackColor = SystemColors.ActiveCaption;
            ReadType = 2;
            bool SelectArc = GetSelect(false);
            if (SelectArc == false)
            {
                return;
            }
            int ERR = 0;

            for (int i = 0; i < DataGrid.RowCount; i++)
            {
                HybridShapeFactory PartHyb = (HybridShapeFactory)PartID.HybridShapeFactory;
                //SPAWorkbench TheSPAWorkbench = (SPAWorkbench)CatDocument.GetWorkbench("SPAWorkbench");
                //Reference referenceObject = SelectArc.Item(i).Reference;
                //Measurable TheMeasurable = TheSPAWorkbench.GetMeasurable(referenceObject);
                //TheMeasurable.GetPoint(PointCoord); //读取选择的曲面坐标
                var TName = DataGrid.Rows[i].Cells[1].Value.ToString(); //读取选择的曲面名称
                HybridShapePointCoord NewPoint = PartHyb.AddNewPointCoord(Convert.ToDouble(DataGrid.Rows[i].Cells[2].Value.ToString()), Convert.ToDouble(DataGrid.Rows[i].Cells[3].Value.ToString()), Convert.ToDouble(DataGrid.Rows[i].Cells[4].Value.ToString()));
                if (KeepName.Checked)
                {
                    NewPoint.set_Name(TName);
                }
                else
                {
                    NewPoint.set_Name("Rx_" + (i + 1));
                }
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
                    ERR += 1;
                }
            }
            if (ERR > 0)
            {
                MessageBox.Show("共计:" + ERR + "个点创建新参考点失败！");
            }
            Creat3dPoint.BackColor = Color.Green;
        }
    }
}
