using System;
using Message.Interface;
using Message.LogServer.DataModel;
using Message.LogServer.DbServer;
using Message.LogServer.MsgTask;
using Message.Model;

namespace Message.LogServer.Server
{
    public class LogServer : ILogService
    {
        public void AddLog(MsgContent msgContent)
        {
            Resource.ListLog.Add(new LogContent
            {
                AppEvent = msgContent.Content,
                AppNo = msgContent.AppNo,
                Content = msgContent.Content,
                CreateTime = DateTime.Now,
                MsgNo = msgContent.MsgNo
            });
            if (!Resource.LogTaskIsRun) TaskManager.RunWriteLog();
            if (!Resource.LogFlushTaskIsRun) TaskManager.RunLogFlush();
            if (!Resource.NeedValidateCollection) DbHelper.ValidateCollection();
        }

        public void AddPushLog(Model.PushLog log)
        {
            DbHelper.InsertPushLog(new Message.LogServer.DataModel.PushLog
            {
                MsgNo = log.MsgNo,
                PushStatus = log.PushStatus,
                PushTime = log.PushTime,
                PushType = log.PushType,
                SubAppNo = log.SubAppNo
            });
        }
    }
}
