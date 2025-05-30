using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Account? Account { get; set; }
        public ICollection<CoachProgram> CoachPrograms { get; set; } = new List<CoachProgram>();
        public ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();
        public ICollection<DiaryEntry> DiaryEntries { get; set; }= new List<DiaryEntry>();
        public ICollection<EmergencyRequest> EmergencyRequests { get; set; } = new List<EmergencyRequest>();                 
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<ProgressPhoto> ProgressPhotos { get; set; } = new List<ProgressPhoto>();
        public ICollection<SkinAnalysis> SkinAnalyses { get; set; } = new List<SkinAnalysis>();
        public ICollection<UserSubscription> UserSubscriptions { get; set; } = new HashSet<UserSubscription>();
    }
}
