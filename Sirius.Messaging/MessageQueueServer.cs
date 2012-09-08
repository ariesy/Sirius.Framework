using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Sirius.Messaging.Data.Interfaces;
using Sirius.Messaging.Interfaces;
using Sirius.Common.Extensions;
using Sirius.Common.Ioc;
using System.Timers;

namespace Sirius.Messaging
{
    public class MessageQueueServer : IMessageQueueServer
    {
        private IMessageDataService _messageDataService;

        public MessageQueueServer()
        {
            _messageDataService = IocContainer.Current.Resolve<IMessageDataService>();
        }
        
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
            if (ItemsEnqued != null)
            {
                ItemsEnqued(_messageDataService.GetAllMessages());
            }

            _messageDataService.MarkNewMessageAsScaned();
        }

        public event Action<List<IMessage>> ItemsEnqued;
    }
}
