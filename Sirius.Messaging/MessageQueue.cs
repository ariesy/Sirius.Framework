using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirius.Messaging.Interfaces;
using Sirius.Common.Extensions;
using Sirius.Messaging.Data.Interfaces;
using Sirius.Common.Ioc;

namespace Sirius.Messaging
{
    public class MessageQueue:IMessageQueue
    {
        private IMessageDataService _messageDataService;

        public MessageQueue()
        {
            _messageDataService = IocContainer.Current.Resolve<IMessageDataService>();
        }

        public bool Enqueue(IMessage message)
        {
            _messageDataService.AddMessage(message);            
            return true;
        }

        public bool Dequeue(IMessage message)
        {
            _messageDataService.RemoveMessage(message);
            return true;
        }
    }
}
