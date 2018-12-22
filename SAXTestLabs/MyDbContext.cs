using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using SAX.CoreLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAXTestLabs
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new SoftDeleteBehavior().Deletable(modelBuilder);
        }

        public DbSet<Person> Person { get; set; }
    }
}
