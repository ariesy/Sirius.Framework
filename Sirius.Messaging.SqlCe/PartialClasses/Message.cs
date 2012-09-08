using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirius.Messaging.Interfaces;
using Sirius.Common.Extensions;

namespace Sirius.Messaging.Data.SqlCe
{
    public partial class Message : IMessage
    {
        public object MessageBody
        {
            get
            {
                return this.Value;
            }
            set
            {
                this.Value = value.ToStringEx();
            }
        }
    }
}
