using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Entities.DTO
{
    public class IssueDTO
    {
        public int IssueId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public int UserId { get; set; }
       // public UserCrudDTO User { get; set; }
         

    }
}
