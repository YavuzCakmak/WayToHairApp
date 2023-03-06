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
        private readonly IFaqService _faqService;
        private readonly IContentRepository _contenttRepository;
        private readonly IMapper _mapper;

        public ContentService(IGenericRepository<Content> repoistory, IUnitOfWork unitOfWork, IMapper mapper, IContentRepository contactRepository, IMeaningService meaningService, IFaqService faqService) : base(repoistory, unitOfWork)
        {
            _mapper = mapper;
            _contenttRepository = contactRepository;
            _meaningService = meaningService;
            _faqService = faqService;
        }

        public async Task<List<FaqDto>> GetAllFaqAndMeaning(byte languageType)
        {
            List<FaqDto> faqDtos = new List<FaqDto>();
            var faqs =  _faqService.GetAllAsync().Result;
            if (faqs != null)
            {
                var faqMeanings = _meaningService.Where(x => x.TableType == Convert.ToInt32(Table.FAQ)).ToList();
                foreach (var faq in faqs)
                {
                    var selectedMeaning = faqMeanings.Find(x => x.DataId == faq.Id && x.LanguageType == languageType);
                    if (selectedMeaning != null)
                    {
                        faqDtos.Add(new FaqDto
                        {
                            Answer = selectedMeaning.Answer,
                            Question = selectedMeaning.Question,
                            Sequence = faq.Sequence
                        });
                    }
                }
            }
            return faqDtos.OrderBy(x => x.Sequence).ToList();
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
