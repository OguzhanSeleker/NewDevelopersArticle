using System;
using System.Collections.Generic;
using System.Text;

namespace NDA.Domain.DeveloperAggregate
{
    //Value Object
    public class Title
    {
        public string TitleName { get; private set; }
        public eLevel Level { get; set; }
        public string TitleDescription { get; private set; }

        private Title() { }
        public Title(string titleName, string titleDescription, eLevel level) { TitleName = titleName; TitleDescription = titleDescription; Level = level; }

    }
}
