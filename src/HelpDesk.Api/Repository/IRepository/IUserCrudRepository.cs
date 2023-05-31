using HelpDesk.Domain.Entities.DTO;

namespace HelpDesk.Api.Repository.IRepository
{
    public interface IUserCrudRepository
    {
        Task<UserCrudDTO> CreateUser(UserCrudDTO usercreateDTO);
        Task<UserCrudDTO> GetUserById(int userId);
        Task<IEnumerable<UserCrudDTO>> GetAllUsers();   
        Task<UserCrudDTO> UpdateUser(UserCrudDTO userupdateDTO);
        Task DeleteUser(int userID);
    }
}
