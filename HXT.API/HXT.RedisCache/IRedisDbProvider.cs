﻿using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXT.RedisCache
{
    public interface IRedisDbProvider : IDisposable
    {
        public IDatabase Database { get; }
    }
}
