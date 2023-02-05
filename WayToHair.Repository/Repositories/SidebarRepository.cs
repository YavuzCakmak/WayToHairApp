using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayToHair.Core.Repositories;
using WayToHair.Core.WayToHairEntites;
using WayToHair.Repository.GenericRepository;

namespace WayToHair.Repository.Repositories
{
    public class SidebarRepository : GenericRepository<Sidebar>, ISidebarRepository
    {
        public SidebarRepository(AppDbContext context) : base(context)
        {
        }
    }
}
