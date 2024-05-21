using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace e_Ticaret.IdentityServer.Tools;

public class JwtTokenGenerator
{
    public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel getCheckAppUserViewModel)
    {
        List<Claim> claims = new();
        if (!string.IsNullOrWhiteSpace(getCheckAppUserViewModel.Role))
            claims.Add(new Claim(ClaimTypes.Role, getCheckAppUserViewModel.Role));
        claims.Add(new Claim(ClaimTypes.NameIdentifier, getCheckAppUserViewModel.Id));

        if (!string.IsNullOrWhiteSpace(getCheckAppUserViewModel.Username))
            claims.Add(new Claim("Username", getCheckAppUserViewModel.Username));

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
        DateTime expireDate = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);

        JwtSecurityToken token = new
            (
            issuer: JwtTokenDefaults.ValidIssuer,
            audience: JwtTokenDefaults.ValidAudience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expireDate,
            signingCredentials: credentials
            );

        JwtSecurityTokenHandler tokenHandler = new();
        return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate);
    }
}
