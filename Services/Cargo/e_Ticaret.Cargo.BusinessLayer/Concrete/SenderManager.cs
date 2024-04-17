using AutoMapper;
using e_Ticaret.Cargo.BusinessLayer.Abstract;
using e_Ticaret.Cargo.DataAccessLayer.Abstract;
using e_Ticaret.Cargo.DtoLayer.ApiDtos.SenderDtos;
using e_Ticaret.Cargo.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace e_Ticaret.Cargo.BusinessLayer.Concrete;

public class SenderManager : ISenderService
{
    private readonly ISenderDal _senderDal;
    private readonly IMapper _mapper;

    public SenderManager(ISenderDal senderDal, IMapper mapper)
    {
        _senderDal = senderDal;
        _mapper = mapper;
    }
    public void TAdd(CreateSenderRequestDto createSenderRequestDto)
    {
        Sender mappedValue = _mapper.Map<Sender>(createSenderRequestDto);
        _senderDal.Add(mappedValue);
    }

    public void TDelete(int id)
    {
        _senderDal.Delete(id);
    }

    public IEnumerable<GetAllSenderResponseDto> TGetAll()
    {
        IEnumerable<Sender> values = _senderDal.GetAll();
        IEnumerable<GetAllSenderResponseDto> mappedValues = values.Select(x => _mapper.Map<GetAllSenderResponseDto>(x)).ToList();
        return mappedValues;
    }

    public GetSenderByFilterResponseDto TGetByFilter(Expression<Func<Sender, bool>>? predicate)
    {
        Sender value = _senderDal.GetByFilter(predicate);
        GetSenderByFilterResponseDto mappedValue = _mapper.Map<GetSenderByFilterResponseDto>(value);
        return mappedValue;
    }

    public GetSenderByIdResponseDto TGetById(int id)
    {
        Sender value = _senderDal.GetById(id);
        GetSenderByIdResponseDto mappedValue = _mapper.Map<GetSenderByIdResponseDto>(value);
        return mappedValue;
    }

    public void TUpdate(UpdateSenderRequestDto updateSenderRequestDto)
    {
        Sender mappedValue = _mapper.Map<Sender>(updateSenderRequestDto);
        _senderDal.Update(mappedValue);
    }
}
