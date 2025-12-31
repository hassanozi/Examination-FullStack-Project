using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace examinationAPI.Helpers
{
    public class GenerateToken
    {
        public static string Generate(string UserId, string Name, string RoleId)
        {
            var key = System.Text.Encoding.ASCII.GetBytes("ExaminationSystem.Data.Constants.SecretKey");
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                       new Claim("UserId", UserId),
                       new Claim(ClaimTypes.Name, Name),
                       new Claim(ClaimTypes.Role, RoleId),
                    }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                    Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature
                    ),
                Issuer = "ExaminationSystem",
                Audience = "Front_ExaminationSystem",
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}