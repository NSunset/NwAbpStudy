using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common.RabbitMQ
{
    public class RabbitMQConfigure
    {
        public const string Key = "RabbitMQConnections";

        public string HostName { get; set; }
        public string VirtualHost { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// 异常重试次数
        /// </summary>
        public int RetryCount { get; set; }

        /// <summary>
        /// 队列名称
        /// </summary>
        public string QueueName { get; set; }

        /// <summary>
        /// 交换机名称
        /// </summary>
        public string BrokerName { get; set; }
    }
}
