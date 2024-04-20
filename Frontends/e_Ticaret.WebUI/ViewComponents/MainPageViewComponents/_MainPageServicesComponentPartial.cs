using e_Ticaret.WebUIDtos.CatalogDtos.FeatureSliderDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.MainPageViewComponents;

public class _MainPageServicesComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _MainPageServicesComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/services");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultServiceDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultServiceDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
