using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Entities.DTO
{
    public class LoginRequestUserDTO
    {
        public string AadharNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}
