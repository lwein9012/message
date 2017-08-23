using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Message.ServiceFrm.Common;

namespace Message.ServiceFrm.Handler
{
    public class RestfulPubMsg : IPubMsg
    {
        public void PubMsg(int num, Model.MsgContent msg, Model.SubMsg sub)
        {
            var result = HttpHelper.Post(sub.ReceiveContent, msg.Content);
            ServerManager.ServerHelper.GetLogImp.AddPushLog(new Model.PushLog
            {
                MsgNo = msg.MsgNo,
                PushStatus = result,
                PushTime = DateTime.Now,
                PushType = sub.ReceiveType,
                SubAppNo = sub.AppNo
            });
            if (result != "OK")
            {
                switch (num)
                {
                    case 0:
                        Task.Factory.StartNew(() =>
                        {
                            Thread.Sleep(10 * 1000);
                            TaskHelper.AddTask(new Task(() => this.PubMsg(1, msg, sub)));
                        });
                        break;
                    case 1:
                        Task.Factory.StartNew(() =>
                        {
                            Thread.Sleep(60 * 1000);
                            TaskHelper.AddTask(new Task(() => this.PubMsg(2, msg, sub)));
                        });
                        break;
                }
            }
        }
    }
}
