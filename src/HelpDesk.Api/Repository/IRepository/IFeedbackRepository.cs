using HelpDesk.Domain.Entities;

namespace HelpDesk.Api.Repository.IRepository
{
    public interface IFeedbackRepository
    {
        Task<Feedback> GetByIdAsync(int id);
        Task<List<Feedback>> GetFeedbackByUserIdAsync(int userId);
        Task AddAsync(Feedback feedback);
        Task UpdateAsync(Feedback feedback);
        Task DeleteAsync(Feedback feedback);

        Task<List<Feedback>> GetFeedbackByIssueId(int issueId);

    }
}
