using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayToHair.Core.WayToHairEntites
{
    public class Faq : BaseEntity
    {
        [Column("parent_id")]
        public int? ParentId { get; set; }
        [Column("question")]
        public string? Question { get; set; }
        [Column("answer")]
        public string? Answer { get; set; }
        [Column("is_view")]
        public bool? IsView { get; set; }
        [Column("sequence")]
        public int? Sequence { get; set; }
    }
}
