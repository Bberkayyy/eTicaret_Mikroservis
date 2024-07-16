using AutoMapper;
using e_Ticaret.Message.DAL.Entities;
using e_Ticaret.Message.Dtos;

namespace e_Ticaret.Message.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<UserMessage, CreateMessageRequestDto>().ReverseMap();
        CreateMap<UserMessage, UpdateMessageRequestDto>().ReverseMap();
        CreateMap<UserMessage, GetMessageByIdResponseDto>().ReverseMap();
        CreateMap<UserMessage, GetAllMessageResponseDto>().ReverseMap();
        CreateMap<UserMessage, ResultMessageInboxResponseDto>().ReverseMap();
        CreateMap<UserMessage, ResultMessageSendboxResponseDto>().ReverseMap();
    }
}
