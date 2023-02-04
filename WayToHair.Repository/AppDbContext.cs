using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WayToHair.Core.WayToHairEntites;

namespace WayToHair.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<FaqEntity> FaqEntity { get; set; }
        public DbSet<SidebarEntity> SidebarEntity { get; set; }
        public DbSet<ContentEntity> ContentEntity { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
