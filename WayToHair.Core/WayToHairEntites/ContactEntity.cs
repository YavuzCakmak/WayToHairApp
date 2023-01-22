using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayToHair.Core
{
    public class ContactEntity : BaseEntity
    {
        public string Email { get; set; }
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
    }
}
