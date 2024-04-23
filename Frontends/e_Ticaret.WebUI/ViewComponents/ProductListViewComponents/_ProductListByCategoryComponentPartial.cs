using e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace e_Ticaret.WebUI.ViewComponents.ProductListViewComponents;

public class _ProductListByCategoryComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _ProductListByCategoryComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string categoryId)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/products/withrelationshipsbycategoryid?categoryId=" + categoryId);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultProductWithRelationshipsByCategoryIdDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultProductWithRelationshipsByCategoryIdDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
