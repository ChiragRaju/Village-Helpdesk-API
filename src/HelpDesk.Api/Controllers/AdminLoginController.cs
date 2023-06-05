using System.Net;
using HelpDesk.Api.Repository.IRepository;
using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Entities.DTO;
using HelpDesk.Domain.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        protected APIResponse _response;
        public AdminLoginController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
            this._response = new();
        }
        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var login = await _adminRepository.Login(model);
           
            if(login.admin == null || string.IsNullOrEmpty(login.Token))
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessage.Add(" Email or Password is Incorrect or empty");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = login;
            return Ok(_response);
        }
        [HttpGet("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var model = new LoginRequestDTO
            {
                Email = email,
                Password = password
            };

            var login = await _adminRepository.Login(model);

            if (login.admin == null || string.IsNullOrEmpty(login.Token))
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessage.Add("Email or Password is Incorrect or empty");
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = login;
            return Ok(_response);
        }




    }
}
