using Domain.Commons;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseExtentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseConfig
{
    public class DermascanContext : DbContext
    {
        public DermascanContext(DbContextOptions<DermascanContext> options) : base(options) { }


        #region db set

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<AIRecommendation> Recommendations { get; set; }

        public virtual DbSet<AnalysisZoneScore> AnalysisZones { get; set; }

        public virtual DbSet<CoachProgram> CoachPrograms { get; set; }

        public virtual DbSet<Consultation> Consultations { get; set; }

        public virtual DbSet<DiaryEntry> DiaryEntries { get; set; }

        public virtual DbSet<Doctor> Doctors { get; set; }

        public virtual DbSet<EmergencyRequest> EmergencyRequests { get; set; }

        public virtual DbSet<Notification> Notifications { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Partner> Partners { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProgressPhoto> ProgressPhotos { get; set; }

        public virtual DbSet<SkinAnalysis> SkinAnalysis { get; set; }

        public virtual DbSet<SkinZone> SkinZones { get; set; }

        public virtual DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserSubscription> UsersSubscriptions { get; set; }

        public virtual DbSet<AccountToken> AccountTokens { get; set; }

        

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User)
                      .WithOne(e => e.Account)
                      .HasForeignKey<User>(e => e.AccountId);


                entity.HasMany(e => e.Tokens)
                      .WithOne(e => e.Account)
                      .HasForeignKey(e => e.AccountId);

                entity.HasIndex(e => e.Email).IsUnique(true);
            });

            modelBuilder.Entity<AIRecommendation>(entity =>
            {
                entity.HasOne(e => e.Analysis)
                       .WithMany(e => e.AIRecommendations)
                       .HasForeignKey(e => e.AnalysisID);

                entity.HasOne(e => e.Product)
                       .WithMany(e => e.AIRecommendations)
                       .HasForeignKey(e => e.ProductID);

            });

            modelBuilder.Entity<AnalysisZoneScore>(entity =>
            {
                

                entity.HasOne(e => e.SkinAnalysis)
                      .WithMany(e => e.AnalysisZoneScores)
                      .HasForeignKey(e => e.SkinAnalysisId);

                entity.HasOne(e => e.Zone)
                      .WithMany(e => e.AnalysisZoneScores)
                      .HasForeignKey(e => e.ZoneID);

            });

            modelBuilder.Entity<CoachProgram>(entity =>
            {
                entity.HasOne(e => e.User)
                      .WithMany(e => e.CoachPrograms)
                      .HasForeignKey(e => e.UserID);
            });

            modelBuilder.Entity<Consultation>(entity =>
            {
                entity.HasOne(e => e.Doctor)
                      .WithMany(e => e.Consultations)
                      .HasForeignKey(e => e.DoctorID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.User)
                      .WithMany(e => e.Consultations)
                      .HasForeignKey(e => e.UserID);
            });

            modelBuilder.Entity<DiaryEntry>(entity =>
            {
                entity.HasOne(e => e.User)
                      .WithMany(e => e.DiaryEntries)
                      .HasForeignKey(e => e.UserID);
            });

            modelBuilder.Entity<EmergencyRequest>(entity =>
            {
                entity.HasOne(e => e.SkinAnalysis)
                      .WithMany()
                      .HasForeignKey(e => e.AnalysisID);

                entity.HasOne(e => e.User)
                      .WithMany(e => e.EmergencyRequests)
                      .HasForeignKey(e => e.UserID);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasOne(e => e.User)
                      .WithMany(e => e.Notifications)
                      .HasForeignKey(e => e.UserID);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(e => e.User)
                      .WithMany(e => e.Orders)
                      .HasForeignKey(e => e.UserID);


                entity.HasOne(e => e.Product)
                      .WithMany(e => e.Orders)
                      .HasForeignKey(e => e.ProductID);

                entity.HasOne(e => e.Analysis)
                      .WithMany()
                      .HasForeignKey(e => e.AnalysisID);

                entity.HasOne(e => e.Partner)
                      .WithMany(e => e.Orders)
                      .HasForeignKey(e => e.PartnerID);
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.HasMany(e => e.Products)
                      .WithOne(e => e.Partner)
                      .HasForeignKey(e => e.PartnerID);
            });

            modelBuilder.Entity<ProgressPhoto>(entity =>
            {
                entity.HasOne(e => e.Analysis)
                      .WithMany(e => e.ProgressPhotos)
                      .HasForeignKey(e => e.AnalysisID);
            });

            modelBuilder.Entity<SubscriptionPlan>(entity =>
            {
                entity.HasMany(e => e.SkinAnalyses)
                      .WithOne(e => e.Plan)
                      .HasForeignKey(e => e.PlanID);
                entity.HasMany(e => e.UserSubscriptions)
                      .WithOne(e => e.Plan)
                      .HasForeignKey(e => e.PlanID);

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(e => e.UserSubscriptions)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserID);

                entity.HasIndex(e => e.Phone).IsUnique(true);
            });
            modelBuilder.Entity<Consultation>()
                .Property(p => p.PricePaid)
                .HasPrecision(18, 4); // 18 là tổng số chữ số, 4 là số chữ số sau dấu phẩy

            // Các property khác
            modelBuilder.Entity<DiaryEntry>()
                .Property(p => p.SleepHours)
                .HasPrecision(5, 2);

            modelBuilder.Entity<DiaryEntry>()
                .Property(p => p.WaterIntakeL)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Doctor>()
                .Property(p => p.Rating)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Order>()
                .Property(p => p.CommissionEarned)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Order>()
                .Property(p => p.UnitPrice)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Partner>()
                .Property(p => p.CommissionRate)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 4);

            modelBuilder.Entity<SubscriptionPlan>()
                .Property(p => p.Price)
                .HasPrecision(18, 4);
            SkinZoneSeedingData.Seeding(modelBuilder);
            SubscriptionSeedingData.Seeding(modelBuilder);
        }


        #region custom function entityframe work core

        public override int SaveChanges()
        {
            HandleSoftDelete();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleSoftDelete();
            return base.SaveChangesAsync(cancellationToken);
        }


        private void HandleSoftDelete()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted && e.Entity is BaseEntity))
            {
                entry.State = EntityState.Modified;
                var entity = (BaseEntity)entry.Entity;
                entity.DeletedAt = DateTime.UtcNow;
            }
        }


        #endregion


    }
}
