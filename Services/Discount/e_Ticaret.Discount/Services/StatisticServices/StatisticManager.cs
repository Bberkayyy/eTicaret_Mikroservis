using Dapper;
using e_Ticaret.Discount.Context;
using System.Data;

namespace e_Ticaret.Discount.Services.StatisticServices;

public class StatisticManager : IStatisticService
{
    private readonly DapperContext _context;

    public StatisticManager(DapperContext context)
    {
        _context = context;
    }
    public async Task<int> GetDiscountCouponCount()
    {
        string query = "Select Count(*) From DiscountCoupons";
        using (IDbConnection conn = _context.CreateConnection())
        {
            int value = await conn.ExecuteScalarAsync<int>(query);
            return value;
        };
    }
}
