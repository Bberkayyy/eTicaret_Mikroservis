using AutoMapper;
using e_Ticaret.Comment.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Comment.Controllers;

[Route("api/statistics")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly CommentContext _context;

    public StatisticsController(CommentContext context)
    {
        _context = context;
    }
    [HttpGet("getactivecommentcount")]
    public IActionResult GetActiveCommentCount()
    {
        return Ok(_context.UserComments.Where(x => x.IsActive == true).Count());
    }
    [HttpGet("getpassivecommentcount")]
    public IActionResult GetPassiveCommentCount()
    {
        return Ok(_context.UserComments.Where(x => x.IsActive == false).Count());
    }
    [HttpGet("getcommentcount")]
    public IActionResult GetCommentCount()
    {
        return Ok(_context.UserComments.Count());
    }
}
