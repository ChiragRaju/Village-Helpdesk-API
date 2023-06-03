using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Entities.DTO;

namespace HelpDesk.Api.Repository.IRepository
{
    public interface IStatusRepository
    {
        Task<StatusDTO> GetStatusByIdAsync(int statusId);
        Task<int> CreateStatusByAdminAsync(StatusDTO statusDTO);
        Task UpdateStatusByAdminAsync(int statusId, StatusDTO statusDTO);
        
        Task DeleteStatusByAdminAsync(int statusId);
        Task<List<StatusDTO>> GetAllStatusByAdminAsync();
    }
}
