using CRUDMongoDB.Model;
using MongoDB.Driver;

namespace CRUDMongoDB.DataAccessLayer
{
    public class UserManagementService : IUserManagement
    {
        private readonly IConfiguration _configuration;
        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<AddUserRequestDto> _mongoCollection;

        public UserManagementService(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration[key: "DatabaseSettings:ConnectionString"]);
            var _MongoDatabase = _mongoClient.GetDatabase(_configuration[key: "DatabaseSettings:DatabaseName"]);
            _mongoCollection = _MongoDatabase.GetCollection<AddUserRequestDto>(_configuration[key: "DatabaseSettings:CollectionName"]);
        }

        public async Task<AddUserResponseDto> AddUserAsync(AddUserRequestDto addUserRequestDto)
        {
            AddUserResponseDto addUserResponseDto = new();
            try
            {
                addUserRequestDto.CreatedOn = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
                addUserRequestDto.UpdatedOn = string.Empty;

                await _mongoCollection.InsertOneAsync(addUserRequestDto);

                addUserResponseDto.IsSuccess = true;
                addUserResponseDto.Message = $"User {addUserRequestDto.LastName} added successfully.";
            }
            catch(Exception ex)
            {
                addUserResponseDto.IsSuccess = false;
                addUserResponseDto.Message = $"Exception Occurred While Adding User {ex.Message}";
            }
            return addUserResponseDto;
        }
    }
}
