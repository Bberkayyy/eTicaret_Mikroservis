using AutoMapper;
using e_Ticaret.Catalog.Dtos.ProductImageDtos;
using e_Ticaret.Catalog.Entities;
using e_Ticaret.Catalog.Settings;
using MongoDB.Driver;

namespace e_Ticaret.Catalog.Services.ProductImageServices;

public class ProductImageManager : IProductImageService
{
    private readonly IMongoCollection<ProductImage> _productImageCollection;
    private readonly IMapper _mapper;

    public ProductImageManager(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductImageAsync(CreateProductImageRequestDto createProductImageRequestDto)
    {
        ProductImage value = _mapper.Map<ProductImage>(createProductImageRequestDto);
        await _productImageCollection.InsertOneAsync(value);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _productImageCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<GetAllProductImageResponseDto>> GetAllProductImageAsync()
    {
        List<ProductImage> value = await _productImageCollection.Find(x => true).ToListAsync();
        List<GetAllProductImageResponseDto> mappedValues = _mapper.Map<List<GetAllProductImageResponseDto>>(value);
        return mappedValues;
    }

    public async Task<GetProductImageResponseDto> GetProductImageAsync(string id)
    {
        ProductImage value = await _productImageCollection.Find<ProductImage>(x => x.Id == id).FirstOrDefaultAsync();
        GetProductImageResponseDto mappedValue = _mapper.Map<GetProductImageResponseDto>(value);
        return mappedValue;
    }

    public async Task UpdateProductImageAsync(UpdateProductImageRequestDto updateProductImageRequestDto)
    {
        ProductImage value = _mapper.Map<ProductImage>(updateProductImageRequestDto);
        await _productImageCollection.FindOneAndReplaceAsync(x => x.Id == updateProductImageRequestDto.Id, value);
    }
}
