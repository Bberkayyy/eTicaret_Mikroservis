using e_Ticaret.Catalog.Services.StatisticServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Catalog.Controllers;

[Route("api/statistics")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticService _statisticService;

    public StatisticsController(IStatisticService statisticService)
    {
        _statisticService = statisticService;
    }
    [HttpGet("getbrandcount")]
    public async Task<IActionResult> GetBrandCount()
    {
        return Ok(await _statisticService.GetBrandCountAsync());
    }
    [HttpGet("getcategorycount")]
    public async Task<IActionResult> GetCategoryCount()
    {
        return Ok(await _statisticService.GetCategoryCountAsync());
    }
    [HttpGet("getproductcount")]
    public async Task<IActionResult> GetProductCount()
    {
        return Ok(await _statisticService.GetProductCountAsync());
    }
    [HttpGet("getproductnameofmaxpriceproduct")]
    public async Task<IActionResult> GetProductNameOfMaxPriceProduct()
    {
        return Ok(await _statisticService.GetProductNameOfMaxPriceProduct());
    }
    [HttpGet("getproductnameofminpriceproduct")]
    public async Task<IActionResult> GetProductNameOfMinPriceProduct()
    {
        return Ok(await _statisticService.GetProductNameOfMinPriceProduct());
    }
}
