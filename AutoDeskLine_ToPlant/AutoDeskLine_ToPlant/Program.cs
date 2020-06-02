using Autodesk.AutoCAD.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Security.Principal;
using System.Diagnostics;
using eMPlantLib;

namespace AutoDeskLine_ToPlant
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread] //单线程设置
        //[MTAThread] //多线程设置
        [DllImportAttribute("kernel32.dll", EntryPoint = "OpenProcess")]
        public static extern IntPtr OpenProcess
     (
         int dwDesiredAccess,
         bool bInheritHandle,
         int dwProcessId
     );
        static void Main()
        {
            //AppCenter.Start("9005f00b-d016-46c8-ae25-7303e7095dfd", typeof(Analytics), typeof(Crashes));
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            bool RunAdmin = identity != null && new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator);
            if (!RunAdmin)
            {
                try
                {
                    Process.Start(new ProcessStartInfo(Assembly.GetEntryAssembly().CodeBase) { UseShellExecute = true, Verb = "runs" });
                }
                catch (Exception)
                {
                    //MessageBox.Show(string.Format("以管理员方式启动失败，将尝试以普通方式启动！{0}{1}", Environment.NewLine, ex), "出错啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // run();//以管理员方式启动失败，则尝试普通方式启动
                    MessageBox.Show("管理员运行失败");
                }
            }
            System.Windows.Forms.Application.Run(new Main());
        }
    }
}
