# SAXCoreLibrary
## Using ASP.NET Core 2.2
### Repositories with Unit Of Work and more.

#### Build State
[![Build Status](https://saxio.visualstudio.com/SAXIOProjectabytes/_apis/build/status/SomboChea.SAXCoreLibrary)](https://saxio.visualstudio.com/SAXIOProjectabytes/_build/latest?definitionId=2)

---
## Requirements & Includes
* Dotnet Core 2.2
* Visual Studio 2017 (For Deploy codes)
---
## Design Patterns
* OOP (Interface, Abstract, Inheritance, Encapsulation, Polymorphism)
* Repositories
    * BaseRepository
    * Repository
* Unit of Work
    * UnitOfWork
* Dependency Injection
    * IRepository
    * ICRUDRepository
    * ISoftDeletable
    * IUnitOfWork
---
## Installation
    git clone https://github.com/SomboChea/SAXCoreLibrary.git
<br />

    cd SAX.CoreLibrary
    dotnet restore
    dotnet build

<br />

## Test (xUnit)

    cd SAXTestLabs
    dotnet restore
    dotnet test

<br />

## How to use (with Test)

* Person.cs
    ```c#
      public class Person
      {
           public int Id { get; set; }
           public string Name { get; set; }
      }
    ```
* MyDbContext.cs
    ```c#
      public class MyDbContext : DbContext
      {
           public MyDbContext(DbContextOptions options) : base(options)
           {
           }

           public DbSet<Person> Person { get; set; }
      }
    ```
* IMyRepository.cs
    ```c#
      public interface IMyRepository : IRepository<Person>
      {
           IEnumerable<Person> GetPeople();
           void AddPerson(Person person);
           Person GetPersonByName(string name);
      }
    ```  
* MyRepository.cs
   ```c#
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
    ```
* IMyUnitOfWork.cs
   ```c#
      public interface IMyUnitOfWork : IUnitOfWork
      {
           IMyRepository PersonRepository();
      }
    ```
* MyUnitOfWork.cs
    ```c#
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
    ```
 ---
* Test Methods
    ```c#
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
    ```
 ---
# LICENSE

MIT License

Copyright (c) 2018 Sambo Chea

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
