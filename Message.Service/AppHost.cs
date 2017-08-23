using Funq;
using Message.Service.Service;

namespace Message.Service
{
    public class AppHost : ServiceStack.AppHostBase
    {
        public AppHost()
            : base("CentaNet.Message.Service", typeof(BaseService).Assembly)
        {

        }

        public override void Configure(Container container)
        {
            
        }
    }
}