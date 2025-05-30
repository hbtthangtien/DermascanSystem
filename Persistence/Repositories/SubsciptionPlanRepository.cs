using Application.Interfaces.IRepositories;
using Domain.Entities;
using Persistence.DatabaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class SubsciptionPlanRepository : BaseRepository<SubscriptionPlan>, ISubsciptionPlanRepository
    {
        public SubsciptionPlanRepository(DermascanContext context) : base(context)
        {
        }
    }
}
