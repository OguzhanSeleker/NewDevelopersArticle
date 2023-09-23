﻿using NDA.Core.Domain;
using System;

namespace NDA.Domain.ArticleAggreate.Events
{
    public class ArticlePublishedDomainEvent : EventBase
    {
        public Guid ArticleId { get; private set; } 

        public ArticlePublishedDomainEvent(Guid id)
        {
            this.ArticleId = id;
        }
    }
}