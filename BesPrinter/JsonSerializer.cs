using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BesPrinter
{
    public class JsonSerializer<T>
    where T : class
    {
        const string SAVE_PATH = "jsonconfig/";
        /// <summary>
        /// 单例模式
        /// </summary>
        static T config;
        private JsonSerializer()
        {

        }
        /// <summary>
        /// 获取保存地址，默认是泛型参数T的类型名称
        /// </summary>
        /// <returns></returns>
        private static string GetSavePath()
        {
            if (!Directory.Exists(SAVE_PATH))
            {
                Directory.CreateDirectory(SAVE_PATH);
            }
            return $"{SAVE_PATH}{typeof(T).ToString()}.json";
        }
        /// <summary>
        /// 保存配置
        /// </summary>
        public static bool Save(T _config)
        {
            config = _config;
            string json = JsonConvert.SerializeObject(_config);
            try
            {
                using (var sw = new StreamWriter(GetSavePath()))
                {
                    sw.WriteAsync(json);
                }

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <returns></returns>
        public static T Load()
        {
            string json = "";
            try
            {
                using (var sr = new StreamReader(GetSavePath()))
                {
                    json = sr.ReadToEnd();
                    if (json != "")
                    {
                        config = JsonConvert.DeserializeObject<T>(json);
                    }
                    else
                    {
                        config = null;
                    }
                }
            }
            catch (Exception)
            {
                config = null;
            }
            return config;
        }

    }
    
}
