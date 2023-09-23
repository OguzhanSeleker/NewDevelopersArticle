using NDA.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDA.Domain.Articles
{
    public sealed class Article : EntityRootBase
    {
        public string ArticleTitle { get; private set; }
        public string Description { get; private set; }
        public Picture TitlePicture { get; set; }
        private Article() { }

        public Guid WriterId { get; private set; }

        public List<Guid> ContributerIdList { get; private set; }

        public void AddContributer(Guid developerId)
        {
            ContributerIdList ??= new List<Guid>();
            ContributerIdList.Add(developerId);
        }
        public void RemoveContributer(Guid developerId)
        {
            ContributerIdList?.Remove(developerId);
        }

        public Article(string articleTitle, string description, Picture titlePicture, Guid writerId)
        {
            ArticleTitle = articleTitle ?? throw new ArgumentNullException(nameof(articleTitle));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            TitlePicture = titlePicture ?? throw new ArgumentNullException(nameof(titlePicture));
            WriterId = writerId;
        }
        public void Update(string articleTitle, string description, Picture titlePicture)
        {
            ArticleTitle = articleTitle ?? throw new ArgumentNullException(nameof(articleTitle));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            if (titlePicture == null) 
                throw new ArgumentNullException(nameof(titlePicture));
            TitlePicture.Update(titlePicture.Name, titlePicture.Base64);
        }
    }
}
