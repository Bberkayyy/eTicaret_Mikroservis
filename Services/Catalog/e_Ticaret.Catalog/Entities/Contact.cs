using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace e_Ticaret.Catalog.Entities;

public class Contact
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
    public DateTime SendDate { get; set; }
    public DateTime? ReadTime { get; set; }
}
