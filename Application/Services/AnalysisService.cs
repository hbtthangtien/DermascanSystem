using Application.DTOs.Common;
using Application.DTOs.SkinAnalysic;
using Application.Interfaces.IServices;
using Application.IUnitOfWorks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AnalysisService : BaseService, IAnalysisService
    {
        private readonly IGenemiService _genemiService;
        private readonly IRoboflowService _roboflowService;
        private readonly ICloudinaryService _cloudinaryService;
        public AnalysisService(IUnitOfWork unitOfWork,
            IGenemiService genemiService,
            IRoboflowService roboflowService,
            ICloudinaryService cloudinaryService) : base(unitOfWork)
        {
            _genemiService = genemiService;
            _roboflowService = roboflowService;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<BaseResponse<ResponseAnalysicDTO>> ScanFaceAnalysic(IFormFile file)
        {
            var imagePathFile = await _cloudinaryService.UploadImageFileAsync(file);
            var skinAnalysis = await _genemiService.FakingDataFromApi();
            var inferenceResult = await _roboflowService.ScanImageFromUser(file);
            var response = new ResponseAnalysicDTO
            {
                InferenceResult = inferenceResult,
                SkinAnalysis = skinAnalysis,
            };
            return BaseResponse<ResponseAnalysicDTO>.SuccessResponse(response);
        }
    }
}
