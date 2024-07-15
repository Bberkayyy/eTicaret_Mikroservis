using e_Ticaret.Discount.Services;
using e_Ticaret.Discount.Services.StatisticServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Discount.Controllers;

[Authorize]
[Route("api/statistics")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticService _statisticService;

    public StatisticsController(IStatisticService statisticService)
    {
        _statisticService = statisticService;
    }
    [HttpGet("getdiscountcopuncount")]
    public async Task<IActionResult> GetDiscountCouponCount()
    {
        return Ok(await _statisticService.GetDiscountCouponCount());
    }
}
