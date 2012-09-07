using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.Messaging.Interfaces
{
    public class MessageQueueEventArgs
    {
        List<object> NewMessages;

        List<object> AllMessages;
    }
}
