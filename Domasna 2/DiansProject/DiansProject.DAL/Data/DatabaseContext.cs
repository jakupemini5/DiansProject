using DiansProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiansProject.DAL.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Feature> Features { get; set; }
        public DbSet<Geometry> Geometries { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLazyLoadingProxies();

        }
    }
}
