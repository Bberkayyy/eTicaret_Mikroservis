using AutoMapper;
using e_Ticaret.Cargo.BusinessLayer.Abstract;
using e_Ticaret.Cargo.DataAccessLayer.Abstract;
using e_Ticaret.Cargo.DtoLayer.ApiDtos.CompanyDtos;
using e_Ticaret.Cargo.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace e_Ticaret.Cargo.BusinessLayer.Concrete;

public class CompanyManager : ICompanyService
{
    private readonly ICompanyDal _companyDal;
    private readonly IMapper _mapper;

    public CompanyManager(ICompanyDal companyDal, IMapper mapper)
    {
        _companyDal = companyDal;
        _mapper = mapper;
    }

    public void TAdd(CreateCompanyRequestDto createCompanyRequestDto)
    {
        Company mappedValue = _mapper.Map<Company>(createCompanyRequestDto);
        _companyDal.Add(mappedValue);
    }

    public void TDelete(int id)
    {
        _companyDal.Delete(id);
    }

    public IEnumerable<GetAllCompanyResponseDto> TGetAll()
    {
        IEnumerable<Company> values = _companyDal.GetAll();
        IEnumerable<GetAllCompanyResponseDto> mappedValues = values.Select(x => _mapper.Map<GetAllCompanyResponseDto>(x)).ToList();
        return mappedValues;
    }

    public GetCompanyByFilterResponseDto TGetByFilter(Expression<Func<Company, bool>>? predicate)
    {
        Company value = _companyDal.GetByFilter(predicate);
        GetCompanyByFilterResponseDto mappedValue = _mapper.Map<GetCompanyByFilterResponseDto>(value);
        return mappedValue;
    }

    public GetCompanyByIdResponseDto TGetById(int id)
    {
        Company value = _companyDal.GetById(id);
        GetCompanyByIdResponseDto mappedValue = _mapper.Map<GetCompanyByIdResponseDto>(value);
        return mappedValue;
    }

    public void TUpdate(UpdateCompanyRequestDto updateCompanyRequestDto)
    {
        Company mappedValue = _mapper.Map<Company>(updateCompanyRequestDto);
        _companyDal.Update(mappedValue);
    }
}
