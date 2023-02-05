using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WayToHair.API.Filters;
using WayToHair.Core.DTOs;
using WayToHair.Core.Services;
using WayToHair.Core.WayToHairEntites;

namespace WayToHair.API.Controllers
{
    [ValidateFilter]
    public class FaqsController : CustomBaseController
    {
        private readonly IFaqService _faqService;
        private readonly IMapper _mapper;

        public FaqsController(IFaqService faqService, IMapper mapper)
        {
            _faqService = faqService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var faqs = await _faqService.GetAllAsync();
            var faqsDtos = _mapper.Map<List<FaqDto>>(faqs.ToList());
            return CreateActionResult(CustomResponseDto<List<FaqDto>>.Succces((int)HttpStatusCode.OK, faqsDtos));
        }


        [ServiceFilter(typeof(NotFoundFilter<Faq>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var faq = await _faqService.GetByIdAsync(id);
            var faqDto = _mapper.Map<FaqDto>(faq);
            return CreateActionResult(CustomResponseDto<FaqDto>.Succces((int)HttpStatusCode.OK, faqDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(FaqDto faqDto)
        {
            var faq = await _faqService.AddAsync(_mapper.Map<Faq>(faqDto));
            return CreateActionResult(CustomResponseDto<FaqDto>.Succces((int)HttpStatusCode.OK, _mapper.Map<FaqDto>(faq)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(FaqDto faqDto)
        {
            await _faqService.UpdateAsync(_mapper.Map<Faq>(faqDto));
            return CreateActionResult(CustomResponseDto<FaqDto>.Succces((int)HttpStatusCode.OK));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var faqModel = await _faqService.GetByIdAsync(id);
            await _faqService.RemoveAsync(faqModel);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succces((int)HttpStatusCode.OK));
        }

    }
}
