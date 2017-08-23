using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using Message.Interface;
using Message.LogServer.DataModel;
using Message.LogServer.DbServer;

namespace Message.LogServer.Server
{
    public class SubServer : ISubService
    {
        public void AddSubMsg(Model.SubMsg subMsg)
        {
            var oldMsg = DbHelper.GetOneSubMsg(subMsg.AppNo, subMsg.PubAppNo, subMsg.PubAppEvent);
            if (oldMsg == null) oldMsg = new SubMsg { AppNo = subMsg.AppNo, PubAppNo = subMsg.PubAppNo, PubAppEvent = subMsg.PubAppEvent };
            oldMsg.Enabled = subMsg.Enabled;
            oldMsg.ReceiveType = subMsg.ReceiveType;
            oldMsg.ReceiveContent = subMsg.ReceiveContent;
            DbHelper.InsertOrUpdateSubMsg(oldMsg);
        }

        public List<Model.SubMsg> GetSubMsgs()
        {
            return DbHelper.GetSubMsgs().Select(p => new Model.SubMsg
            {
                AppNo = p.AppNo,
                PubAppNo = p.PubAppNo,
                PubAppEvent = p.PubAppEvent,
                Enabled = p.Enabled,
                ReceiveType = p.ReceiveType,
                ReceiveContent = p.ReceiveContent
            }).ToList();
        }

        public List<Model.App> GetApps()
        {
            return DbHelper.GetApps().Select(p => new Model.App
            {
                AppNo = p.AppNo,
                AppEvent = p.AppEvent,
                Description = p.Description,
                Enabled = p.Enabled
            }).ToList();
        }

        public void InsertOrUpdateApp(Model.App app)
        {
            var oldApp = DbHelper.GetOneApp(app.AppNo, app.AppEvent);
            if (oldApp == null) oldApp = new App
            {
                AppNo = app.AppNo,
                AppEvent = app.AppEvent
            };
            oldApp.Description = app.Description;
            oldApp.Enabled = app.Enabled;
            DbHelper.InsertOrUpdateApp(oldApp);
        }

        public Model.App GetOneApp(string appNo, string appEvent)
        {
            var oldApp = DbHelper.GetOneApp(appNo, appEvent);
            return new Model.App
            {
                AppNo = oldApp.AppNo,
                AppEvent = oldApp.AppEvent,
                Description = oldApp.Description,
                Enabled = oldApp.Enabled
            };
        }

        public Model.SubMsg GetOneSubMsg(string appNo, string pubAppNo, string pubAppEvent)
        {
            var submsg = DbHelper.GetOneSubMsg(appNo, pubAppNo, pubAppEvent);
            return new Model.SubMsg
            {
                AppNo = submsg.AppNo,
                Enabled = submsg.Enabled,
                PubAppNo = submsg.PubAppNo,
                ReceiveType = submsg.ReceiveType,
                PubAppEvent = submsg.PubAppEvent,
                ReceiveContent = submsg.ReceiveContent
            };
        }
    }
}
