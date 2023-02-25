using Microsoft.Extensions.Hosting;

namespace Application.Helpers.Paths
{
    public class DirectoryPath
    {
        private readonly IHostEnvironment _hostingEnvironment;

        public DirectoryPath(IHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public string GetImageDirectoryPath()
        {
            string basePath = _hostingEnvironment.ContentRootPath;
            string directImagePath = Path.Combine(basePath,"wwwroot","images");
            return directImagePath;
        }
    }
}
