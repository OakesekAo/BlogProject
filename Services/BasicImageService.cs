using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlogProject.Services
{
    public class BasicImageService : IImageService
    {
        public string ConetentType(IFormFile file)
        {
            //take in instance of iformfile, return contecntType property
            return file?.ContentType;
        }

        public string DecodeImage(byte[] data, string type)
        {
            //takes image out of DB and returns a usable string
            if (data is null || type is null) return null;
            //return string interpolation
            return $"data:imgae/{type};base64,{Convert.ToBase64String(data)}";
        }

        public async Task<byte[]> EndcodeImageAsync(IFormFile file)
        {
            //overload - stream to MemoryStream
            if(file is null)return null;
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            return ms.ToArray();
        }

        public async Task<byte[]> EndcodeImageAsync(string fileName)
        {
            //overload -  return file path
            var file = $"{Directory.GetCurrentDirectory()}/wwwroot/images/{fileName}";
            return await File.ReadAllBytesAsync(file);
        }

        public int Size(IFormFile file)
        {
            //return file size as an int
            return Convert.ToInt32(file?.Length);
        }
    }
}
