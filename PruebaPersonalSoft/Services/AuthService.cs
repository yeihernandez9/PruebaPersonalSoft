using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PruebaPersonalSoft.Config.Helpers;
using PruebaPersonalSoft.Models;
using PruebaPersonalSoft.Repositories.Users;

namespace PruebaPersonalSoft.Services
{
	public class AuthService
	{
        private readonly AppSettings _appSettings;

        private IUserCollection db = new UserCollection();

        public AuthService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<AuthResponse> Authenticate(Auth auth)
        {
            var user = await db.Authenticate(auth.Email, auth.Password);
            if (user == null) return null;

            var token = generateJwtToken(user);

            return new AuthResponse(user, token);
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}

