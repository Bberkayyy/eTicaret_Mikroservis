using AutoMapper;
using e_Ticaret.Cargo.DtoLayer.ApiDtos.CompanyDtos;
using e_Ticaret.Cargo.DtoLayer.ApiDtos.DetailDtos;
using e_Ticaret.Cargo.DtoLayer.ApiDtos.SenderDtos;
using e_Ticaret.Cargo.DtoLayer.ApiDtos.OperationDtos;
using e_Ticaret.Cargo.EntityLayer.Concrete;

namespace e_Ticaret.Cargo.BusinessLayer.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Company, CreateCompanyRequestDto>().ReverseMap();
        CreateMap<Company, UpdateCompanyRequestDto>().ReverseMap();
        CreateMap<Company, GetAllCompanyResponseDto>().ReverseMap();
        CreateMap<Company, GetCompanyByFilterResponseDto>().ReverseMap();
        CreateMap<Company, GetCompanyByIdResponseDto>().ReverseMap();

        CreateMap<Detail, CreateDetailRequestDto>().ReverseMap();
        CreateMap<Detail, UpdateDetailRequestDto>().ReverseMap();
        CreateMap<Detail, GetAllDetailResponseDto>().ReverseMap();
        CreateMap<Detail, GetDetailByFilterResponseDto>().ReverseMap();
        CreateMap<Detail, GetDetailByIdResponseDto>().ReverseMap();

        CreateMap<Operation, CreateOperationRequestDto>().ReverseMap();
        CreateMap<Operation, UpdateOperationRequestDto>().ReverseMap();
        CreateMap<Operation, GetAllOperationResponseDto>().ReverseMap();
        CreateMap<Operation, GetOperationByFilterResponseDto>().ReverseMap();
        CreateMap<Operation, GetOperationByIdResponseDto>().ReverseMap();

        CreateMap<Sender, CreateSenderRequestDto>().ReverseMap();
        CreateMap<Sender, UpdateSenderRequestDto>().ReverseMap();
        CreateMap<Sender, GetAllSenderResponseDto>().ReverseMap();
        CreateMap<Sender, GetSenderByFilterResponseDto>().ReverseMap();
        CreateMap<Sender, GetSenderByIdResponseDto>().ReverseMap();
    }
}
