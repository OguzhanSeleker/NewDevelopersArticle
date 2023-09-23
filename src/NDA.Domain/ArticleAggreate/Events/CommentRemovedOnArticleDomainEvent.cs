using NDA.Core.Domain;
using System;

namespace NDA.Domain.ArticleAggreate.Events
{
    public class CommentRemovedOnArticleDomainEvent : EventBase
    {
        private Guid CommentId;

        public CommentRemovedOnArticleDomainEvent(Guid id)
        {
            this.CommentId = id;
        }
    }
}