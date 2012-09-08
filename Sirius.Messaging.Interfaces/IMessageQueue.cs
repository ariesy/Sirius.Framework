﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.Messaging.Interfaces
{
    public interface IMessageQueue
    {
        bool Enqueue(IMessage message);

        bool Dequeue(IMessage message);

    }
}
