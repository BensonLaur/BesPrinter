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

        public string GetLanguage()
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

        public bool GetEnableBatch()
        {
            string value = iniHelper.Read("printing", "enableBatch", "0"); //默认不启用分批次
            return (!value.Equals("0"));
        }
        public void SetEnableBatch(bool enable)
        {
            iniHelper.Write("printing", "enableBatch", enable ? "1" : "0");
        }

        public int GetCountInOneBatch()
        {
            string value = iniHelper.Read("printing", "countInOneBatch", "300"); //默认每批次打印 300
            return Convert.ToInt32(value);
        }
        public void SetCountInOneBatch(int count)
        {
            iniHelper.Write("printing", "countInOneBatch", String.Format("{0:D}",count));
        }

        private IniHelper iniHelper = null;
    }
}
