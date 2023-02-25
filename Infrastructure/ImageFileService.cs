using Application.Helpers.Paths;
using Application.Helpers.Url;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure
{
    public class ImageFileService : IImageFileService
    {
        private readonly DirectoryPath _directoryPath;
        private readonly UrlManager _urlManager;

        public ImageFileService(DirectoryPath directoryPath, UrlManager urlManager)
        {
            _directoryPath = directoryPath;
            _urlManager = urlManager;
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            string directoryPath = _directoryPath.GetImageDirectoryPath();
            string fileName = CreateFileName(file.FileName);
            string filePath = Path.Combine(directoryPath, fileName);

            await using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return fileName;
        }

        private string CreateFileName(string fileName)
        {
            string newFileName = Guid.NewGuid() + fileName;
            return newFileName;
        }

        public void DeleteFile(string fileName)
        {
            string directoryPath = _directoryPath.GetImageDirectoryPath();
            string filePath = Path.Combine(directoryPath, fileName);
            File.Delete(filePath);
        }
    }
}
