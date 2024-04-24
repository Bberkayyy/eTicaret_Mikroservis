using e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/productimage")]
public class ProductImageController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductImageController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("images/{productId}")]
    public async Task<IActionResult> Images(string productId)
    {
        GetProductImageViewbagList();
        ViewBag.productName = await GetProductName(productId);
        ViewBag.productId = productId;
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/productimages/getwithrelationshipsbyproductid?productId=" + productId);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            ResultProductImageWithRelationshipsByProductIdDto? value = JsonConvert.DeserializeObject<ResultProductImageWithRelationshipsByProductIdDto>(jsonData);
            ViewBag.v3 = $"{value.ProductName} Ürününe Ait Görseller";
            return View(value);
        }
        return View();
    }
    [HttpGet]
    [Route("createimages/{productId}")]
    public async Task<IActionResult> CreateProductImage(string productId)
    {
        GetProductImageViewbagList();
        ViewBag.productId = productId;
        ViewBag.productName = await GetProductName(productId);
        ViewBag.v3 = "Ürün Görseli Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createimages/{productId}")]
    public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createProductImageDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7070/api/productimages", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("images", "productimage", new { area = "admin", productId = createProductImageDto.ProductId });
        return View();
    }
    [Route("deleteimages/{id}")]
    public async Task<IActionResult> DeleteProductImage(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:7070/api/productimages?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "product", new { area = "admin" });
        }
        return View();
    }
    [HttpGet]
    [Route("updateimages/{id}")]
    public async Task<IActionResult> UpdateProductImage(string id)
    {
        GetProductImageViewbagList();
        ViewBag.v3 = "Ürün Görseli Güncelleme Sayfası";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/productimages/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateProductImageDto? value = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
            ViewBag.productIdForUpdate = value.ProductId;
            ViewBag.productNameForUpdate = await GetProductName(value.ProductId);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("updateimages/{id}")]
    public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateProductImageDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7070/api/productimages", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("images", "productimage", new { area = "admin", productId = updateProductImageDto.ProductId });
        return View();
    }
    private void GetProductImageViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Ürün İşlemleri";
    }
    private async Task<string> GetProductName(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/products/" + id);
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        ResultProductDto? value = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);
        return value.Name;
    }
}
