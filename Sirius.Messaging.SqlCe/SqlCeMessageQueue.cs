using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirius.Messaging.Interfaces;

namespace Sirius.Messaging.SqlCe
{
    public class SqlCeMessageQueue:IMessageQueue
    {
        public bool Enqueue(object item)
        {
            throw new NotImplementedException();
        }

        public bool Dequeue(object item)
        {
            throw new NotImplementedException();
        }
    }
}
