using Message.Common;

namespace Message.Queue.Redis.Conf
{
    public class BasicConfig
    {
        private static string queuePoints = null;

        /// <summary>
        /// 服务地址
        /// </summary>
        public static string QueuePoints
        {
            get
            {
                if (string.IsNullOrEmpty(queuePoints))
                {
                    queuePoints = ConfHelper.GetQueueConf["QueuePoints"].ToString();
                }
                return queuePoints;
            }
        }

        public const string CACHE_KEY_FORMAT = "CENTANET_MESSAGE_{0}";

        public const string Queue_CACHE_KEY = "CENTANET_MESSAGE_Queue";
    }
}
