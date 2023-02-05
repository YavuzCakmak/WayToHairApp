using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayToHair.Core.WayToHairEntites
{
    public class FaqEntity : BaseEntity
    {
        public int? ParentId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool IsView { get; set; }
        public int Sequence { get; set; }
    }
}
