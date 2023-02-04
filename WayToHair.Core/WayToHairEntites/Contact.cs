using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayToHair.Core.WayToHairEntites
{
    public class Contact : BaseEntity
    {
        [Column("email")]
        public string Email { get; set; }
        [Column("message")]
        public string Message { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
