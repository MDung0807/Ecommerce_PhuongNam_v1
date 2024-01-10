﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Exceptions;
using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce_PhuongNam_v1.Application.Common.Utils
{
    public class JwtUtils
    {
        #region -- Private properties --
        private static readonly string SECRET = "BachelorOfEngineeringThesisByMinhDung";
        /// <summary>
        /// Minutes
        /// </summary>
        private static readonly long EXPIRE = 60;
        #endregion -- Private properties --

        #region -- Public properties -- 
        #endregion -- Public properties --

        /// <summary>
        /// When login success. Reponse token
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static string GenerateToken (AuthResponse response)
        {
            SHA256 sha256 = SHA256.Create(); 
            var secretBytes = Encoding.UTF8.GetBytes (SECRET);
            var symmetricKey = sha256.ComputeHash (secretBytes);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserID", response.Id.ToString()),
                    new Claim("Username", response.Username),
                    new Claim("role", response.RoleName)
                }),

                Expires = now.AddMinutes(Convert.ToInt32(EXPIRE)),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature),
                TokenType = "Bearer"
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        /// <summary>
        /// Decode token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;
                SHA256 sha256 = SHA256.Create();
                var secretBytes = Encoding.UTF8.GetBytes(SECRET);
                var symmetricKey = sha256.ComputeHash(secretBytes);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }
            catch 
            {
                throw new AuthException(AuthConstants.UNAUTHORIZATION);
            }
        }

        /// <summary>
        /// Get token from header
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetToken (HttpContext context)
        {
            string authString = context.Request.Headers["Authorization"].FirstOrDefault();
            if (!authString.IsNullOrEmpty())
            {
                authString = authString.Substring(7);
            }
            return authString == ("null") ? string.Empty : authString;
        }

        /// <summary>
        /// Get ID Client from header['Authorization']
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static int GetUserID(HttpContext context)
        {
            string token = GetToken(context);
            var principal = GetPrincipal(token);
            string id = principal.Claims.ElementAt(0).Value;
            return int.Parse(id);
        }
        
        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create()){
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

    }
}
