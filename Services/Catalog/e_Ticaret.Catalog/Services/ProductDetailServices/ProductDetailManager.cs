using AutoMapper;
using e_Ticaret.Catalog.Dtos.ProductDetailDtos;
using e_Ticaret.Catalog.Entities;
using e_Ticaret.Catalog.Settings;
using MongoDB.Driver;

namespace e_Ticaret.Catalog.Services.ProductDetailServices;

public class ProductDetailManager : IProductDetailService
{
    private readonly IMongoCollection<ProductDetail> _productDetailCollection;
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMapper _mapper;

    public ProductDetailManager(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
        _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductDetailAsync(CreateProductDetailRequestDto createProductDetailRequestDto)
    {
        ProductDetail value = _mapper.Map<ProductDetail>(createProductDetailRequestDto);
        await _productDetailCollection.InsertOneAsync(value);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _productDetailCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<GetAllProductDetailResponseDto>> GetAllProductDetailAsync()
    {
        List<ProductDetail> value = await _productDetailCollection.Find(x => true).ToListAsync();
        List<GetAllProductDetailResponseDto> mappedValues = _mapper.Map<List<GetAllProductDetailResponseDto>>(value);
        return mappedValues;
    }

    public async Task<GetProductDetailResponseDto> GetProductDetailAsync(string id)
    {
        ProductDetail value = await _productDetailCollection.Find<ProductDetail>(x => x.Id == id).FirstOrDefaultAsync();
        GetProductDetailResponseDto mappedValue = _mapper.Map<GetProductDetailResponseDto>(value);
        return mappedValue;
    }

    public async Task<GetProductDetailWithRelationshipsByProductIdResponseDto> GetProductDetailWithRelationshipsByProductIdAsync(string productId)
    {
        ProductDetail value = await _productDetailCollection.Find<ProductDetail>(x => x.ProductId == productId).FirstOrDefaultAsync();
        value.Product = await _productCollection.Find<Product>(x => x.Id == value.ProductId).FirstAsync();
        GetProductDetailWithRelationshipsByProductIdResponseDto mappedValue = _mapper.Map<GetProductDetailWithRelationshipsByProductIdResponseDto>(value);
        return mappedValue;
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailRequestDto updateProductDetailRequestDto)
    {
        ProductDetail value = _mapper.Map<ProductDetail>(updateProductDetailRequestDto);
        await _productDetailCollection.FindOneAndReplaceAsync(x => x.Id == updateProductDetailRequestDto.Id, value);
    }
}
