using HelpDesk.Api.Repository.IRepository;
using HelpDesk.Domain.Data;
using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Entities.DTO;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Api.Repository
{
    public class UserCrudRepository : IUserCrudRepository
    {
        public readonly ApplicationDbContext _context;
        public UserCrudRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<UserCrudDTO> CreateUser(UserCrudDTO usercreateDTO)
        {
            var newUser = new User
            {
                FirstName = usercreateDTO.FirstName,
                LastName = usercreateDTO.LastName,
                AadharNumber = usercreateDTO.AadharNumber
            };
            _context.usersDB.Add(newUser);
            await _context.SaveChangesAsync();
             usercreateDTO.FirstName = newUser.FirstName;
            usercreateDTO.LastName = newUser.LastName;
            usercreateDTO.AadharNumber = newUser.AadharNumber;
            usercreateDTO.PhoneNumber= newUser.PhoneNumber; 
            return usercreateDTO;
        }

        public async Task DeleteUser(int userID)
        {
            var user = await _context.usersDB.FindAsync(userID);
            if (user != null)
            {
                _context.usersDB.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserCrudDTO>> GetAllUsers()
        {
            var user = await _context.usersDB.ToListAsync();
            var userDTOs = user.Select(user => new UserCrudDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AadharNumber = user.AadharNumber,
                PhoneNumber=user.PhoneNumber
            }).ToList();

            return userDTOs;
        }

        public async Task<UserCrudDTO> GetUserById(int userId)
        {
            var user = await _context.usersDB.FindAsync(userId);
            if (user == null)
            {
                return null;
            }
            var userDTO = new UserCrudDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AadharNumber = user.AadharNumber,
                PhoneNumber = user.PhoneNumber  
            };
            return userDTO;
        }

        public async Task<UserCrudDTO> UpdateUser(UserCrudDTO userupdateDTO)
        {
            var existingUser = await _context.usersDB.FindAsync(userupdateDTO.UserId);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.FirstName = userupdateDTO.FirstName;
            existingUser.LastName = userupdateDTO.LastName;
            existingUser.AadharNumber = userupdateDTO.AadharNumber;
            existingUser.PhoneNumber=userupdateDTO.PhoneNumber; 

            await _context.SaveChangesAsync();
            return userupdateDTO;
        }





        //change

    }
}
