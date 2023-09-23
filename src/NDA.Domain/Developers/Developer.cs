using NDA.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NDA.Domain.Developers
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

        private Developer() { }

        public Developer(string firstName, string lastName, Title title)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }

        public void Update(string firstName, string lastName,Title title)
        {
            if(firstName != this.FirstName)
                this.FirstName= firstName;
            if(this.LastName != lastName) 
                this.LastName= lastName;
            if(!this.Title.Equals(title))
                this.Title = title;
        }
    }
}
