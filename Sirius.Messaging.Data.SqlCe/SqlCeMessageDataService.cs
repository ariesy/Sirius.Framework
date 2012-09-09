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
        public List<IMessage> GetAllMessages(string domain = null)
        {
            using (var context = new MessageQueueEntities())
            {
                return context.Messages.Where(m => m.Domain == domain && m.Status != MessageStatus.Deleted ).ToList().Cast<IMessage>().ToList();
            }
        }

        public void MarkNewMessageAsScaned(string domain = null)
        {
            using (var context = new MessageQueueEntities())
            {
                var newMessages = context.Messages.Where(m => m.Domain == domain && m.Status == MessageStatus.New).ToList();
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
                dbMessage.Domain = message.Domain;
                context.Messages.AddObject(dbMessage);
                context.SaveChanges();

            }
        }

        public void RemoveMessage(IMessage message)
        {
            var dm = message.Domain;
            var messageBody = message.MessageBody.ToStringEx();
            using (var context = new MessageQueueEntities())
            {
                var dbMessages = context.Messages.Where(m => m.Domain == dm && m.Value == messageBody ).ToList();
                foreach(var dbMessage in dbMessages)
                {
                    dbMessage.Status = MessageStatus.Deleted;
                }

                context.SaveChanges();
            }
        }


        public void Clear(string domain = null)
        {
            using(var context = new MessageQueueEntities())
            {
                foreach (var message in context.Messages.Where(m=>m.Domain == domain))
                {
                    context.Messages.DeleteObject(message);
                }

                context.SaveChanges();
            }
        }


        public List<IMessage> GetRemovedMessages(string _domain = null)
        {
            using (var context = new MessageQueueEntities())
            {
                return context.Messages.Where(m => m.Status == MessageStatus.Deleted).ToList().Cast<IMessage>().ToList();
            }
        }
    }
}
