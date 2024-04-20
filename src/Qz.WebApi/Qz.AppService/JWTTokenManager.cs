using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace Qz.Application
{
    public class JWTTokenManager
    {
        public static string GenerateToken(IEnumerable<Claim> claims, string Secret, int expiresMinutes = 60, string issuer = null, string audience = null)
        {
            var key = new SymmetricSecurityKey(Convert.FromBase64String(Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(expiresMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public static ClaimsPrincipal GetPrincipal(string token, string secret, bool validateLifetime = true)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(secret))
            {
                return null;
            }

            if (token.StartsWith("Bearer"))
            {
                token = token.Replace("Bearer ", string.Empty);
            }

            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;

                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = validateLifetime,
                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(secret))
                };

                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out securityToken);
                return principal;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}