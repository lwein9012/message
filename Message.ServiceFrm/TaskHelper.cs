using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Message.ServiceFrm
{
    public class TaskHelper
    {
        static List<Task> RunTasks = new List<Task>();
        static Queue<Task> QueueTasks = new Queue<Task>();


        public static bool CanAddTask
        {
            get
            {
                return RunTasks.Count <= 5 && QueueTasks.Count <= 20;
            }
        }

        public static void AddTask(Task task)
        {
            QueueTasks.Enqueue(task);
        }

        static CancellationTokenSource source;

        public static void StartRun()
        {
            source = new CancellationTokenSource();
            var token = source.Token;
            var task = new Task(() =>
            {
                while (true)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    RunTasks.RemoveAll(p => p.IsCompleted);
                    if (RunTasks.Count >= 8)
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                    if (QueueTasks.Count == 0)
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                    var needTask = QueueTasks.Dequeue();
                    if (needTask == null)
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                    needTask.Start();
                    RunTasks.Add(needTask);
                }
            }, token, TaskCreationOptions.LongRunning);
            task.Start();
        }

        public static void Stop()
        {
            source.Cancel();
        }
    }
}
