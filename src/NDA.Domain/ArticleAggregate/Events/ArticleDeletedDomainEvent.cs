using NDA.Core.Domain;
using System;

namespace NDA.Domain.ArticleAggregate.Events
{
    public class ArticleDeletedDomainEvent : EventBase
    {
        public Guid ArticleId { get; private set; }

        public ArticleDeletedDomainEvent(Guid id)
        {
            ArticleId = id;
        }
    }
}