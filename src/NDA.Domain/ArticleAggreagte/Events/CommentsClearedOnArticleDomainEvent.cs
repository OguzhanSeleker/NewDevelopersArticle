using NDA.Core.Domain;
using System;

namespace NDA.Domain.ArticleAggreagte.Events
{
    public class CommentsClearedOnArticleDomainEvent : EventBase
    {
        public Guid ArticleId { get; private set; }

        public CommentsClearedOnArticleDomainEvent(Guid id)
        {
            ArticleId = id;
        }
    }
}