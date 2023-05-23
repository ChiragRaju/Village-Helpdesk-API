using HelpDesk.Domain.Entities.DTO;
using HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HelpDesk.Domain.Data;
using HelpDesk.Api.Repository.IRepository;

namespace HelpDesk.Api.Repository
{
    public class AdminRepository :IAdminRepository
    {
        private readonly ApplicationDbContext _context;
        private string secretKey;

        public AdminRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }


        public bool isUnique(string Email)
        {
            var admin = _context.adminDB.FirstOrDefault(y => y.Email == Email);
            if (admin == null)
            {
                return true;
            }
            return false;
        }
        

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var admin = _context.adminDB.FirstOrDefault(u => u.Email.ToLower() == loginRequestDTO.Email.ToLower() && u.Password == loginRequestDTO.Password);

            if (admin == null)
            {
                return null;
            }
            //if admin was found generate JWT Token
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email,admin.Email.ToString()),
                    new Claim(ClaimTypes.Role,admin.Password),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);

            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenhandler.WriteToken(token),
                admin = admin
            };
            return loginResponseDTO;
        }


    }
}
