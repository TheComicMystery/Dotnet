using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RegistrationMicroservice.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        [BsonElement("username")]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        [BsonElement("email")]
        public string? Email { get; set; }

        [Required]
        [MinLength(6)]
        [BsonElement("password")]
        public string? Password { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
