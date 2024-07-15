using e_Ticaret.WebUIDtos.CargoDtos.CompanyDtos;

namespace e_Ticaret.WebUI.Services.CargoServices.CompanyServices;

public interface ICompanyService
{
    Task<List<ResultCompanyDto>> GetAllCompanyAsync();
    Task CreateCompanyAsync(CreateCompanyDto createCompanyDto);
    Task UpdateCompanyAsync(UpdateCompanyDto updateCompanyDto);
    Task DeleteCompanyAsync(int id);
    Task<UpdateCompanyDto> GetCompanyForUpdateAsync(int id);
}
