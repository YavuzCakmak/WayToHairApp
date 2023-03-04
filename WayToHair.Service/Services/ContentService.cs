using AutoMapper;
using WayToHair.Core.DTOs;
using WayToHair.Core.Repositories;
using WayToHair.Core.Services;
using WayToHair.Core.UnitOfWorks;
using WayToHair.Core.WayToHairEntites;
using WayToHair.Service.Util;

namespace WayToHair.Service.Services
{
    public class ContentService : Service<Content>, IContentService
    {
        private readonly IMeaningService _meaningService;
        private readonly IContentRepository _contenttRepository;
        private readonly IMapper _mapper;

        public ContentService(IGenericRepository<Content> repoistory, IUnitOfWork unitOfWork, IMapper mapper, IContentRepository contactRepository, IMeaningService meaningService) : base(repoistory, unitOfWork)
        {
            _mapper = mapper;
            _contenttRepository = contactRepository;
            _meaningService = meaningService;
        }

        public async Task<ContentDto> GetSidebarAndContent(byte sidebarId, byte languageType)
        {
            #region Objects
            ContentDto contentDtos = new ContentDto();
            #endregion

            var meaning = _meaningService.Where(x => x.DataId == sidebarId && x.LanguageType == languageType && x.TableType == (int)Table.CONTENT).FirstOrDefault();
            if (meaning != null)
            {
                contentDtos.Description = meaning.Description;
                return contentDtos;
            }
            return contentDtos;
        }
    }
}
