using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BesPrinter
{
    class AppConfig
    {
        public static AppConfig config = new AppConfig();

        public AppConfig()
        {
            iniHelper = new IniHelper();
        }

        public CultureInfo GetCultrueInfo()
        {
            return new CultureInfo(GetLanguage());
        }

        private string GetLanguage()
        {
            return iniHelper.Read("basic", "language",""); //默认语言字段为空（默认中文）
        }

        public void SetLanguage(string language)
        {
            iniHelper.Write("basic", "language", language);
        }

        public string GetPrinterConfigName()
        {
            return iniHelper.Read("config", "name", "default"); //默认配置名称为 default
        }

        public void SetPrinterConfigName(string configName)
        {
            iniHelper.Write("config", "name", configName);
        }
        
        private IniHelper iniHelper = null;
    }
}
