using e_Ticaret.Catalog.Dtos.ProductImageDtos;
using e_Ticaret.Catalog.Services.ProductImageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Catalog.Controllers;

[Route("api/productimanges")]
[ApiController]
public class ProductImagesController : ControllerBase
{
    private readonly IProductImageService _productImageService;

    public ProductImagesController(IProductImageService ProductImageService)
    {
        _productImageService = ProductImageService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<GetAllProductImageResponseDto> values = await _productImageService.GetAllProductImageAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductImage(string id)
    {
        GetProductImageResponseDto value = await _productImageService.GetProductImageAsync(id);
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProductImage(CreateProductImageRequestDto createProductImageRequestDto)
    {
        await _productImageService.CreateProductImageAsync(createProductImageRequestDto);
        return Ok("Ürün resmi başarıyla eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteProductImage(string id)
    {
        await _productImageService.DeleteProductImageAsync(id);
        return Ok("Ürün resmi başarıyla silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProductImage(UpdateProductImageRequestDto updateProductImageRequestDto)
    {
        await _productImageService.UpdateProductImageAsync(updateProductImageRequestDto);
        return Ok("Ürün resmi başarıyla güncellendi.");
    }
}
