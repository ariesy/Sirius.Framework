//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;

namespace Sirius.Messaging.SqlCe
{
    public partial class MessageQueueEntities : ObjectContext
    {
        public const string ConnectionString = "name=MessageQueueEntities";
        public const string ContainerName = "MessageQueueEntities";
    
        #region Constructors
    
        public MessageQueueEntities()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public MessageQueueEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public MessageQueueEntities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<Queue> Queues
        {
            get { return _queues  ?? (_queues = CreateObjectSet<Queue>("Queues")); }
        }
        private ObjectSet<Queue> _queues;

        #endregion
    }
}