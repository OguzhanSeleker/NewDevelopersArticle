using NDA.Core.Domain;
using NDA.Core.Helpers;
using NDA.Domain.ArticleAggreate.Events;
using NDA.Domain.ArticleAggreate.Exceptions;
using NDA.Domain.Developers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDA.Domain.ArticleAggreate
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
            this.IsDeleted = true;
            this.DeletedDate = DateTimeHelper.NewDateTime();
            this.AddDomainEvent(new ArticleDeletedDomainEvent(this.Id));
        }
        public void Publish()
        {
            this.Published = true;
            this.PublishedDate = DateTimeHelper.NewDateTime();
            this.AddDomainEvent(new ArticlePublishedDomainEvent(this.Id));
        }

        public Article(string articleTitle, string description, Picture titlePicture, Developer developer)
        {
            ArticleTitle = articleTitle ?? throw new ArgumentNullException(nameof(articleTitle));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            TitlePicture = titlePicture ?? throw new ArgumentNullException(nameof(titlePicture));
            Developer = developer;
            IsDeleted = false;
            Published = false;
            this.AddDomainEvent(new ArticleAddedDomainEvent(this.Id));
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
            this.AddDomainEvent(new ContributerAddedToArticleDomainEvent(this.Id, developer.Id));
        }
        public void RemoveContributer(Developer developer)
        {
            ContributerList?.Remove(developer);
            this.AddDomainEvent(new ContributerRemovedOnArticleDomainEvent(this.Id, developer.Id));
        }

        public void AddComment(string content, Guid developerId)
        {
            Comments ??= new List<CommentItem>();
            CommentItem item = new CommentItem(content, developerId, this.Id);
            Comments.Add(item);
            this.AddDomainEvent(new CommentAddedToArticleDomainEvent(item.Id));
        }
        public void ClearComments()
        {
            Comments?.Clear();
            this.AddDomainEvent(new CommentsClearedOnArticleDomainEvent(this.Id));
        }
        public void RemoveComment(Guid id)
        {
            if (Comments.Any(i => i.Id == id))
                Comments?.Remove(Comments.Find(i => i.Id == id));
            else
                throw new CommentNotFoundException(id);

            this.AddDomainEvent(new CommentRemovedOnArticleDomainEvent(id));
        }
    }
}
