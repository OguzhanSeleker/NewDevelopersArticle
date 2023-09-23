using NDA.Core.Domain;
using System;

namespace NDA.Domain.ArticleAggreagte.Events
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