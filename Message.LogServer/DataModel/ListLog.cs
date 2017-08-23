using System.Collections.Generic;
using MongoDB.Bson;

namespace Message.LogServer.DataModel
{
    public class ListLog : List<BsonDocument>
    {
        public new void Add(BsonDocument doc)
        {
            base.Add(doc);
        }

        public void Add(LogContent logContent)
        {
            var doc = new BsonDocument();
            doc.Add("AppNo", logContent.AppNo);
            doc.Add("AppEvent", logContent.AppEvent);
            doc.Add("MsgNo", logContent.MsgNo);
            doc.Add("Content", this.ParserToBson(logContent.Content));
            doc.Add("CreateTime", logContent.CreateTime);
            base.Add(doc);
        }

        private BsonDocument ParserToBson(string json)
        {
            BsonDocument document;
            if (!BsonDocument.TryParse(json, out document))
                document = new BsonDocument(new Dictionary<string, object> {
                    {"Content",json}
                });
            return document;
        }
    }
}
