using Application.Interfaces.IServices;
using Application.Services;
using Domain.Configs;
using Infrastructure.ExternalServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json.Serialization;
namespace Infrastructure.Extentions
{
    public static class DependenceInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IValidService, ValidService>();
            services.AddScoped<IJwtService, JwtService>();
        }
        public static void AddAuthenticationByJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwt = configuration.GetSection("JwtConfig").Get<JwtConfigs>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var key = Encoding.UTF8.GetBytes(jwt.Token);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwt.ValidateIssuer,
                    ValidIssuer = jwt.ValidIssuer,
                    ValidateAudience = jwt.ValidateAudience,
                    ValidAudience = jwt.ValidAudience,
                    ValidateLifetime = jwt.ValidateLifetime,
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuerSigningKey = jwt.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
        }
        public static void InitialValueConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfig = configuration.GetSection("JwtConfig");
            services.Configure<JwtConfigs>(jwtConfig);
        }
        public static void SetCorsForAPI(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    }
                    );
            });
        }

        public static IMvcBuilder AddCustomJsonOptions(this IMvcBuilder builder)
        {
            return builder.AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

    }

}
