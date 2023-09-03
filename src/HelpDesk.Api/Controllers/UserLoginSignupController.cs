using System.Net;
using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Entities.DTO;
using HelpDesk.Domain.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginSignupController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        protected APIResponse _response;
        public UserLoginSignupController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            this._response = new();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestUserDTO model)
        {
            var loginResponse = await _userRepository.Login(model);
            if (loginResponse.user == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessage.Add(" Username or Password is Incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpGet("login")]

        public async Task<IActionResult> Login(string aadharnumber,string phonenumber)
        {
            var model = new LoginRequestUserDTO
            {
                AadharNumber = aadharnumber,
                PhoneNumber = phonenumber
            };

            var loginResponse = await _userRepository.Login(model);
            if (loginResponse.user == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessage.Add(" Username or Password is Incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }
        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        //{
        //    bool ifAadharUnique = _userRepository.isUnique(model.AadharNumber,model.PhoneNumber);

        //    if (!ifAadharUnique)
        //    {
        //        _response.StatusCode = HttpStatusCode.BadRequest;
        //        _response.IsSuccess = false;
        //        _response.ErrorMessage.Add("Aadhar Number already Exists or Phone Number already Exists");
        //        return BadRequest(_response);
        //    }
        //    var user = await _userRepository.Register(model);
        //    if (user == null)
        //    {
        //        _response.StatusCode = HttpStatusCode.BadRequest;
        //        _response.IsSuccess = false;
        //        _response.ErrorMessage.Add("Error while registration");
        //        return BadRequest(_response);
        //    }
        //    _response.StatusCode = HttpStatusCode.OK;
        //    _response.IsSuccess = true;
        //    return Ok(_response);
        //}
        //[HttpGet("register")]
        //public IActionResult Register(string aadharNumber, string phoneNumber)
        //{
        //    bool ifAadharUnique = _userRepository.isUnique(aadharNumber, phoneNumber);

        //    if (!ifAadharUnique)
        //    {
        //        _response.StatusCode = HttpStatusCode.BadRequest;
        //        _response.IsSuccess = false;
        //        _response.ErrorMessage.Add("Aadhar Number or Phone Number already exists");
        //        return BadRequest(_response);
        //    }

        //    _response.StatusCode = HttpStatusCode.OK;
        //    _response.IsSuccess = true;
        //    return Ok(_response);
        //}

        //new

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            bool isAadharUnique = _userRepository.isUnique(model.AadharNumber, model.PhoneNumber);

            if (!isAadharUnique)
            {
                APIResponse response = new APIResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    IsSuccess = false,
                    ErrorMessage = new List<string> { "Aadhar Number already exists or Phone Number already exists" }
                };
                return BadRequest(response);
            }

            var user = await _userRepository.Register(model);
            if (user == null)
            {
                APIResponse response = new APIResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    IsSuccess = false,
                    ErrorMessage = new List<string> { "Error while registration" }
                };
                return BadRequest(response);
            }

            APIResponse successResponse = new APIResponse
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true
            };
            return Ok(successResponse);
        }



    }






    }
}
