using e_Ticaret.WebUIDtos.CommentDtos.UserCommentDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.UserCommentServices;

public interface IUserCommentService
{
    Task<List<ResultUserCommentDto>> GetAllUserCommentAsync();
    Task CreateUserCommentAsync(CreateUserCommentDto createUserCommentDto);
    Task UpdateUserCommentAsync(UpdateUserCommentDto updateUserCommentDto);
    Task DeleteUserCommentAsync(string id);
    Task<UpdateUserCommentDto> GetUserCommentForUpdateAsync(string id);
    Task<List<ResultUserCommentDto>> GetUserCommentsByProductIdAsync(string productId);
}
