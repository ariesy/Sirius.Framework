using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Sirius.Messaging.Interfaces;
using Sirius.Common.Extensions;
using System.Threading;

namespace Sirius.Messaging.SqlCe
{
    public class SqlCeMessageQueueServer : IMessageQueueServer
    {
        public void Start()
        {
            int scanInterval = ConfigurationManager.AppSettings["scanInterval"].ToInt(10);
            while (true)
            {
                using (var context = new MessageQueueEntities())
                {
                    var newMessages = context.Messages.Where(m => m.Status == MessageStatus.New).ToList();
                    if (newMessages.Count > 0 && ItemsEnqued != null)
                    {
                        ItemsEnqued(newMessages.Select(m => m.Value as object).ToList());
                    }

                    foreach (var message in newMessages)
                    {
                        message.Status = MessageStatus.Scaned;
                    }

                    context.SaveChanges();
                }

                Thread.Sleep(1000 * scanInterval);
            }
        }

        public event Action<List<object>> ItemsEnqued;
    }
}
