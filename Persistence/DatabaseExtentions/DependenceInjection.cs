using Application.Interfaces.IRepositories;
using Application.IUnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DatabaseConfig;
using Persistence.Repositories;
using Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseExtentions
{
    public static class DependenceInjection
    {
        public static void AddDatabaseInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DermascanContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            // Register all repositories
            services.AddScoped<IAIRecommendationRepository, AIRecommendationRepository>();
            services.AddScoped<IAnalysisZoneScoreRepository, AnalysisZoneScoreRepository>();
            services.AddScoped<ICoachProgramRepository, CoachProgramRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IConsultationRepository, ConsultationRepository>();
            services.AddScoped<IDiaryEntryRepository, DiaryEntryRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IEmergencyRequestRepository, EmergencyRequestRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPartnerRepository, PartnerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProgressPhotoRepository, ProgressPhotoRepository>();
            services.AddScoped<ISkinAnalysisRepository, SkinAnalysisRepository>();
            services.AddScoped<ISkinZoneRepository, SkinZoneRepository>();
            services.AddScoped<ISubsciptionPlanRepository, SubsciptionPlanRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserSubsciptionRepository, UserSubsciptionRepository>();
            services.AddScoped<IAccountTokenRepository, AccountTokenRepository>();

            // Register UnitOfWork
            services.AddScoped<IUnitOfWork,UnitOfWork>();


        }
    }
}
