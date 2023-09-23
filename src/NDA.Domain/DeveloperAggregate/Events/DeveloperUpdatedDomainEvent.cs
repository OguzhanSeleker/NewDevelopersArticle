using NDA.Core.Domain;
using System;

namespace NDA.Domain.DeveloperAggregate.Events
{
    public class DeveloperUpdatedDomainEvent : EventBase
    {
        public Guid DeveloperId { get; private set; }

        public DeveloperUpdatedDomainEvent(Guid id)
        {
            DeveloperId = id;
        }
    }
}