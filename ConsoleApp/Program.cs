using ConsoleApp.Data;
using ConsoleApp.Models;
using SAX.CoreLibrary.Domains.Interfaces;
using SAX.CoreLibrary.Repositories;
using SAX.CoreLibrary.UnitOfWork;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //var context = new MyContext();
            //var context2 = new MyContext();

            //var per = new Person { Name = "MSL MSAX 1", Info = "X This ex information 1" };
            //var per2 = new Person { Name = "MSL MSAX 2", Info = "Y This ex information 2" };
            //var per3 = new Person { Name = "MSL MSAX 3", Info = "Y This ex information 3" };

            //List<Person> people = new List<Person>();
            //people.Add(per);
            //people.Add(per2);
            //people.Add(per3);

            //var uow = new MyUnitOfWork(context);

            //uow.PersonRepository().Add(per);
            //uow.PersonRepository().Add(per2);
            //uow.PersonRepository().Add(per3);

            ////Console.WriteLine(uow.Complete());

            //var uow2 = new MyUnitOfWork(context);

            //var perX = new Person { Name = "2 XX MSL MSAX X", Info = "2 XX This ex information X" };
            //var empX = new Employee { Name = "XX MSL MSAX X", Salary = 1000 };

            //uow2.PersonRepository().Detached(people);

            //uow2.PersonRepository().Add(perX);
            //uow2.EmployeeRepository().Add(empX);

            //uow2.PersonRepository().Attached(people);

            //Console.WriteLine(uow2.Complete());

            Console.WriteLine("================");
            Console.WriteLine("Exiting");
            Console.Read();
        }
    }
}
