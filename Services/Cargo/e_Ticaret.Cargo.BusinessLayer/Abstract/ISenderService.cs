using e_Ticaret.Cargo.DtoLayer.ApiDtos.SenderDtos;
using e_Ticaret.Cargo.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace e_Ticaret.Cargo.BusinessLayer.Abstract;

public interface ISenderService
{
    void TAdd(CreateSenderRequestDto createSenderRequestDto);
    void TDelete(int id);
    void TUpdate(UpdateSenderRequestDto updateSenderRequestDto);
    GetSenderByIdResponseDto TGetById(int id);
    GetSenderByFilterResponseDto TGetByFilter(Expression<Func<Sender, bool>>? predicate);
    IEnumerable<GetAllSenderResponseDto> TGetAll();
}
