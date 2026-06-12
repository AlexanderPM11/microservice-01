using Microsoft.EntityFrameworkCore;
using microservice_01.Entities;

namespace microservice_01.Data
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items => Set<Item>();
    }
}
