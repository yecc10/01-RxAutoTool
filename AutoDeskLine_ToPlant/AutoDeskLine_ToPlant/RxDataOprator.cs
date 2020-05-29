using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.OpenXml4Net;
using NPOI.Util;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace AutoDeskLine_ToPlant
{
    static public class RxDataOprator
    {
        /// <summary>
        /// Excel操作
        /// </summary>
        static public class ExcelOprator
        {
            /// <summary>
            /// 将dataGridView导出到EXCEL
            /// </summary>
            /// <param name="dataGridView">需要导出的dataGridView数据</param>
            /// <returns></returns>
            static public bool SaveExcelForLvSport(DataGridView dataGridView, string SportName)
            {
                if (dataGridView.Rows.Count > 1)
                {
                    HSSFWorkbook wkb = new HSSFWorkbook();
                    ISheet sheet = wkb.CreateSheet("瑞祥工业物流组");
                    sheet.DefaultColumnWidth = 15;
                    IRow HeadRow = sheet.CreateRow(0);
                    HeadRow.Height = 400;
                    ICellStyle CST = wkb.CreateCellStyle();
                    CST.VerticalAlignment = VerticalAlignment.Center;
                    CST.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                    for (int i = 0; i < dataGridView.Rows[1].Cells.Count; i++) //初始化表头
                    {
                        ICell HeadCell = HeadRow.CreateCell(i);
                        HeadCell.SetCellValue(dataGridView.Columns[i].HeaderText);
                        HeadCell.CellStyle = CST;
                    }
                    for (int i = 0; i < dataGridView.Rows.Count; i++) //依次遍历全部行
                    {
                        IRow DataRow = sheet.CreateRow(i + 1);
                        DataRow.RowStyle = CST;
                        DataRow.Height = 400;
                        for (int j = 0; j < dataGridView.Rows[i].Cells.Count; j++) //读取每行中所有列
                        {
                            ICell DataCell = DataRow.CreateCell(j);
                            DataCell.SetCellValue(dataGridView.Rows[i].Cells[j].Value.ToString());
                            DataCell.CellStyle = CST;
                        }
                    }

                    string datatime = DateTime.Now.ToString("yyyymmddHHmmssffff");
                    string strDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                    string path = strDesktopPath + "\\瑞祥工业工厂仿真组" + datatime + ".xls";
                    FileStream file = new FileStream(path, FileMode.OpenOrCreate);
                    wkb.Write(file);
                    file.Flush();
                    file.Close();
                    wkb = null;
                    MessageBox.Show("文件已保持到本地桌面！");
                    return true;
                }
                else
                {
                    MessageBox.Show("数据表中不存在任何数据，没有必要导出！");
                    return false;
                }
            }
            static public bool ReadXlsData(string xlsPath, DataGridView DG)
            {
                //DataGridView DG = new DataGridView();
                int RowNum = 0;
                try
                {
                    IWorkbook xlsBook = WorkbookFactory.Create(xlsPath);
                    ISheet sheet = xlsBook.GetSheetAt(0);
                    RxTypeList.CatPointType CP = new RxTypeList.CatPointType();
                    for (int i = 0; i <= sheet.LastRowNum; i++)
                    {
                        IRow Row = sheet.GetRow(i);
                        RowNum = Row.LastCellNum;
                        if (i == 0) //初始化表头
                        {
                            if (RowNum == 3 || RowNum == 4 || RowNum == 7 || RowNum == 8)
                            {
                                DG.DataSource = null;
                                DG.AllowUserToAddRows = true;
                                if (DG.ColumnCount>0)
                                {
                                    DG.Columns.Remove("序号");
                                    DG.Columns.Remove("名称");
                                    DG.Columns.Remove("X坐标");
                                    DG.Columns.Remove("Y坐标");
                                    DG.Columns.Remove("Z坐标");
                                    DG.Columns.Remove("RX");
                                    DG.Columns.Remove("RY");
                                    DG.Columns.Remove("RZ");
                                }
                                DG.Columns.Add("序号", "序号");
                                DG.Columns.Add("名称", "名称");
                                DG.Columns.Add("X坐标", "X坐标");
                                DG.Columns.Add("Y坐标", "Y坐标");
                                DG.Columns.Add("Z坐标", "Z坐标");
                                DG.Columns.Add("RX", "RX");
                                DG.Columns.Add("RY", "RY");
                                DG.Columns.Add("RZ", "RZ");
                            }
                            else
                            {
                                MessageBox.Show("所提供的EXCEL 文件格式不符合默认标准请提供4列(名称、X、Y、Z)、7列(带角度)、8列(多序号)的Xls表!");
                                return false;
                            }

                        }
                        else
                        {
                            string CheckValue = Row.GetCell(0).StringCellValue;
                            if (string.IsNullOrEmpty(CheckValue))
                            {
                                continue;
                            }
                            try
                            {
                                switch (RowNum)
                                {
                                    case 3:
                                        {
                                            DG.Rows.Add(i, "RX_" + i, Row.GetCell(0), Row.GetCell(1), Row.GetCell(2), 0, 0, 0);
                                            break;
                                        }
                                    case 4:
                                        {
                                            DG.Rows.Add(i, Row.GetCell(0), Row.GetCell(1), Row.GetCell(2), Row.GetCell(3), 0, 0, 0);
                                            break;
                                        }
                                    case 7:
                                        {
                                            DG.Rows.Add(i, Row.GetCell(0), Row.GetCell(1), Row.GetCell(2), Row.GetCell(3), Row.GetCell(4), Row.GetCell(5), Row.GetCell(6));
                                            break;
                                        }
                                    case 8:
                                        {
                                            DG.Rows.Add(i, Row.GetCell(1), Row.GetCell(2), Row.GetCell(3), Row.GetCell(4), Row.GetCell(5), Row.GetCell(6), Row.GetCell(7));
                                            break;
                                        }
                                    default:
                                        break;
                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }
                    }

                    return true;
                }
                catch (Exception)
                {
                    MessageBox.Show("打开失败!请确认是否已解密？");
                }
                return false;
            }
            /// <summary>
            /// 读取EXCEL焊点坐标数据
            /// </summary>
            static public string oPenXls()
            {
                //HSSFWorkbook wkb = new HSSFWorkbook();
                Stream myStream = null;
                OpenFileDialog XlsFile = new OpenFileDialog();
                XlsFile.InitialDirectory = "C:\\Users\\Administrator\\Desktop\\";
                XlsFile.Filter = "EXCEL files (*.xls,*.xlsx)|*.xls;*.xlsx";
                XlsFile.FilterIndex = 2;
                XlsFile.RestoreDirectory = true;
                if (XlsFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((myStream = XlsFile.OpenFile()) != null)
                        {
                            return XlsFile.FileName;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
                return null;
            }
        }
    }
}
