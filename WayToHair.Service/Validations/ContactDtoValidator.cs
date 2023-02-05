using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayToHair.Core.DTOs;

namespace WayToHair.Service.Validations
{
    public class ContactDtoValidator : AbstractValidator<ContactDto>
    {
        public ContactDtoValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("E-Mail Boş olamaz.").NotEmpty().WithMessage("E-Mail Boş olamaz.");
            RuleFor(x=> x.Message).NotNull().WithMessage("Mesaj Boş olamaz.").NotEmpty().WithMessage("Mesaj Boş olamaz.");
            RuleFor(x=> x.PhoneNumber).NotNull().WithMessage("Telefon No Boş olamaz.").NotEmpty().WithMessage("Telefon No Boş olamaz.");
        }
    }
}
