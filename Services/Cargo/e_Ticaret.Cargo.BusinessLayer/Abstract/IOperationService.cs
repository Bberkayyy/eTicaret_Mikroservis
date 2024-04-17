using e_Ticaret.Cargo.DtoLayer.ApiDtos.OperationDtos;
using e_Ticaret.Cargo.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace e_Ticaret.Cargo.BusinessLayer.Abstract;

public interface IOperationService 
{
    void TAdd(CreateOperationRequestDto createOperationRequestDto);
    void TDelete(int id);
    void TUpdate(UpdateOperationRequestDto updateOperationRequestDto);
    GetOperationByIdResponseDto TGetById(int id);
    GetOperationByFilterResponseDto TGetByFilter(Expression<Func<Operation, bool>>? predicate);
    IEnumerable<GetAllOperationResponseDto> TGetAll();
}
