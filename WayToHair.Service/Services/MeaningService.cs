using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayToHair.Core.Repositories;
using WayToHair.Core.Services;
using WayToHair.Core.UnitOfWorks;
using WayToHair.Core.WayToHairEntites;

namespace WayToHair.Service.Services
{
    public class MeaningService : Service<Meaning>, IMeaningService
    {
        private readonly IMeaningRepository _meaningRepository;
        private readonly IMapper _mapper;

        public MeaningService(IGenericRepository<Meaning> repoistory, IUnitOfWork unitOfWork, IMapper mapper, IMeaningRepository meaningRepository) : base(repoistory, unitOfWork)
        {
            _mapper = mapper;
            _meaningRepository = meaningRepository;
        }
    }
}
