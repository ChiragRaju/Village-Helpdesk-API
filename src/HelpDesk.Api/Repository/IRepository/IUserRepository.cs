using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Entities.DTO;

namespace HelpDesk.Domain.Repository.IRepository
{
    public interface IUserRepository
    {
        bool isUnique(string Aadharnumber,string PhoneNumber);
        Task<LoginResponseUserDTO> Login(LoginRequestUserDTO loginRequestuserDTO);
        Task<User> Register(RegistrationRequestDTO registrationRequestDTO);

        //Task<bool> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
