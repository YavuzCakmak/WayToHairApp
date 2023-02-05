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
    public class ContentRepository : GenericRepository<Content>, IContentRepository
    {
        public ContentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
