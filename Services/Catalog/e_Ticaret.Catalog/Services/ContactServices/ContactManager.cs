using AutoMapper;
using e_Ticaret.Catalog.Dtos.ContactDtos;
using e_Ticaret.Catalog.Entities;
using e_Ticaret.Catalog.Settings;
using MongoDB.Driver;

namespace e_Ticaret.Catalog.Services.ContactServices;

public class ContactManager : IContactService
{
    private readonly IMongoCollection<Contact> _contactCollection;
    private readonly IMapper _mapper;

    public ContactManager(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
        _mapper = mapper;
    }

    public async void ChangeIsReadToTrue(string id)
    {
        Contact value = await _contactCollection.Find<Contact>(x => x.Id == id).FirstOrDefaultAsync();
        value.IsRead = true;
        value.ReadTime = DateTime.Now;
        await _contactCollection.FindOneAndReplaceAsync(x => x.Id == id, value);
    }

    public async Task CreateContactAsync(CreateContactRequestDto createContactRequestDto)
    {
        Contact value = _mapper.Map<Contact>(createContactRequestDto);
        await _contactCollection.InsertOneAsync(value); ;
    }

    public async Task DeleteContactAsync(string id)
    {
        await _contactCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<GetAllContactResponseDto>> GetAllContactAsync()
    {
        List<Contact> values = await _contactCollection.Find(x => true).ToListAsync();
        List<GetAllContactResponseDto> mappedValues = _mapper.Map<List<GetAllContactResponseDto>>(values);
        return mappedValues;
    }

    public async Task<GetContactResponseDto> GetContactAsync(string id)
    {
        Contact value = await _contactCollection.Find<Contact>(x => x.Id == id).FirstOrDefaultAsync();
        GetContactResponseDto mappedValue = _mapper.Map<GetContactResponseDto>(value);
        return mappedValue;
    }

    public async Task UpdateContactAsync(UpdateContactRequestDto updateContactRequestDto)
    {
        Contact value = _mapper.Map<Contact>(updateContactRequestDto);
        await _contactCollection.FindOneAndReplaceAsync(x => x.Id == updateContactRequestDto.Id, value);
    }
}
