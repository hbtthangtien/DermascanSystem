using Application.Interfaces.IServices;
using Application.IUnitOfWorks;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthenticateService : BaseService, IAuthenticateService
    {
        public AuthenticateService(IUnitOfWork unitOfWork ) : base(unitOfWork)
        {
        }
    }
}
