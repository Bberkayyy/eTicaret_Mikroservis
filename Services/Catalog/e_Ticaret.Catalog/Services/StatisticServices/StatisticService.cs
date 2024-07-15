using e_Ticaret.Catalog.Entities;
using e_Ticaret.Catalog.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace e_Ticaret.Catalog.Services.StatisticServices;

public class StatisticService : IStatisticService
{
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMongoCollection<Brand> _brandCollection;

    public StatisticService(IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
    }

    public async Task<long> GetBrandCountAsync()
    {
        return await _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
    }

    public async Task<long> GetCategoryCountAsync()
    {
        return await _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
    }

    public async Task<long> GetProductCountAsync()
    {
        return await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
    }

    public async Task<string> GetProductNameOfMaxPriceProduct()
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Empty;
        SortDefinition<Product> sort = Builders<Product>.Sort.Descending(x => x.Price);
        ProjectionDefinition<Product> projection = Builders<Product>.Projection.Include(x => x.Name).Exclude("Id");
        BsonDocument product = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();
        return product.GetValue("Name").AsString;
    }

    public async Task<string> GetProductNameOfMinPriceProduct()
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Empty;
        SortDefinition<Product> sort = Builders<Product>.Sort.Ascending(x => x.Price);
        ProjectionDefinition<Product> projection = Builders<Product>.Projection.Include(x => x.Name).Exclude("Id");
        BsonDocument product = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();
        return product.GetValue("Name").AsString;
    }
}
