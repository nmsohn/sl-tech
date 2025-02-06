using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Vanilla.Domain.Entities;
using Vanilla.Dtos.Common;

namespace Vanilla.Application.Common;

public class TokenService
{
    public static string GetToken(TokenDto dto, AppUser user, List<Claim> roleClaims)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(dto.SecretKey));
        var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var userClaims = new List<Claim>
        {
            new("Id", user.Id.ToString()),
            new ("UserName", user.UserName??"")
        };
        userClaims.AddRange(roleClaims);
        var tokeOptions = new JwtSecurityToken(
            issuer: dto.Issuer,
            audience: dto.Audience,
            claims: userClaims,
            expires: DateTime.UtcNow.AddSeconds(dto.TokenExpireSeconds),
            signingCredentials: signInCredentials
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        return tokenString;
    } 
    
    public static ClaimsPrincipal GetPrincipalFromExpiredToken(TokenDto dto, string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = dto.Audience,
            ValidIssuer = dto.Issuer,
            ValidateLifetime = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(dto.SecretKey))
        };

        var principal = new JwtSecurityTokenHandler().ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("GetPrincipalFromExpiredToken Token is not validated");

        return principal;
    }
}