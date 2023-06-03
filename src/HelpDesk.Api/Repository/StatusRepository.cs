using HelpDesk.Api.Repository.IRepository;
using HelpDesk.Domain.Data;
using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Entities.DTO;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Api.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public StatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateStatusByAdminAsync(StatusDTO statusDTO)
        {
            var status = new Status
            {
                StatusDescription = statusDTO.StatusDescription,
                IsCompleted = statusDTO.IsCompleted,
            };

            _context.statusDB.Add(status);
            await _context.SaveChangesAsync();

            return status.StatusId;
        }

        public async Task DeleteStatusByAdminAsync(int statusId)
        {
            var status = await _context.statusDB.FindAsync(statusId);

            if(status != null)
            {
                _context.statusDB.Remove(status);
                await _context.SaveChangesAsync();  
            }
        }

        public async Task<List<StatusDTO>> GetAllStatusByAdminAsync()
        {
           return await _context.statusDB.Select(status => new StatusDTO
           {
               Id=status.StatusId,
               StatusDescription=status.StatusDescription,
               IsCompleted=status.IsCompleted,
           }).ToListAsync();
        }

        public async Task<StatusDTO> GetStatusByIdAsync(int statusId)
        {
            var status = await _context.statusDB.FindAsync(statusId);

            if(status == null)
            {
                return null;
            }
            return new StatusDTO
            {
                Id = status.StatusId,
                StatusDescription = status.StatusDescription,
                IsCompleted = status.IsCompleted
            };
        }

        public async Task UpdateStatusByAdminAsync(int statusId, StatusDTO statusDTO)
        {
            var status = await _context.statusDB.FindAsync(statusId);

            if(status != null)
            {
                status.StatusDescription = statusDTO.StatusDescription;
                status.IsCompleted = statusDTO.IsCompleted;

                await _context.SaveChangesAsync();
            }
        }
    }
}
