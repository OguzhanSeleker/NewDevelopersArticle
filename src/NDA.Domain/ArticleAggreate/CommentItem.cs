using NDA.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDA.Domain.ArticleAggreate
{
    public class CommentItem : Core.Domain.EntityRootBase, Core.Domain.IAggregateRoot
    {
        public string Content { get; private set; }
        public Guid WriterId { get; private set; }
        public Guid ArticleId { get; private set; }

        private CommentItem()
        {

        }

        public CommentItem(string content, Guid writerId, Guid articleId)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
            WriterId = writerId;
            ArticleId = articleId;
        }

        public void Update(string content)
        {
            if(string.IsNullOrEmpty(content))
                throw new ArgumentNullException(nameof(content));
            Content = content;
            Updated = DateTimeHelper.NewDateTime();
        }
    }
}
