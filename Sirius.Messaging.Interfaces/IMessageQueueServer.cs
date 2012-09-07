using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.Messaging.Interfaces
{
    public interface IMessageQueueServer
    {
        void Start();

        event Action<List<object>> ItemsEnqued;
    }
}
