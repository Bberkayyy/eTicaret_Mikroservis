using AutoMapper;
using e_Ticaret.Catalog.Dtos.AboutDtos;
using e_Ticaret.Catalog.Entities;
using e_Ticaret.Catalog.Settings;
using MongoDB.Driver;

namespace e_Ticaret.Catalog.Services.AboutServices;

public class AboutManager : IAboutService
{
    private readonly IMongoCollection<About> _aboutCollection;
    private readonly IMapper _mapper;

    public AboutManager(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
        _mapper = mapper;
    }

    public async Task CreateAboutAsync(CreateAboutRequestDto createAboutRequestDto)
    {
        About value = _mapper.Map<About>(createAboutRequestDto);
        await _aboutCollection.InsertOneAsync(value); ;
    }

    public async Task DeleteAboutAsync(string id)
    {
        await _aboutCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<GetAllAboutResponseDto>> GetAllAboutAsync()
    {
        List<About> values = await _aboutCollection.Find(x => true).ToListAsync();
        List<GetAllAboutResponseDto> mappedValues = _mapper.Map<List<GetAllAboutResponseDto>>(values);
        return mappedValues;
    }

    public async Task<GetAboutResponseDto> GetAboutAsync(string id)
    {
        About value = await _aboutCollection.Find<About>(x => x.Id == id).FirstOrDefaultAsync();
        GetAboutResponseDto mappedValue = _mapper.Map<GetAboutResponseDto>(value);
        return mappedValue;
    }

    public async Task UpdateAboutAsync(UpdateAboutRequestDto updateAboutRequestDto)
    {
        About value = _mapper.Map<About>(updateAboutRequestDto);
        await _aboutCollection.FindOneAndReplaceAsync(x => x.Id == updateAboutRequestDto.Id, value);
    }
}
