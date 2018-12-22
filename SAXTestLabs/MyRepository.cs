using SAX.CoreLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAXTestLabs
{
    public class MyRepository : Repository<Person>, IMyRepository
    {
        private readonly MyDbContext _context;
        public MyRepository(MyDbContext context) : base(context)
        {
            _context = context;
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

        public override bool IsExists(object primaryKey)
        {
            return _context.Person.Any(p => p.Id == int.Parse(primaryKey +""));
        }

        public override bool IsExists(string pearValue)
        {
            return _context.Person.Any(p => p.Name == pearValue);
        }
        
    }
}
