using e_Ticaret.Cargo.BusinessLayer.Abstract;
using e_Ticaret.Cargo.DtoLayer.ApiDtos.OperationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/operations")]
[ApiController]
public class OperationsController : ControllerBase
{
    private readonly IOperationService _operationService;

    public OperationsController(IOperationService OperationService)
    {
        _operationService = OperationService;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<GetAllOperationResponseDto> values = _operationService.TGetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        GetOperationByIdResponseDto value = _operationService.TGetById(id);
        return Ok(value);
    }
    [HttpPost]
    public IActionResult CreateOperation(CreateOperationRequestDto createOperationRequestDto)
    {
        _operationService.TAdd(createOperationRequestDto);
        return Ok("Kargo operasyonu başarıyla eklendi.");
    }
    [HttpDelete]
    public IActionResult DeleteOperation(int id)
    {
        _operationService.TDelete(id);
        return Ok("Kargo operasyonu başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult UpdateOperation(UpdateOperationRequestDto updateOperationRequestDto)
    {
        _operationService.TUpdate(updateOperationRequestDto);
        return Ok("Kargo operasyonu başarıyla güncellendi.");
    }
}
