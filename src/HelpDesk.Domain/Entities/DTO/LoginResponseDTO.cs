using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Entities.DTO
{
    public class LoginResponseDTO
    {
        public LocalUsers User { get; set; }
        public string Token { get; set; }
    }
}
