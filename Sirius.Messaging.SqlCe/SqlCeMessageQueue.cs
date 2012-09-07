using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirius.Messaging.Interfaces;
using Sirius.Common.Extensions;

namespace Sirius.Messaging.SqlCe
{
    public class SqlCeMessageQueue:IMessageQueue
    {
        public bool Enqueue(object item)
        {
            using (var context = new MessageQueueEntities())
            {
                context.Messages.AddObject(new Message{Value = item.ToStringEx(),Status = MessageStatus.New});
                context.SaveChanges();
            }
            
            return true;
        }

        public bool Dequeue(object item)
        {
            using (var context = new MessageQueueEntities())
            {
                var message = context.Messages.FirstOrDefault(m => m.Value == item.ToStringEx(true));
                if (message != null)
                {
                    context.Messages.DeleteObject(message);
                }
            }

            return true;
        }
    }
}
