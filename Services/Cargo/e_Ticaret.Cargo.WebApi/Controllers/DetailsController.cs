using e_Ticaret.Cargo.BusinessLayer.Abstract;
using e_Ticaret.Cargo.DtoLayer.ApiDtos.DetailDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/details")]
[ApiController]
public class DetailsController : ControllerBase
{
    private readonly IDetailService _detailService;

    public DetailsController(IDetailService DetailService)
    {
        _detailService = DetailService;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<GetAllDetailResponseDto> values = _detailService.TGetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        GetDetailByIdResponseDto value = _detailService.TGetById(id);
        return Ok(value);
    }
    [HttpPost]
    public IActionResult CreateDetail(CreateDetailRequestDto createDetailRequestDto)
    {
        _detailService.TAdd(createDetailRequestDto);
        return Ok("Kargo detayı başarıyla eklendi.");
    }
    [HttpDelete]
    public IActionResult DeleteDetail(int id)
    {
        _detailService.TDelete(id);
        return Ok("Kargo detayı başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult UpdateDetail(UpdateDetailRequestDto updateDetailRequestDto)
    {
        _detailService.TUpdate(updateDetailRequestDto);
        return Ok("Kargo detayı başarıyla güncellendi.");
    }
}
