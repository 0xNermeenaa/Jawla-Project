using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;


namespace Repository.Service
{
   

    public interface ICloudinaryService
    {
        Task<string> UploadImageAsync(IFormFile file);
        Task<List<string>> UploadImageAsync(List<IFormFile> file);
        Task<DeletionResult> DeleteImageAsync(string PublicId);
        Task <DeletionResult> DeleteImageAsync(List<string> PublicIds);
    }
    ///-// / 
    /// -// /
    /// 
    /// 
    /// 
    /// 
    /// 
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudinarySettings> config)
        {
            var account = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret);

            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("No file uploaded.");

            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return uploadResult.SecureUrl.ToString();
        }

        public async Task<List<string>> UploadImageAsync(List<IFormFile> file)
        {
            var images = new List<string>();

            if (file != null && file.Count > 0)
            {
                foreach (var image in file)
                {
                    if (image != null)
                    {
                        var imageUrl = await UploadImageAsync(image);
                        images.Add(imageUrl);
                    }
                }
            }
           
            return images;
        }







        public async Task<DeletionResult> DeleteImageAsync(string PublicId)
        {
            var deleteParams = new DeletionParams(PublicId);
            var Result = await _cloudinary.DestroyAsync(deleteParams);
            return Result;
        }


        public async Task<DeletionResult> DeleteImageAsync(List<string> PublicIds)
        {
            var images = new List<string>();
            DeletionResult Result = null; 
            if (PublicIds != null && PublicIds.Count > 0)
            {
                foreach (var image in PublicIds)
                {
                    if (image != null)
                    {
                           Result = await DeleteImageAsync(image);
                        
                    }
                }
            }

            return Result;

        }


    }

}
