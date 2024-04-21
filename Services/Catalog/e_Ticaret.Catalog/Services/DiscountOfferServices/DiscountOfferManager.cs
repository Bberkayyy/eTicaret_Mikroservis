using AutoMapper;
using e_Ticaret.Catalog.Dtos.DiscountOfferDtos;
using e_Ticaret.Catalog.Entities;
using e_Ticaret.Catalog.Settings;
using MongoDB.Driver;

namespace e_Ticaret.Catalog.Services.DiscountOfferServices;

public class DiscountOfferManager : IDiscountOfferService
{
    private readonly IMongoCollection<DiscountOffer> _discountOfferCollection;
    private readonly IMapper _mapper;

    public DiscountOfferManager(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _discountOfferCollection = database.GetCollection<DiscountOffer>(_databaseSettings.DiscountOfferCollectionName);
        _mapper = mapper;
    }

    public async Task ChangeStatusToFalse(string id)
    {
        DiscountOffer value = await _discountOfferCollection.Find<DiscountOffer>(x => x.Id == id).FirstOrDefaultAsync();
        value.IsActive = false;
    }

    public async Task ChangeStatusToTrue(string id)
    {
        DiscountOffer value = await _discountOfferCollection.Find<DiscountOffer>(x => x.Id == id).FirstOrDefaultAsync();
        value.IsActive = true;
    }

    public async Task CreateDiscountOfferAsync(CreateDiscountOfferRequestDto createDiscountOfferRequestDto)
    {
        DiscountOffer value = _mapper.Map<DiscountOffer>(createDiscountOfferRequestDto);
        await _discountOfferCollection.InsertOneAsync(value); ;
    }

    public async Task DeleteDiscountOfferAsync(string id)
    {
        await _discountOfferCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<GetAllDiscountOfferResponseDto>> GetAllDiscountOfferAsync()
    {
        List<DiscountOffer> values = await _discountOfferCollection.Find(x => true).ToListAsync();
        List<GetAllDiscountOfferResponseDto> mappedValues = _mapper.Map<List<GetAllDiscountOfferResponseDto>>(values);
        return mappedValues;
    }

    public async Task<GetDiscountOfferResponseDto> GetDiscountOfferAsync(string id)
    {
        DiscountOffer value = await _discountOfferCollection.Find<DiscountOffer>(x => x.Id == id).FirstOrDefaultAsync();
        GetDiscountOfferResponseDto mappedValue = _mapper.Map<GetDiscountOfferResponseDto>(value);
        return mappedValue;
    }

    public async Task UpdateDiscountOfferAsync(UpdateDiscountOfferRequestDto updateDiscountOfferRequestDto)
    {
        DiscountOffer value = _mapper.Map<DiscountOffer>(updateDiscountOfferRequestDto);
        await _discountOfferCollection.FindOneAndReplaceAsync(x => x.Id == updateDiscountOfferRequestDto.Id, value);
    }
}
