using System.Collections.Generic;
using System.Web.Mvc;
using Message.Common.Aop;
using Message.Model;

namespace Message.Web.Controllers
{
    public class AjaxJsonController : Controller
    {
        public ActionResult GetApps()
        {
            var apps = ServerManager.ServerHelper.GetSubImp.GetApps();
            return this.Json(AopResult.Success(apps));
        }

        public ActionResult SaveApp(string appno, string appevent, string description, bool enabled)
        {
            ServerManager.ServerHelper.GetSubImp.InsertOrUpdateApp(new App
            {
                AppNo = appno,
                AppEvent = appevent,
                Description = description,
                Enabled = enabled
            });
            return this.Json(AopResult.Success(0));
        }

        public ActionResult GetSubMsgs()
        {
            var msgs = ServerManager.ServerHelper.GetSubImp.GetSubMsgs();
            return this.Json(AopResult.Success(msgs));
        }

        public ActionResult SaveSubMsg(string appno, string pubappno, string pubappevent, string receivetype, string receivecontent, bool enabled)
        {
            ServerManager.ServerHelper.GetSubImp.AddSubMsg(new SubMsg
            {
                AppNo = appno,
                PubAppNo = pubappno,
                PubAppEvent = pubappevent,
                ReceiveType = receivetype,
                ReceiveContent = receivecontent,
                Enabled = enabled
            });
            return this.Json(AopResult.Success(0));
        }
    }
}