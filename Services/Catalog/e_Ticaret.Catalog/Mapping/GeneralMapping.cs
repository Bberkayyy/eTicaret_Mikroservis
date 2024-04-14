using AutoMapper;
using e_Ticaret.Catalog.Dtos.CategoryDtos;
using e_Ticaret.Catalog.Dtos.ProductDetailDtos;
using e_Ticaret.Catalog.Dtos.ProductDtos;
using e_Ticaret.Catalog.Dtos.ProductImageDtos;
using e_Ticaret.Catalog.Entities;

namespace e_Ticaret.Catalog.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category, CreateCategoryRequestDto>().ReverseMap();
        CreateMap<Category, GetAllCategoryResponseDto>().ReverseMap();
        CreateMap<Category, GetCategoryResponseDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryRequestDto>().ReverseMap();

        CreateMap<Product, CreateProductRequestDto>().ReverseMap();
        CreateMap<Product, GetAllProductResponseDto>().ReverseMap();
        CreateMap<Product, GetProductResponseDto>().ReverseMap();
        CreateMap<Product, UpdateProductRequestDto>().ReverseMap();

        CreateMap<ProductDetail, CreateProductDetailRequestDto>().ReverseMap();
        CreateMap<ProductDetail, GetAllProductDetailResponseDto>().ReverseMap();
        CreateMap<ProductDetail, GetProductDetailResponseDto>().ReverseMap();
        CreateMap<ProductDetail, UpdateProductDetailRequestDto>().ReverseMap();

        CreateMap<ProductImage, CreateProductImageRequestDto>().ReverseMap();
        CreateMap<ProductImage, GetAllProductImageResponseDto>().ReverseMap();
        CreateMap<ProductImage, GetProductImageResponseDto>().ReverseMap();
        CreateMap<ProductImage, UpdateProductImageRequestDto>().ReverseMap();
    }
}
