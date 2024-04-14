using e_Ticaret.Catalog.Dtos.CategoryDtos;
using e_Ticaret.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Catalog.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<GetAllCategoryResponseDto> values = await _categoryService.GetAllCategoryAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(string id)
    {
        GetCategoryResponseDto value = await _categoryService.GetCategoryAsync(id);
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto createCategoryRequestDto)
    {
        await _categoryService.CreateCategoryAsync(createCategoryRequestDto);
        return Ok("Kategori başarıyla eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return Ok("Kategori başarıyla silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryRequestDto updateCategoryRequestDto)
    {
        await _categoryService.UpdateCategoryAsync(updateCategoryRequestDto);
        return Ok("Kategori başarıyla güncellendi.");
    }
}
