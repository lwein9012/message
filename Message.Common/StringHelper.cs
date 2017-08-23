using System;

namespace Message.Common
{
    public class StringHelper
    {
        /// <summary>
        /// 字符串转Int
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int? ToNullInt32(string val)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 字符串转Int default - 0
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int ToInt32(string val)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Get AppSetting
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="defaultT"></param>
        /// <returns></returns>
        public static T AppSettingValue<T>(string name, T defaultT = default(T))
        {
            try
            {
                defaultT = (T)Convert.ChangeType(System.Configuration.ConfigurationManager.AppSettings[name], typeof(T));
            }
            catch { }
            return defaultT;
        }
    }
}
