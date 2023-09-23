using NDA.Core.Domain;
using System;

namespace NDA.Domain.ArticleAggregate.Events
{
    public class ArticleAddedDomainEvent : EventBase
    {

        public Guid ArticleId { get; private set; }
        public ArticleAddedDomainEvent(Guid id)
        {
            ArticleId = id;
        }
    }
}