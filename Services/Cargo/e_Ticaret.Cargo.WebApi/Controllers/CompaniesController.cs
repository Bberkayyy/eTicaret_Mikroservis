using e_Ticaret.Cargo.BusinessLayer.Abstract;
using e_Ticaret.Cargo.DtoLayer.ApiDtos.CompanyDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<GetAllCompanyResponseDto> values = _companyService.TGetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        GetCompanyByIdResponseDto value = _companyService.TGetById(id);
        return Ok(value);
    }
    [HttpPost]
    public IActionResult CreateCompany(CreateCompanyRequestDto createCompanyRequestDto)
    {
        _companyService.TAdd(createCompanyRequestDto);
        return Ok("Kargo şirketi başarıyla eklendi.");
    }
    [HttpDelete]
    public IActionResult DeleteCompany(int id)
    {
        _companyService.TDelete(id);
        return Ok("Kargo şirketi başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult UpdateCompany(UpdateCompanyRequestDto updateCompanyRequestDto)
    {
        _companyService.TUpdate(updateCompanyRequestDto);
        return Ok("Kargo şirketi başarıyla güncellendi.");
    }
}
