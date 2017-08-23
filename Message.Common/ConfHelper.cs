using System.Collections;
using System.Configuration;
using ServiceStack.Text;

namespace Message.Common
{
    public class ConfHelper
    {
        private static readonly object obj = new object();
        private static IDictionary logconf = null;
        public static IDictionary GetLogConf
        {
            get
            {
                if (logconf == null)
                {
                    lock (obj)
                    {
                        if (logconf == null)
                        {
                            var logconfStr = ConfigurationManager.AppSettings["LogConf"];
                            logconf = JsonSerializer.DeserializeFromString<Hashtable>(logconfStr);
                        }
                    }
                }
                return logconf;
            }
        }

        private static IDictionary queueconf = null;
        public static IDictionary GetQueueConf
        {
            get
            {
                if (queueconf == null)
                {
                    lock (obj)
                    {
                        if (queueconf == null)
                        {
                            var queueconfStr = ConfigurationManager.AppSettings["QueueConf"];
                            queueconf = JsonSerializer.DeserializeFromString<Hashtable>(queueconfStr);
                        }
                    }
                }
                return queueconf;
            }
        }
    }
}
