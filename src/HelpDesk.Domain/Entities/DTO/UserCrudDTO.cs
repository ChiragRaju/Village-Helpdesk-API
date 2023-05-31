using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Entities.DTO
{
    public class UserCrudDTO
    {
        public int UserId { get;set; }
        public string FirstName { get;set; }
        public string LastName { get;set; }
        public string AadharNumber { get;set; }
    }
}
