using System.Collections.Generic;
using Message.Model;

namespace Message.Interface
{
    public interface ISubService
    {
        void AddSubMsg(SubMsg subMsg);

        List<SubMsg> GetSubMsgs();

        SubMsg GetOneSubMsg(string appNo,string pubAppNo,string pubAppEvent);

        List<App> GetApps();

        App GetOneApp(string appNo, string appEvent);

        void InsertOrUpdateApp(App app);
    }
}
