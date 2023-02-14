using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayToHair.Core.WayToHairEntites
{
    public class Meaning : BaseEntity
    {
        [Column("data_id")]
        public int? DataId { get; set; }
        [Column("question")]
        public string? Question { get; set; }
        [Column("answer")]
        public string? Answer { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("table_type")]
        public byte TableType { get; set; }

        [Column("language_type")]
        public byte LanguageType { get; set; }
    }
}
