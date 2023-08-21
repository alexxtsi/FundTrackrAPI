using FundTracrkAPI.Models.DBmodels;
using FundTracrkAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FundTracrkAPI.Services
{
	public class TokenService : ITokenService
	{
		private readonly SymmetricSecurityKey _key;

		// Constructor that initializes the symmetric security key used for token generation
		public TokenService(IConfiguration config)
		{
			_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
		}

		// Method that creates a new JWT token for a user based on their details
		public string CreateToken(UserModel user)
		{
			// Create a new list of claims containing the name ID of the user
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
			};

			// Create signing credentials using the symmetric security key
			var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

			// Create a new security token descriptor with the claims, expiration date, and signing credentials
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddDays(7),
				SigningCredentials = creds
			};

			// Create a new JWT security token handler
			var tokenHandler = new JwtSecurityTokenHandler();

			// Create a new token based on the token descriptor
			var token = tokenHandler.CreateToken(tokenDescriptor);

			// Return the string representation of the token
			return tokenHandler.WriteToken(token);
		}
	}
}