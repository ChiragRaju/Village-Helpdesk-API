using HelpDesk.Api.Repository.IRepository;
using HelpDesk.Domain.Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatBotController : ControllerBase
    {
        private readonly IChatBotRepository _chatRepository;

        public ChatBotController(IChatBotRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatMessageDTO>>> GetChatMessages()
        {
            var chatMessages = await _chatRepository.GetChatMessagesAsync();
            return Ok(chatMessages);
        }

        [HttpPost]
        public async Task<ActionResult<ChatMessageDTO>> AddChatMessage(CreateChatMessageDTO message)
        {
            if (string.IsNullOrEmpty(message.Message) || string.IsNullOrEmpty(message.BotResponse))
            {
                return BadRequest("Sender and message cannot be empty");
            }

            var addedMessage = await _chatRepository.AddChatMessageAsync(message);
            return CreatedAtAction(nameof(GetChatMessages), addedMessage);
        }
    }
}

