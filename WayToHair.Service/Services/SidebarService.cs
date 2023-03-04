using AutoMapper;
using Microsoft.Data.SqlClient.DataClassification;
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
                    var isSucces = false;
                    meaningModel = meaningModels.Find(x => x.DataId == sidebar.Id && x.LanguageType == languageType);
                    if (meaningModel != null)
                    {
                        if (meaningModel.Description == "Anasayfa" && isSucces == false)
                        {
                            isSucces = true;
                            sidebarResponseDtos.Add(new SidebarResponseDto
                            {
                                Id = sidebar.Id,
                                Label = meaningModel.Description,
                                Href = "/",
                                Sequence = sidebar.Sequence
                            });
                        }
                        if (meaningModel.Description == "Home Page" && isSucces == false)
                        {
                            isSucces = true;
                            sidebarResponseDtos.Add(new SidebarResponseDto
                            {
                                Id = sidebar.Id,
                                Label = meaningModel.Description,
                                Href = "/",
                                Sequence = sidebar.Sequence
                            });
                        }
                        else
                        {
                            var englishHref = _meaningService.Where(x => x.DataId == sidebar.Id && x.TableType == Convert.ToInt32(Table.SIDEBAR) && x.LanguageType == (int)Language.EN).FirstOrDefault();
                            sidebarResponseDtos.Add(new SidebarResponseDto
                            {
                                Id = sidebar.Id,
                                Label = meaningModel.Description,
                                Href = englishHref.Description,
                                Sequence = sidebar.Sequence
                            });
                        }
                    }
                   

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
                            if (meaningModel != null)
                            {
                                currentSidebar.ChildSideBarResponseDto.Add(new ChildSideBarResponseDto
                                {
                                    Id = childObject.Id,
                                    Label = meaningModel.Description,
                                    Href = currentSidebar.Href
                                });
                            }
                        }
                    }
                }
            }
            return sidebarResponseDtos.OrderBy(x=> x.Sequence).ToList();
        }
    }
}
