using NDA.Core.Domain;
using System;

namespace NDA.Domain.ArticleAggreagte.Events
{
    public class ContributerAddedToArticleDomainEvent : EventBase
    {
        public Guid ArticleId { get; private set; }
        public Guid DeveloperId { get; private set; }

        public ContributerAddedToArticleDomainEvent(Guid id, Guid developerId)
        {
            ArticleId = id;
            DeveloperId = developerId;
        }
    }
}