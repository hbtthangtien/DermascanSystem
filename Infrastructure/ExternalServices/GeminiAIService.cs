using Application.DTOs.Gemini;
using Application.DTOs.SkinAnalysic;
using Application.Extentions;
using Application.Interfaces.IServices;
using Domain.Constant;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.ExternalServices
{
    public class GeminiAIService : IGenemiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public GeminiAIService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<SkinAnalysisDto> FakingDataFromApi()
        {
            var client = _httpClientFactory.CreateClient("Gemini");
            var requestData = new
            {
                contents = new[]
            {
                new {
                    parts = new[]
                    {
                        new { text = ApiModel.PROMPT }
                    }
                }
            }
            };

            var jsonContent = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("", content);

            if (response.IsSuccessStatusCode)
            {
                
                var responseBody = await response.Content.ReadAsStringAsync();
                var geminiObject = JsonConvert.DeserializeObject<GeminiResponse>(responseBody);
                string rawText = geminiObject.candidates[0].content.parts[0].text;
                string cleanJson = Regex.Replace(rawText, "^```json\\n|\\n```$", "", RegexOptions.Multiline);
                var skinAnalysis = JsonConvert.DeserializeObject<SkinAnalysisDto>(cleanJson);
                return skinAnalysis;
            }
            throw ExceptionFactory.Business("Fail");
        }
    }
}
