using HelpDesk.Api.Repository.IRepository;
using HelpDesk.Domain.Data;
using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Entities.DTO;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Api.Repository
{
    public class IssueCrudRepository : IIssueCrudRepository
    {
        public readonly ApplicationDbContext _context;

        public IssueCrudRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IssueDTO> CreateIssue(IssueDTO issueDTO)
        {
            var newIssue = new Issue
            {
                Description = issueDTO.Description,
                ImageUrl = issueDTO.ImageUrl,
                UserId = issueDTO.UserId
            };
            _context.issueDB.Add(newIssue);
            await _context.SaveChangesAsync();

            issueDTO.IssueId = newIssue.IssueId;
            return issueDTO;

        }

        public async Task DeleteIssue(int issueId)
        {
            var issue = await _context.issueDB.FindAsync(issueId);
            if(issue!=null)
            {
                _context.issueDB.Remove(issue);
                await _context.SaveChangesAsync();  
            }
        }

        public async Task<IEnumerable<IssueDTO>> GetAllIssues()
        {
            var issue = await _context.issueDB.ToListAsync();
            var issueDTOs = issue.Select(issue => new IssueDTO
            {
                IssueId = issue.IssueId,
                Description = issue.Description,
                ImageUrl = issue.ImageUrl,
                UserId = issue.UserId
            }).ToList();
            return issueDTOs;
        }

        public async Task<IssueDTO> GetIssueById(int issueId)
        {
            var issue = await _context.issueDB.FindAsync(issueId);
            if(issue==null)
            {
                return null;
            }
            var issueDTO = new IssueDTO
            {
                IssueId = issue.IssueId,
                Description = issue.Description,
                ImageUrl = issue.ImageUrl,
                UserId = issue.UserId
            };
            return issueDTO;
        }

        public async Task<IEnumerable<IssueDTO>> GetIssuesByUserId(int userId)
        {
           var issues=await _context.issueDB.Where(issue=>issue.UserId==userId).ToListAsync();
            var issueDTOs=issues.Select(issue=>new IssueDTO
            {
                IssueId=issue.IssueId,
                Description=issue.Description,
                ImageUrl=issue.ImageUrl,
                UserId=issue.UserId
            }).ToList();
            return issueDTOs;
        }

        public async Task<IssueDTO> UpdateIssue(IssueDTO issue)
        {
            var existingIssue = await _context.issueDB.FindAsync(issue.IssueId);
            if(existingIssue==null) { return null; }

            existingIssue.IssueId = issue.IssueId;
            existingIssue.Description = issue.Description;
            existingIssue.ImageUrl= issue.ImageUrl;
            await _context.SaveChangesAsync();
            return issue;
        }
    }
}
