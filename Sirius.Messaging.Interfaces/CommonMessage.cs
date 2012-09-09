using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.Messaging.Interfaces
{
    public class CommonMessage : IMessage
    {
        public object MessageBody
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public string Domain
        {
            get;
            set;
        }
    }
}
