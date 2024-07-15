namespace e_Ticaret.WebUI.Services.StatisticServices.CatalogStatisticServices;

public interface ICatalogStatisticService
{
    Task<long> GetCategoryCountAsync();
    Task<long> GetProductCountAsync();
    Task<long> GetBrandCountAsync();
    //Task<decimal> GetProductPriceAvgAsync();
    Task<string> GetProductNameOfMaxPriceProduct();
    Task<string> GetProductNameOfMinPriceProduct();
}
