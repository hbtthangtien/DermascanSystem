using Application.Interfaces.IServices;
using CloudinaryDotNet;
using Domain.Configs;
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

    }
}
