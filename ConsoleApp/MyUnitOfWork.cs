using ConsoleApp.Data;
using ConsoleApp.Models;
using SAX.CoreLibrary.Domains.Interfaces;
using SAX.CoreLibrary.Repositories;
using SAX.CoreLibrary.UnitOfWork;

namespace ConsoleApp
{
    public class MyUnitOfWork : UnitOfWork
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Employee> _employeeRepository;

        public MyUnitOfWork(MyContext context) : base(context)
        {
            _personRepository = new Repository<Person>(context);
            _employeeRepository = new Repository<Employee>(context);
        }

        public IRepository<Person> PersonRepository()
        {
            return _personRepository;
        }

        public IRepository<Employee> EmployeeRepository()
        {
            return _employeeRepository;
        }

    }
}
