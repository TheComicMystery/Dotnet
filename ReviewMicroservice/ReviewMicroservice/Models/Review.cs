using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ReviewMicroservice.Models
{
    public class Review
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
