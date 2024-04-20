using e_Ticaret.WebUIDtos.CatalogDtos.FeatureSliderDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.SpecialOfferDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.MainPageViewComponents;

public class _MainPageCarouselSpeacialOfferComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _MainPageCarouselSpeacialOfferComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/specialoffers");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultSpecialOfferDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultSpecialOfferDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
