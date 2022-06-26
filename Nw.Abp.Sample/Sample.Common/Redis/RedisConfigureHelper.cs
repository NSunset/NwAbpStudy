using Microsoft.Extensions.Options;
using RedisHelper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common.Redis
{
    public class RedisConfigureHelper : IRedisConfigureHelper
    {
        private readonly RedisConfigure _redisConfigInfo;
        public RedisConfigureHelper(IOptions<RedisConfigure> redisConfigInfo)
        {
            _redisConfigInfo = redisConfigInfo.Value;
        }

        public string GetRedisConnectionString()
        {
            return _redisConfigInfo.WriteServerList[0];            
        }
    }
}
