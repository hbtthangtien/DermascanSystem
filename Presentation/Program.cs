
using Infrastructure.Extentions;
using Persistence.DatabaseExtentions;
using Presentation.Middleware;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                            .AddCustomJsonOptions();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDatabaseInjection(builder.Configuration);
            builder.Services.AddRepositories();
            builder.Services.AddServices();
            builder.Services.AddAuthenticationByJwt(builder.Configuration);
            builder.Services.InitialValueConfig(builder.Configuration);
            builder.Services.SetCorsForAPI();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAllOrigins");
            app.UseAuthorization();
            app.UseMiddleware<ExceptionCatchGlobal>();
            app.MapControllers();
            app.Run();
        }
    }
}
