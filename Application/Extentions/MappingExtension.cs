using Application.DTOs.SkinAnalysic;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentions
{
    public static class MappingExtension
    {
        public static SkinAnalysis ToEntity(this CreateAnalysicDTO dto, long userId, long? planId = null)
        {
            var overall = dto.SkinAnalysis?.OverallAnalysis?.Score;

            var entity = new SkinAnalysis
            {
                UserID = userId,
                PlanID = planId,
                CapturedAt = DateTime.Now,
                MediaPath = dto.MediaPath,
                OverallScore = (byte?)overall?.Overall,
                AcneScore = (byte?)overall?.Acne,
                MoistureScore = (byte?)overall?.Moisture,
                PigmentationScore = (byte?)overall?.Pigmentation,
                WrinkleScore = (byte?)overall?.Wrinkle,
                PoreScore = (byte?)overall?.Pore,
                SensitivityScore = (byte?)overall?.Sensitivity,
                AgingScore = (byte?)overall?.Aging,
                
            };
            var aIRecommendations = dto.SkinAnalysis?.SuggestedProducts?.Select(p => new AIRecommendation
            {
                RecommendationType = RecommendationType.Product,
                Message = p.RecommendationReason
            }).ToList() ?? new List<AIRecommendation>();

            var AnalysisZoneScores = dto.SkinAnalysis?.SkinZoneAnalysis?.Select(z => new AnalysisZoneScore
            {
                Score = (byte)z.Score,
                ZoneID = MapZoneNameToZoneId(z.Zone)
            }).ToList() ?? new List<AnalysisZoneScore>();
            foreach(var i in aIRecommendations)
            {
                entity.AIRecommendations.Add(i);
            }
            foreach(var i in  AnalysisZoneScores)
            {
                entity.AnalysisZoneScores.Add(i);   
            }
            return entity;
        }

        private static long MapZoneNameToZoneId(string zoneName)
        {
            return zoneName switch
            {
                "Trán" => 1,
                "Má trái" => 2,
                "Má phải" => 3,
                "Cằm" => 4,
                "Mũi" => 5,
                "Vùng mắt" => 6,
                "Cổ" => 7,
                "Xương hàm" => 8,
                "Môi trên" => 9,
                "Toàn bộ mặt" => 10,
                _ => throw ExceptionFactory.Business("Zone skin is not exist")
            } ;
        }
    }
}
