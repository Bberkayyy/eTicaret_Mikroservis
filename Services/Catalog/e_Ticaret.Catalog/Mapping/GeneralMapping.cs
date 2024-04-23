using AutoMapper;
using e_Ticaret.Catalog.Dtos.AboutDtos;
using e_Ticaret.Catalog.Dtos.BrandDtos;
using e_Ticaret.Catalog.Dtos.CategoryDtos;
using e_Ticaret.Catalog.Dtos.DiscountOfferDtos;
using e_Ticaret.Catalog.Dtos.FeatureSliderDtos;
using e_Ticaret.Catalog.Dtos.ProductDetailDtos;
using e_Ticaret.Catalog.Dtos.ProductDtos;
using e_Ticaret.Catalog.Dtos.ProductImageDtos;
using e_Ticaret.Catalog.Dtos.ServiceDtos;
using e_Ticaret.Catalog.Dtos.SpecialOfferDtos;
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
        CreateMap<Product, GetAllProductWithRelationshipsResponseDto>().ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.Category.Name)).ReverseMap();
        CreateMap<Product, GetAllProductWtihRelationshipsByCategoryIdResponseDto>().ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.Category.Name)).ReverseMap();
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

        CreateMap<FeatureSlider, CreateFeatureSliderRequestDto>().ReverseMap();
        CreateMap<FeatureSlider, GetAllFeatureSliderResponseDto>().ReverseMap();
        CreateMap<FeatureSlider, GetFeatureSliderResponseDto>().ReverseMap();
        CreateMap<FeatureSlider, UpdateFeatureSliderRequestDto>().ReverseMap();

        CreateMap<SpecialOffer, CreateSpecialOfferRequestDto>().ReverseMap();
        CreateMap<SpecialOffer, GetAllSpecialOfferResponseDto>().ReverseMap();
        CreateMap<SpecialOffer, GetSpecialOfferResponseDto>().ReverseMap();
        CreateMap<SpecialOffer, UpdateSpecialOfferRequestDto>().ReverseMap();

        CreateMap<Service, CreateServiceRequestDto>().ReverseMap();
        CreateMap<Service, GetAllServiceResponseDto>().ReverseMap();
        CreateMap<Service, GetServiceResponseDto>().ReverseMap();
        CreateMap<Service, UpdateServiceRequestDto>().ReverseMap();

        CreateMap<DiscountOffer, CreateDiscountOfferRequestDto>().ReverseMap();
        CreateMap<DiscountOffer, GetAllDiscountOfferResponseDto>().ReverseMap();
        CreateMap<DiscountOffer, GetDiscountOfferResponseDto>().ReverseMap();
        CreateMap<DiscountOffer, UpdateDiscountOfferRequestDto>().ReverseMap();

        CreateMap<Brand, CreateBrandRequestDto>().ReverseMap();
        CreateMap<Brand, GetAllBrandResponseDto>().ReverseMap();
        CreateMap<Brand, GetBrandResponseDto>().ReverseMap();
        CreateMap<Brand, UpdateBrandRequestDto>().ReverseMap();

        CreateMap<About, CreateAboutRequestDto>().ReverseMap();
        CreateMap<About, GetAllAboutResponseDto>().ReverseMap();
        CreateMap<About, GetAboutResponseDto>().ReverseMap();
        CreateMap<About, UpdateAboutRequestDto>().ReverseMap();
    }
}
