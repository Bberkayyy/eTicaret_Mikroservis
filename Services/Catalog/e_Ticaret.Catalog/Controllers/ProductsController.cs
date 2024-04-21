using e_Ticaret.Catalog.Dtos.ProductDtos;
using e_Ticaret.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Catalog.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService ProductService)
    {
        _productService = ProductService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<GetAllProductResponseDto> values = await _productService.GetAllProductAsync();
        return Ok(values);
    }
    [HttpGet("withrelationships")]
    public async Task<IActionResult> GetAllWithRelationships()
    {
        List<GetAllProductWithRelationshipsResponseDto> values = await _productService.GetAllProductWithRelationshipsAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(string id)
    {
        GetProductResponseDto value = await _productService.GetProductAsync(id);
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductRequestDto createProductRequestDto)
    {
        await _productService.CreateProductAsync(createProductRequestDto);
        return Ok("Ürün başarıyla eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _productService.DeleteProductAsync(id);
        return Ok("Ürün başarıyla silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductRequestDto updateProductRequestDto)
    {
        await _productService.UpdateProductAsync(updateProductRequestDto);
        return Ok("Ürün başarıyla güncellendi.");
    }
}
