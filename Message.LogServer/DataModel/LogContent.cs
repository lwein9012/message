using System;
using Message.Model;
using MongoDB.Bson;

namespace Message.LogServer.DataModel
{
    public class LogContent : MsgContent
    {
        /// <summary>
        /// mongo Id 编号
        /// </summary>
        public ObjectId _id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
