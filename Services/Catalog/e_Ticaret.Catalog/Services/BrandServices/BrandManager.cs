using AutoMapper;
using e_Ticaret.Catalog.Dtos.BrandDtos;
using e_Ticaret.Catalog.Entities;
using e_Ticaret.Catalog.Settings;
using MongoDB.Driver;

namespace e_Ticaret.Catalog.Services.BrandServices;

public class BrandManager : IBrandService
{
    private readonly IMongoCollection<Brand> _brandCollection;
    private readonly IMapper _mapper;

    public BrandManager(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        _mapper = mapper;
    }

    public async Task CreateBrandAsync(CreateBrandRequestDto createBrandRequestDto)
    {
        Brand value = _mapper.Map<Brand>(createBrandRequestDto);
        await _brandCollection.InsertOneAsync(value); ;
    }

    public async Task DeleteBrandAsync(string id)
    {
        await _brandCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<GetAllBrandResponseDto>> GetAllBrandAsync()
    {
        List<Brand> values = await _brandCollection.Find(x => true).ToListAsync();
        List<GetAllBrandResponseDto> mappedValues = _mapper.Map<List<GetAllBrandResponseDto>>(values);
        return mappedValues;
    }

    public async Task<GetBrandResponseDto> GetBrandAsync(string id)
    {
        Brand value = await _brandCollection.Find<Brand>(x => x.Id == id).FirstOrDefaultAsync();
        GetBrandResponseDto mappedValue = _mapper.Map<GetBrandResponseDto>(value);
        return mappedValue;
    }

    public async Task UpdateBrandAsync(UpdateBrandRequestDto updateBrandRequestDto)
    {
        Brand value = _mapper.Map<Brand>(updateBrandRequestDto);
        await _brandCollection.FindOneAndReplaceAsync(x => x.Id == updateBrandRequestDto.Id, value);
    }
}
