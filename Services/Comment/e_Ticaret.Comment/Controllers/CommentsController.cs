using AutoMapper;
using e_Ticaret.Comment.Context;
using e_Ticaret.Comment.Dtos;
using e_Ticaret.Comment.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Comment.Controllers;

[Route("api/comments")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly CommentContext _context;
    private readonly IMapper _mapper;

    public CommentsController(CommentContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<UserComment> values = _context.UserComments.ToList();
        IEnumerable<GetAllUserCommentResponseDto> mappedValues = _mapper.Map<IEnumerable<GetAllUserCommentResponseDto>>(values);
        return Ok(mappedValues);
    }
    [HttpGet("commentlistbyproductid")]
    public IActionResult GetAllByProductId(string id)
    {
        IEnumerable<UserComment> values = _context.UserComments.Where(x => x.ProductId == id).ToList();
        IEnumerable<GetAllUserCommentByProductIdResponseDto> mappedValues = _mapper.Map<IEnumerable<GetAllUserCommentByProductIdResponseDto>>(values);
        return Ok(mappedValues);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        UserComment? value = _context.UserComments.Find(id);
        GetUserCommentResponseDto mappedValue = _mapper.Map<GetUserCommentResponseDto>(value);
        return Ok(mappedValue);
    }
    [HttpPost]
    public IActionResult CreateComment(CreateUserCommentRequestDto createUserCommentRequestDto)
    {
        UserComment value = _mapper.Map<UserComment>(createUserCommentRequestDto);
        _context.UserComments.Add(value);
        _context.SaveChanges();
        return Ok("Yorum başarıyla eklendi.");
    }
    [HttpDelete]
    public IActionResult DeleteComment(int id)
    {
        UserComment? value = _context.UserComments.Find(id);
        _context.UserComments.Remove(value);
        _context.SaveChanges();
        return Ok("Yorum başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult UpdateComment(UpdateUserCommentRequestDto updateUserCommentRequestDto)
    {
        UserComment? value = _context.UserComments.Find(updateUserCommentRequestDto.Id);
        value.ProductId = updateUserCommentRequestDto.ProductId;
        value.FullName = updateUserCommentRequestDto.FullName;
        value.ImageUrl = updateUserCommentRequestDto.ImageUrl;
        value.Email = updateUserCommentRequestDto.Email;
        value.Detail = updateUserCommentRequestDto.Detail;
        value.Rating = updateUserCommentRequestDto.Rating;
        value.UpdatedDate = updateUserCommentRequestDto.UpdateDate;
        value.IsActive = updateUserCommentRequestDto.IsActive;
        _context.UserComments.Update(value);
        _context.SaveChanges();
        return Ok("Yorum başarıyla güncellendi.");
    }
}