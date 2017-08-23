using System;
using System.Collections.Generic;
using System.Linq;
using Message.LogServer.Conf;
using Message.LogServer.DataModel;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Message.LogServer.DbServer
{
    internal class DbHelper
    {
        #region MSG

        public static void BatchMsgLogsAsync(IEnumerable<BsonDocument> logs)
        {
            var db = Conf.DbConfig.GetDataBase(Conf.BasicConfig.MsgLog);
            var coll = db.GetCollection<BsonDocument>(Conf.BasicConfig.MsgCollection);
            coll.InsertMany(logs);
        }


        public static void InsertMsgLog(BsonDocument log)
        {
            var db = Conf.DbConfig.GetDataBase(Conf.BasicConfig.MsgLog);
            var coll = db.GetCollection<BsonDocument>(Conf.BasicConfig.MsgCollection);
            coll.InsertOne(log, new InsertOneOptions());
        }

        public static void ValidateCollection()
        {
            /*
            var db = Conf.DbConfig.GetDataBase(Conf.BasicConfig.MsgLog);
            var coll = db.GetCollection<BsonDocument>(Conf.BasicConfig.MsgCollection);
            if (coll.Count(p => true) < BasicConfig.RefreshCollCount)
            {
                db.RenameCollection(Conf.BasicConfig.MsgCollection, Conf.BasicConfig.MsgCollectionReName);
            }*/
        }

        #endregion

        #region app

        public static void InsertOrUpdateApp(App app)
        {
            var db = Conf.DbConfig.GetDataBase(Conf.BasicConfig.BaseMsg);
            var coll = db.GetCollection<App>(Conf.BasicConfig.PubApp);
            if (app._id.Timestamp == 0)
            {
                app.CreateTime = DateTime.Now;
                app.UpdateTime = DateTime.Now;
                app._id = new ObjectId();
                coll.InsertOne(app);
            }
            else
            {
                app.UpdateTime = DateTime.Now;
                var filter = Builders<App>.Filter.Eq(p => p._id, app._id);
                var updateBuilders = new UpdateDefinitionBuilder<App>();
                var updateDefinition = updateBuilders.Combine(new[] {
                    Builders<App>.Update.Set(p => p.Enabled, app.Enabled), 
                    Builders<App>.Update.Set(p => p.Description, app.Description),
                    Builders<App>.Update.Set(p => p.UpdateTime, app.UpdateTime)
                });
                coll.UpdateOne(filter, updateDefinition, new UpdateOptions
                    {
                        BypassDocumentValidation = false
                    }
                );
            }
        }

        public static List<App> GetApps()
        {
            var db = Conf.DbConfig.GetDataBase(Conf.BasicConfig.BaseMsg);
            var coll = db.GetCollection<App>(Conf.BasicConfig.PubApp);
            var apps = coll.AsQueryable().ToList();
            return apps;
        }

        public static App GetOneApp(string appNo, string appEvent)
        {
            var db = Conf.DbConfig.GetDataBase(Conf.BasicConfig.BaseMsg);
            var coll = db.GetCollection<App>(Conf.BasicConfig.PubApp);
            var query = coll.AsQueryable();
            var oldApp = query.FirstOrDefault(p => p.AppNo == appNo && p.AppEvent == appEvent);
            return oldApp;
        }

        #endregion

        #region  sub

        public static void InsertOrUpdateSubMsg(SubMsg subMsg)
        {
            var db = Conf.DbConfig.GetDataBase(Conf.BasicConfig.BaseMsg);
            var coll = db.GetCollection<SubMsg>(Conf.BasicConfig.SubApp);
            if (subMsg._id.Timestamp == 0)
            {
                subMsg.CreateTime = DateTime.Now;
                subMsg.UpdateTime = DateTime.Now;
                subMsg._id = new ObjectId();
                coll.InsertOne(subMsg);
            }
            else
            {
                subMsg.UpdateTime = DateTime.Now;
                var filter = Builders<SubMsg>.Filter.Eq(p => p._id, subMsg._id);
                var updateBuilders = new UpdateDefinitionBuilder<SubMsg>();
                var updateDefinition = updateBuilders.Combine(new[] {
                    Builders<SubMsg>.Update.Set(p => p.Enabled, subMsg.Enabled), 
                    Builders<SubMsg>.Update.Set(p => p.ReceiveType, subMsg.ReceiveType),
                    Builders<SubMsg>.Update.Set(p => p.ReceiveContent, subMsg.ReceiveContent),
                    Builders<SubMsg>.Update.Set(p => p.UpdateTime, subMsg.UpdateTime)
                });
                coll.UpdateOne(filter, updateDefinition);
            }
        }

        public static List<SubMsg> GetSubMsgs()
        {
            var db = Conf.DbConfig.GetDataBase(Conf.BasicConfig.BaseMsg);
            var coll = db.GetCollection<SubMsg>(Conf.BasicConfig.SubApp);
            var subMsgs = coll.AsQueryable().ToList();
            return subMsgs;
        }

        public static SubMsg GetOneSubMsg(string appNo, string pubAppNo, string pubAppEvent)
        {
            var db = Conf.DbConfig.GetDataBase(Conf.BasicConfig.BaseMsg);
            var coll = db.GetCollection<SubMsg>(Conf.BasicConfig.SubApp);
            var query = coll.AsQueryable();
            var subMsg = query.FirstOrDefault(p => p.AppNo == appNo && p.PubAppNo == pubAppNo && p.PubAppEvent == pubAppEvent);
            return subMsg;
        }

        #endregion

        #region PushLog

        public static void InsertPushLog(PushLog log)
        {
            var db = Conf.DbConfig.GetMongoClient().GetDatabase(BasicConfig.MsgLog);
            var coll = db.GetCollection<BsonDocument>(BasicConfig.PushLogCollection);
            var bson = new BsonDocument();
            bson.Add("MsgNo", log.MsgNo);
            bson.Add("PushStatus", log.PushStatus);
            bson.Add("PushTime", log.PushTime);
            bson.Add("PushType", log.PushType);
            bson.Add("SubAppNo", log.SubAppNo);
            coll.InsertOne(bson);
        }

        #endregion
    }
}
