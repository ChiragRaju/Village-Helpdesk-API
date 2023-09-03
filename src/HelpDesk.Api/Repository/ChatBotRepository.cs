using HelpDesk.Api.Repository.IRepository;
using HelpDesk.Domain.Entities.DTO;
using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Api.Repository
{
    public class ChatBotRepository : IChatBotRepository
    {
        private readonly ApplicationDbContext _context;

        public ChatBotRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChatMessageDTO>> GetChatMessagesAsync()
        {
            IEnumerable<ChatMessageDTO> chatMessages = await _context.chatMessage
                .Select(m => new ChatMessageDTO
                {
                    Id = m.Id,
                    BotResponse = m.BotResponse,
                    Message = m.Message,
                    Timestamp = m.Timestamp
                })
                .ToListAsync();

            return chatMessages;
        }

        public async Task<ChatMessageDTO> AddChatMessageAsync(CreateChatMessageDTO message)
        {
            var chatMessage = new ChatMessage
            {
                BotResponse = message.BotResponse,
                Message = message.Message,
                Timestamp = DateTime.Now
            };

            _context.chatMessage.Add(chatMessage);
            await _context.SaveChangesAsync();

            var chatMessageDTO = new ChatMessageDTO
            {
                Id = chatMessage.Id,
                BotResponse = chatMessage.BotResponse,
                Message = chatMessage.Message,
                Timestamp = chatMessage.Timestamp
            };

            return chatMessageDTO;
        }
    }
}


