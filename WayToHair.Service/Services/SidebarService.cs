using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayToHair.Core.DTOs;
using WayToHair.Core.Repositories;
using WayToHair.Core.Services;
using WayToHair.Core.UnitOfWorks;
using WayToHair.Core.WayToHairEntites;
using WayToHair.Service.Util;

namespace WayToHair.Service.Services
{
    public class SidebarService : Service<Sidebar>, ISidebarService
    {
        private readonly ISidebarRepository _sidebarRepository;
        private readonly IMapper _mapper;
        private readonly IMeaningService _meaningService;

        public SidebarService(IGenericRepository<Sidebar> repoistory, IUnitOfWork unitOfWork, IMapper mapper, ISidebarRepository sidebarRepository, IMeaningService meaningService) : base(repoistory, unitOfWork)
        {
            _mapper = mapper;
            _sidebarRepository = sidebarRepository;
            _meaningService = meaningService;
        }

        public async Task<List<SidebarResponseDto>> GetAllSidebarAndMeaning(byte languageType)
        {
            List<SidebarResponseDto> sidebarResponseDtos = new List<SidebarResponseDto>();
            List<Meaning> meaningModels = new List<Meaning>();
            Meaning meaningModel = new Meaning();

            var sidebars = await base.GetAllAsync();
            if (sidebars != null && sidebars.Count() > 0)
            {
                meaningModels = _meaningService.Where(x => x.TableType == Convert.ToInt32(Table.SIDEBAR)).ToList();
                foreach (var sidebar in sidebars.ToList().Where(x => x.ParentId == null))
                {
                    meaningModel = meaningModels.Find(x => x.DataId == sidebar.Id && x.LanguageType == languageType);
                    sidebarResponseDtos.Add(new SidebarResponseDto
                    {
                        Id = sidebar.Id,
                        Label = meaningModel.Description,
                        Href = meaningModel.Description
                    });
                }

                var childObjects = sidebars.ToList().FindAll(x => x.ParentId != null);
                if (childObjects != null && childObjects.Count > 0)
                {
                    foreach (var childObject in childObjects)
                    {
                        var currentSidebar = sidebarResponseDtos.Find(x => x.Id == childObject.ParentId);
                        if (currentSidebar != null)
                        {
                            meaningModel = meaningModels.Find(x => x.DataId == childObject.Id && x.LanguageType == languageType);
                            currentSidebar.ChildSideBarResponseDto = new ChildSideBarResponseDto
                            {
                                Label = meaningModel.Description,
                                Href = meaningModel.Description,
                                SubLabel = "Test"
                            };
                        }
                    }
                }
            }
            return sidebarResponseDtos;
        }
    }
}
