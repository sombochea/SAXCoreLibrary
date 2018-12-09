using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace SAXTestLabs
{
    public class Program
    {
        [Fact]
        public void TestRepository()
        {
            Console.WriteLine("Starting Repository Test...");
            
            var optionBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionBuilder.UseInMemoryDatabase("MyDbMem");

            var context = new MyDbContext(optionBuilder.Options);

            IMyRepository repository = new MyRepository(context);

            Person p = new Person { Id = 1, Name = "Sambo" };
            Person p2 = new Person { Id = 2, Name = "Chea" };

            repository.AddPerson(p);
            repository.AddPerson(p2);

            Assert.Equal(p, repository.GetById(1));
            Assert.Equal(p2, repository.GetById(2));

        }

        [Fact]
        public void TestUnitOfWork()
        {
            Console.WriteLine("Starting UnitOfWork Test...");

            var optionBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionBuilder.UseInMemoryDatabase("MyDbMem2");

            var context = new MyDbContext(optionBuilder.Options);

            IMyUnitOfWork unitOfWork = new MyUnitOfWork(context);

            Person p = new Person { Id = 1, Name = "Sambo" };
            Person p2 = new Person { Id = 2, Name = "Chea" };

            unitOfWork.PersonRepository().Add(p);
            unitOfWork.PersonRepository().Add(p2);
            unitOfWork.Complete();

            Assert.Equal(p, unitOfWork.PersonRepository().GetPersonByName(p.Name));
            Assert.Equal(p2, unitOfWork.PersonRepository().GetPersonByName(p2.Name));
        }
    }
}
