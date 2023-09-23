using NDA.Core.Domain;
using System;

namespace NDA.Domain.Developers.Events
{
    public class DeveloperUpdatedDomainEvent : EventBase
    {
        public Guid DeveloperId { get; private set; }

        public DeveloperUpdatedDomainEvent(Guid id)
        {
            this.DeveloperId = id;
        }
    }
}