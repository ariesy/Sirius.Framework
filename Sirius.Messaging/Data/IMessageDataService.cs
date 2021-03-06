﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirius.Messaging.Interfaces;

namespace Sirius.Messaging.Data
{
    public interface IMessageDataService
    {
        List<IMessage> GetAllMessages(string domain = null);

        void MarkNewMessageAsScaned(string domain = null);

        void AddMessage(IMessage message);

        void RemoveMessage(IMessage message);

        void Clear(string domain = null);

        List<IMessage> GetRemovedMessages(string _domain = null);
    }
}
