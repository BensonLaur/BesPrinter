using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BesPrinter
{
    public enum EXE_MODE
    {
        MODE_NORMAL = 0,           //完全正常模式——什么参数都不传, 无参数启动: exe 
        MODE_INIT_PATH = 1,        //初始路径模式——传入一个初始路径: exe 1 "init/file/or/floder/path"
        MODE_SINGLE_IMAGE = 2,     //单图查看模式——传入一个文件路径：exe 2 "image/file/path"
        MODE_FORMAT_CONVERT = 3,   //格式转换模式——传入2个格式后缀，2个路径： exe 3 format1 format2 "path1" "path2"
        MODE_END                   //         或者 传入2个格式后缀，1个路径： exe 3 format1 format2 "path"
    }

    public class ExeModeManager
    {
        //分析得到运行模式相关数据
        static public ExeModeManager AnaliseModeFromArgs(string[] args)
        {
            ExeModeManager exeMode = new ExeModeManager();

            if(args.Length > 0)
            {
                //读取模式
                EXE_MODE mode = EXE_MODE.MODE_NORMAL;
                try
                {
                    mode = (EXE_MODE)int.Parse(args[0]);
                }
                catch(Exception)
                {
                    mode = EXE_MODE.MODE_NORMAL;
                }
                finally
                {
                    if (mode < EXE_MODE.MODE_NORMAL || mode >= EXE_MODE.MODE_END)
                        mode = EXE_MODE.MODE_NORMAL;
                }

                //根据模式，进一步读取相关参数
                switch((EXE_MODE)int.Parse(args[0]))
                {
                    case EXE_MODE.MODE_NORMAL:
                        break;
                    case EXE_MODE.MODE_INIT_PATH:
                        {
                            if (args.Length == 2)
                                exeMode.initPath = args[1];
                            else
                                mode = EXE_MODE.MODE_NORMAL;
                        }
                        break;
                    case EXE_MODE.MODE_SINGLE_IMAGE:
                        {
                            if (args.Length == 2)
                            {
                                exeMode.singleImagePath = args[1];

                                if(!File.Exists(exeMode.singleImagePath))
                                {
                                    MessageBox.Show($"Invalid image path: {exeMode.singleImagePath}", 
                                        "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    mode = EXE_MODE.MODE_NORMAL;
                                }
                            }
                            else
                                mode = EXE_MODE.MODE_NORMAL;
                        }
                        break;
                    case EXE_MODE.MODE_FORMAT_CONVERT:
                        {
                            if (args.Length == 4 || args.Length == 5)
                            {
                                exeMode.formatFrom = args[1];
                                exeMode.formatTo = args[2];
                                exeMode.pathFrom = args[3];

                                if (args.Length == 5)
                                    exeMode.pathTo = args[4];
                                else
                                    exeMode.pathTo = null;

                                if (exeMode.formatFrom == "svg" && exeMode.formatTo == "emf")
                                {
                                    if(!(File.Exists(exeMode.pathFrom) || 
                                         (Directory.Exists(exeMode.pathFrom) && (exeMode.pathTo == null || Directory.Exists(exeMode.pathTo)))
                                        )
                                      )
                                    {
                                        MessageBox.Show($"invalid path:\n\n path1 [{exeMode.pathFrom}]\n\n path2 [{exeMode.pathTo}]\n\n when from-path is file, to-path can be directory or file \n\n when from-path is directory, to-path must be directory too",
                                            "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        mode = EXE_MODE.MODE_END;//格式转换时发生错误，不能继续执行，置为 MODE_END 表示错误
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"unsupported convert [{exeMode.formatFrom}]->[{exeMode.formatTo}]\n\nSupported convert [svg]->[emf]",
                                        "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    mode = EXE_MODE.MODE_END;//格式转换时发生错误，不能继续执行，置为 MODE_END 表示错误
                                }
                            }
                            else
                                mode = EXE_MODE.MODE_END;//格式转换时发生错误，不能继续执行，置为 MODE_END 表示错误
                        }
                        break;
                    default:
                        mode = EXE_MODE.MODE_NORMAL;
                        break;
                }

                //执行模式
                exeMode.mode = mode;
            }

            return exeMode;
        }
        
        //执行模式
        public EXE_MODE mode = EXE_MODE.MODE_NORMAL;
        
        //MODE_INIT_PATH
        public string initPath = null;

        //MODE_SINGLE_IMAGE
        public string singleImagePath = null;

        //MODE_FORMAT_CONVERT
        public string formatFrom = null;
        public string formatTo = null;
        public string pathFrom = null;
        public string pathTo = null;

        //最终运行结果代码
        public int returnCode = 0;
    }
}
