using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CrawlProxyIPTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //加载嵌入的DLL文件
            LoadResourceDll.RegistDLL();

            //加载界面
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
