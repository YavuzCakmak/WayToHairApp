using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayToHair.Core.WayToHairEntites
{
    public class ContentEntity :  BaseEntity
    {
        public int? SidebarId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string IsView { get; set; }
        public int Sequence { get; set; }
    }
}
