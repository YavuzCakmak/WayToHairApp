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
    public class ContentsController : CustomBaseController
    {
        private readonly IContentService _contentService;
        private readonly IMapper _mapper;

        public ContentsController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var contents = await _contentService.GetAllAsync();
            var contentDtos = _mapper.Map<List<ContentDto>>(contents.ToList());
            return CreateActionResult(CustomResponseDto<List<ContentDto>>.Succces((int)HttpStatusCode.OK, contentDtos));
        }


        [ServiceFilter(typeof(NotFoundFilter<Content>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var content = await _contentService.GetByIdAsync(id);
            var contentDto = _mapper.Map<ContentDto>(content);
            return CreateActionResult(CustomResponseDto<ContentDto>.Succces((int)HttpStatusCode.OK, contentDto));
        }

    }
}
