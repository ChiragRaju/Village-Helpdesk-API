using HelpDesk.Api.Repository.IRepository;
using HelpDesk.Domain.Data;
using HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Api.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;
        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task AddAsync(Feedback feedback)
        {
            _context.feedbackDB.Add(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Feedback feedback)
        {
          _context.feedbackDB.Remove(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task<Feedback> GetByIdAsync(int id)
        {
            return await _context.feedbackDB
                .Include(f => f.user)
                .Include(f => f.status)
                .FirstOrDefaultAsync(f => f.FeedBackId == id);
        }

        public async Task<List<Feedback>> GetFeedbackByUserIdAsync(int userId)
        {
            return await _context.feedbackDB
                .Include(f => f.user)
                .Include(f => f.status)
                .Where(f=> f.UserId == userId)
                .ToListAsync(); 
        }
        public async Task<List<Feedback>> GetFeedbackByIssueId(int issueId)
        {
            return await _context.feedbackDB
                .Include(f => f.user)
                .Include(f => f.status)
                .Include(f=>f.IssueId == issueId).ToListAsync();
        }

        public async Task UpdateAsync(Feedback feedback)
        {
            _context.Entry(feedback).State=EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
