using AutoMapper;
using e_Ticaret.Cargo.BusinessLayer.Abstract;
using e_Ticaret.Cargo.DataAccessLayer.Abstract;
using e_Ticaret.Cargo.DtoLayer.ApiDtos.DetailDtos;
using e_Ticaret.Cargo.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace e_Ticaret.Cargo.BusinessLayer.Concrete;

public class DetailManager : IDetailService
{
    private readonly IDetailDal _detailDal;
    private readonly IMapper _mapper;

    public DetailManager(IDetailDal detailDal, IMapper mapper)
    {
        _detailDal = detailDal;
        _mapper = mapper;
    }

    public void TAdd(CreateDetailRequestDto createDetailRequestDto)
    {
        Detail mappedValue = _mapper.Map<Detail>(createDetailRequestDto);
        _detailDal.Add(mappedValue);
    }

    public void TDelete(int id)
    {
        _detailDal.Delete(id);
    }

    public IEnumerable<GetAllDetailResponseDto> TGetAll()
    {
        IEnumerable<Detail> values = _detailDal.GetAll();
        IEnumerable<GetAllDetailResponseDto> mappedValues = values.Select(x => _mapper.Map<GetAllDetailResponseDto>(x)).ToList();
        return mappedValues;
    }

    public GetDetailByFilterResponseDto TGetByFilter(Expression<Func<Detail, bool>>? predicate)
    {
        Detail value = _detailDal.GetByFilter(predicate);
        GetDetailByFilterResponseDto mappedValue = _mapper.Map<GetDetailByFilterResponseDto>(value);
        return mappedValue;
    }

    public GetDetailByIdResponseDto TGetById(int id)
    {
        Detail value = _detailDal.GetById(id);
        GetDetailByIdResponseDto mappedValue = _mapper.Map<GetDetailByIdResponseDto>(value);
        return mappedValue;
    }

    public void TUpdate(UpdateDetailRequestDto updateDetailRequestDto)
    {
        Detail mappedValue = _mapper.Map<Detail>(updateDetailRequestDto);
        _detailDal.Update(mappedValue);
    }
}
