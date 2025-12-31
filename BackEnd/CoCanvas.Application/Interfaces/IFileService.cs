using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCanvas.Application.Files;
using Microsoft.AspNetCore.Http;

namespace CoCanvas.Application.Interfaces
{
    public interface IFileService
    {
        FileData? GetImageAsync(string fileName);
        Task<string> SaveImageAsync(IFormFile image);
    }
}
