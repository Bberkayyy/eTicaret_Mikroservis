using e_Ticaret.WebUIDtos.CatalogDtos.FeatureSliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.MainPageViewComponents;

public class _MainPageCarouselComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _MainPageCarouselComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/featuresliders");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultFeatureSliderDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultFeatureSliderDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
