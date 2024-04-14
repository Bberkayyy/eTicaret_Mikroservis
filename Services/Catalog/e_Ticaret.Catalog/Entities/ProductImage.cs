using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace e_Ticaret.Catalog.Entities;

public class ProductImage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string ProductImageUrl1 { get; set; }
    public string ProductImageUrl2 { get; set; }
    public string ProductImageUrl3 { get; set; }
    [BsonIgnore]
    public Product Product { get; set; }
}
