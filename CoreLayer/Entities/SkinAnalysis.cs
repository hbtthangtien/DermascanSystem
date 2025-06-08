using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SkinAnalysis : BaseEntity
    {
        public long UserID { get; set; }
        public long? PlanID { get; set; }
        public DateTime CapturedAt { get; set; }
        public string MediaPath { get; set; }
        public byte? OverallScore { get; set; }
        public byte? AcneScore { get; set; }
        public byte? MoistureScore { get; set; }
        public byte? PigmentationScore { get; set; }
        public byte? WrinkleScore { get; set; }
        public byte? PoreScore { get; set; }
        public byte? SensitivityScore { get; set; }
        public byte? AgingScore { get; set; }
        public string? ResultJSON { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public User? User { get; set; }
        public SubscriptionPlan? Plan { get; set; }
        public ICollection<AIRecommendation> AIRecommendations { get; set; } = new List<AIRecommendation>();
        public ICollection<AnalysisZoneScore> AnalysisZoneScores { get; set; } = new List<AnalysisZoneScore>();
        public ICollection<ProgressPhoto> ProgressPhotos { get; set; } = new List<ProgressPhoto>();
    }
}
