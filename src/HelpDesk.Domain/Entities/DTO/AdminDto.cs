using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Domain.Common;

namespace HelpDesk.Domain.Entities.DTO
{
    public class AdminDto: AuditableEntity
    {
       
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType (DataType.Password)]  
        public string ConfirmPassword { get; set; }
        public Admin admin { get; set; }
        
       
    }
}
