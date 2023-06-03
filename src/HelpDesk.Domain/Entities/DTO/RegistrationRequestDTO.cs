using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Entities.DTO
{
    public class RegistrationRequestDTO
    {
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
       
        public string AadharNumber { get; set; }
       
        public string Address { get; set; }
        
        public string City { get; set; }
        
        public string PostalCode { get; set; }
        
        public string State { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Role { get; set; }
        //public string PasswordHash { get;set; }
    }
}
