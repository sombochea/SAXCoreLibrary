using SAX.CoreLibrary.Domains.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAXTestLabs
{
    public interface IMyRepository : IRepository<Person>
    {
        IEnumerable<Person> GetPeople();
        void AddPerson(Person person);
        Person GetPersonByName(string name);
    }
}
