using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Domain.Common;

namespace HelpDesk.Domain.Entities
{
    public class Feedback: AuditableEntity
    {
        [Key]
        [Required]
        public int FeedBackId { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public Status status { get; set; }
        public string Description { get; set; }
        [Required]
        public float Rating { get; set; }
        [ForeignKey("Issue")]
        public int IssueId { get;set; }
        public Issue issue { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User user { get; set; }
    }
}
