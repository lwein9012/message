using System;
using Message.Interface;
using Message.Model;
using Message.Queue.Redis.CacheServer;
using ServiceStack;
using ServiceStack.Text;

namespace Message.Queue.Redis.Server
{
    public class QueueServer : IQueueService
    {
        public long PushMsg(MsgContent msg)
        {
            var content = msg.ToJson();
            var result = CacheHelper.Push(content);
            return result;
        }

        public MsgContent PopMsg()
        {
            var result = CacheHelper.Pop();
            var msg = JsonSerializer.DeserializeFromString<MsgContent>(result);
            return msg;
        }

        public long Publish(string name, string value)
        {
            return CacheHelper.Publish(name, value);
        }

        public void Subscribe(string name, Action<string, string> action)
        {
            CacheHelper.Subscribe(name, action);
        }
    }
}
