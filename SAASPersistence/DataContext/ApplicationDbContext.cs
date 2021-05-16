using Microsoft.EntityFrameworkCore;
using SAASDomain.Entities;
using SAASPersistenc.DataContext;
using SAASPersistence.Seeds;
using System.Reflection;
using System.Threading.Tasks;

namespace SAASPersistence.DataContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {
          
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            EnsureCreated();            
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<SubscriptionPackage> SubscriptionPackage { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Seed();
        }

        private void EnsureCreated()
        {
            this.Database.EnsureCreated();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
