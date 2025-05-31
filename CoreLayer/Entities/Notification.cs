using CoreLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Notification
    {
        public long Id { get; set; }
        public long UserID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public NotifType NotifType { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime? ReadAt { get; set; }

        public User? User { get; set; }
    }
}
