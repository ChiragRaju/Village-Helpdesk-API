using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Entities.DTO
{
    public class CreateChatMessageDTO
    {
        public string Message { get; set; }
        public string BotResponse { get; set; } 
    }
}
