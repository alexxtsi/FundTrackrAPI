using FundTracrkAPI.DBManager;
using FundTracrkAPI.Services.Interfaces;
using FundTracrkAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FundTracrkAPI.Extantions
{
	public static class IdentityServiceEtantion
	{
		public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
		{

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding
							.UTF8.GetBytes(config["TokenKey"])),
						ValidateIssuer = false,
						ValidateAudience = false
					};
				});
			return services;
		}
	}
}
