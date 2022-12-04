using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Phillibeans_Server.Models
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }

    }
}
