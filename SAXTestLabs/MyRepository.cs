using SAX.CoreLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAXTestLabs
{
    public class MyRepository : Repository<Person>, IMyRepository
    {
        public MyRepository(MyDbContext context) : base(context)
        {
        }

        public IEnumerable<Person> GetPeople()
        {
            return GetAll();
        }

        public void AddPerson(Person person)
        {
            AddAndSaved(person);
        }

        public Person GetPersonByName(string name)
        {
            return Find(p => p.Name == name).FirstOrDefault();
        }
    }
}
