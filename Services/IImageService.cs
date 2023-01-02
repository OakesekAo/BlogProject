using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BlogProject.Services
{
    public interface IImageService
    {
        Task<byte[]> EndcodeImageAsync(IFormFile file);
        Task<byte[]> EndcodeImageAsync(string fileName);
        string DecodeImage(byte[] data, string type);
        string ConetentType(IFormFile file);
        int Size(IFormFile file);
    }
}
