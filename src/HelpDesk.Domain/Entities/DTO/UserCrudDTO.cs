using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string PhoneNumber { get;set; }
        //changes
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        
        public string State { get; set; }      
        
      
        public string Role { get; set; }
        
    }
}
