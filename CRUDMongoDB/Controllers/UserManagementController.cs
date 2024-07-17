using CRUDMongoDB.DataAccessLayer;
using CRUDMongoDB.Model;
using Microsoft.AspNetCore.Mvc;

namespace CRUDMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController(IUserManagement userManagement) : ControllerBase
    {
        private readonly IUserManagement _userManagement = userManagement;

        [ProducesResponseType(typeof(AddUserResponseDto), 200)]
        [Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUserAsync(AddUserRequestDto requestDto)
        {
            AddUserResponseDto responseDto = new();
            try
            {
                responseDto = await _userManagement.AddUserAsync(requestDto);
            }
            catch(Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = $"Exception Occurred While Adding User {ex.Message}";
            }
            return Ok(responseDto);
        }
    }
}
