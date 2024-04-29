using AutoMapper;
using e_Ticaret.Comment.Dtos;
using e_Ticaret.Comment.Entities;

namespace e_Ticaret.Comment.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<UserComment, GetAllUserCommentResponseDto>().ReverseMap();
        CreateMap<UserComment, GetAllUserCommentByProductIdResponseDto>().ReverseMap();
        CreateMap<UserComment, GetUserCommentResponseDto>().ReverseMap();
        CreateMap<UserComment, CreateUserCommentRequestDto>().ReverseMap();
        CreateMap<UserComment, UpdateUserCommentRequestDto>().ReverseMap();
    }
}
