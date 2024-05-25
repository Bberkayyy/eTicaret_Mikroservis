using e_Ticaret.WebUIDtos.CommentDtos.UserCommentDtos;

namespace e_Ticaret.WebUI.Services.CommentServices.UserCommentServices;

public class UserCommentService : IUserCommentService
{
    private readonly HttpClient _httpClient;

    public UserCommentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateUserCommentAsync(CreateUserCommentDto createUserCommentDto)
    {
        await _httpClient.PostAsJsonAsync("comments", createUserCommentDto);
    }

    public async Task DeleteUserCommentAsync(string id)
    {
        await _httpClient.DeleteAsync("comments?id=" + id);
    }

    public async Task<List<ResultUserCommentDto>> GetAllUserCommentAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("comments");
        List<ResultUserCommentDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultUserCommentDto>>();
        return values;
    }

    public async Task<UpdateUserCommentDto> GetUserCommentForUpdateAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("comments/" + id);
        UpdateUserCommentDto? values = await responseMessage.Content.ReadFromJsonAsync<UpdateUserCommentDto>();
        return values;
    }

    public async Task<List<ResultUserCommentDto>> GetUserCommentsByProductIdAsync(string productId)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("comments/commentlistbyproductid?id=" + productId);
        List<ResultUserCommentDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultUserCommentDto>>();
        return values;
    }

    public async Task UpdateUserCommentAsync(UpdateUserCommentDto updateUserCommentDto)
    {
        await _httpClient.PutAsJsonAsync("comments", updateUserCommentDto);
    }
}
