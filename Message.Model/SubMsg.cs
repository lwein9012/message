using System;

namespace Message.Model
{
    public class SubMsg
    {
        /// <summary>
        /// 订阅着名字
        /// </summary>
        public string AppNo { get; set; }

        /// <summary>
        /// 订阅的应用
        /// </summary>
        public string PubAppNo { get; set; }

        /// <summary>
        /// 订阅的事件
        /// </summary>
        public string PubAppEvent { get; set; }

        /// <summary>
        /// 接收方式 
        /// restful
        /// client
        /// </summary>
        public string ReceiveType { get; set; }

        /// <summary>
        /// restful : 对应的Url地址。推送方式统一采用HttpPost
        /// client  : 为空
        /// </summary>
        public string ReceiveContent { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }
    }
}
