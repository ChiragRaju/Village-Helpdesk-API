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
                UserRefId = issueDTO.UserId
            };
            _context.issueDb.Add(newIssue);
            await _context.SaveChangesAsync();

            issueDTO.IssueId = newIssue.IssueId;
            return issueDTO;

        }


        public async Task DeleteIssue(int issueId)
        {
            var issue = await _context.issueDb.FindAsync(issueId);
            if(issue!=null)
            {
                _context.issueDb.Remove(issue);
                await _context.SaveChangesAsync();  
            }
        }

        public async Task<IEnumerable<IssueDTO>> GetAllIssues()
        {
            var issue = await _context.issueDb.ToListAsync();
            var issueDTOs = issue.Select(issue => new IssueDTO
            {
                IssueId = issue.IssueId,
                Description = issue.Description,
                ImageUrl = issue.ImageUrl,
                //UserId = issue.UserId
            }).ToList();
            return issueDTOs;
        }

        public async Task<IssueDTO> GetIssueById(int issueId)
        {
            var issue = await _context.issueDb.FindAsync(issueId);
            if(issue==null)
            {
                return null;
            }
            var issueDTO = new IssueDTO
            {
                IssueId = issue.IssueId,
                Description = issue.Description,
                ImageUrl = issue.ImageUrl,
                //UserId = issue.UserId
               
            };
            return issueDTO;
        }

        public async Task<IEnumerable<IssueDTO>> GetIssuesByUserId(int userId)
        {
           var issues=await _context.issueDb.Where(issue=>issue.UserRefId==userId).ToListAsync();
            var issueDTOs=issues.Select(issue=>new IssueDTO
            {
                IssueId=issue.IssueId,
                Description=issue.Description,
                ImageUrl=issue.ImageUrl,
                //UserId=issue.UserId
            }).ToList();
            return issueDTOs;
        }

        public async Task<IssueDTO> UpdateIssue(IssueDTO issue)
        {
            var existingIssue = await _context.issueDb.FindAsync(issue.IssueId);
            if(existingIssue==null) { return null; }

            existingIssue.IssueId = issue.IssueId;
            existingIssue.Description = issue.Description;
            existingIssue.ImageUrl= issue.ImageUrl;
            await _context.SaveChangesAsync();
            return issue;
        }
    }
}
