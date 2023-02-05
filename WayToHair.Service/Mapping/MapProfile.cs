using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayToHair.Core.DTOs;
using WayToHair.Core.WayToHairEntites;

namespace WayToHair.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Contact,ContactDto>().ReverseMap(); 
            CreateMap<Content,ContentDto>().ReverseMap(); 
            CreateMap<Faq,FaqDto>().ReverseMap(); 
            CreateMap<SidebarEntity,SidebarDto>().ReverseMap(); 
        }
    }
}
