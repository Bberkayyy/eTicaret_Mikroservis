using e_Ticaret.Cargo.DtoLayer.ApiDtos.DetailDtos;
using e_Ticaret.Cargo.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace e_Ticaret.Cargo.BusinessLayer.Abstract;

public interface IDetailService
{
    void TAdd(CreateDetailRequestDto createDetailRequestDto);
    void TDelete(int id);
    void TUpdate(UpdateDetailRequestDto updateDetailRequestDto);
    GetDetailByIdResponseDto TGetById(int id);
    GetDetailByFilterResponseDto TGetByFilter(Expression<Func<Detail, bool>>? predicate);
    IEnumerable<GetAllDetailResponseDto> TGetAll();
}
