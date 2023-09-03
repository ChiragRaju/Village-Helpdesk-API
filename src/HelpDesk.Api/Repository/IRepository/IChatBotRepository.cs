using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Entities.DTO;

namespace HelpDesk.Api.Repository.IRepository
{
    public interface IChatBotRepository
    {
        Task<IEnumerable<ChatMessageDTO>> GetChatMessagesAsync();
        Task<ChatMessageDTO> AddChatMessageAsync(CreateChatMessageDTO message);
    }
}
