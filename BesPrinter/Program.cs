using System;
using System.Collections.Generic;
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
            ExeModeManager exeMode = ExeModeManager.AnaliseModeFromArgs(args);

            if (exeMode.mode == EXE_MODE.MODE_FORMAT_CONVERT)
            {
                exeMode.returnCode = ImageHelper.ConvertImageByPath(exeMode.pathFrom, exeMode.pathTo,
                    exeMode.formatFrom, exeMode.formatTo);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain(exeMode));
                exeMode.returnCode = 0;
            }

            return exeMode.returnCode;
        }
    }
}
