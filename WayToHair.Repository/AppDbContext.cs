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
        public DbSet<Faq> Faq { get; set; }
        public DbSet<SidebarEntity> Sidebar { get; set; }
        public DbSet<Content> Content { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
