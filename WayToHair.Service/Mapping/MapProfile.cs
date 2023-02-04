﻿using AutoMapper;
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
            CreateMap<ContactEntity,ContactDto>().ReverseMap(); 
            CreateMap<ContentEntity,ContentDto>().ReverseMap(); 
            CreateMap<FaqEntity,FaqDto>().ReverseMap(); 
            CreateMap<SidebarEntity,SidebarDto>().ReverseMap(); 
        }
    }
}