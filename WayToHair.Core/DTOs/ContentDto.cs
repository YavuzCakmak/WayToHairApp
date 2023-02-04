﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayToHair.Core.DTOs
{
    public class ContentDto : BaseDto
    {
        public long? SidebarId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string IsView { get; set; }
        public int Sequence { get; set; }
    }
}