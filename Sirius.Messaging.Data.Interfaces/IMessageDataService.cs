using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirius.Messaging.Interfaces;

namespace Sirius.Messaging.Data.Interfaces
{
    public interface IMessageDataService
    {
        List<IMessage> GetAllMessages(string domain = null);

        void MarkNewMessageAsScaned(string domain = null);

        void AddMessage(IMessage message);

        void RemoveMessage(IMessage message);
    }
}
