using e_Ticaret.WebUIDtos.CatalogDtos.ProductDetailDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/productdetail")]
public class ProductDetailController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductDetailController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("details/{productId}")]
    public async Task<IActionResult> Details(string productId)
    {
        GetProductDetailViewbagList();
        ViewBag.productName = await GetProductName(productId);
        ViewBag.productId = productId;
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/productdetails/getwithrelationshipsbyproductid?productId=" + productId);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            ResultProductDetailWithRelationshipsByProductIdDto? value = JsonConvert.DeserializeObject<ResultProductDetailWithRelationshipsByProductIdDto>(jsonData);
            ViewBag.v3 = $"{value.ProductName} Ürününe Ait Açıklama ve Bilgi";
            return View(value);
        }
        return View();
    }
    [HttpGet]
    [Route("createdetails/{productId}")]
    public async Task<IActionResult> CreateProductDetail(string productId)
    {
        GetProductDetailViewbagList();
        ViewBag.productId = productId;
        ViewBag.productName = await GetProductName(productId);
        ViewBag.v3 = "Ürün Açıklama ve Bilgi Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createdetails/{productId}")]
    public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createProductDetailDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7070/api/productdetails", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("details", "productdetail", new { area = "admin", productId = createProductDetailDto.ProductId });
        return View();
    }
    [Route("deletedetails/{id}")]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:7070/api/productdetails?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "product", new { area = "admin" });
        }
        return View();
    }
    [HttpGet]
    [Route("updatedetails/{id}")]
    public async Task<IActionResult> UpdateProductDetail(string id)
    {
        GetProductDetailViewbagList();
        ViewBag.v3 = "Ürün Açıklama ve Bilgi Güncelleme Sayfası";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/productdetails/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateProductDetailDto? value = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
            ViewBag.productIdForUpdate = value.ProductId;
            ViewBag.productNameForUpdate = await GetProductName(value.ProductId);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("updatedetails/{id}")]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7070/api/productdetails", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("details", "productdetail", new { area = "admin", productId = updateProductDetailDto.ProductId });
        return View();
    }
    private void GetProductDetailViewbagList()
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
