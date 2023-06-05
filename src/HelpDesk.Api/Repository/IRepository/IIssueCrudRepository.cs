using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Entities.DTO;

namespace HelpDesk.Api.Repository.IRepository
{
    public interface IIssueCrudRepository
    {
        Task<IssueDTO> CreateIssue(IssueDTO issueDTO);      

        Task<IssueDTO> GetIssueById(int issueId);
        Task<IEnumerable<IssueDTO>> GetAllIssues();
        Task<IEnumerable<IssueDTO>> GetIssuesByUserId(int userId);
        Task<IssueDTO> UpdateIssue(IssueDTO issue);
        Task DeleteIssue(int issueId);  
    }
}
