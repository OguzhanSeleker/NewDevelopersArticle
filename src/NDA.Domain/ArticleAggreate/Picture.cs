using NDA.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDA.Domain.ArticleAggreate
{
    //Valur Object
    public class Picture : BaseValueObject
    {
        public string Name { get; private set; }
        public string Base64 { get; private set; }
        private Picture() { }

        public Picture(string name, string base64)
        {
            Name = name;
            Base64 = base64;
        }
        public void Update(string name, string base64)
        {
            if (Base64 != base64)
                Base64 = base64;
            if (Name != name)
                Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Base64;
        }
    }
}
