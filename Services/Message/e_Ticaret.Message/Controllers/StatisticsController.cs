using e_Ticaret.Message.Dtos;
using e_Ticaret.Message.Services.StatisticServices;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Message.Controllers;

[Route("api/statistics")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticService _statisticService;

    public StatisticsController(IStatisticService statisticService)
    {
        _statisticService = statisticService;
    }

    [HttpGet("getmessagecount")]
    public async Task<IActionResult> GetMessageCount()
    {
        return Ok(await _statisticService.GetMessageCount());
    }
    [HttpGet("getnumberofincomingmessage")]
    public async Task<IActionResult> GetNumberOfIncomingMessage(string receiverid)
    {
        int value = await _statisticService.GetNumberOfIncomingMessage(receiverid);
        return Ok(value);
    }
}
