using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirius.Common.Extensions;
using Sirius.Messaging.Data.Interfaces;
using Sirius.Messaging.Interfaces;

namespace Sirius.Messaging.Data.SqlCe
{
    class SqlCeMessageDataService : IMessageDataService
    {
        public List<IMessage> GetAllMessages()
        {
            using (var context = new MessageQueueEntities())
            {
                return context.Messages.ToList().Cast<IMessage>().ToList();
            }
        }

        public void MarkNewMessageAsScaned()
        {
            using (var context = new MessageQueueEntities())
            {
                var newMessages = context.Messages.Where(m => m.Status == MessageStatus.New).ToList();
                foreach (var message in newMessages)
                {
                    message.Status = MessageStatus.Scaned;
                }

                context.SaveChanges();
            }
        }

        public void AddMessage(IMessage message)
        {
            using (var context = new MessageQueueEntities())
            {
                var dbMessage = new Message();
                long maxId = 0;
                if (context.Messages.Count() > 0)
                {
                    maxId = context.Messages.Max(m => m.Id);
                }
                dbMessage.Id = maxId + 1;
                dbMessage.Value = message.MessageBody.ToStringEx();
                dbMessage.Status = MessageStatus.New;
                context.Messages.AddObject(dbMessage);
                context.SaveChanges();

            }
        }

        public void RemoveMessage(IMessage message)
        {
            using (var context = new MessageQueueEntities())
            {
                var dbMessages = context.Messages.Where(m => m.Value == message.MessageBody.ToStringEx(true)).ToList();
                foreach(var dbMessage in dbMessages)
                {
                    context.Messages.DeleteObject(dbMessage);
                }

                context.SaveChanges();
            }
        }
    }
}
