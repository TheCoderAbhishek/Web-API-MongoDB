using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CRUDMongoDB.Model
{
    public class AddUserRequestDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        [BsonElement(elementName: "Name")]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string? Contact { get; set; }

        public double? Salary { get; set; }

        public string? CreatedOn { get; set; }

        public string? UpdatedOn { get; set; }
    }

    public class AddUserResponseDto
    {
        public bool? IsSuccess { get; set; }

        public string? Message { get; set; }
    }
}
