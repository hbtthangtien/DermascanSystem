using Application.DTOs.Roboflow;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IRoboflowService
    {
        public Task<InferenceResult> ScanImageFromUser(IFormFile file); 
    }
}
