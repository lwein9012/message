using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.ServiceFrm.Handler
{
    public class PubMsgManager
    {
        public static IPubMsg GetPubMsgImp(string pushtype)
        {
            switch (pushtype)
            {
                case "restful":
                    return new RestfulPubMsg();
                case "client":
                default:
                    return new ClientPubMsg();
            }
        }

        public static IPubMsg DefaultPubMsg
        {
            get { return GetPubMsgImp(PushType.client.ToString()); }
        }

        public enum PushType
        {
            restful,
            client
        }
    }
}
