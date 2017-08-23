using System;
using System.Threading.Tasks;
using Message.Queue.Redis.Conf;
using StackExchange.Redis;

namespace Message.Queue.Redis.CacheServer
{
    internal class CacheHelper
    {
        private static ConnectionMultiplexer Redis = GetRedis();
        private static ConnectionMultiplexer GetRedis()
        {
            var conf = ConfigurationOptions.Parse(BasicConfig.QueuePoints);
            conf.AbortOnConnectFail = false;
            var redis = ConnectionMultiplexer.Connect(conf);
            return redis;
        }

        public static long Publish(string name, string value)
        {
            name = string.Format(BasicConfig.CACHE_KEY_FORMAT, name);
            var channel = new RedisChannel(name, RedisChannel.PatternMode.Auto);
            var sub = Redis.GetSubscriber();
            RedisValue redisValue = value;
            return sub.Publish(channel, redisValue);
        }

        public static void Subscribe(string name, Action<string, string> action)
        {
            name = string.Format(BasicConfig.CACHE_KEY_FORMAT, name);
            var channel = new RedisChannel(name, RedisChannel.PatternMode.Auto);
            var sub = Redis.GetSubscriber();
            sub.Subscribe(channel, (ch, val) => action(ch.ToString(), val.ToString()));
        }

        public static string Pop()
        {
            var db = Redis.GetDatabase();
            RedisKey key = BasicConfig.Queue_CACHE_KEY;
            return db.ListLeftPop(key).ToString();
        }

        public static long Push(string value)
        {
            var db = Redis.GetDatabase();
            RedisKey key = BasicConfig.Queue_CACHE_KEY;
            RedisValue val = value;
            return db.ListRightPush(key, val);
        }
    }
}
