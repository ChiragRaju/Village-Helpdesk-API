using HelpDesk.Domain.Entities.DTO;

namespace HelpDesk.Api.Repository.IRepository
{
    public interface IAdminRepository
    {
        bool isUnique(string Email);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
    }
}
