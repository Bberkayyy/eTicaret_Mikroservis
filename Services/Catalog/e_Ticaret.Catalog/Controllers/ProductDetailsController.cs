using e_Ticaret.Catalog.Dtos.ProductDetailDtos;
using e_Ticaret.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Catalog.Controllers;

[Route("api/productdetails")]
[ApiController]
public class ProductDetailsController : ControllerBase
{
    private readonly IProductDetailService _productDetailService;

    public ProductDetailsController(IProductDetailService ProductDetailService)
    {
        _productDetailService = ProductDetailService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<GetAllProductDetailResponseDto> values = await _productDetailService.GetAllProductDetailAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetail(string id)
    {
        GetProductDetailResponseDto value = await _productDetailService.GetProductDetailAsync(id);
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProductDetail(CreateProductDetailRequestDto createProductDetailRequestDto)
    {
        await _productDetailService.CreateProductDetailAsync(createProductDetailRequestDto);
        return Ok("Ürün detayı başarıyla eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        await _productDetailService.DeleteProductDetailAsync(id);
        return Ok("Ürün detayı başarıyla silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailRequestDto updateProductDetailRequestDto)
    {
        await _productDetailService.UpdateProductDetailAsync(updateProductDetailRequestDto);
        return Ok("Ürün detayı başarıyla güncellendi.");
    }
}
