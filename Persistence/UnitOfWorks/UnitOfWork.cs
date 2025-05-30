using Application.Interfaces.IRepositories;
using Application.IUnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.DatabaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DermascanContext _context;
        public IAccountRepository Accounts { get; private set; }

        public IAIRecommendationRepository AIRecommendations { get; private set; }

        public IAnalysisZoneScoreRepository AnalysisZones { get; private set; }

        public ICoachProgramRepository CoachPrograms { get; private set; }

        public IConsultationRepository Consultations { get; private set; }

        public IDiaryEntryRepository DiaryEntries { get; private set; }

        public IDoctorRepository Doctors { get; private set; }

        public IEmergencyRequestRepository EmergencyRequests { get; private set; }

        public INotificationRepository Notifications { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IPartnerRepository Partners { get; private set; }

        public IProductRepository Products { get; private set; }

        public IProgressPhotoRepository ProgressPhotos { get; private set; }

        public ISkinAnalysisRepository SkinAnalysses { get; private set; }

        public ISkinZoneRepository SkinZones { get; private set; }

        public ISubsciptionPlanRepository Subscriptions { get; private set; }

        public IUserRepository Users { get; private set; }

        public IUserSubsciptionRepository UserSubsciptions { get; private set; }

        public UnitOfWork(DermascanContext context,
            IAccountRepository accounts,
            IAIRecommendationRepository aIRecommendations,
            IAnalysisZoneScoreRepository analysisZones,
            ICoachProgramRepository coachPrograms,
            IConsultationRepository consultations,
            IDiaryEntryRepository diaryEntries,
            IDoctorRepository doctors,
            IEmergencyRequestRepository emergencyRequests,
            INotificationRepository notifications,
            IOrderRepository orders,
            IPartnerRepository partners,
            IProductRepository products,
            IProgressPhotoRepository progressPhotos,
            ISkinAnalysisRepository skinAnalysses,
            ISkinZoneRepository skinZones,
            ISubsciptionPlanRepository subscriptions,
            IUserRepository users,
            IUserSubsciptionRepository userSubsciptions)
        {
            _context = context;
            Accounts = accounts;
            AIRecommendations = aIRecommendations;
            AnalysisZones = analysisZones;
            CoachPrograms = coachPrograms;
            Consultations = consultations;
            DiaryEntries = diaryEntries;
            Doctors = doctors;
            EmergencyRequests = emergencyRequests;
            Notifications = notifications;
            Orders = orders;
            Partners = partners;
            Products = products;
            ProgressPhotos = progressPhotos;
            SkinAnalysses = skinAnalysses;
            SkinZones = skinZones;
            Subscriptions = subscriptions;
            Users = users;
            UserSubsciptions = userSubsciptions;
        }

        private IDbContextTransaction? _currentTransaction;

        // ... Các property như bạn đã khai báo

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return; // Transaction đang mở, bỏ qua
            }
            _currentTransaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                if (_currentTransaction != null)
                {
                    await _currentTransaction.CommitAsync();
                }
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.RollbackAsync();
                }
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
