﻿using Microsoft.EntityFrameworkCore;
using WayToHair.Core.WayToHairEntites;

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
        public DbSet<ContentEntity> ContentEntity { get; set; }
    }
}