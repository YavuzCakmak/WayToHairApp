using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayToHair.Core.Repositories;
using WayToHair.Core.Services;
using WayToHair.Core.UnitOfWorks;
using WayToHair.Core.WayToHairEntites;
using WayToHair.Repository.Repositories;
using WayToHair.Service.Util;

namespace WayToHair.Service.Services
{
    public class ConctactService : Service<Contact>, IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly IOptions<WayToHairSettings> WayToHairSetting ;

        public ConctactService(IGenericRepository<Contact> repoistory, IUnitOfWork unitOfWork, IMapper mapper, IContactRepository contactRepository, IOptions<WayToHairSettings> wayToHairSetting) : base(repoistory, unitOfWork)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
            WayToHairSetting = wayToHairSetting;
        }
    }
}
