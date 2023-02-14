using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayToHair.Core.DTOs
{
    public class MeaningDto : BaseDto
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public string? Description { get; set; }
        public int? DataId { get; set; }
        public byte TableType { get; set; }
        public byte LanguageType { get; set; }
    }
}
