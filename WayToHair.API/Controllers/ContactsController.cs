using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WayToHair.API.Filters;
using WayToHair.Core.DTOs;
using WayToHair.Core.Services;
using WayToHair.Core.WayToHairEntites;

namespace WayToHair.API.Controllers
{
    [ValidateFilterAttribute]
    public class ContactsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IContactService _service;

        public ContactsController(IMapper mapper, IContactService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var contacts = await _service.GetAllAsync();
            var contactDtos = _mapper.Map<List<ContactDto>>(contacts.ToList());
            return CreateActionResult(CustomResponseDto<List<ContactDto>>.Succces(200, contactDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Contact>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _service.GetByIdAsync(id);
            var contactDto = _mapper.Map<ContactDto>(contact);
            return CreateActionResult(CustomResponseDto<ContactDto>.Succces(20, contactDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ContactDto contactDto)
        {
            var contact = await _service.AddAsync(_mapper.Map<Contact>(contactDto));
            return CreateActionResult(CustomResponseDto<ContactDto>.Succces(200, _mapper.Map<ContactDto>(contact)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ContactDto contactDto)
        {
            await _service.UpdateAsync(_mapper.Map<Contact>(contactDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succces(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var contactModel = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(contactModel);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succces(204));
        }
    }

}
