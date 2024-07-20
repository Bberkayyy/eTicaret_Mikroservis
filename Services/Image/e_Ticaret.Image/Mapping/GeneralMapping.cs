using AutoMapper;
using e_Ticaret.Image.DAL.Dtos;
using e_Ticaret.Image.DAL.Entities;

namespace e_Ticaret.Image.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<ProductImage, GetAllProductImageResponseDto>().ReverseMap();
        CreateMap<ProductImage, GetAllProductImagesByProductIdResponseDto>().ReverseMap();
        CreateMap<ProductImage, UploadProductImageRequestDto>().ReverseMap();
        CreateMap<ProductImage, UpdateProductImageRequestDto>().ReverseMap();
    }
}
