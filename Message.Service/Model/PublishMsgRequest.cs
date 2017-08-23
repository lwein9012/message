using System;
using Message.Common.Aop;
using ServiceStack;

namespace Message.Service.Model
{
    public class PublishMsgRequest : IReturn<AopResult<String>>
    {
        /// <summary>
        /// 应用编号
        /// 示例：CentaNet、CCAI、APlus、CentaNet.BizCommon、CentaNet.Passport
        /// 如若区分城市 CentaNet.BizCommon.022、CentaNet.BizCommon.021
        /// </summary>
        public string AppNo { get; set; }

        /// <summary>
        /// 应用事件
        /// 示例：UserRegist（Passport）、CreateChat（CentaNet.BizCommon）
        /// （）内为应用名字
        /// </summary>
        public string AppEvent { get; set; }

        /// <summary>
        /// 消息内容
        /// json 格式
        /// </summary>
        public string Content { get; set; }
    }

    public class PublishMsgResponse
    {
        public string MsgNo { get; set; }

        public string QueueId { get; set; }
    }
}