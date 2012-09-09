using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.Messaging
{
    public interface IMessageQueueServer
    {
        void Start();

        event Action<List<IMessage>> ItemsEnqued;

        event Action<List<IMessage>> ItemDequeued;

        void Stop();
    }
}
