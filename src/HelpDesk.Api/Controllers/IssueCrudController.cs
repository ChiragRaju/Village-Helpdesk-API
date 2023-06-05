using HelpDesk.Api.Repository.IRepository;
using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueCrudController : ControllerBase
    {
        private readonly IIssueCrudRepository _repository;

        public IssueCrudController(IIssueCrudRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{issueId}")]
        public async Task<ActionResult<IssueDTO>> GetIssue(int issueId)
        {
            var issue = await _repository.GetIssueById(issueId);

            if (issue == null)
            {
                return NotFound();
            }

            return Ok(issue);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IssueDTO>>> GetAllIssues()
        {
            var issues = await _repository.GetAllIssues();

            return Ok(issues);
        }

        [HttpPost]
        public async Task<ActionResult<IssueDTO>> CreateIssue(IssueDTO issue)
        {
            var createdIssue = await _repository.CreateIssue(issue);

            return CreatedAtAction(nameof(GetIssue), new { issueId = createdIssue.IssueId }, createdIssue);
        }


        [HttpPut("{issueId}")]
        public async Task<ActionResult<IssueDTO>> UpdateIssue(int issueId, IssueDTO issue)
        {
            if (issueId != issue.IssueId)
            {
                return BadRequest();
            }

            var existingIssue = await _repository.GetIssueById(issueId);
            if (existingIssue == null)
            {
                return NotFound();
            }

            var updatedIssue = await _repository.UpdateIssue(issue);

            return Ok(updatedIssue);
        }

        [HttpDelete("{issueId}")]
        public async Task<ActionResult> DeleteIssue(int issueId)
        {
            var existingIssue = await _repository.GetIssueById(issueId);
            if (existingIssue == null)
            {
                return NotFound();
            }

            await _repository.DeleteIssue(issueId);

            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<IssueDTO>>> GetIssuesByUserId(int userId)
        {
            var issues = await _repository.GetIssuesByUserId(userId);

            return Ok(issues);
        }
    }
}
