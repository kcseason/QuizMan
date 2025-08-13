using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CommonCore.MongoDB
{
    public class BasicModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Remark")]
        public string? Remark { get; set; }

        [BsonElement("CreatedBy")]
        public string? CreatedBy { get; set; }
        [BsonElement("CreateTime")]
        public DateTime? CreateTime { get; set; }
        [BsonElement("UpdatedBy")]
        public string? UpdatedBy { get; set; }
        [BsonElement("UpdateTime")]
        public DateTime? UpdateTime { get; set; }
    }
}
