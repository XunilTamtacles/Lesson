using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

    public class JwtService
    {
        private readonly string secretKey = "9f3c7a1d5e2b8c4f6a9d0e7b3c1f5a8d";
        public string GenerateToken(string username, string role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
