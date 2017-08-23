using Message.Model;

namespace Message.Interface
{
    public interface ILogService
    {
        void AddLog(MsgContent msgContent);

        void AddPushLog(Model.PushLog log);
    }
}
