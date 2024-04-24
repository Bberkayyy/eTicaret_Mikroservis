using AutoMapper;
using e_Ticaret.Catalog.Dtos.ProductDtos;
using e_Ticaret.Catalog.Entities;
using e_Ticaret.Catalog.Settings;
using MongoDB.Driver;

namespace e_Ticaret.Catalog.Services.ProductServices;

public class ProductManager : IProductService
{
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMongoCollection<ProductImage> _productImageCollection;
    private readonly IMongoCollection<ProductDetail> _productDetailCollection;
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;

    public ProductManager(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
        _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
        _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductAsync(CreateProductRequestDto createProductRequestDto)
    {
        Product value = _mapper.Map<Product>(createProductRequestDto);
        await _productCollection.InsertOneAsync(value);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _productCollection.DeleteOneAsync(x => x.Id == id);
        await _productImageCollection.DeleteOneAsync(x => x.ProductId == id);
        await _productDetailCollection.DeleteOneAsync(x => x.ProductId == id);
    }

    public async Task<List<GetAllProductResponseDto>> GetAllProductAsync()
    {
        List<Product> values = await _productCollection.Find(x => true).ToListAsync();
        List<GetAllProductResponseDto> mappedValues = _mapper.Map<List<GetAllProductResponseDto>>(values);
        return mappedValues;
    }

    public async Task<List<GetAllProductWithRelationshipsResponseDto>> GetAllProductWithRelationshipsAsync()
    {
        List<Product> values = await _productCollection.Find(x => true).ToListAsync();
        foreach (Product item in values)
            item.Category = await _categoryCollection.Find<Category>(x => x.Id == item.CategoryId).FirstAsync();
        List<GetAllProductWithRelationshipsResponseDto> mappedValues = _mapper.Map<List<GetAllProductWithRelationshipsResponseDto>>(values);
        return mappedValues;
    }

    public async Task<List<GetAllProductWtihRelationshipsByCategoryIdResponseDto>> GetAllProductWithRelationshipsByCategoryIdAsync(string categoryId)
    {
        List<Product> values = await _productCollection.Find<Product>(x => x.CategoryId == categoryId).ToListAsync();
        foreach (Product item in values)
            item.Category = await _categoryCollection.Find<Category>(x => x.Id == item.CategoryId).FirstAsync();
        List<GetAllProductWtihRelationshipsByCategoryIdResponseDto> mappedValues = _mapper.Map<List<GetAllProductWtihRelationshipsByCategoryIdResponseDto>>(values);
        return mappedValues;
    }

    public async Task<GetProductResponseDto> GetProductAsync(string id)
    {
        Product value = await _productCollection.Find<Product>(x => x.Id == id).FirstOrDefaultAsync();
        GetProductResponseDto mappedValue = _mapper.Map<GetProductResponseDto>(value);
        return mappedValue;
    }

    public async Task UpdateProductAsync(UpdateProductRequestDto updateProductRequestDto)
    {
        Product value = _mapper.Map<Product>(updateProductRequestDto);
        await _productCollection.FindOneAndReplaceAsync(x => x.Id == updateProductRequestDto.Id, value);
    }
}
