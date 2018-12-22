using Microsoft.EntityFrameworkCore;
using SAX.CoreLibrary.Models;

namespace SAX.CoreLibrary.Data
{
    public abstract class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new SoftDeleteBehavior().Deletable(modelBuilder);
        }
        
        public virtual DbSet<Identity> Identities { get; }
    }
}
