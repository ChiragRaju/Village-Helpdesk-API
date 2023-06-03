using System.Data;
using HelpDesk.Api.Repository.IRepository;
using HelpDesk.Domain.Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;   
        }
        [HttpGet("{statusId}")]
        [AllowAnonymous]
        public async Task<ActionResult<StatusDTO>> GetStatusById(int statusId)
        {
            var status = await _statusRepository.GetStatusByIdAsync(statusId);

            if (status == null)
                return NotFound();

            return status;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<StatusDTO>>> GetAllStatuses()
        {
            var statuses = await _statusRepository.GetAllStatusByAdminAsync();
            return statuses;
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public async Task<ActionResult<int>> CreateStatus(StatusDTO statusDTO)
        {
            var statusId = await _statusRepository.CreateStatusByAdminAsync(statusDTO);
            return statusId;
        }

        [HttpPut("{statusId}")]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateStatus(int statusId, StatusDTO statusDTO)
        {
            var status = await _statusRepository.GetStatusByIdAsync(statusId);

            if (status == null)
                return NotFound();

            await _statusRepository.UpdateStatusByAdminAsync(statusId, statusDTO);
            return NoContent();
        }

        [HttpDelete("{statusId}")]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteStatus(int statusId)
        {
            var status = await _statusRepository.GetStatusByIdAsync(statusId);

            if (status == null)
                return NotFound();

            await _statusRepository.DeleteStatusByAdminAsync(statusId);
            return NoContent();
        }
    }
}
