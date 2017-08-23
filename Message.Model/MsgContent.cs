using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Model
{
    public class MsgContent
    {
        /// <summary>
        /// 应用名
        /// </summary>
        public string AppNo { get; set; }

        /// <summary>
        /// 应用事件
        /// </summary>
        public string AppEvent { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 消息编号
        /// </summary>
        public string MsgNo { get; set; }
    }
}
