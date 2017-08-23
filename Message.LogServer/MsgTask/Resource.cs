using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Message.LogServer.DataModel;

namespace Message.LogServer.MsgTask
{
    public class Resource
    {
        /// <summary>
        /// 带写入的资源
        /// </summary>
        public static ListLog ListLog = new ListLog();
        /// <summary>
        /// 任务队列
        /// </summary>
        public static Queue<Task> TaskQueue = new Queue<Task>();
        /// <summary>
        /// 执行的任务
        /// </summary>
        public static List<Task> RunTasks = new List<Task>();

        /// <summary>
        /// 日志写入任务 是否已启动
        /// </summary>
        public static bool LogTaskIsRun { get; set; }

        /// <summary>
        /// 持久化任务是否已执行
        /// </summary>
        public static bool LogFlushTaskIsRun { get; set; }

        /// <summary>
        /// 最后一次校验消息集合数目
        /// </summary>
        public static DateTime LastValidateCollectionDate { private get; set; }

        /// <summary>
        /// 是否需要教验集合消息数目
        /// </summary>
        public static bool NeedValidateCollection
        {
            get { return LastValidateCollectionDate.Date != DateTime.Now.Date; }
        }
    }
}
