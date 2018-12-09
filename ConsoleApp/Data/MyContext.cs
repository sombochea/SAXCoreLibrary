using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using SAX.CoreLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Data
{
    public class MyContext : DataContext
    {
        public MyContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Test;Trusted_Connection=True;");
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
