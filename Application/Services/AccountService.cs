using Application.DTOs.Account;
using Application.DTOs.Common;
using Application.Extentions;
using Application.Interfaces.IServices;
using Application.IUnitOfWorks;
using Domain.Entities;
using Mapster;
using MapsterMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRole = CoreLayer.Enums.UserRole;

namespace Application.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly IValidService _validService;
        public AccountService(IUnitOfWork unitOfWork, IValidService validService) : base(unitOfWork)
        {
            _validService = validService;
        }

        public async Task<IdResponse> CreateAccount(CreateAccountDTO dto)
        {
            if (!_validService.ValidPassword(dto.HashPassword))
            {
                throw ExceptionFactory.Business("Password must be 8–20 characters, include at least one uppercase letter, one number, and one special character.");
            }
            try
            {
                var account = dto.Adapt<Account>();
                var user = dto.Adapt<User>();
                account.HashPassword = BCrypt.Net.BCrypt.HashPassword(dto.HashPassword);
                account.Role = UserRole.USER;
                await _unitOfWork.Accounts.AddAsync(account);
                user.Account = account;
                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.SaveChangeAsync();
                return IdResponse.SuccessResponse(account.Id, "Create Successfully!!!");
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx)
            {
                if (sqlEx.Number == 2601 || sqlEx.Number == 2627)
                {
                    if (sqlEx.Message.Contains("IX_Accounts_Email"))
                    {
                        throw ExceptionFactory.Conflict(dto.Email, "Email");
                    }
                    else
                    {
                        throw ExceptionFactory.Conflict(dto.Phone, "Phone Number");
                    }

                }
                throw ExceptionFactory.Business("Something is wrong");
            }
        }
    }
}
