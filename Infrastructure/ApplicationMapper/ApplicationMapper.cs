using Application.DTOs.Token;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ApplicationMapper
{
    public class ApplicationMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Account, ClaimToken>()
                    .Map(dest => dest.Email, src => src.Email)
                    .Map(dest => dest.Role, src => src.Role)
                    .AfterMapping((src, dest) =>
                    {
                        if (src.User != null)
                            dest.FullName = src.User.FullName;
                        else if (src.Doctor != null)
                            dest.FullName = src.Doctor.FullName;
                        else
                            dest.FullName = string.Empty;
                    });
        }
    }
}
