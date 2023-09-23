using NDA.Core.Domain;
using System;

namespace NDA.Domain.ArticleAggreagte.Events
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