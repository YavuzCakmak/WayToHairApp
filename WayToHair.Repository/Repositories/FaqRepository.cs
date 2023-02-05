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
    public class FaqRepository : GenericRepository<Faq>, IFaqRepository
    {
        public FaqRepository(AppDbContext context) : base(context)
        {
        }
    }
}
