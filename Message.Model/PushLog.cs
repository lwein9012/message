
using System;

namespace Message.Model
{
    public class PushLog
    {
        /// <summary>
        /// 消息编号
        /// </summary>
        public string MsgNo { get; set; }

        /// <summary>
        /// 订阅应用
        /// </summary>
        public string SubAppNo { get; set; }

        /// <summary>
        /// 推送时间
        /// </summary>
        public DateTime PushTime { get; set; }

        /// <summary>
        /// 推送状态
        /// </summary>
        public string PushStatus { get; set; }

        /// <summary>
        /// 推送方式
        /// </summary>
        public string PushType { get; set; }
    }
}
