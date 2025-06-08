
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseConfig;

namespace Presentation.BackgroundServices
{
    public class AutoDeleteRefreshTokenBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public AutoDeleteRefreshTokenBackgroundService(IServiceProvider service)
        {
            _serviceProvider = service;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using(var scope = _serviceProvider.CreateScope())
                    {
                        var _context = scope.ServiceProvider.GetRequiredService<DermascanContext>();
                        var now = DateTime.Now;
                         await _context.AccountTokens
                            .Where(t => t.ExpiryTime < now || t.UpdatedAt != null || t.DeletedAt != null)
                            .ExecuteDeleteAsync(stoppingToken);
                      
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                await Task.Delay(TimeSpan.FromMinutes(30), stoppingToken);
            }
        }
    }
}
