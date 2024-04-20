using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace e_Ticaret.Catalog.Entities;

public class Service
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Title { get; set; }
    public string Icon { get; set; }
}
