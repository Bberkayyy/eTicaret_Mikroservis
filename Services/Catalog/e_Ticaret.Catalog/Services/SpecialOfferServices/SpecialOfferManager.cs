using AutoMapper;
using e_Ticaret.Catalog.Dtos.SpecialOfferDtos;
using e_Ticaret.Catalog.Entities;
using e_Ticaret.Catalog.Settings;
using MongoDB.Driver;

namespace e_Ticaret.Catalog.Services.SpecialOfferServices;

public class SpecialOfferManager : ISpecialOfferService
{
    private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;
    private readonly IMapper _mapper;

    public SpecialOfferManager(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _specialOfferCollection = database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);
        _mapper = mapper;
    }

    public async Task CreateSpecialOfferAsync(CreateSpecialOfferRequestDto createSpecialOfferRequestDto)
    {
        SpecialOffer value = _mapper.Map<SpecialOffer>(createSpecialOfferRequestDto);
        await _specialOfferCollection.InsertOneAsync(value);
    }

    public async Task DeleteSpecialOfferAsync(string id)
    {
        await _specialOfferCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<GetAllSpecialOfferResponseDto>> GetAllSpecialOfferAsync()
    {
        List<SpecialOffer> values = await _specialOfferCollection.Find(x => true).ToListAsync();
        List<GetAllSpecialOfferResponseDto> mappedValues = _mapper.Map<List<GetAllSpecialOfferResponseDto>>(values);
        return mappedValues;
    }

    public async Task<GetSpecialOfferResponseDto> GetSpecialOfferAsync(string id)
    {
        SpecialOffer value = await _specialOfferCollection.Find<SpecialOffer>(x => x.Id == id).FirstOrDefaultAsync();
        GetSpecialOfferResponseDto mappedValue = _mapper.Map<GetSpecialOfferResponseDto>(value);
        return mappedValue;
    }

    public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferRequestDto updateSpecialOfferRequestDto)
    {
        SpecialOffer value = _mapper.Map<SpecialOffer>(updateSpecialOfferRequestDto);
        await _specialOfferCollection.FindOneAndReplaceAsync(x => x.Id == updateSpecialOfferRequestDto.Id, value);
    }
}
