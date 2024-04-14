using AutoMapper;
using e_Ticaret.Catalog.Dtos.ProductDtos;
using e_Ticaret.Catalog.Entities;
using e_Ticaret.Catalog.Settings;
using MongoDB.Driver;

namespace e_Ticaret.Catalog.Services.ProductServices;

public class ProductManager : IProductService
{
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMapper _mapper;

    public ProductManager(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
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
    }

    public async Task<List<GetAllProductResponseDto>> GetAllProductAsync()
    {
        List<Product> values = await _productCollection.Find(x => true).ToListAsync();
        List<GetAllProductResponseDto> mappedValues = _mapper.Map<List<GetAllProductResponseDto>>(values);
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
