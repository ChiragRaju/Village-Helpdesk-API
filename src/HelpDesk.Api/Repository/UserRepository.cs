using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Domain.Data;
using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Entities.DTO;
using HelpDesk.Domain.Repository.IRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HelpDesk.Domain.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private string secretKey;

        public UserRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }
        
        public bool isUnique(string Aadharnumber)
        {
            var user = _context.usersDB.FirstOrDefault(x => x.AadharNumber == Aadharnumber);

            if (user == null)
            {
                return true;
            }
            return false;
        }

        

        public async Task<LoginResponseUserDTO> Login(LoginRequestUserDTO loginRequestuserDTO)
        {

            var user = _context.usersDB.FirstOrDefault(u => u.AadharNumber == loginRequestuserDTO.AadharNumber && u.PhoneNumber == loginRequestuserDTO.PhoneNumber);
            if (user == null)
            {
                return new LoginResponseUserDTO()
                {
                    Token = "",
                    user = null
                };
            }
            //if user was found generate JWT Token
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    //new Claim(ClaimTypes.Role,user.Role),
                    new Claim(ClaimTypes.MobilePhone,user.UserId.ToString()),
                    new Claim(ClaimTypes.SerialNumber,user.AadharNumber)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            LoginResponseUserDTO loginResponseuser2DTO = new LoginResponseUserDTO()
            {
                Token = tokenhandler.WriteToken(token),
                user = user
            };
            return loginResponseuser2DTO;
        }

        public async Task<User> Register(RegistrationRequestDTO registrationRequestDTO)
        {

            User user = new()
            {
                FirstName = registrationRequestDTO.FirstName,
                LastName = registrationRequestDTO.LastName,
                AadharNumber = registrationRequestDTO.AadharNumber,
                Address = registrationRequestDTO.Address,
                City = registrationRequestDTO.City,
                PostalCode = registrationRequestDTO.PostalCode,
                State = registrationRequestDTO.State,
                PhoneNumber = registrationRequestDTO.PhoneNumber,
                Role = registrationRequestDTO.Role
                //Email = registrationRequestDTO.Email
            };
            _context.usersDB.Add(user);
            await _context.SaveChangesAsync();
            user.AadharNumber = "";
            return user;
        }
    }
}
