
using System;

namespace Message.Interface
{
    public interface IQueueService
    {
        /// <summary>
        /// 从右边插入队列底部
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        long PushMsg(Model.MsgContent msg);

        /// <summary>
        /// 从队列中取出左边第一个消息
        /// </summary>
        /// <returns></returns>
        Model.MsgContent PopMsg();

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long Publish(string name, string value);

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
        void Subscribe(string name, Action<string, string> action);
    }
}
