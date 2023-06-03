using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Entities.DTO
{
    public class StatusDTO
    {
        public int Id { get; set; }
        public string StatusDescription { get; set; }

        public bool IsCompleted { get; set; }   
    }
}
