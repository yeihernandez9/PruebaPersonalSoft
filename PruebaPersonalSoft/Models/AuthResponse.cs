using System;
namespace PruebaPersonalSoft.Models
{
	public class AuthResponse
	{
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public AuthResponse(User user, string token)
        {
            Email = user.email;
            Token = token;
        }
    }
}

