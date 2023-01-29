using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayToHair.Core;

namespace WayToHair.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<ContactEntity> ContactEntity { get; set; }
        public DbSet<FaqEntity> FaqEntity { get; set; }
        public DbSet<SidebarEntity> SidebarEntity { get; set; }
    }
}
