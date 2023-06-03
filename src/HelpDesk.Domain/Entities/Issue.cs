using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Domain.Common;

namespace HelpDesk.Domain.Entities
{
    public class Issue: AuditableEntity
    {
        [Key]
        [Required]
        public int IssueId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [ForeignKey("User")]
        public int UserId { get;set; }
        public User user { get; set; }

        [ForeignKey("Status")]

        public int StatusId { get; set; }
        public Status status { get; set; }

        [ForeignKey("Admin")]
        public int? AdminId { get; set; }
        public Admin admin { get; set; }

        [ForeignKey("Worker")]
        public int? WorkerId { get; set; }
        public Worker worker { get; set; }
    }
}
