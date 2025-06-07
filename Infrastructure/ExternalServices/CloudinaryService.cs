using Application.Interfaces.IServices;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Domain.Configs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalServices
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;
        private readonly CloundinaryConfig _config;
        public CloudinaryService(IOptions<CloundinaryConfig> options)
        {
            _config = options.Value;
            var Account = new Account(_config.CloudName, _config.ApiKey, _config.ApiSecret);
            cloudinary = new Cloudinary(Account);
        }

        public async Task<string> UploadImageFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentNullException(nameof(file));
            }
            using (var stream = file.OpenReadStream())
            {
                var uploadParam = new ImageUploadParams
                {

                    File = new FileDescription(file.Name, stream),
                    Folder = $"Dermascan/images"
                };
                var uploadResult = await cloudinary.UploadAsync(uploadParam);
                return uploadResult.SecureUrl.ToString();
            }
        }
    }
}
