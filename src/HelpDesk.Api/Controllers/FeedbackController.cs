using HelpDesk.Api.Repository.IRepository;
using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;   
        }
        private FeedbackDTO MapFeedbackToDTO(Feedback feedback)
        {
            return new FeedbackDTO
            {
                feedbackId = feedback.FeedBackId,
                FeedbackDescription = feedback.Description,
                FirstNameUser = feedback.user?.FirstName,
                LastNameUser = feedback.user.LastName,
                StatusDescription = feedback.Description,
                IssueId = feedback.IssueId,

            };
        }

        // GET api/feedback/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackDTO>> GetFeedback(int id)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if(feedback == null) { return NotFound(); }
            return MapFeedbackToDTO(feedback);
        }

        // GET api/user/{userId}/feedback
        //[Route("api/user/{userId}/feedback")]
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<FeedbackDTO>>> GetFeedbacksByUserId(int userId)
        {
            var feedbacks = await _feedbackRepository.GetFeedbackByUserIdAsync(userId);
            return feedbacks.Select(f => MapFeedbackToDTO(f)).ToList();
        }
        [HttpGet("issue/{issueId}")]
        public async Task<ActionResult<List<FeedbackDTO>>> GetFeedbackByIssueId(int issueId)
        {
            var feedback = await _feedbackRepository.GetFeedbackByIssueId(issueId);
            return feedback.Select(f=>MapFeedbackToDTO(f)).ToList();    
        }

        // POST api/feedback
        [HttpPost]
        public async Task<ActionResult> CreateFeedback(CreateFeedbackDTO createFeedbackDto)
        {
            var feedback = new Feedback
            {
                Description = createFeedbackDto.Description,
                UserId = createFeedbackDto.UserId,
                StatusId = createFeedbackDto.StatusId,
                IssueId = createFeedbackDto.IssueId
            };

            await _feedbackRepository.AddAsync(feedback);
            // return Ok();
            return CreatedAtRoute("DefaultApi", new { id = feedback.FeedBackId }, MapFeedbackToDTO(feedback));
        }

        // PUT api/feedback/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFeedback(int id, CreateFeedbackDTO updateFeedbackDto)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if (feedback == null)
                return NotFound();

            feedback.Description = updateFeedbackDto.Description;
            feedback.UserId = updateFeedbackDto.UserId;
            feedback.StatusId = updateFeedbackDto.StatusId;
            feedback.IssueId = updateFeedbackDto.IssueId;

            _feedbackRepository.UpdateAsync(feedback);
            return Ok(MapFeedbackToDTO(feedback));
        }

        // DELETE api/feedback/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFeedback(int id)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if (feedback == null)
                return NotFound();

            _feedbackRepository.DeleteAsync(feedback);
            return Ok();
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<FeedbackDTO>> GetFeedbackById(int id)
        //{
        //    var feedbackDTO = await _feedbackRepository.GetByIdAsync(id);
        //    if (feedbackDTO == null)
        //    {
        //        return NotFound();
        //    }
        //    return feedbackDTO;
        //}

        //[HttpGet("user/{userId}")]
        //public async Task<ActionResult<List<FeedbackDTO>>> GetFeedbacksByUserId(int userId)
        //{
        //    var feedbackDtos = await _feedbackRepository.GetFeedbackByUserIdAsync(userId);
        //    return feedbackDtos;
        //}

        //[HttpPost]
        //public async Task<ActionResult> CreateFeedback([FromBody] FeedbackDto feedbackDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    await _feedbackRepository.AddAsync(feedbackDto);
        //    return Ok();
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateFeedback(int id, [FromBody] FeedbackDTO feedbackDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != feedbackDto.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await _feedbackRepository.UpdateAsync(feedbackDto);
        //    return Ok();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteFeedback(int id)
        //{
        //    await _feedbackRepository.DeleteAsync(id);
        //    return Ok();
        //}
    }
}
