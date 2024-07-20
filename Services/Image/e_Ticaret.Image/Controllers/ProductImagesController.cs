using AutoMapper;
using e_Ticaret.Image.DAL.Context;
using e_Ticaret.Image.DAL.Dtos;
using e_Ticaret.Image.DAL.Entities;
using e_Ticaret.Image.Services;
using e_Ticaret.Image.Services.GoogleCloudServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_Ticaret.Image.Controllers;

[Route("api/images")]
[ApiController]
public class ProductImagesController : ControllerBase
{
    private readonly ImageContext _context;
    private readonly ICloudStorageService _cloudStorageService;
    private readonly IMapper _mapper;

    public ProductImagesController(ImageContext context, ICloudStorageService cloudStorageService, IMapper mapper)
    {
        _context = context;
        _cloudStorageService = cloudStorageService;
        _mapper = mapper;
    }
    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        List<ProductImage> images = await _context.ProductImages.ToListAsync();
        foreach (var image in images)
        {
            await GenerateSignedUrl(image);

        }
        List<GetAllProductImageResponseDto> values = images.Select(x => _mapper.Map<GetAllProductImageResponseDto>(x)).ToList();
        return Ok(values);
    }
    [HttpGet("getproductimagesbyproductid/{productId}")]
    public async Task<IActionResult> GetProductImagesByProductId(string productId)
    {
        List<ProductImage> images = await _context.ProductImages.Where(x => x.ProductId == productId).ToListAsync();
        foreach (var image in images)
        {
            await GenerateSignedUrl(image);

        }
        List<GetAllProductImagesByProductIdResponseDto> values = images.Select(x => _mapper.Map<GetAllProductImagesByProductIdResponseDto>(x)).ToList();
        return Ok(values);
    }
    [HttpPost("uploadproductimage")]
    public async Task<IActionResult> Create([FromForm] UploadProductImageRequestDto uploadProductImageRequestDto)
    {
        ProductImage uploadedProductImage = _mapper.Map<ProductImage>(uploadProductImageRequestDto);
        if (uploadedProductImage.ImageFile != null)
        {
            uploadedProductImage.SavedFileName = GenerateFileNameToSaveService.GenerateFileNameToSave(uploadedProductImage.ImageFile.FileName);
            uploadedProductImage.SavedUrl = await _cloudStorageService.UploadFileAsync(uploadedProductImage.ImageFile, uploadedProductImage.SavedFileName);
        }
        _context.Add(uploadedProductImage);
        await _context.SaveChangesAsync();
        return Ok("Ürün görseli başarıyla yüklendi.");
    }
    [HttpPut("updateproductimage")]
    public async Task<IActionResult> Update([FromForm] UpdateProductImageRequestDto updateProductImageRequestDto)
    {
        ProductImage? productImage = await _context.ProductImages.FindAsync(updateProductImageRequestDto.Id);
        productImage.ProductId = updateProductImageRequestDto.ProductId;
        productImage.ImageFile = updateProductImageRequestDto.ImageFile;
        if (productImage.ImageFile != null)
        {
            if (!string.IsNullOrEmpty(productImage.SavedFileName))
            {
                await _cloudStorageService.DeleteFileAsync(productImage.SavedFileName);
            }
            productImage.SavedFileName = GenerateFileNameToSaveService.GenerateFileNameToSave(productImage.ImageFile.FileName);
            productImage.SavedUrl = await _cloudStorageService.UploadFileAsync(productImage.ImageFile, productImage.SavedFileName);
        }
        _context.Update(productImage);
        await _context.SaveChangesAsync();
        return Ok("Ürün görseli başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        ProductImage? value = await _context.ProductImages.FindAsync(id);
        if (value != null)
        {
            if (!string.IsNullOrWhiteSpace(value.SavedFileName))
            {
                await _cloudStorageService.DeleteFileAsync(value.SavedFileName);
                value.SavedFileName = String.Empty;
                value.SavedUrl = String.Empty;
            }
            _context.ProductImages.Remove(value);
        }
        await _context.SaveChangesAsync();
        return Ok("Ürün görseli başarıyla silindi.");
    }

    private async Task GenerateSignedUrl(ProductImage productImage)
    {
        if (!string.IsNullOrWhiteSpace(productImage.SavedFileName))
        {
            productImage.PhotoUrl = await _cloudStorageService.GetSignedUrlAsync(productImage.SavedFileName);
        }
    }
}
