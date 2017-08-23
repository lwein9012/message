using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.ServiceFrm.Handler
{
    public interface IPubMsg
    {
        void PubMsg(int num, Model.MsgContent msg, Model.SubMsg sub);
    }
}
