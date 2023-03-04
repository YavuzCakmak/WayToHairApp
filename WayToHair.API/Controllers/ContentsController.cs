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

        public ContentsController(IContentService contentService, IMapper mapper)
        {
            _contentService = contentService;
            _mapper = mapper;
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

        [HttpGet("GetSidebarAndContent")]
        public async Task<IActionResult> GetSidebarAndContent([FromQuery] byte sidebarId, [FromQuery] byte languageType)
        {
            var sidebarDtos = await _contentService.GetSidebarAndContent(sidebarId, languageType);
            return CreateActionResult(CustomResponseDto<ContentDto>.Succces((int)HttpStatusCode.OK, sidebarDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ContentDto contentDto)
        {
            var content = await _contentService.AddAsync(_mapper.Map<Content>(contentDto));
            return CreateActionResult(CustomResponseDto<ContentDto>.Succces((int)HttpStatusCode.OK, _mapper.Map<ContentDto>(content)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ContentDto contentDto)
        {
            await _contentService.UpdateAsync(_mapper.Map<Content>(contentDto));
            return CreateActionResult(CustomResponseDto<ContentDto>.Succces((int)HttpStatusCode.OK));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var contentModel = await _contentService.GetByIdAsync(id);
            await _contentService.RemoveAsync(contentModel);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succces((int)HttpStatusCode.OK));
        }

    }
}
