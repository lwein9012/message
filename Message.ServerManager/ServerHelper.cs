using Message.Interface;

namespace Message.ServerManager
{
    public class ServerHelper
    {
        static readonly LogServer.Server.LogServer log = new LogServer.Server.LogServer();
        static readonly LogServer.Server.SubServer sub = new LogServer.Server.SubServer();
        static readonly Queue.Redis.Server.QueueServer queue = new Queue.Redis.Server.QueueServer();
        public static ILogService GetLogImp
        {
            get { return log; }
        }

        public static ISubService GetSubImp
        {
            get { return sub; }
        }

        public static IQueueService GetQueueImp
        {
            get { return queue; }
        }
    }
}
