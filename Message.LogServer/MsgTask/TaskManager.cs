
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Message.LogServer.MsgTask
{
    internal class TaskManager
    {
        public static void RunWriteLog()
        {
            Resource.LogTaskIsRun = true;
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    var count = Resource.ListLog.Count;
                    if (count > 0)
                    {
                        var docs = Resource.ListLog.Take(count);
                        Resource.TaskQueue.Enqueue(new Task(() => DbServer.DbHelper.BatchMsgLogsAsync(docs)));
                    }
                    Thread.Sleep(5 * 1000);
                }
            });
        }

        public static void RunLogFlush()
        {
            Resource.LogFlushTaskIsRun = true;
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Resource.RunTasks.RemoveAll(p => p.IsCompleted);
                    if (Resource.RunTasks.Count >= 5)
                    {
                        Thread.Sleep(3 * 1000); continue;
                    }
                    if (Resource.TaskQueue.Count == 0)
                    {
                        Thread.Sleep(5 * 1000); continue;
                    }
                    var task = Resource.TaskQueue.Dequeue();
                    if (task == null)
                    {
                        Thread.Sleep(5 * 1000); continue;
                    }
                    task.Start();
                    Resource.RunTasks.Add(task);
                }
            });
        }
    }
}
