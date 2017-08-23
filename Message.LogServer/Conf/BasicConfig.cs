using System;
using Message.Common;

namespace Message.LogServer.Conf
{
    internal class BasicConfig
    {
        private static string dbaddress = null;

        /// <summary>
        /// 服务地址
        /// </summary>
        public static string DbAddress
        {
            get
            {
                if (string.IsNullOrEmpty(dbaddress))
                {
                    dbaddress = ConfHelper.GetLogConf["LogDbAddress"].ToString();
                }
                return dbaddress;
            }
        }

        private static long refreshCollCount = 0;

        /// <summary>
        /// 集合刷新数量
        /// </summary>
        public static long RefreshCollCount
        {
            get
            {
                if (refreshCollCount == 0)
                {
                    refreshCollCount = StringHelper.AppSettingValue<long>("RefreshCollCount", 1 * 10000 * 10000);
                }
                return refreshCollCount;
            }
        }

        /// <summary>
        /// 消息服务 （基础库）
        /// </summary>
        public static string BaseMsg = "BaseMessage";

        /// <summary>
        /// 消息服务（基础集合名）
        /// 发布消息应用
        /// </summary>
        public static string PubApp = "PubApp";

        /// <summary>
        /// 消息服务（基础库名）
        /// 订阅消息应用
        /// </summary>
        public static string SubApp = "SubApp";

        /// <summary>
        /// 消息服务 （日志库）
        /// </summary>
        public static string MsgLog = "MsgLog";

        /// <summary>
        /// 消息服务（日志集合名）
        /// </summary>
        public static string MsgCollection
        {
            get { return string.Format("{0}{1}", MsgLog, DateTime.Now.ToString("yyyyMM")); }
        }

        /// <summary>
        /// 消息服务（日志集合名）
        /// </summary>
        public static string MsgCollectionReName
        {
            get { return string.Format("{0}{1}", MsgLog, DateTime.Now.ToString("yyyyMMdd")); }
        }

        /// <summary>
        /// 消息服务（日志集合名）
        /// </summary>
        public static string PushLogCollection
        {
            get { return string.Format("{0}{1}", "PushMsgLog", DateTime.Now.ToString("yyyyMM")); }
        }
    }
}
