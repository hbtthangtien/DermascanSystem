﻿using Application.DTOs.SkinAnalysic;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IGenemiService
    {
        public Task<SkinAnalysisDto> FakingDataFromApi();
    }
}
