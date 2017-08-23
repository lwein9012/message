using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Message.Model;
using ServiceStack;

namespace Message.Service.Service
{
    public class BaseService : IService
    {
        protected static Dictionary<string, App> Apps = ServerManager.ServerHelper.GetSubImp.GetApps().ToDictionary(app => string.Format("{0}.{1}", app.AppNo, app.AppEvent), app => app);

        protected static Dictionary<string, DateTime> CacheAppValidate = new Dictionary<string, DateTime>();

        protected bool ValidateApp(string appNo, string appEvent)
        {
            var key = string.Format("{0}.{1}", appNo, appEvent);
            var retValue = false;
            if (Apps.ContainsKey(key))
                retValue = Apps[key].Enabled;
            else
            {
                var app = LoadApp(appNo, appEvent).Result;
                if (app != null)
                {
                    retValue = app.Enabled;
                }
            }
            if (retValue)
            {
                if (!CacheAppValidate.ContainsKey(key))
                {
                    CacheAppValidate.Add(key, DateTime.Now);
                }
                else if ((DateTime.Now - CacheAppValidate[key]).TotalSeconds > 120)
                {
                    LoadApp(appNo, appEvent);
                }
            }
            return retValue;
        }

        private async Task<App> LoadApp(string appNo, string appEvent)
        {
            var task = Task.Factory.StartNew<App>(() =>
            {
                var key = string.Format("{0}.{1}", appNo, appEvent);
                if (!CacheAppValidate.ContainsKey(key) || (DateTime.Now - CacheAppValidate[key]).TotalSeconds > 120)
                {
                    var app = ServerManager.ServerHelper.GetSubImp.GetOneApp(appNo, appEvent);
                    if (app != null)
                    {
                        Apps[key] = app;
                    }
                    CacheAppValidate[key] = DateTime.Now;
                    return app;
                }
                return null;
            });
            return task.Result;
        }
    }
}