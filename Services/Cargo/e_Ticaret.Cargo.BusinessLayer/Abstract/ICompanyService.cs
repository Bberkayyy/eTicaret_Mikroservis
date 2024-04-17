using e_Ticaret.Cargo.DtoLayer.ApiDtos.CompanyDtos;
using e_Ticaret.Cargo.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace e_Ticaret.Cargo.BusinessLayer.Abstract;

public interface ICompanyService
{
    void TAdd(CreateCompanyRequestDto createCompanyRequestDto);
    void TDelete(int id);
    void TUpdate(UpdateCompanyRequestDto updateCompanyRequestDto);
    GetCompanyByIdResponseDto TGetById(int id);
    GetCompanyByFilterResponseDto TGetByFilter(Expression<Func<Company, bool>>? predicate);
    IEnumerable<GetAllCompanyResponseDto> TGetAll();
}
