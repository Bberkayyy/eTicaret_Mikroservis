using e_Ticaret.WebUIDtos.CatalogDtos.CategoryDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.UILayoutViewComponents;

public class _UILayoutNavbarCategoriesComponenPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _UILayoutNavbarCategoriesComponenPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/categories");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultCategoryDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultCategoryDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
