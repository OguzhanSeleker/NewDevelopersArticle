using System;
using System.Runtime.Serialization;

namespace NDA.Domain.ArticleAggreate.Exceptions
{
    [Serializable]
    public class CommentNotFoundException : Exception
    {
        private Guid id;

        public CommentNotFoundException()
        {
        }

        public CommentNotFoundException(Guid id)
        {
            this.id = id;
        }

        public CommentNotFoundException(string message) : base(message)
        {
        }

        public CommentNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CommentNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}