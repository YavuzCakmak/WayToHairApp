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
    public class MeaningRepository : GenericRepository<Meaning>, IMeaningRepository
    {
        public MeaningRepository(AppDbContext context) : base(context)
        {
        }
    }
}
