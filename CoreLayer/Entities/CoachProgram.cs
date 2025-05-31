using Domain.Commons;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CoachProgram : BaseEntity
    {
        public long UserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentWeek { get; set; }
        public CoachProgramStatus Status { get; set; }
        public string? PlanJSON { get; set; }
        public User? User { get; set; }
    }
}
