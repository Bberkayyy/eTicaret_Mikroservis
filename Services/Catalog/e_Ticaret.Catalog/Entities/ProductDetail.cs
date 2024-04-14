using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace e_Ticaret.Catalog.Entities;

public class ProductDetail
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string ProductDescription { get; set; }
    public string ProductInfo { get; set; }
    [BsonIgnore]
    public Product Product { get; set; }
}
