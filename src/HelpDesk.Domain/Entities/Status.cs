using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Domain.Common;

namespace HelpDesk.Domain.Entities
{
    public class Status: AuditableEntity
    {
        [Key]
        [Required]
        public int StatusId { get; set; }
        [Required]
        public string StatusDescription { get; set; }

        public ICollection<Issue> Issues { get; set; }

        public bool IsCompleted { get; set; }
    }
}
