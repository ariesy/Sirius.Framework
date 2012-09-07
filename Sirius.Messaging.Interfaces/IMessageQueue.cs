using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.Messaging.Interfaces
{
    public interface IMessageQueue
    {
        bool Enqueue(object item);

        bool Dequeue(object item);

    }
}
