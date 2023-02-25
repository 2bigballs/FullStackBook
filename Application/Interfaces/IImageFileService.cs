using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IImageFileService
    {
        Task<string> SaveFileAsync(IFormFile file);
        void DeleteFile(string fileName);
    }
}
