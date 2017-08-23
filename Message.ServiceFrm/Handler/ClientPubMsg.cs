using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Message.ServiceFrm.Handler
{
    public class ClientPubMsg : IPubMsg
    {
        private const string NAME_FORMAT = "{0}_{1}";
        public void PubMsg(int num, Model.MsgContent msg, Model.SubMsg sub)
        {
            var name = string.Format(NAME_FORMAT, msg.AppNo, msg.AppEvent);
            var result = ServerManager.ServerHelper.GetQueueImp.Publish(name, msg.Content);
            ServerManager.ServerHelper.GetLogImp.AddPushLog(new Model.PushLog
            {
                MsgNo = msg.MsgNo,
                PushStatus = result.ToString(CultureInfo.InvariantCulture),
                PushTime = DateTime.Now,
                PushType = "client",
                SubAppNo = "client all"
            });
            if (result < 0)
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
