using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.Messaging.Interfaces
{
    public interface IMessage
    {
        object MessageBody { get; set; }

        string Status { get; set; }
    }
}
