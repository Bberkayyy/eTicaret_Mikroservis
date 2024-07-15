namespace e_Ticaret.Catalog.Services.StatisticServices;

public interface IStatisticService
{
    Task<long> GetCategoryCountAsync();
    Task<long> GetProductCountAsync();
    Task<long> GetBrandCountAsync();
    //Task<decimal> GetProductPriceAvgAsync();
    Task<string> GetProductNameOfMaxPriceProduct();
    Task<string> GetProductNameOfMinPriceProduct();
}
