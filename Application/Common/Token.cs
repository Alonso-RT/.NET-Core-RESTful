using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Common
{
    public static class Token
    {
        public static string GenerateToken(tblCliente cliente, DateTime expiration, string stringKey, string issuer, string audience)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("ID", cliente.ClienteID.ToString()),
                new Claim("UserName", cliente.NombreUsuario.ToString())
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(stringKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiration,
                signingCredentials: creds,
                issuer: issuer,
                audience: audience);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
