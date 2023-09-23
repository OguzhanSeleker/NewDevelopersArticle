using NDA.Core.Domain;
using System;

namespace NDA.Domain.ArticleAggreate.Events
{
    public class CommentsClearedOnArticleDomainEvent : EventBase
    {
        public Guid ArticleId { get; private set; }

        public CommentsClearedOnArticleDomainEvent(Guid id)
        {
            this.ArticleId = id;
        }
    }
}