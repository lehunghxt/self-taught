using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXT.RabitMQ
{
    public interface IRabbitMQProducer
    {
        public void SendProductMessage<T>(T message);
    }
}
