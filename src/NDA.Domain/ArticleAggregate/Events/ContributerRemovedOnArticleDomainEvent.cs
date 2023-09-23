using NDA.Core.Domain;
using System;

namespace NDA.Domain.ArticleAggregate.Events
{
    public class ContributerRemovedOnArticleDomainEvent : EventBase
    {
        public Guid ArticleId { get; private set; }
        public Guid DeveloperId { get; private set; }

        public ContributerRemovedOnArticleDomainEvent(Guid id, Guid developerId)
        {
            ArticleId = id;
            DeveloperId = developerId;
        }
    }
}