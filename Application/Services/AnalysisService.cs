using Application.DTOs.Common;
using Application.DTOs.SkinAnalysic;
using Application.Extentions;
using Application.Interfaces.IServices;
using Application.IUnitOfWorks;
using Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AnalysisService : BaseService, IAnalysisService
    {
        private readonly IGenemiService _genemiService;
        private readonly IRoboflowService _roboflowService;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IUserContextService _userContextService;
        public AnalysisService(IUnitOfWork unitOfWork,
            IGenemiService genemiService,
            IRoboflowService roboflowService,
            ICloudinaryService cloudinaryService,
            IUserContextService userContextService) : base(unitOfWork)
        {
            _genemiService = genemiService;
            _roboflowService = roboflowService;
            _cloudinaryService = cloudinaryService;
            _userContextService = userContextService;
        }

        public async Task<IdResponse> CreateAnalysicStatistic(CreateAnalysicDTO dto)
        {
            var userId = _userContextService.GetUserId();
            var planId = _userContextService.GetPlanId();
            var skinAnalysis = dto.ToEntity(userId,planId);
            string json = JsonSerializer.Serialize(dto);
            skinAnalysis.ResultJSON = json;
            await _unitOfWork.SkinAnalysses.AddAsync(skinAnalysis);
            await _unitOfWork.SaveChangeAsync();
            return IdResponse.SuccessResponse(skinAnalysis.Id,"Create successfully");
        }

        public async Task<BaseResponse<ResponseAnalysicDTO>> ScanFaceAnalysic(IFormFile file)
        {
            var imagePathFile = await _cloudinaryService.UploadImageFileAsync(file);
            var skinTask =  _genemiService.FakingDataFromApi();
            var roboflowTask =  _roboflowService.ScanImageFromUser(file);
            await Task.WhenAll(skinTask, roboflowTask);
            var inferenceResult = roboflowTask.Result;
            var skinAnalysis = skinTask.Result;
            var response = new ResponseAnalysicDTO
            {
                InferenceResult = inferenceResult,
                SkinAnalysis = skinAnalysis,
            };
            var create = response.Adapt<CreateAnalysicDTO>();
            create.MediaPath = imagePathFile;
            var analysicId = await CreateAnalysicStatistic(create);
            return BaseResponse<ResponseAnalysicDTO>.SuccessResponse(response);
        }
    }
}
