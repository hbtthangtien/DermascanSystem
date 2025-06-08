using Application.Interfaces.IServices;
using Application.Services;
using Domain.Configs;
using Domain.Constant;
using Infrastructure.ExternalServices;
using Mapster;
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
            services.AddSingleton<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IGenemiService,GeminiAIService>();
            services.AddScoped<IAnalysisService,AnalysisService>();
            services.AddScoped<IRoboflowService, RoboflowService>();
            services.AddScoped<IUserContextService, UserContextService>();
            services.AddScoped<IPlanGuardService, PlanGuardService>();
            services.AddScoped<ISubscriptionPlanService, SubscriptionPlanService>();
            services.AddHttpContextAccessor();
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
            var apiGemini = configuration.GetSection("GeminiApi");
            var cloudinaryConfig = configuration.GetSection("Cloudinary");
            var roboflowConfig = configuration.GetSection("Roboflow");
            services.Configure<JwtConfigs>(jwtConfig);
            services.Configure<GeminiApi>(apiGemini);
            services.Configure<CloundinaryConfig>(cloudinaryConfig);
            services.Configure<RoboflowConfig>(roboflowConfig);
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
        public static void AddMapperToProject(this IServiceCollection services)
        {
            services.AddMapster();
        }

        public static void ConfigureHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("Roboflow",client =>
            {
                var roboflowConfig = configuration.GetSection("Roboflow").Get<RoboflowConfig>();
                var endpoint = roboflowConfig!.EndPoint
                                   .Replace("{project_name}", roboflowConfig.ProjectName)
                                   .Replace("{version}", roboflowConfig.Version)
                                   .Replace("{api_key}", roboflowConfig.ApiKey);
                client.BaseAddress = new Uri(endpoint);
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.BaseAddress = new Uri(endpoint);
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient("Gemini", client =>
            {
                var geminiConfig = configuration.GetSection("GeminiApi").Get<GeminiApi>();
                var endpoint = geminiConfig!.BaseUrl + ApiModel.MODEL_FLASH_PREVIEW + "?key=" +geminiConfig.ApiKey;
                client.BaseAddress = new Uri(endpoint);
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.BaseAddress = new Uri(endpoint);
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
        }
    }

}
