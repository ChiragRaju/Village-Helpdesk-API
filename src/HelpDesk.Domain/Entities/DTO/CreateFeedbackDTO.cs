using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Entities.DTO
{
    public class CreateFeedbackDTO
    {
        public string Description { get; set; }
        public int UserId { get; set; }
        public int StatusId { get;set; }
        public int IssueId { get;set; }
    }
}
