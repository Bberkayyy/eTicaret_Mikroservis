using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace e_Ticaret.Catalog.Entities;

public class DiscountOffer
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public int DiscountRate { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public bool IsActive { get; set; }
}
