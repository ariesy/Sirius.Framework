using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.Messaging
{
    public interface IMessage
    {
        object MessageBody { get; set; }

        string Status { get; set; }

        string Domain { get; set; }
    }
}
