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
    public class MeaningsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IMeaningService _service;

        public MeaningsController(IMapper mapper, IMeaningService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var meanings = await _service.GetAllAsync();
            var meaningDtos = _mapper.Map<List<MeaningDto>>(meanings.ToList());
            return CreateActionResult(CustomResponseDto<List<MeaningDto>>.Succces((int)HttpStatusCode.OK, meaningDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Meaning>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var meaning = await _service.GetByIdAsync(id);
            var meaningDto = _mapper.Map<MeaningDto>(meaning);
            return CreateActionResult(CustomResponseDto<MeaningDto>.Succces((int)HttpStatusCode.OK, meaningDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(MeaningDto meaningDto)
        {
            var meaning = await _service.AddAsync(_mapper.Map<Meaning>(meaningDto));
            return CreateActionResult(CustomResponseDto<MeaningDto>.Succces((int)HttpStatusCode.OK, _mapper.Map<MeaningDto>(meaning)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(MeaningDto meaningDto)
        {
            await _service.UpdateAsync(_mapper.Map<Meaning>(meaningDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succces((int)HttpStatusCode.OK));
        }

        [HttpGet("TEST")]
        public string Test()
        {
            return "OK";
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var meaningModel = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(meaningModel);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succces((int)HttpStatusCode.OK));
        }
    }

}
