using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirius.Messaging.Interfaces;
using System.Configuration;

namespace Sirius.Messaging.SqlCe
{
    public class SqlCeMessageQueueServer : IMessageQueueServer
    {
        public void Start()
        {
            int scanInterval = ConfigurationManager.AppSettings["scanInterval"].ToInt()
            while (true)
            { }
        }

        public event Action<List<object>> ItemsEnqued;
    }
}
