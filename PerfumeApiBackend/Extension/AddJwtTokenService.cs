using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PerfumeApiBackend.Models;
using System.Text;

namespace PerfumeApiBackend.Extension
{
    public static class AddJwtTokenService
    {
        public static void AddJwtTokenServices(this IServiceCollection services, IConfiguration configuration)
        {
            /*
            --Binding JwtSetting with configuration appsettings.json--
            var bindJwtSettings = new JwtSettings();
            configuration.Bind("JwtValues", bindJwtSettings);
            */

            //Binding JwtSetting with secret manager
            var bindJwtSettings = configuration.GetSection("PerfumeProject:JwtValues").Get<JwtSettings>();

            //Add instance
            services.AddSingleton(bindJwtSettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = bindJwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(bindJwtSettings.IssuerSigningKey)),
                    ValidateIssuer = bindJwtSettings.ValidateIssuer,
                    ValidIssuer = bindJwtSettings.ValidIssuer,
                    ValidateAudience = bindJwtSettings.ValidateAudience,
                    ValidAudience = bindJwtSettings.ValidAudience,
                    RequireExpirationTime = bindJwtSettings.RequiredExpirationTime,
                    ValidateLifetime = bindJwtSettings.ValidateLifeTime,
                    ClockSkew = TimeSpan.FromDays(1)
                }; 
            });
        }
    }
}
