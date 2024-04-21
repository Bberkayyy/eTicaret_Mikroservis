using e_Ticaret.WebUIDtos.CatalogDtos.AboutDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.UILayoutViewComponents;

public class _UILayoutFooterAboutComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _UILayoutFooterAboutComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/abouts");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultAboutDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultAboutDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
