using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.Geometry;
using System.Data;
using System.Reflection;
using AutoDeskLine_ToPlant;

namespace AutoDeskLK
{
    public class Mctrol
    {
        [CommandMethod("GetDate")]
        public static void GetDate()
        {
            CadRead CR = new CadRead();
            CR.ShowDialog();
            //Document Doc = Application.DocumentManager.MdiActiveDocument;
            //Editor Editor = Doc.Editor;
            //PromptSelectionResult Rest = Editor.GetSelection();
            //if (Rest.Status == PromptStatus.OK) return;
            //Application.ShowAlertDialog("第一个选中集中实体的数量:" + Rest.Value.Count.ToString());
        }
    }
}
