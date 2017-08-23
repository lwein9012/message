
using System;
using Message.Common;
using Message.Common.Aop;
using Message.Model;
using Message.ServerManager;
using Message.Service.Model;

namespace Message.Service.Service
{
    public class PubService : BaseService
    {
        public AopResult<PublishMsgResponse> Post(PublishMsgRequest request)
        {
            // 发布消息，需注册应用和事件 
            if (!base.ValidateApp(request.AppNo, request.AppEvent))
                return AopResult.Fail<PublishMsgResponse>("非法调用！");
            var msgNo = NumHelper.GetRandomNo();
            var msg = new MsgContent { MsgNo = msgNo, AppNo = request.AppNo, AppEvent = request.AppEvent, Content = request.Content };
            // 记录消息日志 
            ServerHelper.GetLogImp.AddLog(msg);
            // 推送消息到队列
            var queueId = ServerHelper.GetQueueImp.PushMsg(msg);
            return AopResult.Success(new PublishMsgResponse
            {
                QueueId = queueId.ToString(),
                MsgNo = msgNo
            });
        }
    }
}