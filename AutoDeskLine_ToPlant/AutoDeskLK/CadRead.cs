using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Interop;
using System.Reflection;
using AutoDeskLine_ToPlant;



namespace AutoDeskLK
{
    public partial class CadRead : Form
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
        AcadApplication tAcadApplication = null;
        System.Data.DataTable datatable = new System.Data.DataTable();
        System.Data.DataColumn dataColum;
        DataRow DataRow;
        DataView dataview;
        int index = 0;
        /// <summary>
        /// 参考点
        /// </summary>
        double[] RefPoint = new double[3];
        public CadRead()
        {
            InitializeComponent();
            //try
            //{
            //    tAcadApplication = (AcadApplication)Marshal.GetActiveObject("AutoCAD.Application");
            //    string AcadPath = tAcadApplication.Path;
            //    Assembly.LoadFrom(AcadPath + "\\acmgd.dll");
            //    Assembly.LoadFrom(AcadPath + "\\acdbmgd.dll");
            //    Assembly.LoadFrom(AcadPath + "\\accoremgd.dll");
            //}
            //catch (System.Exception)
            //{
            //    MessageBox.Show("尚未运行AutoCAD 软件 必备运行库未加载");
            //}
            timer.Enabled = true;
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "序号";
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
            dataColum.ColumnName = "R角";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "TrackType";
            datatable.Columns.Add(dataColum);
        }
        private void SetRefPoint_Click(object sender, EventArgs e)
        {
            // AutoCAD.AcadApplication Cad = new AutoCAD.AcadApplication();
            try
            {
                int Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                int heigh = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                tAcadApplication.Width = Width;
                tAcadApplication.Height = heigh;
            }
            catch (System.Exception)
            {
            }
            this.WindowState = FormWindowState.Minimized;
            try
            {
                tAcadApplication = (AcadApplication)Marshal.GetActiveObject("AutoCAD.Application");
                if (tAcadApplication.Name == "AutoCAD")
                {
                    tAcadApplication.Visible = true;
                    AcadDocument caddocument = tAcadApplication.ActiveDocument;
                    caddocument.Activate();
                    try
                    {
                        caddocument.Utility.Prompt("请选择一个基准点:");
                        var point = caddocument.Utility.GetPoint();
                        RefPoint = point;
                        SX_AIX.Text = Convert.ToString(point[0]);
                        SY_AIX.Text = Convert.ToString(point[1]);
                        this.WindowState = FormWindowState.Maximized;
                    }
                    catch (System.Exception)
                    {
                        this.WindowState = FormWindowState.Maximized;
                        MessageBox.Show("UCS创建失败！e02" + e);
                    }
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                    MessageBox.Show("请先打开AutoCad!+e00");
                }
            }
            catch (System.Exception)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show("请先打开AutoCad!");
            }


        }

        private void ManulInputPoint_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            try
            {
                tAcadApplication = (AcadApplication)Marshal.GetActiveObject("AutoCAD.Application");
                if (tAcadApplication.Name == "AutoCAD")
                {
                    tAcadApplication.Visible = true;
                    AcadDocument caddocument = tAcadApplication.ActiveDocument;
                    caddocument.Activate();
                    try
                    {
                        do
                        {
                            double[] point = new double[3];
                            caddocument.Utility.Prompt("请选择一个点:");
                            try
                            {

                                point = caddocument.Utility.GetPoint();
                                caddocument.Utility.Prompt("如果取消继续输入请按ESC,");
                            }
                            catch (System.Exception)
                            {
                                break;
                            }
                            try
                            {
                                double[] Tpoint = CadOprator.TackAix(point, RefPoint, ApplyPlantAix.Checked);
                                if (Tpoint.Length == 3)
                                {
                                    DataRow = datatable.NewRow();
                                    DataRow["序号"] = index;
                                    DataRow["X坐标"] = Convert.ToString(Tpoint[0]);
                                    DataRow["Y坐标"] = Convert.ToString((Tpoint[1]));
                                    DataRow["Z坐标"] = Convert.ToString((Tpoint[2]));
                                    DataRow["R角"] = Convert.ToString(0);
                                    String Ttrack = string.Empty;
                                    if (SingeRoadSelected.Checked)
                                    {
                                        Ttrack = "SingerTrack";
                                    }
                                    else
                                    {
                                        Ttrack = "DoubleTrack";
                                    }
                                    DataRow["TrackType"] = Ttrack;
                                    datatable.Rows.Add(DataRow);
                                    dataview = new DataView(datatable);
                                    DataGrid.DataSource = dataview;
                                    DataGrid.Update();
                                    index += 1;
                                }
                            }
                            catch (System.Exception)
                            {

                                throw;
                            }
                        }
                        while (index != 99999);
                        this.WindowState = FormWindowState.Maximized;
                    }
                    catch (System.Exception)
                    {
                        this.WindowState = FormWindowState.Maximized;
                        //MessageBox.Show("UCS创建失败！e02" + e);
                    }
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                    //MessageBox.Show("请先打开AutoCad!+e00");
                }
            }
            catch (System.Exception)
            {
                this.WindowState = FormWindowState.Maximized;
                //MessageBox.Show("请先打开AutoCad!");
            }
        }

        private void ClearData_Click(object sender, EventArgs e)
        {
            datatable.Clear();
            dataview = new DataView(datatable);
            DataGrid.DataSource = dataview;
            DataGrid.Update();
            index = 0;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.FindForm().Text = "AutoDesk导出坐标BY_安徽瑞祥工业【工厂仿真组】叶朝成_当前时间: " + DateTime.Now.ToString();
        }
        /// <summary>
        /// 路径坐标运算
        /// </summary>
        /// <param name="NewAIX">新坐标值Double[3]</param>
        /// <returns></returns>
        public bool AixOprate(double[] NewAIX)
        {
            if (SX_AIX.Text == string.Empty || SY_AIX.Text == string.Empty)
            {
                MessageBox.Show("未初始化参考坐标！请先初始化参考坐标系！");
                return false;
            }
            if (NewAIX != null && NewAIX.Length == 3)
            {
                double x, y, z;
                x = NewAIX[0];
                y = NewAIX[1];
                z = NewAIX[2];
                if (ApplyPlantAix.Checked)
                {
                    x = (NewAIX[0] - RefPoint[0]) / 1000 * 20;
                    y = (NewAIX[1] - RefPoint[1]) / 1000 * 20;
                    z = (NewAIX[2] - RefPoint[2]) / 1000 * 20;
                }
                else
                {
                    x = (NewAIX[0] - RefPoint[0]);
                    y = (NewAIX[1] - RefPoint[1]);
                    z = (NewAIX[2] - RefPoint[2]);
                }
                DataRow = datatable.NewRow();
                DataRow["序号"] = index;
                DataRow["X坐标"] = Convert.ToString(x);
                DataRow["Y坐标"] = Convert.ToString(y);
                DataRow["Z坐标"] = Convert.ToString(z);
                datatable.Rows.Add(DataRow);
                dataview = new DataView(datatable);
                DataGrid.DataSource = dataview;
                DataGrid.Update();
                index += 1;
                return true;
            }
            else
            {
                MessageBox.Show("输入坐标为空或坐标值长度错误！");
                return false;
            }

        }

        private void DeleteData_Click(object sender, EventArgs e)
        {
            datatable.Rows.Remove(datatable.Rows[index - 1]);
            dataview = new DataView(datatable);
            DataGrid.DataSource = dataview;
            DataGrid.Update();
            index -= 1;
        }

        private void ManulInputLine_Click(object sender, EventArgs e)
        {
            tAcadApplication = (AcadApplication)Marshal.GetActiveObject("AutoCAD.Application");
            Console.Write("AAA");
            CadOprator.ReadSingeLine();
        }

        private void OutExcel_Click(object sender, EventArgs e)
        {
            RxDataOprator.ExcelOprator.SaveExcelForLvSport(this.DataGrid, "Cad路径坐标值");
        }
    }
}
