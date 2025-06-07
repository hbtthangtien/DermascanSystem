using Application.Interfaces.IServices;
using Application.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PlanGuardService : BaseService, IPlanGuardService
    {
        private readonly IUserContextService userContext;
        public PlanGuardService(IUnitOfWork unitOfWork, IUserContextService userContext) : base(unitOfWork)
        {
            this.userContext = userContext;
        }

        public Task ValidateAsync(long userId)
        {
            throw new NotImplementedException();
        }
    }
}
