using Microsoft.EntityFrameworkCore;
using SAASDomain.Entities;
using System.Threading.Tasks;

namespace SAASPersistenc.DataContext
{
    public interface IApplicationDbContext
    {
        DbSet<User> User { get; set; }
        DbSet<SubscriptionPackage> SubscriptionPackage { get; set; }
        DbSet<Region> Region { get; set; }
        DbSet<Country> Country { get; set; }
      

        Task<int> SaveChangesAsync();
    }
}
