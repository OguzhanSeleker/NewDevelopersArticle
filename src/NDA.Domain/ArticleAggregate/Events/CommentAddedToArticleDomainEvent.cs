using NDA.Core.Domain;
using System;

namespace NDA.Domain.ArticleAggregate.Events
{
    public class CommentAddedToArticleDomainEvent : EventBase
    {
        public Guid CommentId { get; private set; }
        private CommentAddedToArticleDomainEvent() { }
        public CommentAddedToArticleDomainEvent(Guid commentId)
        {
            CommentId = commentId;
        }
    }
}