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
    public class SidebarService : Service<Sidebar>, ISidebarService
    {
        private readonly ISidebarRepository _sidebarRepository;
        private readonly IMapper _mapper;

        public SidebarService(IGenericRepository<Sidebar> repoistory, IUnitOfWork unitOfWork, IMapper mapper, ISidebarRepository sidebarRepository) : base(repoistory, unitOfWork)
        {
            _mapper = mapper;
            _sidebarRepository = sidebarRepository;
        }
    }
}
