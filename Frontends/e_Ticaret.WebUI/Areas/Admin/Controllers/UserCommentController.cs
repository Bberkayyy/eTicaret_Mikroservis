using e_Ticaret.WebUIDtos.CommentDtos.UserCommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/usercomment")]
public class UserCommentController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public UserCommentController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetUserCommentViewbagList();
        ViewBag.v3 = "Yorum Listesi";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7075/api/comments");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultUserCommentDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultUserCommentDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [Route("deleteusercomment/{id}")]
    public async Task<IActionResult> DeleteUserComment(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:7075/api/comments?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "usercomment", new { area = "admin" });
        return View();
    }
    [HttpGet]
    [Route("updateusercomment/{id}")]
    public async Task<IActionResult> UpdateUserComment(string id)
    {
        GetUserCommentViewbagList();
        ViewBag.v3 = "Yorum Güncelleme Sayfası";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7075/api/comments/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateUserCommentDto? value = JsonConvert.DeserializeObject<UpdateUserCommentDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("updateusercomment/{id}")]
    public async Task<IActionResult> UpdateUserComment(UpdateUserCommentDto updateUserCommentDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateUserCommentDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7075/api/comments", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "usercomment", new { area = "admin" });
        return View();
    }
    private void GetUserCommentViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Yorum İşlemleri";
    }
}
