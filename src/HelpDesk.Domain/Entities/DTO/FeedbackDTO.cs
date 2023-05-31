using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Entities.DTO
{
    public class FeedbackDTO
    {
        public int feedbackId { get;set; }
        public string FeedbackDescription { get; set; }
        public string FirstNameUser { get;set; }
        public string LastNameUser { get;set; }
        public string StatusDescription { get; set; }
        public int IssueId { get; set; }
    }
}

