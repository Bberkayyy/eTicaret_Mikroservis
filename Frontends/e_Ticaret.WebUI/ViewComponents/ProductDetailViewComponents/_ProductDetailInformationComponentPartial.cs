using e_Ticaret.WebUIDtos.CatalogDtos.ProductDetailDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailInformationComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _ProductDetailInformationComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string productId)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/productdetails/getwithrelationshipsbyproductid?productId=" + productId);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            ResultProductDetailWithRelationshipsByProductIdDto? value = JsonConvert.DeserializeObject<ResultProductDetailWithRelationshipsByProductIdDto>(jsonData);
            return View(value);
        }
        return View();
    }
}
