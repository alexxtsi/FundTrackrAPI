using FundTracrkAPI.DBManager;
using FundTracrkAPI.Services.Interfaces;
using FundTracrkAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FundTracrkAPI.Extantions
{
    public static class AppServicesExtantion
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseMySQL(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
