using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayToHair.Core.WayToHairEntites
{
    public class Content :  BaseEntity
    {
        [Column("sidebar_id")]
        public int? SidebarId { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("title")]
        public string? Title { get; set; }
        [Column("is_view")]
        public bool IsView { get; set; }
        [Column("sequence")]
        public int? Sequence { get; set; }
    }
}
