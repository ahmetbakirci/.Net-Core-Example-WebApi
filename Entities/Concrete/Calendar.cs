using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Entities.Concrete
{
    public class Calendar
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
