using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Events
{
    public class EntityUpdateEventArgs
    {
        public IEntity EntityObject { get; set; }
        public readonly IEntity NewEntityObject;

        public EntityUpdateEventArgs(IEntity entityObject, IEntity newEntityObject)
        {
            EntityObject = entityObject;
            NewEntityObject = newEntityObject;
        }
    }
}
