using NDA.Core.Domain;
using System;

namespace NDA.Domain.ArticleAggregate.Events
{
    public class CommentRemovedOnArticleDomainEvent : EventBase
    {
        private Guid CommentId;

        public CommentRemovedOnArticleDomainEvent(Guid id)
        {
            CommentId = id;
        }
    }
}