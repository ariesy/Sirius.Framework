using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Sirius.Messaging.Interfaces;
using Sirius.Common.Extensions;
using System.Timers;

namespace Sirius.Messaging.SqlCe
{
    public class SqlCeMessageQueueServer : IMessageQueueServer
    {
        public void Start()
        {
            int scanInterval = ConfigurationManager.AppSettings["MessageQueueScanInterval"].ToInt(10);
            Timer timer = new Timer(1000 * scanInterval);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            using (var context = new MessageQueueEntities())
            {
                var newMessages = context.Messages.Where(m => m.Status == MessageStatus.New).ToList();
                if (newMessages.Count > 0 && ItemsEnqued != null)
                {
                    ItemsEnqued(context.Messages.ToList().Cast<IMessage>().ToList());
                }

                foreach (var message in newMessages)
                {
                    message.Status = MessageStatus.Scaned;
                }

                context.SaveChanges();
            }
        }

        public event Action<List<IMessage>> ItemsEnqued;
    }
}
