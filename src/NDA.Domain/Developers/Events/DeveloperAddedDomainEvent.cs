using NDA.Core.Domain;
using System;

namespace NDA.Domain.Developers.Events
{
    public class DeveloperAddedDomainEvent : EventBase
    {
        public Guid DeveloperId { get; private set; }
        public DeveloperAddedDomainEvent(Guid id)
        {
            this.DeveloperId = id;
        }
    }
}