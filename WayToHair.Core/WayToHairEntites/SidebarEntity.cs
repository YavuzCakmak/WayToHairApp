using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayToHair.Core
{
    public class SidebarEntity : BaseEntity
    {
        public long? ParentId { get; set; }
        public string Description { get; set; }
        public string IsView { get; set; }
        public int Sequence { get; set; }
    }
}
