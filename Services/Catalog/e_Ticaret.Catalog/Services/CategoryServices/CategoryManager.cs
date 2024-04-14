using AutoMapper;
using e_Ticaret.Catalog.Dtos.CategoryDtos;
using e_Ticaret.Catalog.Entities;
using e_Ticaret.Catalog.Settings;
using MongoDB.Driver;

namespace e_Ticaret.Catalog.Services.CategoryServices;

public class CategoryManager : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;

    public CategoryManager(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        MongoClient client = new(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task CreateCategoryAsync(CreateCategoryRequestDto createCategoryRequestDto)
    {
        Category value = _mapper.Map<Category>(createCategoryRequestDto);
        await _categoryCollection.InsertOneAsync(value); ;
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await _categoryCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<GetAllCategoryResponseDto>> GetAllCategoryAsync()
    {
        List<Category> values = await _categoryCollection.Find(x => true).ToListAsync();
        List<GetAllCategoryResponseDto> mappedValues = _mapper.Map<List<GetAllCategoryResponseDto>>(values);
        return mappedValues;
    }

    public async Task<GetCategoryResponseDto> GetCategoryAsync(string id)
    {
        Category value = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
        GetCategoryResponseDto mappedValue = _mapper.Map<GetCategoryResponseDto>(value);
        return mappedValue;
    }

    public async Task UpdateCategoryAsync(UpdateCategoryRequestDto updateCategoryRequestDto)
    {
        Category value = _mapper.Map<Category>(updateCategoryRequestDto);
        await _categoryCollection.FindOneAndReplaceAsync(x => x.Id == updateCategoryRequestDto.Id, value);
    }
}
