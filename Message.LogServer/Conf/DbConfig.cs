using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Message.LogServer.Conf
{
    internal class DbConfig
    {
        internal static MongoClientSettings GetSetting()
        {
            var address = BasicConfig.DbAddress;
            if (string.IsNullOrEmpty(address)) return null;
            var addresses = address.Split(',');
            var lst = new List<MongoServerAddress>();
            foreach (var s in addresses)
            {
                var vals = s.Split(':');
                lst.Add(new MongoServerAddress(vals[0], Int32.Parse(vals[1])));
            }
            if (lst.Count == 0) return new MongoClientSettings { Server = lst[0] };
            return new MongoClientSettings { Servers = lst };
        }

        internal static IMongoDatabase GetDataBase(string dbName)
        {
            if (string.IsNullOrEmpty(dbName)) return null;
            //MongoDB 服务器地址
            var client = GetMongoClient();
            //MongoDb 数据库名称
            var datebase = client.GetDatabase(dbName);
            return datebase;
        }

        internal static MongoClient GetMongoClient()
        {
            var client = new MongoClient(GetSetting());
            return client;
        }
    }
}
