using Application.DTOs.Common;
using Application.DTOs.SkinAnalysic;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IAnalysisService
    {
        public Task<BaseResponse<ResponseAnalysicDTO>> ScanFaceAnalysic(IFormFile file);

        public Task<IdResponse> CreateAnalysicStatistic(CreateAnalysicDTO dto);
    }
}
