using Microsoft.EntityFrameworkCore;
using SAX.CoreLibrary.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAXTestLabs
{
    public class MyUnitOfWork : UnitOfWork, IMyUnitOfWork
    {
        private readonly IMyRepository personRepository;
        public MyUnitOfWork(MyDbContext context) : base(context)
        {
            personRepository = new MyRepository(context);
        }

        public IMyRepository PersonRepository()
        {
            return personRepository;
        }
    }
}
