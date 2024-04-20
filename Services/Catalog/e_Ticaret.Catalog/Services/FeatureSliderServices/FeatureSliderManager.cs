using AutoMapper;
using e_Ticaret.Catalog.Dtos.FeatureSliderDtos;
using e_Ticaret.Catalog.Entities;
using e_Ticaret.Catalog.Settings;
using MongoDB.Driver;

namespace e_Ticaret.Catalog.Services.FeatureSliderServices;

public class FeatureSliderManager : IFeatureSliderService
{
    private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
    private readonly IMapper _mapper;

    public FeatureSliderManager(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _featureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
        _mapper = mapper;
    }

    public async Task ChangeStatusToFalse(string id)
    {
        FeatureSlider value = await _featureSliderCollection.Find<FeatureSlider>(x => x.Id == id).FirstOrDefaultAsync();
        value.Status = false;
    }

    public async Task ChangeStatusToTrue(string id)
    {
        FeatureSlider value = await _featureSliderCollection.Find<FeatureSlider>(x => x.Id == id).FirstOrDefaultAsync();
        value.Status = true;
    }

    public async Task CreateFeatureSliderAsync(CreateFeatureSliderRequestDto createFeatureSliderRequestDto)
    {
        FeatureSlider value = _mapper.Map<FeatureSlider>(createFeatureSliderRequestDto);
        await _featureSliderCollection.InsertOneAsync(value); ;
    }

    public async Task DeleteFeatureSliderAsync(string id)
    {
        await _featureSliderCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<GetAllFeatureSliderResponseDto>> GetAllFeatureSliderAsync()
    {
        List<FeatureSlider> values = await _featureSliderCollection.Find(x => true).ToListAsync();
        List<GetAllFeatureSliderResponseDto> mappedValues = _mapper.Map<List<GetAllFeatureSliderResponseDto>>(values);
        return mappedValues;
    }

    public async Task<GetFeatureSliderResponseDto> GetFeatureSliderAsync(string id)
    {
        FeatureSlider value = await _featureSliderCollection.Find<FeatureSlider>(x => x.Id == id).FirstOrDefaultAsync();
        GetFeatureSliderResponseDto mappedValue = _mapper.Map<GetFeatureSliderResponseDto>(value);
        return mappedValue;
    }

    public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderRequestDto updateFeatureSliderRequestDto)
    {
        FeatureSlider value = _mapper.Map<FeatureSlider>(updateFeatureSliderRequestDto);
        await _featureSliderCollection.FindOneAndReplaceAsync(x => x.Id == updateFeatureSliderRequestDto.Id, value);
    }
}
