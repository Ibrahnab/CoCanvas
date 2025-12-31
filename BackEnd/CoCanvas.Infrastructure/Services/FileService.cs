using CoCanvas.Application.Files;
using CoCanvas.Application.Interfaces;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CoCanvas.Infrastructure.Services
{
    public class FileService : IFileService
    {
        //private readonly IWebHostEnvironment _env;
        private readonly string _rootPath = "wwwroot/images";

        public FileService()
        {
            //_env = en
        }
        public FileData? GetImageAsync(string fileName)
        {

            var filePath = Path.Combine("wwwroot/images", fileName);

            if (!File.Exists(filePath))
                //return Task.FromResult<FileData?>(null);
                return null;

            var stream = File.OpenRead(filePath);
            var file = System.IO.File.OpenRead(filePath);
            var contentType = GetContentType(filePath);

            return new FileData
            {
                Stream = stream,
                ContentType = contentType,
                FileName = Path.GetFileName(filePath),
            };
   
        }

        public async Task<string> SaveImageAsync(IFormFile image)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine("wwwroot/images", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
                return fileName;
            }
        }

        private static string GetContentType(string path)
        {
            var extension = Path.GetExtension(path).ToLowerInvariant();

            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".webp" => "image/webp",
                _ => "application/octet-stream"
            };
        }
    }
}
