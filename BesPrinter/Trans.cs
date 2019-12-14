using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace BesPrinter
{
    class Trans
    {
        public static ResourceManager resourceManager = new ResourceManager(typeof(Language.Translation));

        public static string tr(string name)
        {
            return resourceManager.GetString(name, AppConfig.config.GetCultrueInfo());
        }

    }
}
