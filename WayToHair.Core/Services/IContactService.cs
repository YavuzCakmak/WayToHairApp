using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayToHair.Core.DTOs;
using WayToHair.Core.WayToHairEntites;
using WayToHair.Service.Util;

namespace WayToHair.Core.Services
{
    public interface IContactService : IService<Contact>
    {
        public Task SendMail(EmailModel emailModel);
    }
}
