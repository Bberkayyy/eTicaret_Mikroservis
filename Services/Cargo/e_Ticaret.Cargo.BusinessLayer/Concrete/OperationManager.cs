using AutoMapper;
using e_Ticaret.Cargo.BusinessLayer.Abstract;
using e_Ticaret.Cargo.DataAccessLayer.Abstract;
using e_Ticaret.Cargo.DtoLayer.ApiDtos.OperationDtos;
using e_Ticaret.Cargo.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace e_Ticaret.Cargo.BusinessLayer.Concrete;

public class OperationManager : IOperationService
{
    private readonly IOperationDal _operationDal;
    private readonly IMapper _mapper;

    public OperationManager(IOperationDal operationDal, IMapper mapper)
    {
        _operationDal = operationDal;
        _mapper = mapper;
    }
    public void TAdd(CreateOperationRequestDto createOperationRequestDto)
    {
        Operation mappedValue = _mapper.Map<Operation>(createOperationRequestDto);
        _operationDal.Add(mappedValue);
    }

    public void TDelete(int id)
    {
        _operationDal.Delete(id);
    }

    public IEnumerable<GetAllOperationResponseDto> TGetAll()
    {
        IEnumerable<Operation> values = _operationDal.GetAll();
        IEnumerable<GetAllOperationResponseDto> mappedValues = values.Select(x => _mapper.Map<GetAllOperationResponseDto>(x)).ToList();
        return mappedValues;
    }

    public GetOperationByFilterResponseDto TGetByFilter(Expression<Func<Operation, bool>>? predicate)
    {
        Operation value = _operationDal.GetByFilter(predicate);
        GetOperationByFilterResponseDto mappedValue = _mapper.Map<GetOperationByFilterResponseDto>(value);
        return mappedValue;
    }

    public GetOperationByIdResponseDto TGetById(int id)
    {
        Operation value = _operationDal.GetById(id);
        GetOperationByIdResponseDto mappedValue = _mapper.Map<GetOperationByIdResponseDto>(value);
        return mappedValue;
    }

    public void TUpdate(UpdateOperationRequestDto updateOperationRequestDto)
    {
        Operation mappedValue = _mapper.Map<Operation>(updateOperationRequestDto);
        _operationDal.Update(mappedValue);
    }
}
