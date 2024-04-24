using e_Ticaret.WebUIDtos.CatalogDtos.ProductImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailImageSliderComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _ProductDetailImageSliderComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string productId)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/productimages/getwithrelationshipsbyproductid?productId=" + productId);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            ResultProductImageWithRelationshipsByProductIdDto? value = JsonConvert.DeserializeObject<ResultProductImageWithRelationshipsByProductIdDto>(jsonData);
            return View(value);
        }
        return View();
    }
}
