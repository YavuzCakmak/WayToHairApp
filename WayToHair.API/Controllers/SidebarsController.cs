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
    public class SidebarsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ISidebarService _service;

        public SidebarsController(IMapper mapper, ISidebarService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var sidebars = await _service.GetAllAsync();
            var sidebarDtos = _mapper.Map<List<SidebarDto>>(sidebars.ToList());
            return CreateActionResult(CustomResponseDto<List<SidebarDto>>.Succces((int)HttpStatusCode.OK, sidebarDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Sidebar>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sidebar = await _service.GetByIdAsync(id);
            var sidebarDto = _mapper.Map<SidebarDto>(sidebar);
            return CreateActionResult(CustomResponseDto<SidebarDto>.Succces((int)HttpStatusCode.OK, sidebarDto));
        }

        [HttpGet("GetAllSidebarAndMeaning")]
        public async Task<IActionResult> GetAllSidebarAndMeaning([FromHeader] byte languageType)
        {
            var sidebarDtos = await _service.GetAllSidebarAndMeaning(languageType);
            return CreateActionResult(CustomResponseDto<List<SidebarResponseDto>>.Succces((int)HttpStatusCode.OK, sidebarDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(SidebarDto contactDto)
        {
            var sidebar = await _service.AddAsync(_mapper.Map<Sidebar>(contactDto));
            return CreateActionResult(CustomResponseDto<SidebarDto>.Succces((int)HttpStatusCode.OK, _mapper.Map<SidebarDto>(sidebar)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(SidebarDto contactDto)
        {
            await _service.UpdateAsync(_mapper.Map<Sidebar>(contactDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succces((int)HttpStatusCode.OK));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var sidebarModel = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(sidebarModel);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succces((int)HttpStatusCode.OK));
        }
    }

}
