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
            return iniHelper.Read("basic", "language","");
        }

        public void SetLanguage(string language)
        {
            iniHelper.Write("basic", "language", language);
        }
        
        private IniHelper iniHelper = null;
    }
}
