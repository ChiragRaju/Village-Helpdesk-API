using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Domain.Common;

namespace HelpDesk.Domain.Entities.DTO
{
    public class UserDto: AuditableEntity
    {
        [Required]
        public string AadharNumber { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
