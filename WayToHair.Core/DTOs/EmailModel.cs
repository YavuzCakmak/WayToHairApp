using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayToHair.Service.Util
{
    public class EmailModel
    {
        public string Body { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string To { get; set; }
        public string Password { get; set; }
    }
}
