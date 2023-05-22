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
    public class UserRepository //:IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private string secretKey;

        public UserRepository(ApplicationDbContext context,IConfiguration configuration)
        {
            _context = context;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        //public bool isUnique(string aadharnumber, string email)
        //{
        //    var user = _context.localUsersDb.FirstOrDefault(x => x.AadharNumber == aadharnumber);
        //    var admin = _context.localUsersDb.FirstOrDefault(y => y.Email == email);
        //    if (user == null || admin == null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        //{
        //    var admin = _context.localUsersDb.FirstOrDefault(u => u.Email.ToLower() == loginRequestDTO.Email.ToLower() && u.Password == loginRequestDTO.Password);
        //    var user = _context.localUsersDb.FirstOrDefault(u => u.AadharNumber == loginRequestDTO.ANumber && u.PhoneNumber == loginRequestDTO.PNumber);
        //    if (admin == null || user == null)
        //    {
        //        return null;
        //    }
        //    //if user and admin was found generate JWT Token
        //    var tokenhandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(secretKey);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Email,admin.AdminId.ToString()),
        //            new Claim(ClaimTypes.,user.Password),
        //        })
        //    }

       // }

        //public async Task<LocalUsers> Register(RegistrationRequestDTO registrationRequestDTO)
        //{
        //    LocalUsers localUsers = new()
        //    {
        //        FirstName = registrationRequestDTO.FirstName,
        //        LastName = registrationRequestDTO.LastName,
        //        AadharNumber = registrationRequestDTO.AadharNumber,
        //        Address = registrationRequestDTO.Address,
        //        City = registrationRequestDTO.City,
        //        PostalCode = registrationRequestDTO.PostalCode,
        //        State = registrationRequestDTO.State,
        //        PhoneNumber = registrationRequestDTO.PhoneNumber,
        //        Email = registrationRequestDTO.Email               
        //    };
        //    _context.localUsersDb.Add(localUsers);
        //    await _context.SaveChangesAsync();
        //    localUsers.Password = "";
        //    return localUsers;
        //}
    }
}
