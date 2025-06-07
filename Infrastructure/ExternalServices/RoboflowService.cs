using Application.DTOs.Roboflow;
using Application.Extentions;
using Application.Interfaces.IServices;
using Domain.Configs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalServices
{
    public class RoboflowService : IRoboflowService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RoboflowService(IHttpClientFactory httpClientFactory, IOptions<RoboflowConfig> options)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<InferenceResult> ScanImageFromUser(IFormFile file)
        {
            var client = _httpClientFactory.CreateClient("Roboflow");
            if (file == null || file.Length == 0)
            {
                throw ExceptionFactory.Business("No file uploaded.");
            }
            using(var memorySteam = new MemoryStream())
            {
                await file.CopyToAsync(memorySteam);
                var imageData = memorySteam.ToArray();

                using(var content = new MultipartFormDataContent())
                {
                    var byteArrayContent = new ByteArrayContent(imageData);
                    byteArrayContent.Headers.Add("Content-Type", "application/octet-stream");
                    content.Add(byteArrayContent, "file", file.FileName);
                    var response = await client.PostAsync("", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<InferenceResult>(responseBody);
                        return result;
                    }
                    throw ExceptionFactory.Business($"Failed to get response from Roboflow: {response.ReasonPhrase}");
                }
            }

        }
    }
}
