using NDA.Core.Domain;
using NDA.Domain.ArticleAggregate;
using NDA.Domain.DeveloperAggregate.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace NDA.Domain.DeveloperAggregate
{
    public sealed class Developer : EntityRootBase
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Title Title { get; private set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string FullQualifiedName
        {
            get
            {
                return $"{Title.Level.ToString()} {Title.TitleName} {FullName}";
            }
        }
        public List<Article> Articles { get; private set; }

        public List<CommentItem> Comments { get; private init; }

        private Developer() { }

        public Developer(string firstName, string lastName, Title title)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Title = title ?? throw new ArgumentNullException(nameof(title));
            this.AddDomainEvent(new DeveloperAddedDomainEvent(Id));
        }

        public void Update(string firstName, string lastName, Title title)
        {
            if (firstName != FirstName)
                FirstName = firstName;
            if (LastName != lastName)
                LastName = lastName;
            if (!Title.Equals(title))
                Title = title;

            this.AddDomainEvent(new DeveloperUpdatedDomainEvent(Id));
        }

        public void AddArticle(Article article)
        {
            Articles ??= new List<Article>();
            Articles.Add(article);
        }

    }
}
