using AutoMapper;
using e_Ticaret.Catalog.Dtos.ServiceDtos;
using e_Ticaret.Catalog.Entities;
using e_Ticaret.Catalog.Settings;
using MongoDB.Driver;

namespace e_Ticaret.Catalog.Services.ServiceServices;

public class ServiceManager : IServiceService
{
    private readonly IMongoCollection<Service> _serviceCollection;
    private readonly IMapper _mapper;

    public ServiceManager(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _serviceCollection = database.GetCollection<Service>(_databaseSettings.ServiceCollectionName);
        _mapper = mapper;
    }

    public async Task CreateServiceAsync(CreateServiceRequestDto createServiceRequestDto)
    {
        Service value = _mapper.Map<Service>(createServiceRequestDto);
        await _serviceCollection.InsertOneAsync(value); ;
    }

    public async Task DeleteServiceAsync(string id)
    {
        await _serviceCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<GetAllServiceResponseDto>> GetAllServiceAsync()
    {
        List<Service> values = await _serviceCollection.Find(x => true).ToListAsync();
        List<GetAllServiceResponseDto> mappedValues = _mapper.Map<List<GetAllServiceResponseDto>>(values);
        return mappedValues;
    }

    public async Task<GetServiceResponseDto> GetServiceAsync(string id)
    {
        Service value = await _serviceCollection.Find<Service>(x => x.Id == id).FirstOrDefaultAsync();
        GetServiceResponseDto mappedValue = _mapper.Map<GetServiceResponseDto>(value);
        return mappedValue;
    }

    public async Task UpdateServiceAsync(UpdateServiceRequestDto updateServiceRequestDto)
    {
        Service value = _mapper.Map<Service>(updateServiceRequestDto);
        await _serviceCollection.FindOneAndReplaceAsync(x => x.Id == updateServiceRequestDto.Id, value);
    }
}
