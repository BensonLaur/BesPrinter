using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BesPrinter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            //AppConfig.config.SetPrinterConfigName("default");
            // zh  en ko
            //AppConfig.config.SetLanguage("ko");
            string lang = AppConfig.config.GetLanguage();
            
            //获得运行模式
            ExeModeManager exeMode = ExeModeManager.AnaliseModeFromArgs(args);

            if (exeMode.mode == EXE_MODE.MODE_END)//发生错误，直接返回
                return -1;
            if (exeMode.mode == EXE_MODE.MODE_FORMAT_CONVERT)
            {
                if(exeMode.pathTo == null)
                {
                    exeMode.returnCode = ImageHelper.ConvertImageByPath(exeMode.pathFrom,
                        exeMode.formatFrom, exeMode.formatTo);
                }
                else
                {
                    exeMode.returnCode = ImageHelper.ConvertImageByPath(exeMode.pathFrom, exeMode.pathTo,
                        exeMode.formatFrom, exeMode.formatTo);
                }
            }
            else
            {
                if (!lang.Equals("") && !lang.Equals("zh"))
                {
                    //设置全局运行的语言设置，初始化窗口时会根据设置选择界面翻译
                    System.Threading.Thread.CurrentThread.CurrentUICulture = AppConfig.config.GetCultrueInfo();
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain(exeMode));
                exeMode.returnCode = 0;
            }

            return exeMode.returnCode;
        }
    }
}
