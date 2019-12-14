﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace BesPrinter
{
    class IniHelper
    {
        public static string iniDir = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "setting\\";
        public string iniFile = null;

        public IniHelper()
        {
            Directory.CreateDirectory(iniDir);

            iniFile = iniDir + "BesPrinter.ini";
        }

        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, iniFile);
        }

        public string Read(string section, string key, string defaultValue)
        {
            StringBuilder value = new StringBuilder() ;
            GetPrivateProfileString(section, key, defaultValue, value, 255, iniFile);
            return value.ToString();
        }


        /// <summary>
        /// 修改INI配置文件
        /// </summary>
        /// <param name="section">段落</param>
        /// <param name="key">关键字</param>
        /// <param name="val">值</param>
        /// <param name="filepath">文件完整路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        
        /// <summary>
        /// 读INI配置文件
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="def">缺省值</param>
        /// <param name="retval"></param>
        /// <param name="size">指定装载到lpReturnedString缓冲区的最大字符数量</param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);

        
    }
}
