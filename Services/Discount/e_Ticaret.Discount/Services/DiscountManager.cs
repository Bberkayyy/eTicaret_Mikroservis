using Dapper;
using e_Ticaret.Discount.Context;
using e_Ticaret.Discount.Dtos;
using System.Data;

namespace e_Ticaret.Discount.Services;

public class DiscountManager : IDiscountService
{
    private readonly DapperContext _context;

    public DiscountManager(DapperContext context)
    {
        _context = context;
    }

    public async Task CreateDiscountCouponAsync(CreateDiscountCouponRequestDto createCouponRequestDto)
    {
        string query = "insert into DiscountCoupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
        DynamicParameters parameters = new();
        parameters.Add("@code", createCouponRequestDto.Code);
        parameters.Add("@rate", createCouponRequestDto.Rate);
        parameters.Add("@isActive", true);
        parameters.Add("@validDate", createCouponRequestDto.ValidDate);
        using (IDbConnection conn = _context.CreateConnection())
        {
            await conn.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteDiscountCouponAsync(int id)
    {
        string query = "delete from DiscountCoupons where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection conn = _context.CreateConnection())
        {
            await conn.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetAllDiscountCouponResponseDto>> GetAllDiscountCouponAsync()
    {
        string query = "select * from DiscountCoupons";
        using (IDbConnection conn = _context.CreateConnection())
        {
            IEnumerable<GetAllDiscountCouponResponseDto> values = await conn.QueryAsync<GetAllDiscountCouponResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetDiscountCouponResponseDto> GetDiscountCouponAsync(int id)
    {
        string query = " select * from DiscountCoupons where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection conn = _context.CreateConnection())
        {
            GetDiscountCouponResponseDto? value = await conn.QueryFirstOrDefaultAsync<GetDiscountCouponResponseDto>(query, parameters);
            return value;
        }
    }

    public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponRequestDto updateCouponRequestDto)
    {
        string query = "update DiscountCoupons set Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@code", updateCouponRequestDto.Code);
        parameters.Add("@rate", updateCouponRequestDto.Rate);
        parameters.Add("@isActive", updateCouponRequestDto.IsActive);
        parameters.Add("@validDate", updateCouponRequestDto.ValidDate);
        parameters.Add("@id", updateCouponRequestDto.Id);
        using (IDbConnection conn = _context.CreateConnection())
        {
            await conn.ExecuteAsync(query, parameters);
        }
    }
}
