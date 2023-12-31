﻿using NDA.Core.Domain;
using NDA.Core.Helpers;
using NDA.Domain.ArticleAggregate.Events;
using NDA.Domain.ArticleAggregate.Exceptions;
using NDA.Domain.DeveloperAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDA.Domain.ArticleAggregate
{
    public sealed class Article : EntityRootBase
    {
        private Article() { }
        public string ArticleTitle { get; private set; }
        public string Description { get; private set; }
        public Picture TitlePicture { get; private set; }
        public Developer Developer { get; private set; }
        public bool Published { get; private set; }
        public DateTime? PublishedDate { get; private set; }
        public List<Developer> ContributerList { get; private set; } = new List<Developer>();
        public List<CommentItem> Comments { get; private set; } = new List<CommentItem>();
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedDate { get; private set; }

        public void Delete()
        {
            IsDeleted = true;
            DeletedDate = DateTimeHelper.NewDateTime();
            AddDomainEvent(new ArticleDeletedDomainEvent(Id));
        }
        public void Publish()
        {
            Published = true;
            PublishedDate = DateTimeHelper.NewDateTime();
            AddDomainEvent(new ArticlePublishedDomainEvent(Id));
        }

        public Article(string articleTitle, string description, Picture titlePicture, Developer developer)
        {
            ArticleTitle = articleTitle ?? throw new ArgumentNullException(nameof(articleTitle));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            TitlePicture = titlePicture ?? throw new ArgumentNullException(nameof(titlePicture));
            Developer = developer;
            IsDeleted = false;
            Published = false;
            AddDomainEvent(new ArticleAddedDomainEvent(Id));
        }
        public void Update(string articleTitle, string description, Picture titlePicture)
        {
            ArticleTitle = articleTitle ?? throw new ArgumentNullException(nameof(articleTitle));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            if (titlePicture == null)
                throw new ArgumentNullException(nameof(titlePicture));
            TitlePicture.Update(titlePicture.Name, titlePicture.Base64);

            Updated = DateTimeHelper.NewDateTime();
        }
        public void AddContributer(Developer developer)
        {
            ContributerList ??= new List<Developer>();
            ContributerList.Add(developer);
            AddDomainEvent(new ContributerAddedToArticleDomainEvent(Id, developer.Id));
        }
        public void RemoveContributer(Developer developer)
        {
            ContributerList?.Remove(developer);
            AddDomainEvent(new ContributerRemovedOnArticleDomainEvent(Id, developer.Id));
        }

        public void AddComment(string content, Guid developerId)
        {
            Comments ??= new List<CommentItem>();
            CommentItem item = new CommentItem(content, developerId, Id);
            Comments.Add(item);
            AddDomainEvent(new CommentAddedToArticleDomainEvent(item.Id));
        }
        public void ClearComments()
        {
            Comments?.Clear();
            AddDomainEvent(new CommentsClearedOnArticleDomainEvent(Id));
        }
        public void RemoveComment(Guid id)
        {
            if (Comments.Any(i => i.Id == id))
                Comments?.Remove(Comments.Find(i => i.Id == id));
            else
                throw new CommentNotFoundException(id);

            AddDomainEvent(new CommentRemovedOnArticleDomainEvent(id));
        }
    }
}
