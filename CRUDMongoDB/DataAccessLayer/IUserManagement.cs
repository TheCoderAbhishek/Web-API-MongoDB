using CRUDMongoDB.Model;

namespace CRUDMongoDB.DataAccessLayer
{
    public interface IUserManagement
    {
        Task<AddUserResponseDto> AddUserAsync(AddUserRequestDto addUserRequestDto);
    }
}
