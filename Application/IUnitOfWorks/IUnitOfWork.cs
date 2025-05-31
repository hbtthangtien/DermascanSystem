using Application.Interfaces.IRepositories;

namespace Application.IUnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        public IAccountRepository Accounts { get; }

        public IAIRecommendationRepository AIRecommendations { get; }

        public IAnalysisZoneScoreRepository AnalysisZones { get; }

        public ICoachProgramRepository CoachPrograms { get; }

        public IConsultationRepository Consultations { get; }

        public IDiaryEntryRepository DiaryEntries { get; }

        public IDoctorRepository Doctors { get; }

        public IEmergencyRequestRepository EmergencyRequests { get; }

        public INotificationRepository Notifications { get; }

        public IOrderRepository Orders { get; }

        public IPartnerRepository Partners { get; } 

        public IProductRepository Products { get; } 

        public IProgressPhotoRepository ProgressPhotos { get; }

        public ISkinAnalysisRepository SkinAnalysses { get; }

        public ISkinZoneRepository SkinZones { get; }

        public ISubsciptionPlanRepository Subscriptions { get; }

        public IUserRepository Users { get; }

        public IUserSubsciptionRepository UserSubsciptions { get; }

        IBaseRepository<T> GetRepository<T>() where T : class;
        public Task BeginTransactionAsync();
        public Task CommitTransactionAsync();
        public Task RollbackTransactionAsync();
        public Task SaveChangeAsync();

    }
}
