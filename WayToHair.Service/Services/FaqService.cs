using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class FaqService : Service<Faq>, IFaqService
    {
        private readonly IFaqRepository _faqRepository;
        private readonly IMapper _mapper;
        private readonly IMeaningService _meaningService;
        public FaqService(IGenericRepository<Faq> repoistory, IUnitOfWork unitOfWork, IMapper mapper, IFaqRepository faqRepository, IMeaningService meaningService) : base(repoistory, unitOfWork)
        {
            _mapper = mapper;
            _faqRepository = faqRepository;
            _meaningService = meaningService;
        }

        public async Task<List<FaqDto>> GetAllFaqAndMeaning(byte languageType)
        {
            List<FaqDto> faqDtos = new List<FaqDto>();
            var faqs = await base.GetAllAsync();
            if (faqs != null)
            {
                var faqMeanings = _meaningService.Where(x => x.TableType == Convert.ToInt32(Table.FAQ)).ToList();
                foreach (var faq in faqs.ToList())
                {
                    var selectedMeaning = faqMeanings.Find(x => x.DataId == faq.Id && x.LanguageType == languageType);
                    faqDtos.Add(new FaqDto
                    {
                        Answer = selectedMeaning.Answer,
                        Question = selectedMeaning.Question,
                        Sequence = faq.Sequence,
                        Id = faq.Id,
                        IsView = faq.IsView
                    });
                }
            }
            return faqDtos;
        }
    }
}
