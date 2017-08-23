using System;
using MongoDB.Bson;

namespace Message.LogServer.DataModel
{
    class SubMsg : Model.SubMsg
    {
        public ObjectId _id { get; set; }

        /// <summary>
        /// 订阅时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
